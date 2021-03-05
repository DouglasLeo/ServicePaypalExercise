namespace Paypal.Services
{
    interface IOnlineService
    {
        double PaymentFee(double amount);
        double Interest(double amount, int months);
    }
}
