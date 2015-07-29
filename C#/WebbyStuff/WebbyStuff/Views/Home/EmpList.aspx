<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Employee List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <tr>
    <th>Name</th>
    <th>Staff ID</th>
    <th>Department</th>
    </tr>
    <% foreach(var e in (IEnumerable<WebbyStuff.localhost.Employee>)Model) 
     {%> 
     <tr>
        <td><%= Html.ActionLink(e.Name, "GetEmp", new {id = e.Number})%></td> <td><%= e.Number %></td> <td><%= Html.ActionLink(e.Department, "getEmpByDept", new { dept = e.Department })%></td>
     <% } %>
     </tr>
     </table>
</asp:Content>