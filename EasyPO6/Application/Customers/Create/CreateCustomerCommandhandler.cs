using Domain.Customers;
using MediatR;
using Domain.Primitives;
using Domain.ValuesObjects;

namespace Application.Customers.Create;
internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUniOfWork _uniOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUniOfWork uniOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentException(nameof(customerRepository));
        _uniOfWork = uniOfWork ?? throw new ArgumentException(nameof(uniOfWork));
    }
    public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        if(PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
        {
            throw new ArgumentException(nameof(phoneNumber));
        }
        if(Addres.Create(command.Country, command.Line1,command.Line2, command.City,command.State, command.ZipCode) is not Addres addres)
        {
            throw new ArgumentException(nameof(addres));
        }
        var customers = new Customer(
            new CustomerID(Guid.NewGuid()),
            command.Name,
            command.LastName,
            command.Email,
            phoneNumber,
            addres,
            true
        );
        await _customerRepository.add(customers);
        await _uniOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
