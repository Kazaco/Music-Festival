<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="God_Machine.WebForm1" %>

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
            background-color: #FFFFFF;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            width: 153px;
            text-align: right;
        }
        .auto-style5 {
            width: 161px;
        }
        .auto-style6 {
            width: 153px;
            text-align: right;
            height: 26px;
        }
        .auto-style7 {
            width: 161px;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1" style="height: 46px">
            <span class="auto-style2">Create an Account</span></div>
        <table class="auto-style3">
            <tr>
                <td class="auto-style6">Username</td>
                <td class="auto-style7">
                    <asp:TextBox ID="hfname" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style4">E-mail</td>
                <td class="auto-style5">
                    <asp:TextBox ID="hfemail" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Password</td>
                <td class="auto-style5">
                    <asp:TextBox ID="hfpassword" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">City</td>
                <td class="auto-style5">
                    <asp:TextBox ID="hfcity" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">State</td>
                <td class="auto-style5">
                    <asp:TextBox ID="hfstate" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Phone Number</td>
                <td class="auto-style5">
                    <asp:TextBox ID="hfphone" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 26px" Text="Submit" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
