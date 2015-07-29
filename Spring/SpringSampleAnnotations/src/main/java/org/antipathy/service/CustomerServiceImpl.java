package org.antipathy.service;

import org.antipathy.model.Customer;
import org.antipathy.repository.CustomerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service("customerService")
public class CustomerServiceImpl implements CustomerService 
{
    public CustomerServiceImpl() {

    }

    //@Autowired
    public CustomerServiceImpl(CustomerRepository c) {
        System.out.println("Constructor Injection");
        this.customerRepository =c;
    }

    //@Autowired v
    private CustomerRepository customerRepository;

    @Autowired  //needs noargs constructor
    public void setCustomerRepository(CustomerRepository customerRepository) {
        System.out.println("Setter Injection");
        this.customerRepository = customerRepository;
    }
	
	public List<Customer> findAll()
	{
		return customerRepository.findAll();
	}
}
