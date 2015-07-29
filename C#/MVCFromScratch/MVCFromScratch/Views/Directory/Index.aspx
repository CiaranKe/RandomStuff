<%@ Page Trace="true" Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DirectoryInfo>>" %>
<%@ Import Namespace="System.IO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%= ViewData["title"] %></title>
</head>
<body>
    <div>
        <h2><%= ViewData["message"] %></h2>
        <% Trace.Warn("DataTraceInformation", "Starting DrillDown Loop"); %>
        <% foreach (DirectoryInfo d in Model) 
                    {
                        if (Trace.IsEnabled)
                        {
                            Trace.Write("DataTraceInformation", "Printing a link to " + d.Name);
                        }%>

                        <%= Html.ActionLink(d.Name, "DrillDown", new {dir=d.FullName}) %> <br />
                          
                 <% } %>
        <br />
        <% Trace.Warn("DataTraceInformation", "Completed DrillDown Loop"); %>
    </div>
</body>
</html>