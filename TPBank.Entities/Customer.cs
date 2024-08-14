using System.Text.RegularExpressions;

namespace TPBank.Entities;

public class Customer
{
    private Guid _customerID;
    public Guid CustomerID
    {
        get => _customerID;
        set
        {

            _customerID = value;
        }
    }
    private long _customerCode;
    public long CustomerCode
    {
        get => _customerCode;
        set
        {
            _customerCode = value;
        }
    }

    public string? CustomerName
    {
        get => _customerName;
        set
        {
            _customerName = value;
        }
    }
    public string? Address { get => _address; set => _address = value; }
    public string? Landmark { get => _landmark; set => _landmark = value; }
    public string? City { get => _city; set => _city = value; }
    public string? Country { get => _country; set => _country = value; }
    public string? Mobile
    {
        get => _mobile; set
        {

            _mobile = value;
        }
    }
    public string? UserName
    {
        get => _userName; set
        {
            _userName = value;

        }
    }
    public string? Password
    {
        get => _password; set
        {
            _password = value;
        }
    }

    private string? _customerName;
    private string? _address;
    private string? _landmark;
    private string? _city;
    private string? _country;
    private string? _mobile;
    private string? _userName;
    private string? _password;

    public Customer(Guid customerID, long customerCode, string? customerName, string? address, string? landmark, string? city, string? country, string? mobile, string? userName, string? password)
    {
        CustomerCode = customerCode;
        CustomerName = customerName;
        Address = address;
        Landmark = landmark;
        City = city;
        Country = country;
        Mobile = mobile;
        UserName = userName;
        Password = password;
        CustomerID = customerID;
    }

    public override string ToString()
    {
        return string.Format("Id: {0}, Code: {1}, Name: {2}, Address: {3}, Landmark: {4}, City: {5}, Country: {6}, Mobile: {7}, Username: {8}, Password: {9}.", CustomerID, CustomerCode, CustomerName, Address, Landmark, City, Country, Mobile, UserName, Password);
    }
}
