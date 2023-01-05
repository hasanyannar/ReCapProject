using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ProjectDbContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ProjectDbContext context = new ProjectDbContext())
            {
                var result = from c in context.Customer
                             join u in context.User
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.CustomerId,
                                 CustomerName = u.FirstName + " " + u.LastName, 
                                 CompanyName = c.CompanyName,
                             };
                return result.ToList();
            }
        }
    }
}
