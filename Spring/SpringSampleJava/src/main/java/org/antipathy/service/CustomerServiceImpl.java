package org.antipathy.service;

import org.antipathy.model.Customer;
import org.antipathy.repository.CustomerRepository;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;

public class CustomerServiceImpl implements CustomerService 
{
    @Autowired
    private CustomerRepository customerRepository;

    public CustomerServiceImpl() {}

    public CustomerServiceImpl(CustomerRepository c) {
        this.customerRepository = c;
    }

    @Autowired
    public void setCustomerRepository(CustomerRepository customerRepository) {
        this.customerRepository = customerRepository;
    }
	
	public List<Customer> findAll()
	{
		return customerRepository.findAll();
	}
}
