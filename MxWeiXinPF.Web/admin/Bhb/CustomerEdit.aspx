<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="Web.admin.Bhb.CustomerEdit" %>

<%@ Import Namespace="Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
      
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="<%=backUrl %>" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="<%=backUrl %>">
                <span>
                    <%=parentName%></span></a> <i class="arrow"></i><span>
                        <%=pageName%></span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>客户类型</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlType" runat="server" datatype="*" errormsg="请选择客户类型" sucmsg=" ">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>所属区域</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlOneArea" runat="server"  AutoPostBack="true"
                        onselectedindexchanged="ddlOneArea_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlTwoArea" runat="server">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>客户姓名</dt>
            <dd>
                <asp:TextBox ID="txtRealName" runat="server" CssClass="input normal" datatype="*"
                    errormsg="请填写客户姓名" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>身份证号</dt>
            <dd>
                <asp:TextBox ID="txtIdCard" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/"
                    nullmsg="请填写身份证号" errormsg="由数字、字母组成" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>固定电话</dt>
            <dd>
                <asp:TextBox ID="txtTelephone" runat="server" CssClass="input normal"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>移动电话</dt>
            <dd>
                <asp:TextBox ID="txtMobile" runat="server" CssClass="input normal"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>代发银行</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlBank" runat="server">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>银行账号</dt>
            <dd>
                <asp:TextBox ID="txtBankAccount" runat="server" CssClass="input normal"></asp:TextBox></dd>
        </dl>
        <dl>
            <dt>开户人</dt>
            <dd>
                <asp:TextBox ID="txtAcountName" runat="server" CssClass="input normal"></asp:TextBox></dd>
        </dl>
        <dl>
            <dt>详细地址</dt>
            <dd>
                <asp:TextBox ID="txtArea" runat="server" CssClass="input normal"></asp:TextBox></dd>
        </dl>
        <%--     <dl>
            <dt>排序</dt>
            <dd>
                <asp:TextBox ID="txtSortid" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                <span class="Validform_checktip">*数字，越小越向前</span>
            </dd>
        </dl>--%>
    </div>
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>
