<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebbyStuff.Models.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <form method="post" action="">
    <select name="Salutation">
        <option value="Mr.">Mr.</option>
        <option value="Mrs.">Mrs.</option>
        <option value="Miss.">Miss.</option>
        <option value="Ms.">Ms.</option>
        <option value="Dr.">Dr.</option>
    </select><br />
    <%= Html.LabelFor(m => Model.FirstName) %> <%= Html.TextBoxFor(m => Model.FirstName) %> <%= Html.ValidationMessageFor(m => m.FirstName) %> <br />
    <%= Html.LabelFor(m => Model.LastName) %> <%= Html.TextBoxFor(m => Model.LastName) %> <%= Html.ValidationMessageFor(m => m.LastName) %><br />
    Male: <%= Html.RadioButtonFor(m => Model.Gender, "Male") %> <%= Html.ValidationMessageFor(m => m.Gender) %> <br />
    Female: <%= Html.RadioButtonFor(m => Model.Gender, "Female")%> <br />
    <input type="submit" />
    </form>
    <p></p>
</asp:Content>
