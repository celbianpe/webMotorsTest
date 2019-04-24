using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.Core.Utils
{
    public class ResultBase
    {
        public ResultBase()
        {
            Messages = new Dictionary<MessageType, string>();
        }

        public bool Success { get; set; } = true;
        
        public Dictionary<MessageType, string> Messages { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name}:");
            sb.AppendLine($"{nameof(Success)}:{Success}");
            sb.AppendLine($"{nameof(Messages)}:{Messages}");
            foreach (var message in Messages) sb.AppendLine($"\t[{message.Key}] {message.Value}");

            return sb.ToString();
        }

        public void AddMessage(MessageType messageType, string message)
        {
            Messages.Add(messageType, message);
        }

        public void AddInfo(string message)
        {
            AddMessage(MessageType.Info, message);
        }

        public void AddWarning(string message)
        {
            AddMessage(MessageType.Warning, message);
        }

        public void AddApiConsumeError(string message)
        {
            Success = false;
            AddMessage(MessageType.ApiConsumeError, message);
        }

        public void AddBusinessError(string message)
        {
            Success = false;
            AddMessage(MessageType.BusinessError, message);
        }

        public void AddSystemError(string message)
        {
            Success = false;
            AddMessage(MessageType.SystemError, message);
        }

        public void AddSystemError(Exception err)
        {
            Success = false;
            AddMessage(MessageType.SystemError, err.Message);
        }

    }
}