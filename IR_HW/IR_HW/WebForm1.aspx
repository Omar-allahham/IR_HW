<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="IR_HW.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
<title>Selecting a latitude and longitude value for a form</title>

<meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no' />
<script src='https://api.tiles.mapbox.com/mapbox.js/v1.6.2/mapbox.js' type="text/javascript"></script>
<link href='https://api.tiles.mapbox.com/mapbox.js/v1.6.2/mapbox.css' rel='stylesheet' />

<style type="text/css">
  body { margin:0; padding:0; }
  #map { position:absolute; top:6px; 
bottom:-35px; 
width:100%;
        left: 0px;
    }

    .map-overlay {
    position:absolute;
    top:5px;
    right:5px;
    padding:5px;
    background:#fff;
    font-size:14px;
        width: 213px;
    }
.map-overlay input {
    }
    .style5
    {
        font-size: x-large;
        color: #800000;
    }
    .style6
    {
        font-size: large;
    }
    </style>
</head>
<body>
<div id='map'>
    </div>
<div class='map-overlay'>
<form id="form1" runat="server">
    <label class="style5"><strong>Input your Info</strong></label><br /><br />
    <label for='latitude' ><strong>Latitude</strong></label><br />
    <input type='text' size='20' id='latitude' /><br />
    <label for='longitude'><strong>Longitude</strong></label><br />
    <input type='text' size='20' id='longitude' onclick="return longitude_onclick()" /><br />
    <strong>Disease Name</strong><br />
    <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged"></asp:TextBox>
    <br />
    <strong>Radius</strong><br />
    <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="129px">
        <asp:ListItem Value="500"></asp:ListItem>
        <asp:ListItem Value="1000"></asp:ListItem>
        <asp:ListItem Value="1500"></asp:ListItem>
        <asp:ListItem Value="2000"></asp:ListItem>
        <asp:ListItem Value="3000"></asp:ListItem>
        <asp:ListItem Value="200000"></asp:ListItem>
        <asp:ListItem Value="300000"></asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </asp:DropDownList>
    <strong>
    <br />
    <span class="style6">
    <br />
    Start Date</span><asp:Calendar ID="Calendar1" 
        runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" 
        CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
        ForeColor="#003399" Height="200px" Width="220px" 
        onselectionchanged="Calendar1_SelectionChanged">
        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
            Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
        <WeekendDayStyle BackColor="#CCCCFF" />
    </asp:Calendar>
    <br />
    <span class="style6">End Date</span></strong><asp:Calendar ID="Calendar2" 
        runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" 
        CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
        ForeColor="#003399" Height="200px" Width="220px" 
        onselectionchanged="Calendar2_SelectionChanged">
        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
            Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
        <WeekendDayStyle BackColor="#CCCCFF" />
    </asp:Calendar>
    <br />
                    <div>
                    <asp:HiddenField ID="Hidden1" runat="server" />
                    <asp:HiddenField ID="Hidden2" runat="server" />
                </div>
    <asp:Button ID="Button1" runat="server" Text="Search" Width="93px" onclick="Button1_Click" 
         />

    </form>

</div>
<script type="text/javascript">
    var radius = 200000;
    var x = false;
    var circle;

    var map = L.mapbox.map('map', 'examples.map-9ijuk24y')
    .setView([0, 0], 2);

    // get the form inputs we want to update
    var latitude = document.getElementById('latitude');
    var longitude = document.getElementById('longitude');

    var marker = L.marker([0, 0], {
        draggable: true
    }).addTo(map);

    // every time the marker is dragged, update the form
    marker.on('dragend', ondragend);

    // set the initial values in the form
    ondragend();

    //drawing circle
    function ondragend() {
        var ll = marker.getLatLng();
        latitude.value = ll.lat;
        longitude.value = ll.lng;
        if (x == true) {
            circle = L.circle([ll.lat, ll.lng], document.getElementById('<%= DropDownList1.ClientID %>').value, {
                color: 'red',
                fillColor: '#f03',
                fillOpacity: 0.5
            }).addTo(map);
        }
        else
            x = true;

        latitude.value = ll.lat;
        longitude.value = ll.lng;
        var var1 = ll.lng;
        var JavaScriptVar = ll.lat;

        document.getElementById('<%= Hidden1.ClientID %>').value = var1;
        document.getElementById('<%= Hidden2.ClientID %>').value = JavaScriptVar;
    }

    function longitude_onclick() {

    }

</script>
</body>
</html>
