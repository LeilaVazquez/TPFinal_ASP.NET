<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3_Vazquez.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .btn-ok {
            background-color: palevioletred;
            color: white;
        }

        p {
            margin-bottom: 1px;
        }
    </style>
    <div class="row">
        <div class="col-4">
            <h2>Login</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" REQUIRED placeholder="Email" CssClass="form-control" TextMode="Email" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" placeholder="*****" REQUIRED ID="txtPassword" CssClass="form-control" TextMode="Password" />
            </div>
            <asp:Button runat="server" Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-ok" />
            <div class="mb-3">
                <br />
                <p>¿No estas registrado?</p>
                <a href="Registro.aspx">Registrarme</a>
            </div>
        </div>
    </div>
</asp:Content>
