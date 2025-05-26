namespace MyShoppingApp.Shared;

public class ServiceFailureException : Exception
{
    public ServiceFailureException(ServiceFailureSeverity severity, string message) : base(message)
    {
        Severity = severity;
    }

    public ServiceFailureSeverity Severity { get; }
}
