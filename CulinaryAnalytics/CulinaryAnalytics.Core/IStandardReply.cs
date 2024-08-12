using CulinaryAnalytics.Core.Implementations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CulinaryAnalytics.Core
{
    /// <summary>
    /// Wrapper for any service level method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStandardReply<T>
    {
        /// <summary>
        /// Indicates if request was successful
        /// </summary>
        bool Success { get; set; }
        /// <summary>
        /// Contains the data requested
        /// </summary>
        T? Response { get; set; }
        /// <summary>
        /// Use for record count when returning list
        /// </summary>
        int TotalRecords { get; set; }
        /// <summary>
        /// IEnumerable string list of messages returned from method
        /// </summary>
        List<string> Messages { get; set; }
        /// <summary>
        /// IEnumerable Exception list of any exceptions thrown within the service layers
        /// </summary>
        List<Exception> Exceptions { get; set; }
        /// <summary>
        /// Adds the current exception to reply
        /// </summary>
        /// <param name="exc">the current exception being thrown</param>
        /// <param name="logData">generic object to be included in the log</param>
        /// <param name="logger">an instance of the currently used log</param>
        /// <param name="methodName">name of method where the error occured</param>
        /// <param name="forward">indicates if exception should be thrown</param>
        public void ProcessException(Exception exc, object? logData, ILogger logger, string methodName, bool forward = false)
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
        /// <summary>
        /// Clears all messages from reply
        /// </summary>
        public void ClearMessages()
        {
            Messages?.Clear();
        }
        /// <summary>
        /// Clears all exceptions from reply
        /// </summary>
        public void ClearExceptions()
        {
            Exceptions?.Clear();
        }

        public static IStandardReply<T> CreateStandardReply(bool success)
        {
            var instance = new StandardReply<T>();
            instance.Success = success;
            return (IStandardReply<T>)instance;
        }
    }
}
