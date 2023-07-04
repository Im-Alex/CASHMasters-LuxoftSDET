using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMasterApp.App
{
    /// <summary>
    /// Represents a calculator for denominations used to calculate change.
    /// <param name="denominations">List of denominatios per country.</param>
    /// </summary>
    /// <param name="price">The price of the item.</param>
    /// <param name="amountPaid">The amount paid by the customer.</param>
    /// <returns>A dictionary containing the denominations and their corresponding amounts.</returns>

    public class CalculatorDenominations
    {
        private List<decimal> _denominations;

        public CalculatorDenominations(List<decimal> denominations) { 
            _denominations = denominations;
            
        }

        public Dictionary<decimal,int> CalculateChange(decimal price, decimal amountPaid)
        {
            try
            {
                decimal change = amountPaid - price;

                if (change < 0)
                {
                    throw new ArgumentException("The amount paid isn´t enough ");
                }

                Dictionary<decimal,int> result  = new Dictionary<decimal,int>();    
                foreach
                    (decimal denomination in _denominations)
                {
                    int amountDenomination = (int)(change / denomination);

                    if(amountDenomination>0)
                    {
                        result.Add(denomination, amountDenomination);
                        change %= denomination;
                    }
                }
                return result;
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Dictionary<decimal, int>();
            }
        }
    }
}
