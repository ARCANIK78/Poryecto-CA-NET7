namespace Domain.Customers;
public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(Customer id);
    Task add(Customer customer);
}