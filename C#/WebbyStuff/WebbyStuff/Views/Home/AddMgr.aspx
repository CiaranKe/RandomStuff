<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddEmp
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add Manager</h2>
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
    <td>Reports:</td>
    <td><input name="Reports" /></td>
    </tr>
    <tr>
    <td>Bonus Per Report:</td>
    <td><input name="BonPerRept" /></td>
    </tr>
    </table>
    <input type="submit" />
    </form>

</asp:Content>