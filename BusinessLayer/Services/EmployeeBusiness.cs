using BusinessLayer.Interfaces;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EmployeeBusiness: IEmployeeBusiness
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeBusiness(IEmployeeRepository repository)
        {
            this._repository = repository;
        }
        public object GetUserDetails()
        {
            return this._repository.GetUserDetails();
        }


    }
}
