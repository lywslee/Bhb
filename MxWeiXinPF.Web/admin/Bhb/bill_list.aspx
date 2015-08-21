<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bill_list.aspx.cs" Inherits="Web.admin.Bhb.bill_list" %>

<%@ Import Namespace="Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>收料登记</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>收料登记列表</span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                    <li><a class="add" href="bill_edit.aspx?action=<%=MXEnums.ActionEnum.Add %>"><i></i>
                        <span>新增</span></a></li>
                    <li>
                        <asp:LinkButton ID="btnSave" Visible="false" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                    <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                    <li>
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除选中数据，是否继续？');"
                            OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="btn_submit" runat="server" CssClass="icon-btn submit" OnClick="btn_submit_Click"
                            OnClientClick="return CheckPostBack('btn_submit','对不起，请选中您要操作的记录');"><i></i><span>提交</span></asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="btn_print" runat="server" CssClass="icon-btn submit" OnClick="btn_print_Click"
                            OnClientClick="return CheckPostBack('btn_print','对不起，请选中您要打印的记录');"><i></i><span>打印</span></asp:LinkButton></li>
                </ul>
            </div>
            <div class="r-list">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
            </div>
        </div>
    </div>
    <!--/工具栏-->
    <!--列表-->
    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th width="3%">
                        选择
                    </th>
                    <th align="left" width="5%">
                        收料编号
                    </th>
                    <th align="left" width="5%">
                        产品
                    </th>
                    <th align="left" width="5%">
                        规格
                    </th>
                    <th align="left" width="2%">
                        单位
                    </th>
                    <th width="5%">
                        数量
                    </th>
                    <th width="5%">
                        价格
                    </th>
                    <th width="5%">
                        金额
                    </th>
                    <th align="left" width="8%">
                        客户姓名
                    </th>
                    <th align="left" width="5%">
                        移动电话
                    </th>
                    <th align="left" width="5%">
                        固定电话
                    </th>
                    <th align="left" width="5%">
                        代发银行
                    </th>
                    <th align="left" width="5%">
                        银行账号
                    </th>
                    <th align="left" width="5%">
                        户名
                    </th>
                    <th width="5%">
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                    <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <%#Eval("BNum")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <%#Eval("ProductName")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <%#Eval("ProductStandard")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <%#Eval("Unit")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden; text-align: right;">
                    <%#Eval("NetWeight")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden; text-align: right;">
                    <%#Eval("Price")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden; text-align: right;">
                    <%#Eval("Amount")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden; padding-left: 5px;">
                    <%#Eval("CustomerName")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <%#Eval("Mobile")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <%#Eval("Tel")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <%#Eval("BankName")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <%#Eval("BankAccount")%>
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden; padding-left: 5px;">
                    <%#Eval("AccountName")%>
                </td>
                <!--Action 操作-->
                <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <a href="bill_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a>
                    <%--<a href="standard_list.aspx?action=<%#MXEnums.ActionEnum.Add %>&productID=<%#Eval("id")%>">
                            放款</a>--%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <!--/列表-->
    <!--内容底部-->
    <div class="line20">
    </div>
    <div class="pagelist">
        <div class="l-btns">
            <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
        </div>
        <div id="PageContent" runat="server" class="default">
        </div>
    </div>
    <!--/内容底部-->
    </form>
</body>
</html>
