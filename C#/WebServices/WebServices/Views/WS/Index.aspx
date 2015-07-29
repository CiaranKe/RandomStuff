<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <div>
        <form method="post" action="">
            <input name="a" type="text"/><br />
            <input name="b" type="text"/><br />
            <input type="submit" />
        </form>
        <h2><%= ViewData["Message"] %></h2>
    </div>
</body>
</html>
