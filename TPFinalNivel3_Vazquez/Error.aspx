<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPFinalNivel3_Vazquez.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         .btn-ok {
            background-color:palevioletred;
            color: white;
        }      
    </style>
    <h1>User o password incorrectos</h1>
    <br />
    <asp:Label Text="" ID="lblMensaje" runat="server" />
    <br />
    <br />
    <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-ok" OnClick="btnVolver_Click" runat="server" />
</asp:Content>
