<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPFinalNivel3_Vazquez.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detalle del artículo</h2>
    <div class="row">
        <div class="col-md-6">
            <div class="mb-3">
                <br />
                <label id="lblDescrip">Descripción:</label>
                <br />
                <label id="lblmarca">Marca:</label>
                <br />
                <label id="lblCat">Categoría</label>
                <br />
                <label id="lblCod">Código:</label>
            </div>
            <div class="mb-3">
                <label id="lblPrecio"></label>
            </div>
            <div class="mb-3">
            </div>
        </div>
        <div class="col-md-6">
            <div>
                <asp:Image ImageUrl="https://www.chanchao.com.tw/images/default.jpg" runat="server" ID="Image1" CssClass="img-fluid mb-3" />
            </div>
        </div>
    </div>
</asp:Content>
