package org.antipathy.service;

import java.util.List;
import org.antipathy.model.Customer;
import org.antipathy.repository.CustomerRepository;

public class CustomerServiceImpl implements CustomerService 
{
    public CustomerServiceImpl() {

    }
    public CustomerServiceImpl(CustomerRepository c) {
        this.customerRepository =c;
    }

    private CustomerRepository customerRepository;

    public void setCustomerRepository(CustomerRepository customerRepository) {
        this.customerRepository = customerRepository;
    }
	
	public List<Customer> findAll()
	{
		return customerRepository.findAll();
	}
}
