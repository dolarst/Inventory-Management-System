<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductEntryUI.aspx.cs" Inherits="InventoryApp.UI.ProductEntryUI" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 156px;
        }
        .auto-style3 {
            width: 78px;
        }
        #saveButton {
            padding-top: 6px;
        }
        .position {
            margin-top: 20px;
           
        }
        #body {
            background: whitesmoke;
        }
        #message {
            background: rgb(78, 82, 71);
            margin-top: 10px;
            padding-left: 50px;
            font-family: sans-serif;
            color: white;
            font-weight: bold;
        }
    </style>
    <script src="../Scripts/jquery-3.1.0.min.js"></script>
    <link rel="stylesheet" href="../Content/bootstrap.min.css" type="text/css" media="all"/> 
    <script src="../Scripts/bootstrap.min.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
</head>
<body id="body">
    <form id="form1" runat="server">
       
<div class = "page-header">
   
   <h1 style="color:green" align="center">
      Invertory Mangement
      <small>Product Entry</small>
       <asp:Button ID="showAllButton" CssClass="btn btn-info" runat="server" OnClick="showAllButton_Click" Text="Show All" />
   </h1>

   
</div>
        
        <div class="container col-md-12 col-lg-12 col-sm-12">
          <div class="form-group col-md-7 col-sm-5 container row">

                <label class="auto-style2">Bar Code&nbsp;&nbsp; </label>  
                 <asp:TextBox ID="barcodeBox" CssClass ="form-control" runat="server" Width="268px"></asp:TextBox>
                
                <label class="auto-style2">Name</label>
                 <asp:TextBox CssClass ="form-control" ID="nameEntryBox" runat="server" Width="264px"></asp:TextBox>
                
           
                <label class="auto-style2">Quantity</label>
                <asp:TextBox CssClass="form-control" ID="quantityEntryBox" runat="server" Width="265px"></asp:TextBox>
              
            
                <label class="auto-style2">Unit Price</label>
                <asp:TextBox CssClass="form-control" ID="unitPriceEntryBox" runat="server" Width="267px"></asp:TextBox>
             
                
                <label class="auto-style2">Entry Date </label>
                <asp:TextBox CssClass="form-control" ID="datePikerBox" runat="server" Width="267px"></asp:TextBox>
          
               <div  id ="saveButton">
                 <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-success" OnClick="SaveButton_Click" Text="Save" />
               </div>
                   
               <div id="message"> <asp:Label ID="messageLabel" runat="server"></asp:Label> </div>
               
          </div>    
              
             
               
                
               
                    
                   
               
       
      
                  
            
                 <label for="searchBox"> Search (By Date ) </label>
                 <div class="col-md-5 col-sm-7" id ="searchBox">
                  
                    <div class="col-md-3 col-sm-5">    
                        <asp:TextBox ID="fromDateBox" runat="server"></asp:TextBox>
                    </div><!-- end of fromdatebox div -->
                                
                    <div class="col-md-3 col-sm-5">
                         <asp:TextBox ID="toDateBox" runat="server"></asp:TextBox>
                    </div> <!-- end of toDateBox div -->
                   
                      <div class="col-sm-2">
                          <asp:Button ID="showButoon" runat="server" CssClass="btn btn-info" OnClick="showButoon_Click" Text="Show" />
                     </div>
                     
                     
                       <!-- grid view start -->
          <div class="col-sm-12 position">
            <asp:GridView ID="productGridView" runat="server" AutoGenerateColumns="False" Width="364px">
             <Columns>
                <asp:TemplateField HeaderText="BarCode">
                 <ItemTemplate>
                     <asp:Label runat="server" ID="barcodeLabel" Text='<%#Eval("BarCode")%>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
                 
                 
                  <asp:TemplateField HeaderText="Name">
                 <ItemTemplate>
                     <asp:Label runat="server" ID="nameLabel" Text='<%#Eval("Name")%>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
                 
             <asp:TemplateField HeaderText="Quantity">
                 <ItemTemplate>
                     <asp:Label runat="server"  ID="quantityLabel" Text='<%#string.Format("{0}",Eval("Quantity"))%>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
                 
                  <asp:TemplateField HeaderText="Unit Price">
                 <ItemTemplate>
                     <asp:Label runat="server" ID="unitPriceLabel" Text='<%#string.Format("{0}",Eval("UnitPrice"))%>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
                 
                  <asp:TemplateField HeaderText="Total">
                 <ItemTemplate>
                     <asp:Label runat="server" ID="totalLabel" Text='<%#Eval("Total")%>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
            

            </Columns>
                <HeaderStyle BackColor="#66FF99" />
            </asp:GridView>
      </div>
                     
                     

                 </div> 
            
        
            
            
            
            
                         
        </div>
        

    </form>
     <script>
         $(function () {
             $("#datePikerBox").datepicker();
             $("#fromDateBox").datepicker();
             $("#toDateBox").datepicker();
         });
  </script>
</body>
</html>
