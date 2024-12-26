using System;

namespace VariableUsage
{
    class VariableAssignment
    {
        static void Main(string[] args)
        {
            User user = GetUserInformation();
            double[] itemPrices = GetItemPrices();
            double totalPrice = CalculateTotalPrice(itemPrices);
            double discount = CalculateDiscount(totalPrice);
            DisplaySummary(user, totalPrice, discount);
        }

        static User GetUserInformation()
        {
            string tckn = GetValidTckn();
            string firstName = GetInput("First Name: ");
            string lastName = GetInput("Last Name: ");
            string phoneNumber = GetValidPhoneNumber();
            byte age = Convert.ToByte(GetInput("Age: "));

            return new User(tckn, firstName, lastName, phoneNumber, age);
        }

        static string GetValidTckn()
        {
            string tckn;
            do
            {
                tckn = GetInput("Turkish Identity Number (T.C. Kimlik Numarası): ");
                if (tckn.Length != 11)
                {
                    Console.WriteLine("!!! T.C. Identity Number must be 11 digits long !!!");
                }
            } while (tckn.Length != 11);

            return tckn;
        }

        static string GetValidPhoneNumber()
        {
            string phoneNumber;
            do
            {
                phoneNumber = GetInput("Phone Number : ");
                if (phoneNumber.Length != 11)
                {
                    Console.WriteLine("!!! Phone number must be 11 digits long !!!");
                }
            } while (phoneNumber.Length != 11);

            return phoneNumber;
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static double[] GetItemPrices()
        {
            double[] prices = new double[2];
            prices[0] = Convert.ToDouble(GetInput("Price of the first item: "));
            prices[1] = Convert.ToDouble(GetInput("Price of the second item: "));
            return prices;
        }

        static double CalculateTotalPrice(double[] prices)
        {
            return prices[0] + prices[1];
        }

        static double CalculateDiscount(double totalPrice)
        {
            return totalPrice * 0.10; // 10% discount
        }

        static void DisplaySummary(User user, double totalPrice, double discount)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine($"{user.Tckn} Turkish Identity Number, {user.FirstName} {user.LastName} has been registered.");
            Console.WriteLine($"A notification has been sent to the phone number: {user.PhoneNumber}");
            Console.WriteLine($"Total spending: {totalPrice:F2} TL, Discount earned (10%): {discount:F2} TL.");
        }
    }

    class User
    {
        public string Tckn { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public byte Age { get; }

        public User(string tckn, string firstName, string lastName, string phoneNumber, byte age)
        {
            Tckn = tckn;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Age = age;
        }
    }
}
