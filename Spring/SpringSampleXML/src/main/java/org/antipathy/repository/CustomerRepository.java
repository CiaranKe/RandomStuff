package org.antipathy.repository;

import java.util.List;

import org.antipathy.model.Customer;

public interface CustomerRepository {

	List<Customer> findAll();

}