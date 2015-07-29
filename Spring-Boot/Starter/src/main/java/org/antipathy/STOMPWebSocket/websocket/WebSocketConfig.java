package org.antipathy.STOMPWebSocket.websocket;

import org.springframework.context.annotation.Configuration;
import org.springframework.messaging.simp.config.MessageBrokerRegistry;
import org.springframework.web.socket.config.annotation.AbstractWebSocketMessageBrokerConfigurer;
import org.springframework.web.socket.config.annotation.EnableWebSocketMessageBroker;
import org.springframework.web.socket.config.annotation.StompEndpointRegistry;

@Configuration                          /* indicate that this is a Spring configuration class.*/
@EnableWebSocketMessageBroker           /* enables WebSocket message handling, backed by a message broker */
public class WebSocketConfig extends AbstractWebSocketMessageBrokerConfigurer
{

    /* The configureMessageBroker() method overrides the default method in WebSocketMessageBrokerConfigurer to
       configure the message broker. It starts by calling enableSimpleBroker() to enable a simple memory-based
       message broker to carry the greeting messages back to the client on destinations prefixed with "/topic".
       It also designates the "/app" prefix for messages that are bound for @MessageMapping-annotated methods.*/
    @Override
    public void configureMessageBroker(MessageBrokerRegistry config)
    {
        config.enableSimpleBroker("/topic");
        config.setApplicationDestinationPrefixes("/app");
    }

    /* The registerStompEndpoints() method registers the "/hello" endpoint, enabling SockJS fallback options so that
    alternative messaging options may be used if WebSocket is not available. This endpoint, when prefixed with "/app",
    is the endpoint that the GreetingController.greeting() method is mapped to handle.*/
    @Override
    public void registerStompEndpoints(StompEndpointRegistry stompEndpointRegistry)
    {
        stompEndpointRegistry.addEndpoint("/hello").withSockJS();
    }
}
