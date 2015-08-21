<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dic.aspx.cs" Inherits="Web.admin.Bhb.Dic" %>

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
    <script type="text/javascript">
        function OpenDialog(name, action, id) {
            $.dialog({
                id: 'selectIco',
                fixed: true,
                lock: true,
                max: false,
                min: false,
                title: name,
                content: "url:/admin/Bhb/<%=EditUrl %>?action=" + action + "&id=" + id,
                height: 280,
                width: 500
            });

        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
        <asp:PlaceHolder ID="phList" runat="server"><i class="arrow"></i><span>
            <%=PageName%></span></asp:PlaceHolder>
        <asp:PlaceHolder ID="phDetail" runat="server" Visible="false"><a href="<%=ThisUrl %>">
            <i class="arrow"></i><span>
                <%=PageName%></span></a> <i class="arrow"></i><span>
                    <asp:Literal ID="ltlAreaName" runat="server"></asp:Literal></span> </asp:PlaceHolder>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                    <li><a class="add" href="javascript:OpenDialog('新增','<%=MXEnums.ActionEnum.Add %>',0)">
                        <i></i><span>新增</span></a></li>
                    <li>
                        <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                    <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                    <li>
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');"
                            OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </div>
    <!--/工具栏-->
    <!--列表-->
    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th width="8%">
                        选择
                    </th>
                    <th align="left">
                        编号
                    </th>
                    <th align="left">
                        名称
                    </th>
                    <th align="left">
                        排序
                    </th>
                    <th width="12%">
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                    <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />
                    <asp:HiddenField ID="hidLayer" Value='<%#Eval("dLevel") %>' runat="server" />
                </td>
                <td class="listTdRow">
                    <%#Eval("dNum")%>
                </td>
                <td class="listTdRow">
                    <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                    <a href="javascript:OpenDialog('编辑','<%=MXEnums.ActionEnum.Edit %>',<%#Eval("ID")%>)">
                        <%#Eval("dName")%></a>
                </td>
                <td class="listTdRow">
                    <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("dSortNum")%>' CssClass="sort"
                        onkeydown="return checkNumber(event);" />
                </td>
                <td align="center" class="listTdRow">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("dType").ToString()=="00"?true:false %>' ViewStateMode="Inherit">
                        <a href="javascript:OpenDialog('新增','<%=MXEnums.ActionEnum.Add %>',<%#Eval("id")%>)">
                            添加子级</a> </asp:PlaceHolder>
                    <a href="javascript:OpenDialog('编辑','<%=MXEnums.ActionEnum.Edit %>',<%#Eval("ID")%>)">
                        修改</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <!--/列表-->
    </form>
</body>
</html>
