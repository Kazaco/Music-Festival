<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestScheduler.aspx.cs" Inherits="God_Machine.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            color: #FF66CC;
        }
    </style>
</head>
<body bgcolor="black">
    <form id="form1" runat="server">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style3" NavigateUrl="Default.aspx">Return to Main</asp:HyperLink>
        <br />
        <br />
        <div>
            <asp:Label ID="Greeting" runat="server" style="font-size: xx-large; color: #FFFFFF"></asp:Label>
            <br />
        </div>
        <table align="center" border="2" style="width: 100%; border-color: white; background-color: #000000">
            <tr style="color: #FFFFFF">
                <td align="center" style="width: 40">My Itinerary:</td>
                <td align="center" class="modal-lg" rowspan="6" style="width: 10%">&nbsp;</td>
                <td align="center" colspan="4" style="width: 40%">Search Music Festivals by:</td>
                <td align="center" rowspan="6" style="width: 10%">&nbsp;</td>
            </tr>
            <tr style="color: #FFFFFF">
                <td ;="" rowspan="4" style="width: 1009px; vertical-align:top;">
                    <asp:GridView ID="myScheduleGrid" runat="server" AutoGenerateColumns="false" ValidateRequestMode="Enabled">
                        <Columns>
                            <asp:BoundField DataField="user_email" HeaderText="Account" />
                            <asp:BoundField DataField="festival_name" HeaderText="Festival Name" />
                            <asp:BoundField DataField="festival_year" HeaderText="Year" />
                            <asp:BoundField DataField="events_stage" HeaderText="Stage" />
                            <asp:BoundField DataField="events_time_begin" HeaderText="Time Begin" />
                            <asp:BoundField DataField="events_time_end" HeaderText="Time End" />
                            <asp:BoundField DataField="events_date" HeaderText="Date" />
                            <asp:BoundField DataField="bands_name" HeaderText="Band" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="RemoveEvent" runat="server" CausesValidation="false" OnClick="RemoveEvent_Click" style="background-color: #000000" Text="Remove" ForeColor="White" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td align="center" style="width: 161px; height: 20px">Festival Name:</td>
                <td align="center" style="width: 161px; height: 20px">Year:</td>
                <td align="center" style="width: 162px; height: 20px">State:</td>
                <td align="center" style="width: 162px; height: 20px">Band:</td>
            </tr>
            <tr style="color: #FFFFFF">
                <td align="center" style="width: 459px">
                    <asp:TextBox ID="FestBox" runat="server" EnableViewState="true" style="background-color: #E46CA8" Text=""></asp:TextBox>
                </td>
                <td align="center" style="width: 459px">
                    <asp:TextBox ID="YearBox" runat="server" autopostback="false" EnableViewState="true" style="background-color: #E46CA8" Text=""></asp:TextBox>
                </td>
                <td align="center" style="width: 459px">
                    <asp:TextBox ID="StateBox" runat="server" autopostback="false" EnableViewState="true" style="background-color: #E46CA8" Text=""></asp:TextBox>
                </td>
                <td align="center" style="width: 459px">
                    <asp:TextBox ID="BandBox" runat="server" autopostback="false" EnableViewState="true" style="background-color: #E46CA8" Text="" ViewStateMode="Enabled"></asp:TextBox>
                </td>
            </tr>
            <tr style="color: #FFFFFF">
                <td align="center" colspan="4">
                    <asp:Button ID="SearchButton" runat="server" CausesValidation="false" EnableViewState="true" OnClick="SearchButton_Click" style="background-color: #000000" Text="Search" ForeColor="White" />
                </td>
            </tr>
            <tr style="color: #FFFFFF">
                <td align="center" colspan="4" style="vertical-align:top;">
                    <asp:GridView ID="schedGrid" runat="server" AutoGenerateColumns="false" ForeColor="White">
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Festival Name" />
                            <asp:BoundField DataField="year" HeaderText="Year" />
                            <asp:BoundField DataField="city" HeaderText="City" />
                            <asp:BoundField DataField="state" HeaderText="State" />
                            <asp:BoundField DataField="venue" HeaderText="Venue" />
                            <asp:BoundField DataField="date_begin" HeaderText="Festival Begin" />
                            <asp:BoundField DataField="date_end" HeaderText="Festival End" />
                            <asp:BoundField DataField="stage" HeaderText="Event Stage" />
                            <asp:BoundField DataField="date" HeaderText="Date" />
                            <asp:BoundField DataField="time_begin" HeaderText="Event Begin" />
                            <asp:BoundField DataField="time_end" HeaderText="Event End" />
                            <asp:BoundField DataField="bands_name" HeaderText="Band" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="AddEventButton" runat="server" CausesValidation="false" OnClick="AddEvent" style="background-color: #000000" Text="Add" ForeColor="White" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr style="color: #FFFFFF">
                <td class="auto-style2" style="width: 1009px">
                    <asp:Button ID="TextMeButton" runat="server" CausesValidation="false" CssClass="auto-style1" style="background-color: #000000" Text="Text me Schedule!" UseSubmitBehavior="false" />
                </td>
                <td align="center" colspan="4"></td>
            </tr>
        </table>
    </form>
</body>
</html>
