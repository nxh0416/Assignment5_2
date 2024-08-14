using TPBank.Entities;

namespace TPBank.DataAccessLayer;

public class CustomerDataAccessLayer : ICustomerDataAccesslayer
{
    private List<Customer> _customers;

    public CustomerDataAccessLayer()
    {
        _customers = [];
    }

    public List<Customer> GetCustomers()
    {
        return _customers;
    }
    public List<Customer> GetCustomersByCondition(Func<Customer, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return _customers.Where(predicate).ToList();
    }
    public Guid AddCustomer(Customer customer)
    {
        _customers.Add(customer);
        return customer.CustomerID;
    }
    // Update address, landmark, city, country, mobile, password
    public bool UpdateCustomer(Customer customer)
    {
        var cus = _customers.FirstOrDefault(c => c.UserName!.Equals(customer.UserName));
        if (cus == null)
            return false;
        cus.Address = customer.Address ?? cus.Address;
        cus.Landmark = customer.Landmark ?? cus.Landmark;
        cus.City = customer.City ?? cus.City;
        cus.Country = customer.Country ?? cus.Country;
        cus.Mobile = customer.Mobile ?? cus.Mobile;
        cus.Password = customer.Password ?? cus.Password;
        return true;
    }
    public bool DeleteCustomer(Guid customerID)
    {
        var cus = _customers.FirstOrDefault(c => c.CustomerID!.Equals(customerID));
        if (cus == null)
            return false;
        _customers.Remove(cus);
        return true;
    }

}
