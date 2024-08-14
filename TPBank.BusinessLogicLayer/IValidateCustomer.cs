using TPBank.BusinessLogicLayer;

namespace TPBank.BusinessLogicLayer;
public interface ICustomerValidation
{
    public string? ValidateInputIsNotEmpty(string inputIsNotEmpty);
    public string? ValidateCustomerName(string name);
    public string? ValidateMobile(string mobile);
    public string? ValidateUserName(string userName);
    public string? ValidatePassword(string password);
}