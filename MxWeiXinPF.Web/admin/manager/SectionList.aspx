<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SectionList.aspx.cs" Inherits="Web.admin.manager.SectionList" %>

<%@ Import namespace="Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>部门管理</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>部门管理</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="SectionEdit.aspx?action=<%=MXEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
        <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本部门及下属子部门，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">选择</th>
    <th align="left" width="10%">部门ID</th>
  <%--  <th align="left" width="12%">部门编号</th>--%>
    <th align="left">部门名称</th>
<%--    <th align="left">部门负责人</th>--%>
 <%--   <th width="8%">默认</th>--%>
    <th align="left" width="65">排序</th>
    <th width="12%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server"  style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />
      <asp:HiddenField ID="hidLayer" Value='<%#Eval("LevelNum") %>' runat="server" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;"><%#Eval("Id")%></td>
   <%-- <td style="white-space:nowrap;word-break:break-all;overflow:hidden;"><%#Eval("Num")%></td>--%>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
      <a href="SectionEdit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("Name")%></a>
    </td>
<%--    <td align="center"><%#Eval("real_name")%></td>--%>
    <td><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("Sort")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <a href="SectionEdit.aspx?action=<%#MXEnums.ActionEnum.Add %>&id=<%#Eval("id")%>">添加子级</a>
      <a href="SectionEdit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a>
    </td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->
</form>
</body>
</html>
