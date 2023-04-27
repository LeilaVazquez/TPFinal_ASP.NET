<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="TPFinalNivel3_Vazquez.Listado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         .btn-ok {
            background-color:palevioletred;
            color: white;
    </style>
    <h1>Artículos</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
            </div>
        </div>
    </div>
    <div class="col-6">
        <div class="mb-3">
            <asp:CheckBox Text="Filtro avanzado" runat="server" ID="chkAvanzado" CssClass="" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
        </div>
    </div>

    <%if (FiltroAvanzado)
        {%>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" runat="server" />
                <asp:DropDownList AutoPostBack="true" ID="ddlCampo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Código" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoría" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
            </div>
        </div>
    </div>
    <%} %>
    <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id"
        CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        AllowingPaging="True" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descrip" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>
    <a href="AgregarArticulo.aspx" class="btn btn-ok">Agregar</a>
</asp:Content>
