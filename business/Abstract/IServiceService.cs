using System.Collections.Generic;
using entity;
namespace business.Abstract
{
    public interface IServiceService
    {
        Service GetById(int id);
        List<Service> GetAll();
        void Create(Service entity);
        void Update(Service entity);
        void Delete(Service entity);
    }
}