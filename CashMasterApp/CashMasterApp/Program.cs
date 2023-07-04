using System;
using System.Collections.Generic;
using System.Diagnostics;
using CashMasterApp.App;
using CashMasterApp.Utils;

public class Program
{
    public static void Main()
    {
        string path = "C:\\Frameworks\\C#\\CashMasterApp\\CashMasterApp\\Datas\\Denominaciones.json";
        ReadJson readJson = new ReadJson(path);

        string country = "MEX";
        List<decimal> countryDenominations = readJson.GetDenominationFromCountry(country);

        CalculatorDenominations calculator = new CalculatorDenominations(countryDenominations);


        bool exit = false;

        while(!exit)
        {

            Console.Write("Enter the price please: ");
            decimal price;
            if(!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price. Please enter a valid decimal number");
                continue;
            }

            Console.Write("Enter the mount paid please: ");
            decimal amountPaid;
            if(!decimal.TryParse(Console.ReadLine(),out amountPaid))
            {
                Console.WriteLine("Invalid amount paid. Please enter a valid decimal number");
                continue;
            }
        try
        {
            Dictionary<decimal, int> change = calculator.CalculateChange(price, amountPaid);
            Console.WriteLine("CHANGE: ");
            foreach (KeyValuePair<decimal, int> kvp in change)
            {
                Console.WriteLine($"{kvp.Key * kvp.Value}");
                Console.WriteLine($"Denomination ==>> {kvp.Key}: Amount ==> {kvp.Value}");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

            Console.WriteLine("Do you want to calculate another change? (Y/N)");
            string input = Console.ReadLine();
            if(input.ToUpper()!= "Y")
            {
                exit = true;
            }


        }

       


    }
}