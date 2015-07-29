package org.antipathy.STOMPWebSocket.model;

/**
 * Created by Ciaran on 19/10/2014.
 */
public class SayHello
{
    private String content;

    public SayHello(String _content)
    {
        this.content = _content;
    }

    public String getContent()
    {
        return content;
    }
}
