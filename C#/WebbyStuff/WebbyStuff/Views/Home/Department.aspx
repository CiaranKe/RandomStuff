<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Department Search Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form method="post" action="getEmpByDept">
    <select name ="dept">
    <% foreach (var s in (IEnumerable<String>)Model)
       {%>
         <option value="<%= s %>"> <%= s %></option>
       <% } %>
    </select><input type="submit" />
    </form>
</asp:Content>

