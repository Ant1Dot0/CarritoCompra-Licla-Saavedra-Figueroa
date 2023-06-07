<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carritoo.aspx.cs" Inherits="Vista.Ca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="height: 198px">

        <%if (total > 0)
            { %>
        <asp:GridView ID="GridViewCarrito" DataKeyNames="ID" 
            CssClass="table table-striped-columns table-bordered table-dark mt-2" 
            runat="server" 
            AutoGenerateColumns="false"
            OnSelectedIndexChanged="GridViewCarrito_SelectedIndexChanged">
            <Columns>

                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Producto" DataField="Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Eliminar Producto" />

            </Columns>


        </asp:GridView>

        <div class="row">
            <div class="col-sm-12">
                <div class="card text-right">
                    <div class="card-body">
                        <h5 class="card-title">Total a pagar: <%=total%> </h5>
                        <asp:LinkButton runat="server" CssClass="btn btn-secondary" OnClick ="btnVaciar_Click" Text="VaciarCarrito"/>
                        <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick ="btnPagar_Click" Text="Pagar"/>
                    </div>
                </div>
            </div>
        </div>
        <%} %>
        <%else
            { %>

        <div class="row mt-2">
            <div class="col-sm-12">
                <div class="card text-center">
                    <div class="card-body">
                        <h5 class="card-title">Aun no has añadido ningún artículo</h5>
                        <p class="card-text">Revisa la tienda para seleccionar nuevos artículos</p>
                        <a href="Default.aspx" class="btn btn-primary">Ir a ShopArt</a>
                    </div>
                </div>
            </div>
        </div>

        <%} %>
    </div>
</asp:Content>
