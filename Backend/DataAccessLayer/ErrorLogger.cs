namespace DataAccessLayer
{
    public class ErrorLogger
    {
        private readonly Action<string, Exception> _logAction;

        public ErrorLogger(Action<string, Exception> logAction)
        {
            _logAction = logAction;
        }

        public void LogError(string message, Exception ex)
        {
            _logAction(message, ex);
        }
    }
}
