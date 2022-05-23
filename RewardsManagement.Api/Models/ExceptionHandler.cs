using System;
namespace RewardsManagement.Api.Models
{
    public class ExceptionHandler : Exception
    {
        public ExceptionHandler(string ErrorMessage) : base(ErrorMessage)
        {
            Logger.LogMessage(ErrorMessage);
        }
    }   
}