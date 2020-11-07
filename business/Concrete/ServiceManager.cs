using System.Collections.Generic;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private IServiceRepository _servicerepository;
        public ServiceManager(IServiceRepository servicerepository)
        {
            _servicerepository = servicerepository;
        }
        public void Create(Service entity)
        {
            _servicerepository.Create(entity);
        }

        public void Delete(Service entity)
        {
           _servicerepository.Delete(entity);
        }

        public List<Service> GetAll()
        {
            return _servicerepository.GetAll();
        }

        public Service GetById(int id)
        {
            return _servicerepository.GetById(id);
        }

        public void Update(Service entity)
        {
            _servicerepository.Update(entity);
        }
    }
}