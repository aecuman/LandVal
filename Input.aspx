<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Input.aspx.cs" Inherits="WebApplication4.Input" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <script type="text/javascript">
          function validate() {
              var tenure = document.getElementById('<%=tenure.ClientID %>').value;
            var type = document.getElementById('<%=type.ClientID %>').value;
            var District = document.getElementById('<%=districtddl.ClientID %>').value;
            var village = document.getElementById('<%=villageTextbox.ClientID %>').value;
            var block = document.getElementById('<%=blockTextbox.ClientID %>').value;
            var size = document.getElementById('<%=sizeTextBox.ClientID %>').value;
            var user = document.getElementById('<%=userTextBox.ClientID %>').value;
            var price = document.getElementById('<%=priceTextbox.ClientID %>').value;


            if (tenure == "") {
                alert("Select a tenure");
                return false;
            }
            if (type == "") {
                alert("Select whether Vacant or Developed");
                return false;
            }
            if (District == "") {
                alert("Enter District");
                return false;
            }
            if (village == "") {
                alert("Enter Village");
                return false;
            }

            if (block == "") {
                alert("Enter Block");
                return false;
            }
            if (size == "") {
                alert("Enter Plot Size");
                return false;
            }
            if (user == "") {
                alert(" Enter The current Use for plot");
                return false;
            }
            if (price == "") {
                alert("Enter Price");
                return false;
            }



        }
    </script>
     
    <div class="starter">
   <div class="tablecontent"><p>Tenure</p><asp:DropDownList ID="tenure" runat="server" CssClass="dropdown" AutoPostBack="True" /></div>
   <div class="tablecontent"><p>Vacant/Developed</p><asp:DropDownList ID="type" runat="server" CssClass="dropdown" OnSelectedIndexChanged="type_SelectedIndexChanged" AutoPostBack="true"> </asp:DropDownList> </div>
        </div>
    <h2>Location details:</h2>
    <div class="starter">
       <div class="tablecontent"><p>District</p><asp:DropDownList id="districtddl" runat="server" CssClass="dropdown" AutoPostBack="true"></asp:DropDownList></div>
       <div class="tablecontent"><p>Village</p><asp:TextBox ID="villageTextbox" Text="" runat="server" /></div>
        <div class="tablecontent"><p>Block</p><asp:TextBox ID="blockTextbox" Text="" runat="server" /></div>
       
        </div>
    <h2>Land details:</h2>
    <div class="starter">
        <div class="tablecontent"><p>Plot Size</p><asp:TextBox ID="sizeTextBox" Text="" runat="server" /></div>
        <div class="tablecontent"><p>User</p><asp:TextBox ID="userTextBox" Text="" runat="server" /></div>
        </div>
    <div id="stru" style="display:none" runat="server">
    <h2>Structures</h2>
    <div class="starter">
    <div class="tablecontent"><p>Type</p><asp:TextBox ID="TypTextBox" Text="" runat="server" /></div>
    <div class="tablecontent"><p>Roof</p><asp:TextBox ID="RoofTextBox" Text="" runat="server" /></div>
   <div class="tablecontent"> <p>Windows</p><asp:TextBox ID="WindTextBox" Text="" runat="server" /></div>
   <div class="tablecontent"> <p>Wall</p><asp:TextBox ID="WallTextBox" Text="" runat="server" /></div>
    <div class="tablecontent"><p>Door</p><asp:TextBox ID="DoorTextBox" Text="" runat="server" /></div>
   <div class="tablecontent"> <p>Floor</p><asp:TextBox ID="FloorTextBox" Text="" runat="server" /></div>
   <div class="tablecontent"> <p>Area</p><asp:TextBox ID="AreaTextBox" Text="" runat="server" /></div>
       
    <h3>Accomodation</h3>
   
   <div class="tablecontent"> <p>Rooms/Space</p><asp:TextBox ID="RoomTextBox" Text="" runat="server" /></div>
    <div class="tablecontent"><p>Baths</p><asp:TextBox ID="BathTextBox" Text="" runat="server" /></div>
    <div class="tablecontent"><p>WC's</p><asp:TextBox ID="WCTextBox" Text="" runat="server" /></div>
    <div class="tablecontent"><p>Kitchen</p><asp:TextBox ID="KitchenTextBox" Text="" runat="server" /></div>
    <div class="tablecontent"><p>Laundry</p><asp:TextBox ID="LaundTextBox" Text="" runat="server" /></div>
    <div class="tablecontent"><p>Others</p><asp:TextBox ID="OtherTextBox" Text="" runat="server" /></div>
        </div>
         </div>
    <h3>Price:</h3>
    <div class="starter">
         <div class="tablecontent"><p>Price:</p><asp:TextBox ID="priceTextbox" Text="" runat="server" /></div>
          
        <div class="tablecontent"><p><label for ="date">Date :</label> </p><asp:TextBox ID="date" runat="server" TextMode="Date" /></div>   
    <div class="tablecontent"><p>Remarks</p><asp:TextBox ID="remarksTextBox" Text="" runat="server" /></div>
        </div>
    <asp:Button ID="Insertbtn" Text="Submit" runat="server" OnClientClick="return validate();" OnClick="Insertbtn_Click" />
</asp:Content>


