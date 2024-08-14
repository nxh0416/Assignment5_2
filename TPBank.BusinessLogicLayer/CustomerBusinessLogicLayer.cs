using System.Text.RegularExpressions;
using TPBank.DataAccessLayer;
using TPBank.Entities;
namespace TPBank.BusinessLogicLayer;

public class CustomerBusinessLogicLayer : ICustomerBusinessLogicLayer, ICustomerValidation
{
    private readonly string _admin = "system";
    private readonly string _password = "manager";
    private CustomerDataAccessLayer _customerDatas;

    public CustomerBusinessLogicLayer()
    {
        _customerDatas = new CustomerDataAccessLayer();
    }
    public string? ValidateInputIsNotEmpty(string input)
    {
        if (string.IsNullOrEmpty(input.Trim()))
        {
            return "Invalid input! Input can not be empty.";
        }
        return null;
    }
    public string? ValidateCustomerName(string name)
    {
        if (string.IsNullOrEmpty(name.Trim()))
        {
            return "Customer name can not be empty";
        }
        else if (name.Trim().Length >= 40)
        {
            return "Customer name can not exceed 40 characters";
        }
        return null;
    }
    public string? ValidateMobile(string mobile)
    {
        string mobilePattern = @"^[0-9]{10}$";
        if (!Regex.IsMatch(mobile!, mobilePattern))
        {
            return "Mobile phone must be 10 digits";
        }
        else if (_customerDatas.GetCustomers().Exists(c => c.Mobile!.Equals(mobile)))
        {
            return "Mobile already exists";
        }
        return null;
    }
    public string? ValidateUserName(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            return "Username can not be empty.";
        }
        else if (_customerDatas.GetCustomers().Exists(c => c.UserName!.Equals(userName)))
        {
            return "Username already exists";
        }
        return null;
    }
    public string? ValidatePassword(string password)
    {
        string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)*.{6,}$";
        if (Regex.IsMatch(password!, passwordPattern))
            return null;
        return "Password must have at least 6 characters, include lower case, upper case, and digit number";
    }


    public string? LoginTPBank(string? userName, string? passWord)
    {
        if (userName!.Equals(_admin) && passWord!.Equals(_password))
            return null;
        return "Username or password is not match.";
    }

    public bool AddCustomer(Customer customer)
    {
        try
        {
            _customerDatas.AddCustomer(customer);
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

    public bool UpdateCustomer(Customer customer)
    {
        try
        {
            _customerDatas.UpdateCustomer(customer);
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

    public bool DeleteCustomer(Customer customer)
    {
        try
        {
            _customerDatas.DeleteCustomer(customer.CustomerID);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<Customer> FindCustomerByUserName(string? userName)
    {
        return _customerDatas.GetCustomersByCondition(cus => cus.UserName!.Equals(userName!));
    }

    public List<Customer> FindCustomerByMobile(string? mobile)
    {
        return _customerDatas.GetCustomersByCondition(cus => cus.Mobile!.Equals(mobile!));
    }
    public List<Customer> GetAllExistingCustomer()
    {
        return _customerDatas.GetCustomers();
    }

    public List<Customer> FindCustomerByName(string? customerName)
    {
        return _customerDatas.GetCustomersByCondition(cus => cus.CustomerName!.Equals(customerName!));
    }

    public List<Customer> FindCustomerByAddress(string? address)
    {
        return _customerDatas.GetCustomersByCondition(cus => cus.Address!.Equals(address!));
    }

    public List<Customer> FindCustomerByCity(string? city)
    {
        return _customerDatas.GetCustomersByCondition(cus => cus.City!.Equals(city!));
    }

    public List<Customer> FindCustomerByCountry(string? country)
    {
        return _customerDatas.GetCustomersByCondition(cus => cus.Country!.Equals(country!));
    }

}
