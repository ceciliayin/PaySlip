using System;
using System.Runtime.Intrinsics.X86;
using System.Xml;

namespace PaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            //print initial messages and  read the user input
            Console.WriteLine("Welcome to the payslip generator!");
            
            Console.WriteLine("Please input your name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please input your surname: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter your annual salary: ");
            int annualSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your super rate: ");
            int superRate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your payment start date: ");
            string startDate = Console.ReadLine();
            Console.WriteLine("Please enter your payment end date: ");
            string endDate = Console.ReadLine();

            //Calculate the gross income
            var grossIncome = Convert.ToInt32 (annualSalary / 12);

            //Calculate income tax
            
            double tax = 0;

            if (annualSalary > 18201 && annualSalary < 37000)
            {
               tax = Convert.ToInt32(((annualSalary - 18200) * 0.19)/12);
            }

            if (annualSalary > 37001 && annualSalary < 87000)
            {
                tax = Convert.ToInt32 ((3572 + (annualSalary - 37000) * 0.325) / 12);
            }

            if (annualSalary < 87001 && annualSalary > 180000)
            {
                tax = Convert.ToInt32((19822 + (annualSalary - 87000) * 0.37)/12);
            }
            
            if(annualSalary>180001)
            {
                tax = Convert.ToInt32((54332 + (annualSalary - 180000) * 0.45)/12);
            }
            
            //calculate the net income
            double netIncome = Convert.ToInt32 (grossIncome - tax);
            
            //calculate super
            double super = Convert.ToInt32 (grossIncome * superRate *0.01);

            //print the outcome
            Console.WriteLine($"Name: {firstName} {lastName}");
            Console.WriteLine($"Pay Period : {startDate} - {endDate}");
            Console.WriteLine($"Gross Income : {grossIncome}");
            Console.WriteLine($"Income Tax: {tax}");
            Console.WriteLine($"Net Income: {netIncome}");
            Console.WriteLine($"Super: {super}");
            Console.WriteLine("Thank you for using MYOB!");
        }
    }
}

