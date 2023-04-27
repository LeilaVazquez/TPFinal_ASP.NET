<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Vazquez.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .banner {
            background-image: url(../Images/tienda.jpg);
            background-attachment: fixed;
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
            margin: 40px;
        }
        .btn-def {
            background-color: palevioletred;
            color: white;
            margin: 6px;
           
            margin-left: 60px;
            font-size: 1.5rem;
        }

        .py-5 {
            padding-top: 5rem !important;
            padding-bottom: 24rem !important;
        }
    </style>
    <div class="row py-5 banner">
        <div class="col">
            <a href="Catalogo.aspx" class="btn btn-def">Catálogo</a>
       
        </div>  
        <div class="col-sm-12 col-md-12 col-lg-12 banner">
        </div>
    </div>
    <hr />
    <footer >
        <div class="container d-flex justify-content-center align-items-center">
            <p> Sitio creado por  </p> 
            <p> <img src="Images/github.svg" alt="" /></p>
            <p> /LeilaVazquez</p>    
        </div>
    </footer>
</asp:Content>
