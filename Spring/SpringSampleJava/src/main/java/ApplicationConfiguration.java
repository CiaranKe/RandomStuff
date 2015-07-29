import org.antipathy.service.CustomerService;
import org.antipathy.service.CustomerServiceImpl;
import org.springframework.context.annotation.*;
import org.springframework.context.support.PropertySourcesPlaceholderConfigurer;

@Configuration
@ComponentScan({"org.antipathy"})
@PropertySource("app.properties")
public class ApplicationConfiguration
{
    @Bean(name="customerService")
    @Scope("singleton")
    public CustomerService getCustomerService()
    {
        //autowired
        CustomerServiceImpl customerService = new CustomerServiceImpl();
        //constructor injection
        //CustomerServiceImpl customerService = new CustomerServiceImpl(getCustomerRepository());
        //setter injection
        //customerService.setCustomerRepository(getCustomerRepository());
        return new CustomerServiceImpl();
    }



    /*
    //replaced by @repository
    @Bean(name="customerRepository")
    public CustomerRepository getCustomerRepository()
    {
        return new HibernateCustomerRepositoryImpl();
    }
    */

    @Bean
    public static PropertySourcesPlaceholderConfigurer getPropertySourcesPlaceholderConfigurer() {
        return new PropertySourcesPlaceholderConfigurer();
    }
}
