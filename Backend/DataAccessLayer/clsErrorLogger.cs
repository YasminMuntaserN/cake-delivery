using Microsoft.IdentityModel.Protocols;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class clsErrorLogger
    {
        private Action<string, Exception> _logAction;

        // Constructor that takes an Action delegate for logging
        public clsErrorLogger(Action<string, Exception> logAction)
        {
            _logAction = logAction;
        }

        // Method to log an error with a specific type and exception
        public void LogError(string errorType, Exception ex)
        {
            _logAction?.Invoke(errorType, ex);
        }

        public static void LogToEventViewer(string message, Exception ex)
        {
            // Implementation for logging to the Event Viewer
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "YourAppSource"; // Your application source name
                eventLog.WriteEntry($"{message}: {ex.Message}", EventLogEntryType.Error);
            }
        }
    }

}