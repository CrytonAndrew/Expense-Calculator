using System;

namespace Task1
{
    abstract class Expense
    {
        public abstract double calculateExpense();
    }

    class MonthlyExpenditure: Expense
    {
        // Instance variables used to calculate some of the expense
        protected double groceries = 0;
        protected double water_lights;
        protected double travel;
        protected double cellphone;
        protected double other;

        // Constructor to get some of the monthly expenses 
        public MonthlyExpenditure(double groceries, double water_lights, double travel, double cellphone, double other)
        {
            this.groceries = groceries;
            this.water_lights = water_lights;
            this.travel = travel;
            this.cellphone = cellphone;
            this.other = other;
        }

        // Function to calculate the expenses and returns the calculated total
        public override  double calculateExpense()
        {
            double total = this.groceries + this.water_lights + this.travel + this.cellphone + this.other;
            return total;
        }
    }

    class Homeloan : Expense
    {
        // Instance Variables needed to calculate a homeloan
        protected double purchasePrice;
        protected double totalDeposit;
        protected double interestRate;
        protected int numberOfMonths;

        // Consturctor to for the homeloan - to get values for the homeloan 
        public Homeloan(double purchasePrice,double totalDeposit,double interestRate,int numberOfMonths)
        {
            this.purchasePrice = purchasePrice;
            this.totalDeposit = totalDeposit;
            this.interestRate = interestRate;
            this.numberOfMonths = numberOfMonths;
        }

        // Function calculates and returns the monthly repayment of a homeloan
        public override double calculateExpense()
        {
            if (this.numberOfMonths >= 240 && this.numberOfMonths <= 360)
            {
                double repayment = this.purchasePrice * (1 + (this.interestRate / 100 * (this.numberOfMonths / 12) ));
                return repayment / this.numberOfMonths;
            }
            else
            {
                Console.WriteLine("Number of months is Invalid");
                return 0;
            } 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            double repaymentAmount = 0;
            double rentalAmount = 0;

            Console.Write("Enter monthly gross income: ");
            double income = double.Parse(Console.ReadLine());


            // ---------------------  Tax  -------------------------------------
            Console.Write("Enter tax deduction: ");
            double taxDeduction = double.Parse(Console.ReadLine());


            // ---------------------  Monthly things ---------------------------
            Console.Write("Enter groceries: ");
            double groceries = double.Parse(Console.ReadLine());

            Console.Write("Enter water and lights : ");
            double waterAndLights = double.Parse(Console.ReadLine());
  
            Console.Write("Enter travel costs: ");
            double travelCosts = double.Parse(Console.ReadLine());

            Console.Write("Enter cellphone and tellphone: ");
            double phoneBill = double.Parse(Console.ReadLine());

            Console.Write("Enter other: ");
            double other = double.Parse(Console.ReadLine());

            MonthlyExpenditure monthlyExpenditure = new MonthlyExpenditure(groceries, waterAndLights, travelCosts, phoneBill, other);
            double totalMonthlyExp = monthlyExpenditure.calculateExpense();
            Console.WriteLine($"Total Monthly Expenses: {totalMonthlyExp}");


            // ---------------------  House Loan  ------------------------------

            Console.Write("Enter property type: ");
            string propertyType = Console.ReadLine(); // Rent or RENT

            if (propertyType.Equals("renting"))
            {
                Console.Write("What is the rental monthly amount (renting or buying): ");
                rentalAmount = double.Parse(Console.ReadLine());




            }
            else if (propertyType.Equals("buying a property"))
            {
                Console.Write("Enter house purchase price: ");
                double purchasePrice = double.Parse(Console.ReadLine());

                Console.Write("Enter house deposit: ");
                double deposit = double.Parse(Console.ReadLine());

                Console.Write("Enter interest rate: ");
                double interestRate = double.Parse(Console.ReadLine());

                Console.Write("Enter number of months: ");
                int numberOfMonths = int.Parse(Console.ReadLine());

                Homeloan homeloan = new Homeloan(purchasePrice, deposit, interestRate, numberOfMonths);
                repaymentAmount = homeloan.calculateExpense();

                double third_of_monthly = income * (0.3);
                Console.WriteLine($"Qualify for homeloan: R {third_of_monthly}");
                if (repaymentAmount > third_of_monthly)
                {
                    Console.WriteLine($"Unlikely To Qualify for a Homeloan");
                }
            }
            else
            {
                Console.WriteLine("Property type not recognized");
            }

            double remaining = income - rentalAmount - totalMonthlyExp - repaymentAmount - taxDeduction;

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"" +
                $"Total Expenses: \n" +
                $"Income - R {Math.Round(income, 2)}, \n" +
                $"Tax - R {Math.Round(taxDeduction, 2)}, \n" +
                $"Rent - R {Math.Round(rentalAmount, 2)}, \n" +
                $"MonthlyExp - R {Math.Round(totalMonthlyExp, 2)}, \n" +
                $"Homeloan Monthly Payment - R {Math.Round(repaymentAmount, 2)}, \n" +
                $"Remaining Check - R {Math.Round(remaining, 2)}, \n");
            Console.WriteLine("--------------------------------------------");
            
        }
    }
}
