using System.Collections.Generic;
using System.Linq;
using WebAPIExercise.Data;
using WebAPIExercise.Data.Models;

namespace WebAPIExercise.Services.CustomerService
{
    public class InMemoryDatabaseService : ICustomerService
    {
        private WebAPIExerciseContext context;

        public InMemoryDatabaseService( WebAPIExerciseContext context ){
            this.context = context;
        }
        
        public Customer Add(Customer newCustomer)
        {
            var addedCustomer = this.context.Customers.Add(newCustomer);
            this.context.SaveChanges();
            return addedCustomer.Entity;
        }

        public void Delete(Customer deletedCustomer)
        {
            this.context.Customers.Remove(deletedCustomer);
            this.context.SaveChanges();
        }

        public IList<Customer> GetAll()
        {
            return this.context.Customers.ToList();
            //throw new System.NotImplementedException();
        }

        public Customer GetOne(long id)
        {
            return this.context.Customers.Find(id);
            //throw new System.NotImplementedException();
        }

        public void Update(Customer updatedCustomer)
        {
            this.context.Customers.Update(updatedCustomer);
            this.context.SaveChanges();
            //throw new System.NotImplementedException();
        }
    }
}