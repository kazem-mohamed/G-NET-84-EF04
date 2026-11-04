using Microsoft.EntityFrameworkCore;

namespace G_NET_84_EF04;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("National Bank Management System");
    }

    private static void AddCustomer(BankContext context)
    {
        Console.WriteLine("\n--- Add New Customer ---");
        var fullName = ReadRequired("Full name: ");
        var nationalId = ReadRequired("National ID: ");
        if (context.Customers.Any(customer => customer.NationalId == nationalId))
        {
            Console.WriteLine("A customer with this national ID already exists.");
            return;
        }

        var dateOfBirth = ReadDate("Date of birth (yyyy-MM-dd): ");
        var email = ReadRequired("Email: ");
        var phoneNumber = ReadRequired("Phone: ");
        var address = ReadRequired("Address: ");
        var type = ReadChoice("1) Individual\n2) Business\nChoice: ", 1, 2) == 1
            ? CustomerType.Individual : CustomerType.Business;

        var customer = new Customer { FullName = fullName, NationalId = nationalId, DateOfBirth = dateOfBirth, Email = email, PhoneNumber = phoneNumber, Address = address, CustomerType = type };
        context.Customers.Add(customer);
        context.SaveChanges();
        Console.WriteLine($"Customer created successfully. CustomerId = {customer.Id}");
    }

    private static string ReadRequired(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var value = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(value)) return value;
            Console.WriteLine("Value is required. Please try again.");
        }
    }

    private static DateTime ReadDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (DateTime.TryParse(Console.ReadLine(), out var result)) return result;
            Console.WriteLine("Invalid date. Please use a valid date such as 2000-01-25.");
        }
    }

    private static int ReadChoice(string prompt, params int[] validChoices)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out var choice) && validChoices.Contains(choice)) return choice;
            Console.WriteLine("Invalid choice. Please try again.");
        }
    }
}
