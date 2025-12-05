<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CalculatorWebApp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <style>
        .label { width: 100px; display: inline-block; }
        .input { margin-bottom: 10px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Index</h2>
            <div class="input">
                <asp:Label ID="lblA" runat="server" CssClass="label" Text="Nhập a:"></asp:Label>
                <asp:TextBox ID="txtA" runat="server" Width="50px"></asp:TextBox>
            </div>
            <div class="input">
                <asp:Label ID="lblB" runat="server" CssClass="label" Text="Nhập b:"></asp:Label>
                <asp:TextBox ID="txtB" runat="server" Width="50px"></asp:TextBox>
            </div>
            <div class="input">
                <asp:RadioButtonList ID="rblOperation" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Cộng" Value="+" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Trừ" Value="-"></asp:ListItem>
                    <asp:ListItem Text="Nhân" Value="*"></asp:ListItem>
                    <asp:ListItem Text="Chia" Value="/"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="input">
                <asp:Button ID="btnCalculate" runat="server" Text="calculate" OnClick="btnCalculate_Click" />
            </div>
        </div>
    </form>
</body>
</html>