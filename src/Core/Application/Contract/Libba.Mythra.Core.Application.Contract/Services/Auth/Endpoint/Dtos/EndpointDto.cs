using Libba.Mythra.Core.Domain.Enums;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Dtos;

public class EndpointDto
{
    public Guid Id { get; set; }
    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    public HttpVerb HttpVerb { get; set; }
    public string Path { get; set; }
}
