package org.antipathy.async;


import org.antipathy.async.model.Page;
import org.antipathy.async.service.FaceBookLookupService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.scheduling.annotation.EnableAsync;

import java.util.concurrent.Future;

@Configuration
@EnableAsync                /* switches on Spring’s ability to run @Async methods in a background thread pool.*/
@EnableAutoConfiguration    /* switches on reasonable default behaviors based on the content of your classpath. For
                               example, it looks for any class that implements the CommandLineRunner interface and
                               invokes its run() method. In this case, it runs the run method in this class*/
@ComponentScan              /* tells Spring to search recursively through the hello package and its children for classes
                               marked directly or indirectly with Spring’s @Component annotation. This directive ensures
                               that Spring finds and registers the FacebookLookupService, because it is marked with
                               @Service, which in turn is a kind of @Component annotation. */
public class FacebookApplication implements CommandLineRunner
{
    @Autowired
    FaceBookLookupService faceBookLookupService;

    @Override
    public void run(String... args) throws Exception
    {

        //start the clock
        long start = System.currentTimeMillis();

        //kick off multiple async lookups
        Future<Page> page1 = faceBookLookupService.findPage("PivotalSoftware");
        Future<Page> page2 = faceBookLookupService.findPage("CloudFoundry");
        Future<Page> page3 = faceBookLookupService.findPage("SpringFramework");

        //wait until they're done
        while (!(page1.isDone()) && !(page2.isDone()) && !(page3.isDone()))
        {
            Thread.sleep(10);
        }

        //print results
        System.out.println("Elapsed Time: " + (System.currentTimeMillis() - start));
        System.out.println(page1.get());
        System.out.println(page2.get());
        System.out.println(page3.get());
    }

    public static void main(String[] args)
    {
        /* The main() method defers to the SpringApplication helper class, providing Application.class as an argument
        to its run() method. This tells Spring to read the annotation metadata from Application and to manage it as a
        component in the Spring application context.*/
        SpringApplication.run(FacebookApplication.class, args);
    }
}

/* To compare how long this takes without the asynchronous feature, try commenting out the @Async annotation and run
the service again. The total elapsed time should increase noticeably because each query takes at least a second.*/
