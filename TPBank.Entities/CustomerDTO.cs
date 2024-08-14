namespace TPBank.Entities;

public class CustomerAddDTO
{
    public string? CustomerName { get; set; }
    public string? Address { get; set; }
    public string? Landmark { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Mobile { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}

public class CustomerUpdateDTO
{
    public string? Address { get; set; }
    public string? Landmark { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Mobile { get; set; }
    public string? Password { get; set; }
}