using System;
using log4net;

namespace RewardsManagement.Models
{
    public class RewardEngine
    {  public decimal CalculateRewards(decimal fn, decimal limit)
        {
            try
            {
                //Example : (120 - 50) x 1 + (120 - 100) x 1 = 90 points
                if (fn > limit)
                {
                    return (fn - limit) * 1;
                }
            }
            catch(Exception ex)
            {
                Logger.LogMessage(ex.StackTrace);
                 return 0;
            } 
             return 0;         
        }

        public decimal TotalRewards(decimal fn, decimal sn)
        {
           try
            {
                //Example : (120 - 50) x 1 + (120 - 100) x 1 = 90 points               
                    return (sn + fn);
                
            }
             catch(Exception ex)
            {
                Logger.LogMessage(ex.StackTrace);
                 return 0;
            } 
            
        }
    }
}