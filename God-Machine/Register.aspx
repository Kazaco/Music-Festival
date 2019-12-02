<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="God_Machine.Register" %>
      
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #000000;
            text-align: left;
        }
        .auto-style2 {
            font-size: xx-large;
            background-color: #000000;
            color: #FFFFFF;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            width: 153px;
            text-align: right;
            color: #FFFFFF;
        }
        .auto-style5 {
            width: 161px;
        }
        .auto-style6 {
            width: 153px;
            text-align: right;
            height: 26px;
            color: #FFFFFF;
        }
        .auto-style7 {
            width: 161px;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
            width: 68px;
            color: #FFFFFF;
        }
        .auto-style9 {
            width: 68px;
        }
        .auto-style10 {
            width: 68px;
            text-align: center;
        }
        .auto-style11 {
            color: #FFFFFF;
        }
        .auto-style12 {
            width: 68px;
            color: #FFFFFF;
        }
        .auto-style13 {
            width: 68px;
            text-align: center;
            color: #FFFFFF;
        }
        .auto-style14 {
            color: #FFFFFF;
            background-color: #000000;
        }
    </style>
</head>
<body bgcolor="black">
    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style3" NavigateUrl="Default.aspx">Return to Main</asp:HyperLink>
    <form id="form1" runat="server">
        <div class="auto-style1" style="height: 46px">
            <span class="auto-style2">Create/Modify an Account</span></div>
        <table class="auto-style3">
            <tr>
                <td class="auto-style6">Name</td>
                <td class="auto-style7">
                    <asp:TextBox ID="hfname" runat="server" ForeColor="Black" OnTextChanged="hfname_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">E-mail</td>
                <td class="auto-style5">
                    <asp:TextBox ID="hfemail" runat="server" ForeColor="Black"></asp:TextBox>
                </td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Password</td>
                <td class="auto-style5">
                    <asp:TextBox ID="hfpassword" runat="server" ForeColor="Black"></asp:TextBox>
                </td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">City</td>
                <td class="auto-style5">
                    <asp:TextBox ID="hfcity" runat="server" ForeColor="Black"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="Button1" runat="server" OnClick="Button_Submit" style="height: 26px" Text="Submit" CssClass="auto-style14" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">State</td>
                <td class="auto-style5">
                    <asp:TextBox ID="hfstate" runat="server" ForeColor="Black"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="Button2" runat="server" OnClick="Button_Update" style="height: 26px" Text="Update" CssClass="auto-style14" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Phone Number</td>
                <td class="auto-style5">
                    <asp:TextBox ID="hfphone" runat="server" ForeColor="Black"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="Button3" runat="server" OnClick="Button_Delete" style="height: 26px" Text="Delete" CssClass="auto-style14" />
                </td>
                <td>
                    &nbsp;</td>
                  <td>
                      &nbsp;</td>
            </tr>
        </table>
        <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="userGrid" runat="server" AutoGenerateColumns="false" CssClass="auto-style11">
            <Columns>
                 <asp:BoundField DataField="email" HeaderText="KEY: E-mail" />
                 <asp:BoundField DataField="name" HeaderText="Name" />
                 <asp:BoundField DataField="password" HeaderText="Password" />
                 <asp:BoundField DataField="city" HeaderText="City" />
                 <asp:BoundField DataField="state" HeaderText="State" />
                 <asp:BoundField DataField="phone" HeaderText="Phone" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
 
