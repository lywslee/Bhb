<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="Web.admin.Bhb.Customer" %>

<%@ Import Namespace="Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%=PageName%></title>
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
        </i><span>
            <%=PageName%></span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                    <li><a class="add" href="<%=EditUrl %>?action=<%=MXEnums.ActionEnum.Add %>"><i></i><span>
                        新增</span></a></li>
                  <%--  <li>
                        <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>--%>
                    <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                    <li>
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');"
                            OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                </ul>
            </div>
             <div class="r-list">
     <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
    </div>
        </div>
    </div>
    <!--/工具栏-->
    <!--列表-->
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th width="60">
                        选择
                    </th>
                    <%--  <th align="left" width="10%">区域ID</th>--%>
                    <th align="left">
                        客户姓名
                    </th>
                    <th align="left">
                        客户类型
                    </th>
                    <th align="left">
                        所在区域
                    </th>
                    <th align="left">
                        身份证号
                    </th>
                    <th align="left">
                        固定电话
                    </th>
                    <th align="left">
                        移动电话
                    </th>
                   <%-- <th align="left">
                        住址
                    </th>--%>
                    <th align="left">
                        代发银行
                    </th>
                    <th align="left">
                        银行账号
                    </th>
                    <th align="left">
                        户名
                    </th>
                    <th align="left">
                        添加人
                    </th>
                    <th align="left">
                        添加日期
                    </th>
                   <%-- <th align="left" width="65">
                        排序
                    </th>--%>
                    <th >
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td  align="center">
                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                    <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />
                </td>
                <td class="listTdRow">
                    <a href='<%=EditUrl %>?action=<%=MXEnums.ActionEnum.Edit %>&id=<%#Eval("ID") %>'>
                        <%#Eval("CName")%></a>
                </td>
                <td class="listTdRow">
                    <%#Eval("dName")%>
                </td>
                <td class="listTdRow">
                    <%#Eval("OneRName")%> <%#Eval("TwoRName")%>
                </td>
                <td class="listTdRow">
                    <%#Eval("CardNumber")%>
                </td>
                <td class="listTdRow">
                    <%#Eval("Tel")%>
                </td>
                <td class="listTdRow">
                    <%#Eval("Mobile")%>
                </td>
                <%--<td class="listTdRow">
                    <%#Eval("Address")%>
                </td>--%>
                <td class="listTdRow">
                    <%#Eval("BankNameDic")%>
                </td>
                <td class="listTdRow">
                    <%#Eval("BankAccount")%>
                </td>
                <td class="listTdRow">
                    <%#Eval("AcountName")%>
                </td>
                <td class="listTdRow">
                    <%#Eval("AddPerson")%>
                </td>
                <td class="listTdRow">
                    <%#Utils.FormatPageTimeDay(Eval("AddTime").ToString())%>
                </td>
               <%-- <td>
                    <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("SortNum")%>' CssClass="sort"
                        onkeydown="return checkNumber(event);" />
                </td>--%>
                <td align="center" class="listRow">
                    <a href='<%=EditUrl %>?action=<%=MXEnums.ActionEnum.Edit %>&id=<%#Eval("ID") %>'>修改</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\">暂无记录</td></tr>" : ""%>
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
