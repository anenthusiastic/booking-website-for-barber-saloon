using data.Abstract;
using entity;

namespace data.Concrete.EFCore
{
    public class EFCoreServiceRepository : GenericRepository<Service,BarberContext>,IServiceRepository
    {
        
    }
}