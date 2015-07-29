<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add Employee
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add New Employees</h2>
    <%: Html.ActionLink("Add Employee", "AddEmp", "Home")%> <br />
    <%: Html.ActionLink("Add Sales Employee", "AddSls", "Home")%><br />
    <%: Html.ActionLink("Add Manager", "AddMgr", "Home")%>

</asp:Content>
