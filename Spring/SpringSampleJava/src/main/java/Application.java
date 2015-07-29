import org.antipathy.service.CustomerService;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

public class Application {

	public static void main(String[] args)
    {
		//CustomerService service = new CustomerServiceImpl();
        ApplicationContext applicationContext = new AnnotationConfigApplicationContext(ApplicationConfiguration.class);
        CustomerService service = applicationContext.getBean("customerService", CustomerService.class);
		System.out.println(service.findAll().get(0).getFisrtName());
	}

}
