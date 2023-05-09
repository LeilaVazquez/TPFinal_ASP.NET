<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3_Vazquez.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .validacion {
            color: red;
            font-size: 15px;
        }
        .btn-ok {
            background-color: palevioletred;
            color: white;
        }
    </style>
    <div class="row">
        <div class="col-4">
            <h2>Registrate</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail"  placeholder="Email" CssClass="form-control" TextMode="Email"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validacion" runat="server" ErrorMessage="El email es requerido" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" placeholder="*****" ID="txtPassword" CssClass="form-control" TextMode="Password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validacion" runat="server" ErrorMessage="La contraseña es requerida" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </div>
            <asp:Button runat="server" Text="Registrarse" ID="btnRegistro" OnClick="btnRegistro_Click" CssClass="btn btn-ok" />
            <asp:Button Text="Cancelar" runat="server"  ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn" CausesValidation="false" />
        </div>
    </div>
</asp:Content>
