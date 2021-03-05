using System;
using System.Collections.Generic;
using System.Text;

namespace Paypal.Services
{
    class PaypalServices : IOnlineService
    {
        private const double FeePercentage = 0.02;
        private const double MonthlyInterest = 0.01;
        public double PaymentFee (double amount)
        {
            return amount * FeePercentage;
        }

        public double Interest (double amount, int months)
        {
            return amount * MonthlyInterest * months;
        }
    }
}
