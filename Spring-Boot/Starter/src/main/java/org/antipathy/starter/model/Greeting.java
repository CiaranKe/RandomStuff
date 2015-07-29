package org.antipathy.starter.model;

/**
 * Created by Ciaran on 18/10/2014.
 */
public class Greeting
{
    private final long id;
    private final String content;

    public Greeting(long _id, String _greeting)
    {
        this.id = _id;
        this.content = _greeting;
    }

    public long getId()
    {
        return id;
    }

    public String getContent()
    {
        return content;
    }
}
