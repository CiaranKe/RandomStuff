package org.antipathy.repository;


import java.util.ArrayList;
import java.util.List;

import org.antipathy.model.Customer;

public class HibernateCustomerRepositoryImpl implements CustomerRepository 
{
	public List<Customer> findAll()
	{
		List<Customer> customers = new ArrayList<Customer>();
		
		Customer customer = new Customer();
		customer.setFisrtName("Ciaran");
		customer.setLastName("Kearney");
		
		customers.add(customer);
		
		return customers;
	}
}
