<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="TPFinalNivel3_Vazquez.AgregarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <style>
        .btn-ok {
            background-color: palevioletred;
            color: white;
        }
    </style>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="md-3">
                <label for="txtCodigo" class="form-label">Código:</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese un código" ControlToValidate="txtCodigo"></asp:RequiredFieldValidator>
            </div>
            <div class="md-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
            </div>
            <div class="md-3">
                <label for="ddlMarca" class="form-label">Marca:</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="md-3">
                <label for="ddlCategoria" class="form-label">Categoría:</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
            <br />
            <div class="md-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-ok" OnClick="btnAceptar_Click" runat="server" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" CausesValidation="false" />
 
            </div>
        </div>
        <div class="col-6">
            <div class="md-3">
                <label for="txtPrecio" class="form-label">Precio:</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese un precio" ControlToValidate="txtPrecio"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^\d+(,\d{1,4}0{0,4})?$" ControlToValidate="txtPrecio" ErrorMessage="Ingrese solo números"></asp:RegularExpressionValidator>
            </div>
            <div class="md-3">
                <label for="txtDescripcion" class="form-label">Descripción:</label>               
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese una descripción" ControlToValidate="txtDescripcion"></asp:RequiredFieldValidator>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <contenttemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image class="img-thumbnail" onerror="this.src='Images/default.png'" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server" ID="imgArticulo" Width="60%" />
                </contenttemplate>
            </asp:UpdatePanel>
            <div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server"> 
            </asp:UpdatePanel> 
        </div>
    </div>
</asp:Content>
