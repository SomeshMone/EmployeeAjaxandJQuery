using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            this._context = context;
        }
        public object GetUserDetails()
        {
            var data=_context.Employee.ToList();
            if(data!=null) 
            {
                return data;
            }
            else
            {
                return null;
            }

        }

    }
}
