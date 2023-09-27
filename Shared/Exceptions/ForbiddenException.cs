using Microsoft.Extensions.Localization;
using Shared.Resoutces;
using System.Net;
using System.Runtime.Serialization;

namespace Shared.Exceptions;

[Serializable]
public class ForbiddenException : RestException
{
    public ForbiddenException()
        : base(nameof(General.ForbiddenException))
    {
    }

    public ForbiddenException(string message)
        : base(message)
    {
    }

    public ForbiddenException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public ForbiddenException(LocalizedString message)
        : base(message)
    {
    }

    public ForbiddenException(LocalizedString message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected ForbiddenException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
}
