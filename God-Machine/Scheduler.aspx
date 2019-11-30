<%@ Page Title="Scheduler" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Scheduler.aspx.cs" Inherits="God_Machine.Scheduler" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div>

            <h1>
            <asp:Label ID="Greeting" runat="server" style="font-size: xx-large; color: #FFFFFF"></asp:Label>
		    </h1>
		    <table align="center" style="width: 100%; border-color: whie; background-color: #000000" border="2">
                <tr style="color: #FFFFFF">
                    <td align="center" style="width: 40">My Itinerary:</td>
                    <td align="center" class="modal-lg" style="width: 10%" rowspan="6">&nbsp;</td>
                    <td align="center" colspan="4" style="width: 40%">Search Music Festivals by:</td>
                    <td align="center" style="width: 10%" rowspan="6">&nbsp;</td>
                </tr>
                <tr style="color: #FFFFFF">
                    <td style="width: 1009px; vertical-align:top;" rowspan="4";  >
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
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td style="width: 161px; height: 20px" align="center">Festival Name:</td>
                    <td style="width: 161px; height: 20px" align="center">Year:</td>
                    <td style="width: 162px; height: 20px" align="center">State:</td>
                    <td style="width: 162px; height: 20px" align="center">Band:</td>
                </tr>
                <tr style="color: #FFFFFF">
                    <td style="width: 459px" align="center">
                        <asp:TextBox ID="FestivalBox" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 459px" align="center">
                        <asp:TextBox ID="YearBox" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 459px" align="center">
                        <asp:TextBox ID="StateBox" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 459px" align="center">
                        <asp:TextBox ID="BandBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr style="color: #FFFFFF">
                    <td colspan="4" align="center">
                        <asp:Button ID="SearchButton" runat="server" style="background-color: #000000" Text="Search" />
                    </td>
                </tr>
                <tr style="color: #FFFFFF">
                     <td style="vertical-align:top;" colspan="4" align="center" >
                        <asp:GridView ID="schedGrid" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="name" HeaderText="Festival Name" />
                                <asp:BoundField DataField="year" HeaderText="Year" />
                                <asp:BoundField DataField="city" HeaderText="City" />
                                <asp:BoundField DataField="state" HeaderText="State" />
                                 <asp:BoundField DataField="venue" HeaderText="Venue" />
                                <asp:BoundField DataField="date_begin" HeaderText="Festival Begin" />
                                <asp:BoundField DataField="date_end" HeaderText="Festival End" />
                                <asp:BoundField DataField="stage" HeaderText="Event Stage" />
                                <asp:BoundField DataField="time_begin" HeaderText="Event Begin" />
                                <asp:BoundField DataField="time_end" HeaderText="Event End" />
                                <asp:BoundField DataField="bands_name" HeaderText="Band" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="color: #FFFFFF">
                    <td style="width: 1009px" class="text-center">
                        <asp:Button ID="TextMeButton" runat="server" style="background-color: #000000" Text="Text me Schedule!" />
                    </td>
                    <td colspan="4" align="center">
                        <asp:Button ID="AddItineraryButton" runat="server" style="background-color: #000000" Text="Add to my Itenerary!" />
                    </td>
                </tr>
            </table>
		<br /><br /><br />
	   </div>
</asp:Content>