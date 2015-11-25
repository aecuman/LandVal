<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataGrid.aspx.cs" Inherits="WebApplication4.DataGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
<div class="starter">
        <div class="tablecontent">
        <p>Tenure</p><asp:DropDownList ID="Tenure" runat="server" DataTextField="Tenure" CssClass="dropdown" >
           
    </asp:DropDownList>
            </div>
        
    

 <div class="tablecontent"><p>Vacant/Developed</p><asp:DropDownList ID="districtddl" runat="server" CssClass="dropdown"></asp:DropDownList></div>


<div class="tablecontent"><p>Village</p><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></div>


<div class="tablecontent"><p>Block</p><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></div>

    <div class="tablecontent"><asp:Button ID="search" Text="search" runat="server" OnClick="search_Click" /></div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="MainContent">

    
    <div class="table">
    <asp:DataGrid ID="Grid" runat="server" PageSize="5" AllowPaging="True" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="Vertical" CellSpacing="5" DataKeyField="lndID">
        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundColumn HeaderText="id" DataField="lndID" Visible="false"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Tenure" DataField="TenID" Visible="false"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Type" DataField="typID" Visible="false"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="District" DataField="dstrct"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Village" DataField="villa"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Block" DataField="blck"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Size" DataField="size"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="User" DataField="user"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Price" DataField="price" DataFormatString="{0:N0}"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Date" DataField="date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Remarks" DataField="remarks"></asp:BoundColumn>

        </Columns>
        
        <EditItemStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Height="34px" Width="80px" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    </asp:DataGrid>  
    </div>
</asp:Content>
