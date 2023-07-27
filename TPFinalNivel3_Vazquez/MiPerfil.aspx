<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPFinalNivel3_Vazquez.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 15px;
        }
        .btn-ok {
            background-color:palevioletred;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" REQUIRED placeholder="Email" CssClass="form-control" TextMode="Email"/>         
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfv1" CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtApellido" CssClass="form-control" />
                 <asp:RequiredFieldValidator ID="rfv2" CssClass="validacion" ErrorMessage="El apellido es requerido" ControlToValidate="txtApellido" runat="server" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" accept=".jpg,.png,.jpeg"/>           
            </div>
            <asp:Image ImageUrl="https://www.chanchao.com.tw/images/default.jpg" runat="server" ID="imgNuevoPerfil" CssClass="img-fluid mb-3" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-ok" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
        </div>
    </div>
</asp:Content>

