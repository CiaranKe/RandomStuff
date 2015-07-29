<%@ Page Trace="true" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>InvokeTest</title>
</head>
<body>
    <div>
        <h2> <%= ViewData["one"] %></h2>
        <h2> <%= ViewData["two"] %></h2>
        <!--<%= Html.ActionLink("Buy your product now", "BuyNow") %>-->
        <form method="post" action="BuyNow.aspx">
        <input type="text" Name="" /> Customer ID <br/>
        </form>

    </div>
</body>
</html>
