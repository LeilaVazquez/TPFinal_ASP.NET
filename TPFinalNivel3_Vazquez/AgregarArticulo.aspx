﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="TPFinalNivel3_Vazquez.AgregarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="md-3">
                <label for="txtCodigo" class="form-label">Código:</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="md-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
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
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="Listado.aspx">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="md-3">
                <label for="txtPrecio" class="form-label">Precio:</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <div class="md-3">
                <label for="txtDescripcion" class="form-label">Descripción:</label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
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
                <contenttemplate>
                    <div class="mb-3">
                        <br />
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    </div>
                    <%if (ConfirmaEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminación" ID="ckConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmarEliminacion" OnClick="btnConfirmarEliminacion_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>
                    <% } %>
                </contenttemplate>
            </asp:UpdatePanel> 
        </div>
    </div>
</asp:Content>
