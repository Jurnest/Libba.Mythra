using Microsoft.Extensions.Configuration;
using System.Text.Json;
using NLog.Targets;
using NLog.Common;
using System.Text;
using NLog;

namespace Libba.Mythra.Infrastructure.NLog.Targets;

[Target("LokiHttp")]
public class LokiHttpTarget : TargetWithLayout
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public string _endpoint { get; set; }
    public string _labels { get; set; }

    public LokiHttpTarget()
    {
        // IConfiguration örneğini al
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        _endpoint = configuration["LokiSettings:Endpoint"];
        _labels = configuration["LokiSettings:Labels"];
    }


    protected override void Write(LogEventInfo logEvent)
    {
        SendLogToLokiAsync(logEvent).Wait();
    }

    private async Task SendLogToLokiAsync(LogEventInfo logEvent)
    {
        try
        {
            var actualEndpoint = _endpoint;
            var actualLabels = _labels;


            var logMessage = RenderLogEvent(Layout, logEvent);

            string timestamp = (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() * 1_000_000).ToString();

            var streamLabels = new Dictionary<string, string>();
            streamLabels["level"] = logEvent.Level.ToString().ToLower();
            streamLabels["logger"] = logEvent.LoggerName;

            if (!string.IsNullOrWhiteSpace(actualLabels))
            {
                foreach (var labelPair in actualLabels.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var parts = labelPair.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        streamLabels[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }

            var payload = new
            {
                streams = new[]
                {
                    new
                    {
                        stream = streamLabels,
                        values = new[]
                        {
                            new[] { timestamp, logMessage }
                        }
                    }
                }
            };

            var jsonPayload = JsonSerializer.Serialize(payload);

            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(actualEndpoint, content);


            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            InternalLogger.Error(ex, "LokiHttpTarget: Log gönderme hatası.");
        }
    }
}