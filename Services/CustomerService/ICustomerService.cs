using System.Collections.Generic;
using WebAPIExercise.Models;

namespace WebAPIExercise.Services.CustomerService
{
    public interface ICustomerService
    {
        IList<Customer> GetAll();

        Customer GetOne(long id);

        Customer Add(Customer newCustomer);

        void Update(Customer updatedCustomer);

        void Delete(Customer deletedCustomer);

    }


}
