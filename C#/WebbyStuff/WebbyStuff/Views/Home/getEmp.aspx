<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Department Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <%= ViewData["Message"] %>
        <h2><%= ViewData["Name"] %></h2>
        Salary : <%= ViewData["Salary"] %><br />
        ID: <%= ViewData["ID"] %><br />
        Dept: <%= ViewData["Dept"] %><br />
</asp:Content>