using TPBank.Entities;

namespace TPBank.DataAccessLayer;

public interface ICustomerDataAccesslayer
{
    List<Customer> GetCustomers();
    List<Customer> GetCustomersByCondition(Func<Customer, bool> predicate);
    Guid AddCustomer(Customer customer);
    bool UpdateCustomer(Customer customer);
    bool DeleteCustomer(Guid customerID);
}
