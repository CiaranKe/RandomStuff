package org.antipathy.STOMPWebSocket.controller;

import org.antipathy.STOMPWebSocket.model.Hello;
import org.antipathy.STOMPWebSocket.model.SayHello;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.stereotype.Controller;

@Controller
public class SayHelloController
{
    @MessageMapping("/hello")   /* ensures that if a message is sent to destination "/hello", then the greeting() method
                                   is called */
    @SendTo("/topic/greetings") /*  */
    public SayHello greeting(Hello hello) throws Exception
    {
        //simulate a delay
        Thread.sleep(3000L);
        return new SayHello("Hello " + hello.getName() + "!");
    }
}
