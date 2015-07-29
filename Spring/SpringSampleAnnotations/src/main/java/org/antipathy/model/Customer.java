package org.antipathy.model;


import org.springframework.stereotype.Component;

@Component("customer") // any bean
//@Service  Service teir for business logic
//@Repository  Data access layer
public class Customer {
	
	private String fisrtName;
	private String lastName;

	public String getFisrtName() 
	{
		return fisrtName;
	}

	public String getLastName() 
	{
		return lastName;
	}

	public void setFisrtName(String _fisrtName) 
	{
		this.fisrtName = _fisrtName;
	}

	public void setLastName(String _lastName) 
	{
		this.lastName = _lastName;
	}
}
