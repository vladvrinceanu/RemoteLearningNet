namespace iQuest.VendingMachine.Services
{
    internal class CardValidator : ICardValidator
    {
        public bool IsCardNumberValid(string cardNumber)
        {
            int sum = 0;
            bool secondNumber = false;
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(cardNumber[i].ToString());
                if (secondNumber)
                {
                    n *= 2;
                    if (n > 9)
                    {
                        n = (n % 10) + (n / 10);
                    }
                }
                sum += n;
                secondNumber = !secondNumber;
            }
            return (sum % 10 == 0);
        }
    }
}
