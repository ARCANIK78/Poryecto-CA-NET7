using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistencia.Repostiories;
public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;
    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        
    }
    public async Task add(Customer customer) => await _context.Customers.AddAsync(customer);
    public async Task<Customer?> GetByIdAsync(CustomerID id) => await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
}
