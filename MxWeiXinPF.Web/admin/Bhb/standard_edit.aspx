<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="standard_edit.aspx.cs"
    Inherits="Web.admin.manager.standard_edit" ValidateRequest="false" %>

<%@ Import Namespace="Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑产品规格信息</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });

        $(function () {
            //            /*JQuery 限制文本框只能输入数字*/
            //            $(".NumText").keyup(function () {
            //                $(this).val($(this).val().replace(/D|^0/g, ''));
            //            }).bind("paste", function () {  //CTR+V事件处理    
            //                $(this).val($(this).val().replace(/D|^0/g, ''));
            //            }).css("ime-mode", "disabled"); //CSS设置输入法不可用    

            /*JQuery 限制文本框只能输入数字和小数点*/
            $(".small").keyup(function () {
                $(this).val($(this).val().replace(/[^0-9.]/g, ''));
            }).bind("paste", function () {  //CTR+V事件处理    
                $(this).val($(this).val().replace(/[^0-9.]/g, ''));
            }).css("ime-mode", "disabled"); //CSS设置输入法不可用    
        });  
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="standard_list.aspx?productID=<%=productID %>" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="standard_list.aspx?productID=<%=productID %>">
                <span>产品规格列表</span></a> <i class="arrow"></i><span>编辑产品规格</span>
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
            <dt>规格名称</dt>
            <dd>
                <asp:TextBox ID="txt_sName" runat="server" CssClass="input normal" datatype="*1-50"
                    sucmsg=" " Text=""></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>计量单位</dt>
            <dd>
                <asp:TextBox ID="txt_sUnit" runat="server" CssClass="input normal" datatype="*1-50"
                    sucmsg=" " Text=""></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>重量</dt>
            <dd>
                <asp:TextBox ID="txt_sWeight" runat="server" CssClass="input small" datatype="*1-50"
                    Width="80px" sucmsg=" " Text=""></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>体积</dt>
            <dd>
                <asp:TextBox ID="txt_sVolume" runat="server" CssClass="input small" datatype="*1-50"
                    Width="80px" sucmsg=" " Text=""></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>价格</dt>
            <dd>
                <asp:TextBox ID="txt_sPrice" runat="server" CssClass="input small" datatype="*1-50"
                    Width="80px" sucmsg=" " Text=""></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>排序</dt>
            <dd>
                <asp:TextBox ID="txtSortid" runat="server" CssClass="input normal" datatype="n" sucmsg=" ">99</asp:TextBox>
                <span class="Validform_checktip">*数字，越小越向前</span>
            </dd>
        </dl>
        <dl>
            <dt>备注</dt>
            <dd>
                <asp:TextBox ID="txt_Remark" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                <span class="Validform_checktip">非必填，可为空</span></dd>
        </dl>
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
