using System.Collections.Generic;
using WebAPIExercise.Models;

namespace WebAPIExercise.Services.CustomerService
{
    public class InMemoryCustomerService : ICustomerService
    {
        
        private IList<Customer> customers;

        public InMemoryCustomerService( IList<Customer> customers = null )
        {
            if (customers == null){
                new List<Customer>();
            }else{
                this.customers = customers;
            }
        }
        

        public IList<Customer> GetAll(){
            
        }
        public Customer GetOne(long id){

        }
        public Customer Add(Customer newCustomer){
            
        }

        public void Update(Customer updatedCustomer){
            
        }


        public void Delete(Customer deletedCustomer){
            foreach( Customer customer in customers){
                if(customer.Id == deletedCustomer.Id){
                    customers.Remove(customer);
                    return;
                }
            }
        }

    }


}
