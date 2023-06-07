<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Caja.aspx.cs" Inherits="Vista.Caja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container" style="height:198px">

      <asp:GridView ID="GridViewCarrito" CssClass="table table-striped-columns table-bordered table-dark mt-2" runat="server" AutoGenerateColumns="false" >
          <Columns>

              <asp:BoundField HeaderText="ID" DataField="ID" />
              <asp:BoundField HeaderText="Producto" DataField="Nombre" />
              <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
              <asp:BoundField HeaderText="Precio" DataField="Precio" />
              <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Eliminar Producto" />

          </Columns>
          

      </asp:GridView>
       

    </div>
            
</asp:Content>
