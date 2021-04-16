# Expense Calculator - Task 

This is a console application that is an expense calculator. It allows for taking in values that will then produce values at the end showing the remaining part of the paycheck

## Usage

#### Calculations (Monthly Expenses):
```C#
class MonthlyExpenditure: Expense
    {
        protected double groceries;
        protected double water_lights;
        protected double travel;
        protected double cellphone;
        protected double other;

        public MonthlyExpenditure(double groceries, double water_lights, double travel, double cellphone, double other)
        {
            this.groceries = groceries;
            this.water_lights = water_lights;
            this.travel = travel;
            this.cellphone = cellphone;
            this.other = other;
        }

        public override  double calculateExpense()
        {
            double total = this.groceries + this.water_lights + this.travel + this.cellphone + this.other;
            return total;
        }
    }
```

#### Calculations (HomeLoan Expenses):

```C#
class Homeloan : Expense
    {
        protected double purchasePrice;
        protected double totalDeposit;
        protected double interestRate;
        protected int numberOfMonths;

        public Homeloan(double purchasePrice,double totalDeposit,double interestRate,int numberOfMonths)
        {
            this.purchasePrice = purchasePrice;
            this.totalDeposit = totalDeposit;
            this.interestRate = interestRate;
            this.numberOfMonths = numberOfMonths;
        }

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
```

#### Entering Values:


```C# 
Console.Write("Enter monthly gross income: ");
            double income = double.Parse(Console.ReadLine()); // Enter Income in double 

            Console.Write("Enter tax deduction: ");
            double taxDeduction = double.Parse(Console.ReadLine()); // Enter tax

            Console.Write("Enter groceries: ");
            double groceries = double.Parse(Console.ReadLine()); // Enter groceries

            Console.Write("Enter water and lights : ");
            double waterAndLights = double.Parse(Console.ReadLine()); // Enter water and lights

            Console.Write("Enter travel costs: ");
            double travelCosts = double.Parse(Console.ReadLine()); // Enter travel costs 

            Console.Write("Enter cellphone and tellphone: ");
            double phoneBill = double.Parse(Console.ReadLine()); // Enter cellphone and tellphone bill


            Console.Write("Enter other: ");
            double other = double.Parse(Console.ReadLine()); // Enter other expenses

            MonthlyExpenditure monthlyExpenditure = new MonthlyExpenditure(groceries, waterAndLights, travelCosts, phoneBill, other);
            double totalMonthlyExp = monthlyExpenditure.calculateExpense();
            Console.WriteLine($"Total Monthly Expenses: {totalMonthlyExp}"); // Prints total monthly expenses 

```


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
