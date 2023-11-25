<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="p10.WebForm2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Gewicht (in kg)</td>
                <td>
                    <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtWeight" ErrorMessage="Pflichtfeld" ForeColor="Red" runat="server" Display="Dynamic"/>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtWeight" ErrorMessage="Das Gewicht muss zwischen 20 und 300 kg liegen" ForeColor="Red" MinimumValue="20" MaximumValue="300" Type="Double"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td>Grösse (in m)</td>
                <td>
                    <asp:TextBox ID="txtHeight" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtHeight" ErrorMessage="Pflichtfeld" ForeColor="Red" runat="server" Display="Dynamic"/>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtHeight" ErrorMessage="Die Grösse muss zwischen 1.4 und 2.2 m liegen" ForeColor="Red" MinimumValue="1,4" MaximumValue="2,2" Type="Double"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td>BMI:</td>
                <td>
                    <asp:TextBox ID="txtBMI" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <p>
            <asp:Button ID="btnCalc" runat="server" OnClick="btnCalc_Click" Style="width: 100px" Text="berechne" />
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Style="width: 100px" Text="reset" />
        </p>
    </form>
</body>
</html>