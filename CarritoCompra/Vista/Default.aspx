<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vista._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container ">
        <div class="row mt-2" style="display: flex; flex-direction: row; justify-content: space-between;">
            <%foreach (var x in listaA)
                {%>
            <div class="card mt-2" style="width: 18rem;">
                <img src="<%=x.ImagenURL%>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%=x.Nombre%></h5>
                    <p class="card-text"><%=x.Descripcion%></p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
            <%}%>
        </div>
        </div>
</asp:Content>
