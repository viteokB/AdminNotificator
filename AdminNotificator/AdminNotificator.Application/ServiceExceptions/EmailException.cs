using System.Globalization;

namespace AdminNotificator.Application.ServiceExceptions;

public class EmailException : ServiceException
{
    public EmailException()
    {
    }

    public EmailException(string message) : base(message)
    {
    }

    public EmailException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}