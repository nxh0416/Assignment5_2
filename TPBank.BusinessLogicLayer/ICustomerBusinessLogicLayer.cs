using TPBank.Entities;

namespace TPBank.BusinessLogicLayer;

public interface ICustomerBusinessLogicLayer
{
    string? LoginTPBank(string? userName, string? passWord);
    bool AddCustomer(Customer customer);
    bool UpdateCustomer(Customer customer);
    bool DeleteCustomer(Customer userName);
    List<Customer> FindCustomerByUserName(string? userName);
    List<Customer> FindCustomerByMobile(string? mobile);
    List<Customer> GetAllExistingCustomer();
    List<Customer> FindCustomerByName(string? customerName);
    List<Customer> FindCustomerByAddress(string? address);
    List<Customer> FindCustomerByCity(string? city);
    List<Customer> FindCustomerByCountry(string? country);
}
