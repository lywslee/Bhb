<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="Web.admin.Bhb.Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <object id="factory" style="display: none" classid="clsid:1663ed61-23eb-11d2-b92f-008048fdd814"
        codebase="smsx.cab" viewastext>
    </object>
    <style type="text/css">
        @media print
        {
            .noprint
            {
                display: none;
            }
        }
    </style>
    <script type="text/javascript">
        function PrintTable() {
            document.getElementById("div_printing").style.visibility = "hidden";
            doprint();
            window.close();
        }

        function doprint() {
            factory.printing.printer = "XP-58"
            factory.printing.header = "";
            factory.printing.footer = "";
            factory.printing.portrait = true; //portrait是指打印方向，设置为true就是纵向，false就是横向。
            factory.printing.leftMargin = 20
            factory.printing.topMargin = 10
            factory.printing.rightMargin = 10
            factory.printing.bottomMargin = 2
            factory.DoPrint(false); //设置为false，直接打印 
        }  
    </script>
    <style type="text/css">
        .fontSize
        {
            font-size: 12px;
            width: 90%;
        }
        .fontSize1
        {
            font-size: 1px;
            width: 90%;
        }
        .tdLeft
        {
            text-align: left;
        }
        .tdRight
        {
            text-align: right;
        }
        .tdCenter
        {
            text-align: center;
        }
        td
        {
            text-align: center;
            font-size: 20px;
        }
        .tabp
        {
            border-left-color: #000000;
            border-bottom-color: #000000;
            border-top-color: #000000;
            border-collapse: collapse;
            border-right-color: #000000;
        }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <!--打印-->
    <div id="div_print" style="width: 100%; margin-top: 5px; text-align: center;">
        <%-- <asp:Literal ID="lbl_content" runat="server">
      
        </asp:Literal>--%>
        <div style="text-align: center; font-size: 26px; font-weight: bold; height: 40px;
            width: 854px">
            <asp:Label ID="lbl_top" runat="server" Text="">山东凯华木业有限公司收料单</asp:Label></div>
        <div style="text-align: right; font-size: 20px; height: 25px; width: 854px">
            编号:<asp:Label ID="lbl_BNum" runat="server" Text=""><%=ModelInfo.BNum%></asp:Label></div>
        <table class="tabp" bordercolor="#000000" style="width: 854px; height: 310px;" border="1"
            cellspacing="0" cellpadding="0">
            <tr>
                <td style="width: 16%">
                    客户名称
                </td>
                <td style="width: 16%">
                    <%=ModelInfo.CustomerName%>
                </td>
                <td style="width: 16%">
                    固定电话
                </td>
                <td style="width: 16%">
                    <%=ModelInfo.Tel%>
                </td>
                <td style="width: 16%">
                    移动电话
                </td>
                <td style="width: 16%">
                    <%=ModelInfo.Mobile%>
                </td>
            </tr>
            <tr>
                <td>
                    银行账号
                </td>
                <td colspan="5" style="text-align: left;">
                    <%=ModelInfo.BankAccount%>
                    /
                    <%=ModelInfo.BankName%>
                    /
                    <%=ModelInfo.AccountName%>
                </td>
            </tr>
            <tr>
                <td>
                    产品名称
                </td>
                <td>
                    <%=ModelInfo.ProductName%>
                </td>
                <td>
                    产品规格
                </td>
                <td>
                    <%=ModelInfo.ProductStandard%>
                </td>
                <td>
                    价格
                </td>
                <td>
                    <%=ModelInfo.Price%>(元/吨)
                </td>
            </tr>
            <tr>
                <td>
                    毛重
                </td>
                <td>
                    <%=ModelInfo.GrossWeight%>
                    吨
                </td>
                <td>
                    皮重
                </td>
                <td>
                    <%=ModelInfo.Tare%>
                    吨
                </td>
                <td>
                    净重
                </td>
                <td>
                    <%=ModelInfo.NetWeight%>
                    吨
                </td>
            </tr>
            <tr>
                <td>
                    金额大写
                </td>
                <td colspan="3" style="text-align: left;">
                    <%=je%>
                </td>
                <td>
                    金额
                </td>
                <td>
                    <%= String.Format("{0:N}", ModelInfo.Amount)%>
                </td>
            </tr>
            <tr>
                <td >
                    备注
                </td>
                <td colspan="3" class="tdLeft">
                    <%=ModelInfo.Remark%>
                </td>
                <td>
                    存放库房
                </td>
                <td>
                    <%=ModelInfo.WareHouse%>
                </td>
            </tr>
            <tr>
                <td style="font-size: 24px; font-weight: bold;">
                    声<br />
                    明
                </td>
                <td colspan="5" style="text-align: left">
                    1、凡进入本厂的所有大料、刨花、细沫，如发现有掺入沙、石及水等弄虚作假行为，经查实，对其作出不预付款和扣押车辆等决定。望自律！<br />
                    2、收料单请妥善保管，如有损坏不予付款！
                </td>
            </tr>
        </table>
        <table style="width: 854px; height: 30px;" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="tdLeft">
                    打印时间:<asp:Label ID="lbl_printTime" runat="server" Text=""><%=DateTime.Now.ToString("yyyy-MM-dd HH:mm") %></asp:Label>
                </td>
                <td class="tdCenter">
                    制单人:<asp:Label ID="lbl_AddPerson" runat="server" Text=""> <%=ModelInfo.AddPerson%></asp:Label>
                </td>
                <td class="tdRight">
                    电话:<asp:Label ID="lbl_Mobile" runat="server" Text="">18653916070</asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_printing" style="position: absolute; top: 0px; left: 0px; background-color: #FFFFFF;
        font-size: 16px; font-weight: bold; font-family: 微软雅黑; padding-top: 30px; text-align: center;
        width: 200px; height: 100px;">
        正在打印。。。
    </div>
    </form>
</body>
</html>
