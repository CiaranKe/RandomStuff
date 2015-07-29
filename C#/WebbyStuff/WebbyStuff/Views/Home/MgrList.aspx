<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebbyStuff.localhost.Manager[]>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Employee List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <tr>
    <th>Name</th>
    <th>Staff ID</th>
    <th>Department</th>
    <th>Reports</th>
    <th>Bonus Per Report</th>
    </tr>
    <% foreach(var e in (IEnumerable<WebbyStuff.localhost.Manager>)Model) 
     {%> 
     <tr>
        <td><%= Html.ActionLink(e.Name, "GetEmp", new {id = e.Number})%></td> <td><%= e.Number %></td> <td><%= Html.ActionLink(e.Department, "getEmpByDept", new { dept = e.Department })%> </td> <td><%= e.Reports %></td> <td><%= e.BonusPerReport %></td>
     <% } %>
     </tr>
     </table>
</asp:Content>