package org.antipathy.async.service;

import org.antipathy.async.model.Page;
import org.springframework.scheduling.annotation.Async;
import org.springframework.scheduling.annotation.AsyncResult;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import java.util.concurrent.Future;

/* The class is marked with the @Service annotation, making it a candidate for Spring’s component scanning to detect it
and add it to the application context.*/
@Service
public class FaceBookLookupService
{
    /* The FacebookLookupService class uses Spring’s RestTemplate to invoke a remote REST point (graph.facebook.com),
    and then convert the answer into a Page object.*/
    RestTemplate restTemplate = new RestTemplate();


    @Async /* The findPage method is flagged with Spring’s @Async annotation, indicating it will run on a separate
              thread. The method’s return type is Future<Page> instead of Page, a requirement for any asynchronous
              service. This code uses the concrete implementation of AsyncResult to wrap the results of the Facebook
              query.*/
    public Future<Page> findPage(String page) throws InterruptedException
    {
        System.out.println("Looking up : " + page);

        Page results = restTemplate.getForObject("http://graph.facebook.com/" + page, Page.class);
        Thread.sleep(1000L);
        return new AsyncResult<Page>(results);
    }
}

/*  	Creating a local instance of the FacebookLookupService class does NOT allow the findPage method to run
        asynchronously. It must be created inside a @Configuration class or picked up by @ComponentScan. */
