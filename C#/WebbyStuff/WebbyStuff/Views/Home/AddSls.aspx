<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddEmp
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add Sales Employee</h2>
    <form method="post" action="">
    <table>
    <tr>
    <td>Name:</td>
    <td><input name="Name" /></td>
    </tr>
    <tr>
    <td>Salary</td>
    <td><input name="Salary" /></td>
    </tr>
    <tr>
    <td>Dept:</td>
    <td><input name="Dept" /></td>
    </tr>
    <tr>
    <td>Comission:</td>
    <td><input name="Comission" /></td>
    </tr>
    <tr>
    <td>Comission Rate:</td>
    <td><input name="ComissionRate" /></td>
    </tr>
    <tr>
    <td>Number of Sales:</td>
    <td><input name="numSales" /></td>
    </tr>
    </table>
    <input type="submit" />
    </form>

</asp:Content>