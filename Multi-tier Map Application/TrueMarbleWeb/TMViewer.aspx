<%@ Page EnableEventValidation="false" Title="Home Page" Language="C#" AutoEventWireup="true" CodeFile="TMViewer.aspx.cs" Inherits="_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server"> <title>TrueMarble Web Viewer</title> 
    <style type="text/css">
        .auto-style1 {
            width: 65px;
        }
        .auto-style2 {
            width: 311px;
        }
        .auto-style3 {
            width: 65px;
            height: 306px;
        }
        .auto-style4 {
            width: 311px;
            height: 306px;
        }
        .auto-style5 {
            width: 42px;
        }
        .auto-style6 {
            width: 42px;
            height: 306px;
        }
        #displayZoom {
            width: 51px;
        }
        #out {
            width: 68px;
        }
        table {
            align-content:center;
        }
        
    </style>
</head>
<body>
 <form id="frmMain" runat="server">
 <div>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
     <input id="txtX" type="text"  runat="server" hidden="hidden" value="0"/><br />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
     <input id="txtY" type="text"  runat="server" hidden="hidden" value="0"/><br />Zoom&nbsp; 
     &nbsp;
     <input id="btn_in" type="button" value="zoom in" runat="server" onserverclick="btnIn_ServerClick"/>&nbsp;
     <input id="displayZoom" type="text" disabled runat="server" value="0"/>&nbsp;
     <input id="btn_out" type="button" value="zoom out" runat="server" onserverclick="btnOut_ServerClick"/><br />
     &nbsp;<br />
     </div>
 </form>
    <div id="divMsg" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <input id="btnNorth" type="button" value="^" runat="server"
        onserverclick="btnNorth_ServerClick" /></td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <input id="btnWest" type="button" value="&lt;" runat="server"
        onserverclick="btnWest_ServerClick" /></td>
                <td class="auto-style4">
     <img id="imgTile" runat="server" src="" /></td>
                <td class="auto-style6">
                    <input id="btnEast" type="button" value="&gt;" runat="server"
        onserverclick="btnEast_ServerClick" /></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <input id="btnSouth" type="button" value="v" runat="server"
        onserverclick="btnSouth_ServerClick" /></td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</body>
</html>
