<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="TPFinalNivel3_Vazquez.MisFavoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Mis Favoritos</h3>
    <div class="row">
        <asp:GridView ID="dgvMisFavoritos" runat="server" DataKeyNames="Id"
            CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvMisFavoritos_SelectedIndexChanged"
            OnPageIndexChanging="dgvMisFavoritos_PageIndexChanging"
            AllowingPaging="True" PageSize="5">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descrip" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
                <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Quitar" />
            </Columns>
         </asp:gridview>
    </div>
</asp:Content>
