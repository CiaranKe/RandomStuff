package org.antipathy.starter.controller;

import org.antipathy.starter.model.Greeting;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.concurrent.atomic.AtomicLong;

/**
 * Created by Ciaran on 18/10/2014.
 */

@RestController /* @Controller &  @ResponseBody rolled together, everything in this class is restful
                   Because Jackson 2 is on the classpath, Spring’s MappingJackson2HttpMessageConverter
                   is automatically chosen to convert the Greeting instance to JSON*/
public class GreetingController
{
    private static final String template = "Hello %s!";
    private final AtomicLong counter = new AtomicLong();

    /* @RequestParam binds the value of the query string parameter name into the name parameter of the greeting()
       method. This query string parameter is not required; if it is absent in the request, the defaultValue of
       "World" is used. */
    @RequestMapping(value = "/greeting", method = RequestMethod.GET)
    public Greeting greeting(@RequestParam(value="name", required=false, defaultValue="World") String name) {
        return new Greeting(counter.incrementAndGet(), String.format(template, name));
    }

    @RequestMapping("/")
    public String index()
    {
        return "this is the index";
    }
}
