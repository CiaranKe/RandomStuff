<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <div>
        <% using (Html.BeginForm("Index", "Form", FormMethod.Post)) { %>
            <label for="Firstname">First Name:</label><input type="text" name="Firstname" />
            <label for="Lastname">Last Name:</label><input type="text" name="Lastname" />
            <input type="radio" name="Gender" value="Male" /><label for="Gender">Male</label>
            <input type="radio" name="Gender" value="Female" /><label for="Gender">Female</label>
            <select name="Salutation" >
                <option value="Mr.">Mr.</option>
                <option value="Ms">Ms.</option>
                <option value="Miss.">Miss</option>
                <option value="Mrs.">Mrs.</option>
                <option value="Dr.">Dr.</option>
            </select><br />
            <input type="checkbox" name="Interests" value="Soccer"/>Soccer <br />
            <input type="checkbox" name="Interests" value="Radiohead"/>Radiohead <br />
            <input type="checkbox" name="Interests" value="Eastenders"/>Eastenders <br />

            <p> Hello <%= ViewData["sal"] %> <%= ViewData["fname"] %> <%= ViewData["lname"] %>, You are a <%= ViewData["Gender"] %> who likes  <%= ViewData["interests"] %></p>
            <input type="submit" value="Index" />
            <% } %>

    </div>
</body>
</html>
