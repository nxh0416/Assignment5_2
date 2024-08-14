using TPBank.BusinessLogicLayer;
using TPBank.Entities;

Presentation.LoginPage();


public static class Presentation
{
    private static readonly CustomerBusinessLogicLayer customerBUS = new();
    public static void LoginPage()
    {
        while (true)
        {
            Utilies.Header("TP Bank");
            Utilies.Heading("login page");
            Console.Write("Username: ");
            var usernName = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            var message = customerBUS.LoginTPBank(usernName, password);
            if (message == null)
            {
                MainMenuPage();
                break;
            }
            else
            {
                Console.WriteLine(message);
                Console.WriteLine("Press enter to continue or \"alt\" + \"enter\" to exit.");
                while (true)
                {
                    var userKey = Console.ReadKey();
                    if (userKey.Modifiers == ConsoleModifiers.Alt && userKey.Key == ConsoleKey.Enter)
                    {
                        return;
                    }
                    else if (userKey.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
        }
    }
    public static void MainMenuPage()
    {
        bool exitProgram = false;
        while (!exitProgram)
        {
            List<string> mainMenuOps = ["Add Customer", "Get All Existing Customer", "Find Customer", "Update Customer", "Delete Customer", "Exit"];
            Utilies.Header("Main menu");
            Utilies.PrintOperations(mainMenuOps);
            var operation = Utilies.GetUserOperation(1, mainMenuOps.Count);
            switch (operation)
            {
                case 1:
                    {
                        AddCustomerPage();
                        break;
                    }
                case 2:
                    {
                        GetAllCustomerPage();
                        break;
                    }
                case 3:
                    {
                        FindCustomerPage();
                        break;
                    }
                case 4:
                    {
                        UpdateCustomerPage();
                        break;
                    }
                case 5:
                    {
                        DeleteCustomerPage();
                        break;
                    }
                case 6:
                    {
                        exitProgram = true;
                        break;
                    }
                default:
                    {
                        throw new Exception("Invalid main operation");
                    }
            }
            Utilies.PauseScreen();
        }
    }
    public static void AddCustomerPage()
    {
        Utilies.Header("Add customer");
        string? cusName, address, landmark, city, country, mobile, username, password;
        while (true)
        {
            Console.Write("Customer Name: ");
            cusName = Console.ReadLine();
            var message = customerBUS.ValidateCustomerName(cusName!);
            if (message == null)
                break;
            Console.WriteLine(message);
        }

        while (true)
        {
            Console.Write("Address: ");
            address = Console.ReadLine();
            var message = customerBUS.ValidateInputIsNotEmpty(address!);
            if (message == null)
                break;
            Console.WriteLine(message);
        }

        while (true)
        {
            Console.Write("Landmark: ");
            landmark = Console.ReadLine();
            var message = customerBUS.ValidateInputIsNotEmpty(landmark!);
            if (message == null)
                break;
            Console.WriteLine(message);
        }

        while (true)
        {
            Console.Write("City: ");
            city = Console.ReadLine();
            var message = customerBUS.ValidateInputIsNotEmpty(city!);
            if (message == null)
                break;
            Console.WriteLine(message);
        }
        while (true)
        {
            Console.Write("Country: ");
            country = Console.ReadLine();
            var message = customerBUS.ValidateInputIsNotEmpty(country!);
            if (message == null)
                break;
            Console.WriteLine(message);
        }
        while (true)
        {
            Console.Write("Mobile: ");
            mobile = Console.ReadLine();
            var message = customerBUS.ValidateMobile(mobile!);
            if (message == null)
                break;
            Console.WriteLine(message);
        }
        while (true)
        {
            Console.Write("Username: ");
            username = Console.ReadLine();
            var message = customerBUS.ValidateUserName(username!);
            if (message == null)
                break;
            Console.WriteLine(message);
        }
        while (true)
        {
            Console.Write("Password: ");
            password = Console.ReadLine();
            var message = customerBUS.ValidatePassword(password!);
            if (message == null)
                break;
            Console.WriteLine(message);
        }
        var customerID = Guid.NewGuid();
        var customerCode = 100L;
        var customer = new Customer(customerID: customerID, customerCode: customerCode, cusName, address, landmark, city, country, mobile, username, password);
        customerBUS.AddCustomer(customer);
    }

    public static void GetAllCustomerPage()
    {
        Utilies.Header("Get All existing customer");
        var customers = customerBUS.GetAllExistingCustomer();
        Utilies.PrintListCustomer(customers);
    }
    public static void FindCustomerPage()
    {
        bool exitProgram = false;
        while (!exitProgram)
        {

            Utilies.Header("Find Customer Menu");
            List<string> findCustomerOps = ["Find By UserName", "Find By Address", "Find By City", "Find By Mobile", "Exit"];
            Utilies.PrintOperations(findCustomerOps);
            var operation = Utilies.GetUserOperation(1, findCustomerOps.Count);
            switch (operation)
            {
                case 1:
                    {
                        Utilies.Header("Find customer by Username");
                        Console.Write("Enter User Name: ");
                        var cusUsername = Console.ReadLine();
                        var customers = customerBUS.FindCustomerByUserName(cusUsername);
                        Utilies.PrintListCustomer(customers, $"There is no customer with name: {cusUsername}.");
                        break;
                    }
                case 2:
                    {
                        Utilies.Header("Find customer by address");
                        Console.Write("Enter Customer Address: ");
                        var cusAddress = Console.ReadLine();
                        var customers = customerBUS.FindCustomerByAddress(cusAddress);
                        Utilies.PrintListCustomer(customers, $"There is no customer with address: {cusAddress}.");
                        break;
                    }
                case 3:
                    {
                        Utilies.Header("Find customer by City");
                        Console.Write("Enter Customer City: ");
                        var cusCity = Console.ReadLine();
                        var customers = customerBUS.FindCustomerByCity(cusCity);
                        Utilies.PrintListCustomer(customers, $"There is no customer with city: {cusCity}.");
                        break;
                    }
                case 4:
                    {
                        Utilies.Header("Find customer by mobile");
                        Console.Write("Enter Customer Mobile: ");
                        var cusMobile = Console.ReadLine();
                        var customers = customerBUS.FindCustomerByMobile(cusMobile);
                        Utilies.PrintListCustomer(customers, $"There is no customer with mobile: {cusMobile}.");
                        break;
                    }
                case 5:
                    {
                        exitProgram = true;
                        break;
                    }
            }
            if (!exitProgram) Utilies.PauseScreen();
        }
    }

    public static void UpdateCustomerPage()
    {
        Utilies.Header("Update customer");
        Console.Write("Enter Username you want to update: ");
        var username = Console.ReadLine();
        var customers = customerBUS.FindCustomerByUserName(username);
        switch (customers.Count)
        {
            case 1:
                {
                    var customer = customers[0];
                    Console.WriteLine("=> You selected {0} has:", customer.UserName);
                    Utilies.PrintUpdateCustomerInfo(customer);
                    Console.WriteLine("=> Enter the information you want to update (Address, Landmark, City, Country, Mobile, Passwrd): ");
                    Console.WriteLine("If the input value is null or empty, default will not change");
                    Console.Write("Address: ");
                    var address = Console.ReadLine();
                    if (string.IsNullOrEmpty(address!.Trim()))
                    {
                        address = customer.Address;
                    }
                    Console.Write("Landmark: ");
                    var landmark = Console.ReadLine();
                    if (string.IsNullOrEmpty(landmark!.Trim()))
                    {
                        landmark = customer.Landmark;
                    }
                    Console.Write("City: ");
                    var city = Console.ReadLine();
                    if (string.IsNullOrEmpty(city!.Trim()))
                    {
                        city = customer.City;
                    }
                    Console.Write("Country: ");
                    var country = Console.ReadLine();
                    if (string.IsNullOrEmpty(country!.Trim()))
                    {
                        country = customer.Country;
                    }
                    string? mobile;
                    while (true)
                    {
                        Console.Write("Mobile: ");
                        mobile = Console.ReadLine();
                        if (string.IsNullOrEmpty(mobile!.Trim()))
                        {
                            mobile = customer.Mobile;
                            break;
                        }
                        else
                        {
                            var message = customerBUS.ValidateMobile(mobile);
                            if (message == null)
                            {
                                break;
                            }
                            Console.WriteLine(message);
                        }
                    }
                    string? password;
                    while (true)
                    {
                        Console.Write("Password: ");
                        password = Console.ReadLine();
                        if (string.IsNullOrEmpty(password!.Trim()))
                        {
                            password = customer.Password;
                            break;
                        }
                        else
                        {
                            var message = customerBUS.ValidatePassword(password);
                            if (message == null)
                            {
                                break;
                            }
                            Console.WriteLine(message);
                        }
                    }
                    var updatedCustomer = new Customer(customer.CustomerID, customer.CustomerCode, customer.CustomerName, address, landmark, city, country, mobile, customer.UserName, password);
                    if (customerBUS.UpdateCustomer(updatedCustomer))
                    {
                        Console.WriteLine("=> Update Succeed: ");
                        Utilies.PrintUpdateCustomerInfo(customer);
                    }
                    else
                    {
                        Console.WriteLine("=> Update failed: ");
                        Console.WriteLine("Error: Internal error");
                    }
                    break;
                }
            case 0:
                {
                    Console.WriteLine("Customer not found.");
                    break;
                }
            default:
                {
                    throw new Exception("Internal sever error");
                }
        }
    }
    public static void DeleteCustomerPage()
    {
        Utilies.Header("delete customer");
        Console.Write("Enter user name you want to delete: ");
        var username = Console.ReadLine();
        var customers = customerBUS.FindCustomerByUserName(username);
        switch (customers.Count)
        {
            case 1:
                {
                    var customer = customers[0];
                    if (customerBUS.DeleteCustomer(customer))
                    {
                        Console.WriteLine("Delete Succeed");
                    }
                    else
                    {
                        Console.WriteLine("Failed to Delete");
                    }
                    break;
                }
            case 0:
                {
                    Console.WriteLine("Customer not found");
                    break;
                }
            default:
                {
                    throw new Exception("Internal server error");
                }
        }
    }
}

public static class Utilies
{
    public static void Header(string header)
    {
        Console.Clear();
        Console.WriteLine("=============== {0} ===============", header.ToUpper());
        Console.WriteLine();
    }
    public static void Heading(string heading)
    {
        Console.WriteLine("++++++ {0} ++++++", heading);
    }
    public static void PauseScreen()
    {
        Console.WriteLine();
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
        Console.WriteLine();
    }
    public static void PrintOperations(List<string> operations)
    {
        for (int i = 0; i < operations.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {operations[i]}");
        }
    }
    public static int GetUserOperation(int from = 1, int to = 1)
    {
        while (true)
        {
            Console.Write("Enter your selection: ");
            var uesrInput = Console.ReadLine();
            if (string.IsNullOrEmpty(uesrInput!.Trim()))
            {
                Console.WriteLine("Invalid select operations. Operation can not be empty");
            }
            else if (!int.TryParse(uesrInput, out var number))
            {
                Console.WriteLine("Invalid select operations. Operation select must be a number.");
            }
            else if (!(number.CompareTo(from) >= 0 && number.CompareTo(to) <= 0))
            {
                Console.WriteLine("Invalid select operations. Operations is out of bound");
            }
            else
            {
                return number;
            }
        }
    }
    public static void PrintListCustomer(List<Customer> customers, string message = "Currently there is no customer to show")
    {
        for (int i = 0; i < customers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. " + customers[i].ToString());
        }
        if (customers.Count == 0)
        {
            Console.WriteLine(message);
        }
    }
    public static void PrintUpdateCustomerInfo(Customer customer)
    {
        Console.WriteLine("\tCustomer Name: {0}", customer.CustomerName);
        Console.WriteLine("\tAddress: {0}", customer.Address);
        Console.WriteLine("\tLandmark: {0}", customer.Landmark);
        Console.WriteLine("\tCity: {0}", customer.City);
        Console.WriteLine("\tCountry: {0}", customer.Country);
        Console.WriteLine("\tMobile: {0}", customer.Mobile);
        Console.WriteLine("\tUsername: {0}", customer.UserName);
        Console.WriteLine("\tPassword: {0}", customer.Password);
    }
}