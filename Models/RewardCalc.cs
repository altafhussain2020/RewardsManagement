namespace RewardsManagement.Models
{
    public class Calc
    {
        public decimal CalculateRewards(decimal fn, decimal limit)
        {
            //Example : (120 - 50) x 1 + (120 - 100) x 1 = 90 points
            if(fn>limit)
            {
                return (fn-limit)*1;
            }
            return 0;
        }

        public decimal TotalRewards(decimal fn, decimal sn)
        {
            //Example : (120 - 50) x 1 + (120 - 100) x 1 = 90 points
            return (sn + fn);
        }
    }
}