package org.antipathy.repository;

import org.antipathy.model.Customer;

import java.util.List;

public interface CustomerRepository {

	List<Customer> findAll();

}