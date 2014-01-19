<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PEW.Web.Controllers.Models.BaseViewData>" %>
<%@ Import Namespace="PEW.Web.Controllers.Models" %>
<%if(Model.HasMessage()){ %>

	<%if(Model.MessageType == BaseViewData.ViewDataMessageType.Error) { %> 
		<div class="ui-widget ui-corner-all ui-state-error">
			<span class="ui-icon ui-icon-alert" style="float: left; margin-right: .3em;"></span>
			<span style="padding-bottom:15px;"><%=Model.MessageText%></span>
		</div> 
	<%}%>

	<%if(Model.MessageType == BaseViewData.ViewDataMessageType.Information) { %> 
		<div class="ui-widget ui-corner-all ui-state-highlight">
			<span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
			<span style="padding-bottom:15px;"><%=Model.MessageText%></span>
		</div> 
	<%}%>

<%} %>


