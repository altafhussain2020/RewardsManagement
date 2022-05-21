using System;
namespace RewardsManagement.Models
{
    public class ExceptionHandler : Exception
    {
        public ExceptionHandler(string ErrorMessage) : base(ErrorMessage)
        {
            Logger.LogMessage(ErrorMessage);
        }
    }   
}