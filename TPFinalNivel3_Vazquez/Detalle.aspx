<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPFinalNivel3_Vazquez.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .image-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100%; /* Asegura que el contenedor ocupe todo el espacio disponible */
        }

        .centered-image {
            max-width: 100%;
            max-height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detalle del artículo</h2>
    <div class="row">
        <div class="col-md-6">
            <div class="mb-3">
                <br />
                <label id="lblNom">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNom" CssClass="form-control" />
                <br />
                <label id="lblDescrip">Descripción:</label>
                <asp:TextBox runat="server" ID="txtDesc" CssClass="form-control" />
                <br />
                <label id="lblcod">Código:</label>
                <asp:TextBox runat="server" ID="txtCod" CssClass="form-control" />
                <br />
                <label id="lblmarca">Marca:</label>
                <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control" />
                <br />
                <label id="lblCat">Categoría</label>
                <asp:TextBox runat="server" ID="txtCat" CssClass="form-control" />
                <br />
                <label id="lblPrecio">Precio:</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:TextBox runat="server" ID="txtImg" CssClass="form-control" Visible="false" />
            </div>
        </div>
        <div class="col-md-6">
            <br />
            <div class="image-container">
                <asp:Image class="img-thumbnail centered-image" onerror="this.src='Images/default.png'" runat="server" ID="imgArticulo" />
            </div>
        </div>
    </div>
</asp:Content>
