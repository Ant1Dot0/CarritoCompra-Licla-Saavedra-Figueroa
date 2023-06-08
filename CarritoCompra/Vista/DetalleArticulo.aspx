<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Vista.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="text-center">
                    <div class="card-body">
                        <h2><%=articulo.Codigo%> - <%=articulo.Nombre%></h2>
                        <h4><%=articulo.Descripcion %></h4>
                        <h5>Marca: <%=articulo.Marca %></h5>
                        <h5>Categoria: <%=articulo.Categoria %></h5>
                        <h5 class="precio">$<%=articulo.Precio%></h5>
                        <asp:LinkButton runat="server" CssClass="btn btn-primary" Text="Agregar al carrito" OnClick="btnAgregar_Click" />
                        <asp:LinkButton runat="server" CssClass="btn btn-secondary" Text="Agregar e ir a pagar" OnClick="btnPagar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <%foreach (var x in ListaImagenes)
                {%>
            <div class="col-md-4">
                <img src="<%=x.ImagenUrl %>" onerror="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" style="width: 400px; height: 400px; object-fit: cover;" />
            </div>
            <%} %>
        </div>
    </div>
</asp:Content>
