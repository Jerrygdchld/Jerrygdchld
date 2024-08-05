using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CulinaryAnalytics.Core.Implementations
{
    public class StandardReply<T> : IStandardReply<T>
    {
        public bool Success { get; set; } = true;
        public List<string> Messages { get; set; } = [];
        public List<Exception> Exceptions { get; set; } = [];
        public T? Response { get; set; }
        public int TotalRecords { get; set; }

        public void ClearExceptions()
        {
            Exceptions?.Clear();
        }

        public void ClearMessages()
        {
            Messages?.Clear();
        }

        public void ProcessException(Exception exc, object logData, ILogger logger, string methodName, bool forward = false)
        {
            Success = false;
            Messages.Add($"Error in {methodName} call failed.");
            Messages.Add(exc.Message.ToString());
            Exceptions?.Add(exc);
            logger.LogError(exc, "Error logged in {methodName} with data {data}.", methodName, JsonConvert.SerializeObject(logData));
            if (forward)
            {
                throw exc;
            }
        }
    }
}
