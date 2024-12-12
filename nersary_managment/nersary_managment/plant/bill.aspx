<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bill.aspx.cs" Inherits="Movie.plant.bill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
        .style2
        {
            text-align: center;
        }
        </style>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.22/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
    <script type="text/javascript">
        function Export() {
            html2canvas(document.getElementById('bill'), {
                onrendered: function (canvas) {
                    var data = canvas.toDataURL();
                    var docDefinition = {
                        content: [{
                            image: data,
                            width: 500
                        }]
                    };
                    pdfMake.createPdf(docDefinition).download("Table.pdf");
                }
            });
        }
    </script>
    </head>
<body>
    <table width=500px align=center frame="box" id="bill">
        <tr>
            <td colspan="5" align=center>
                <img align="middle" height="100px" width="120px" src="lep.jpg" /> </tr>
        <tr>
            <td class="style2" colspan="5">
                <strong>INVOICE</strong></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <strong>Bill To :<br />
                Bill No : 1&nbsp;&nbsp;&nbsp;&nbsp; Bill Date : 27-04-2023</strong><br />
                Adesh Jadhav 
                <br />
                Rankala Tower kolhapur 416012<br />
                phone : 976677030<br />
                Email : Adesh@gmail.com</td>
            <td class="style1" colspan="2">
                <strong>Name<br />
                </strong>1023 Lakshtirth vasahat
                <br />
                near rankala kolhapur
                <br />
                phone:0231-41623<br />
                Email:@gmail.com</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td bgcolor="#00CC00">
                Sr. no.</td>
            <td bgcolor="#00CC00">
                Plant Name</td>
            <td bgcolor="#00CC00">
                Quantity</td>
            <td bgcolor="#00CC00">
                Unit Prise</td>
            <td bgcolor="#00CC00">
                Amount</td>
        </tr>
        <tr>
            <td style="text-align: center">
                1</td>
            <td style="text-align: center">
                Yellow Rose </td>
            <td style="text-align: center">
                5</td>
            <td style="text-align: center">
                50</td>
            <td style="text-align: center">
                250</td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" rowspan="2" style="text-align: center">
                Thank You For Your Order....</td>
            <td>
                GST (5%)</td>
            <td>
                13</td>
        </tr>
        <tr>
            <td>
                Total Amount</td>
            <td>
                263</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <img height="25px" width="25px" src="download%20(1).png" /></td>
            <td colspan="2">
                1023 Lakshtirth vasahat
                <br />
                near rankala kolhapur</td>
            <td colspan="2" rowspan="2" style="text-align: center">
                <img  height="60px" width="160px"  src="images.png" /></td>
        </tr>
        <tr>
            <td style="text-align: center">
                <img  height="25px" width="25px" 
                    src="communication-email-icon-plex-iconset-cornmanthe-38.png" 
                   /></td>
            <td colspan="2">
                @gmail.com</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <img  height="25px" width="25px" src="download.png" /></td>
            <td colspan="2">
                0231-41623</td>
            <td colspan="2" style="text-align: center">
                Signature</td>
        </tr>
        <tr>
            <td colspan="5" style="text-align: center">
                <br />
            </td>
        </tr>
        </table>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClientClick="Export()" Text="Print" />
    
    </div>
    </form>
</body>
</html>
