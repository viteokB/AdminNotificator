using System.Globalization;

namespace AdminNotificator.Application.ServiceExceptions;

public class ServiceException : Exception
{
    public ServiceException()
    {
    }

    public ServiceException(string message) : base(message)
    {
    }

    public ServiceException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}