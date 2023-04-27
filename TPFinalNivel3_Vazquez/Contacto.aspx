<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TPFinalNivel3_Vazquez.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         .btn-ok {
            background-color:palevioletred;
            color: white;
        }      
        .validacion {
            color: red;
            font-size: 12px;
        }
        .ok{
            color: forestgreen;
            font-size: 15px;
            text-align: center;
        }
    </style>
    <h2>Formulario de contacto</h2>
    <br />
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="validacion" runat="server" ErrorMessage="Ingrese un email" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label class="form-label">Asunto</label>
                <asp:TextBox runat="server" ID="txtAsunto" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validacion" runat="server" ErrorMessage="Ingrese un asunto" ControlToValidate="txtAsunto"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label class="form-label">Mensaje</label>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMensaje" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validacion" runat="server" ErrorMessage="Ingrese un mensaje" ControlToValidate="txtMensaje"></asp:RequiredFieldValidator>
            </div>
            <asp:Button Text="Aceptar" runat="server" CssClass="btn btn-ok" ID="btnAceptar" OnClick="btnAceptar_Click" />
        </div>
        <div class="col"></div>
        <asp:Label ID="lblMessage"  CssClass="ok" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
