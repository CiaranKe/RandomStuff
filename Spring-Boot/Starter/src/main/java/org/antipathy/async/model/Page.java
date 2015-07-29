package org.antipathy.async.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/**
 * Created by Ciaran on 18/10/2014.
 */

@JsonIgnoreProperties(ignoreUnknown = true)  /* Spring uses the Jackson JSON library to convert Facebook’s JSON response
                                                into a Page object. The @JsonIgnoreProperties annotation signals Spring
                                                to ignore any attributes not listed in the class. This makes it easy to
                                                make REST calls and produce domain objects. */
public class Page
{
    private String name;
    private String webSite;

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public String getWebSite()
    {
        return webSite;
    }

    public void setWebSite(String webSite)
    {
        this.webSite = webSite;
    }

    @Override
    public String toString()
    {
        return "Page [name = " + name + ", webSite = " + webSite + "]";
    }
}
