package org.antipathy.starter;


import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.ComponentScan;

import java.util.Arrays;

@ComponentScan             /* tells Spring to search recursively through the hello package and its children for classes
                              marked directly or indirectly with Spring’s @Component annotation. */
@EnableAutoConfiguration   /* switches on reasonable default behaviors based on the content of your classpath.
                              For example, because the application depends on the embeddable version of Tomcat
                              (tomcat-embed-core.jar), a Tomcat server is set up and configured with reasonable
                              defaults on your behalf. And because the application also depends on Spring MVC
                              (spring-webmvc.jar), a Spring MVC DispatcherServlet is configured and registered for you
                              — no web.xml necessary!*/

/* Normally you would add @EnableWebMvc for a Spring MVC app, but Spring Boot adds it automatically when it sees
   spring-webmvc on the classpath. This flags the application as a web application and activates key behaviors such as
   setting up a DispatcherServlet.*/

public class Application
{
    /* The main() method defers to the SpringApplication helper class, providing Application.class as an argument to
    its run() method. This tells Spring to read the annotation metadata from Application and to manage it as a component
     in the Spring application context.*/
    public static void main(String[] args)
    {
        ApplicationContext ctx = SpringApplication.run(Application.class, args);

        System.out.println("Beans provided:");

        String[] beans = ctx.getBeanDefinitionNames();
        Arrays.sort(ctx.getBeanDefinitionNames());

        for (String beanName : beans)
        {
            System.out.println(beanName);
        }
    }
}
