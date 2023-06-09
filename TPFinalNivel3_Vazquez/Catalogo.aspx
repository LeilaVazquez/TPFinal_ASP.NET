﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPFinalNivel3_Vazquez.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .icono-favorito {
            background-image: url('Images/fav.jpg');
            background-size: contain;
            width: 40px;
            height: 40px;
            border: none;
            float: right;
        }

        .btn-ok {
            background-color: palevioletred;
            color: white;
        }

        .btn-list {
            background-color: lightpink;
            color: #c5217a;
        }

        .card .card-img-custom {
            aspect-ratio:1/1;
            object-fit: contain;
        }
        @media(max-width: 767.98px){
            .card .card-img-custom{
                aspect-ratio: 1.45/1;
            }
        }
    </style>
    <h1>Catálogo</h1>
    <br />
    <asp:Button Text="Ver Listado" ID="btnVerListado" CssClass="btn btn-list" runat="server" OnClick="btnVerListado_Click" />
    <br />
    <br />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="Repeater" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%#Eval("ImagenUrl") %>" onerror="this.src='Images/default.png'" class="card-img-top card-img-custom" alt="..." />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Precio") %></p>
                            <asp:Button ID="btnVermas" runat="server" Text="Ver más" CssClass="btn btn-ok" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnVermas_Click" />
                            <asp:Button ID="Fav" runat="server" Title="Agregar a Favoritos" Text="" CommandArgument='<%#Eval("Id")%>' OnClick="btnAgregarFavorito_Click" CssClass="icono-favorito" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
