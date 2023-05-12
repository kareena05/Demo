namespace Test.Services
{
    public class PaymentService : IPaymenService
    {
        int a = 10;

        public void ChangeAmount()
        {
            a = 10;
        }
    }
}
