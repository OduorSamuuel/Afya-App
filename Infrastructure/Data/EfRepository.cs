using AfyaApp.Infrastructure.Data;
using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;



namespace AfyaApp.Infrastructure.Data
{
    // inherit from Ardalis.Specification type
    public class EfRepository<T>(ApplicationDbContext applicationDbContext)
    : RepositoryBase<T>(applicationDbContext), IRepository<T>
    where T : class, IAggregateRoot
    {

    }
   



}


