<%@ Page Title="Admin" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.cs" Inherits="God_Machine.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<button type="button" class="btn btn-primary" style="margin-top: 30px" data-toggle="modal" data-target="#newFestival">New Festival</button>
   
    <div class="modal fade" id="newFestival" tabindex="-1" role="dialog" aria-hidden="true"> 
        <div class="modal-dialog" role="document">
            <div class="modal-content" style="border-width:3px; border-color:#ff69b4; background-color:black; color:#ff69b4; font-family: 'Times New Roman'"; font-size: 20px;>
                <div class="modal-header " style="background-color:#ff69b4; color:black; border:none;">
                    <h2 class="modal-title center" style="text-align:center; font-weight: bold" id="exampleTitle">Create a New Festival!</h2>
                </div>
                <div class="modal-body">
					
                    <b>Festival Name</b>
					<br />
                    <input type="text" class="bop" id="festivalName"  runat="server" />
                    <br /><br />
                    <b>Address</b>
					<br />
                    <input type="text" class="bop" id="addy"  runat="server"/>
                    <br /><br />
					<b>City</b>
					<br />
                    <input type="text" class="bop" id="fest_city"  runat="server"/>
                    <br /><br />
					<b>State</b>
					<br />
                    <input type="text" class="bop" id="fest_state"  runat="server"/>
                    <br /><br />
                    <b>Start Date</b>
					<br />
                    <input type="date" class="bop" id="startDate" runat="server"/>
                    <br /><br />
					<b>End Date</b>
					<br />
                    <input type="date" class="bop" id="endDate" runat="server"/>
					<br /><br />
					<b>Add Poster</b>
                    <input type="file" class="bop" value="Choose Map" name="map" accept=".jpg, .png"/>
					<br />
                    <b>Add Map</b>
                    <input type="file" class="bop" value="Choose Map" name="map" accept=".jpg, .png"/>
					<br />
                    <b>Add Set Times</b>
                    <input type="file" class="bop" value="Choose Festival" name="poster" accept=".xlsx" />
                </div>
                <div class="modal-footer" style="background-color:#ff69b4; border:none">
                    <button type="button" class="btn btn-secondary pob"  data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-primary pob" onclick="NewTourneySubmit_Click" runat="server" data-dismiss="modal">Submit</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>