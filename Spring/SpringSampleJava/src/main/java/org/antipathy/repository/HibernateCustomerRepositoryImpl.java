package org.antipathy.repository;


import org.antipathy.model.Customer;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;

@Repository("customerRepository")
public class HibernateCustomerRepositoryImpl implements CustomerRepository 
{

    @Value("${someProperty}")
    private String someValue;

    public List<Customer> findAll()
	{
		List<Customer> customers = new ArrayList<Customer>();
		
		Customer customer = new Customer();
		customer.setFisrtName(someValue);
		customer.setLastName("Kearney");
		
		customers.add(customer);
		
		return customers;
	}
}
