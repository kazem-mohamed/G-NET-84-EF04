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

    private static void OpenAccount(BankContext context)
    {
        Console.WriteLine("\n--- Open New Account ---");
        var accountNumber = ReadRequired("Account number: ");
        if (context.Accounts.Find(accountNumber) is not null)
        {
            Console.WriteLine("An account with this number already exists.");
            return;
        }

        var accountType = ReadChoice("1) Savings\n2) Current\n3) Business\nChoice: ", 1, 2, 3) switch
        {
            1 => AccountType.Savings,
            2 => AccountType.Current,
            _ => AccountType.Business
        };
        var branchCode = ReadRequired("Branch code: ");
        var customerId = ReadInt("Customer ID: ");
        var ownership = ReadChoice("1) Primary\n2) CoHolder\nChoice: ", 1, 2) == 1
            ? OwnershipType.Primary : OwnershipType.CoHolder;

        if (context.Branches.Find(branchCode) is null)
        {
            Console.WriteLine($"Branch '{branchCode}' does not exist.");
            return;
        }

        if (context.Customers.Find(customerId) is null)
        {
            Console.WriteLine($"Customer {customerId} does not exist.");
            return;
        }

        context.Accounts.Add(new Account { AccountNumber = accountNumber, AccountType = accountType, BranchCode = branchCode, OpeningDate = DateTime.UtcNow, CurrentBalance = 0m });
        context.CustomerAccounts.Add(new CustomerAccount { AccountNumber = accountNumber, CustomerId = customerId, OwnershipType = ownership, OwnershipStartDate = DateTime.UtcNow, AccountStatus = AccountStatus.Active });
        context.SaveChanges();
        Console.WriteLine($"Account '{accountNumber}' created and linked to customer {customerId}.");
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

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out var value)) return value;
            Console.WriteLine("Invalid number. Please try again.");
        }
    }
}
