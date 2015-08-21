<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaEdit.aspx.cs" Inherits="Web.admin.Bhb.AreaEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>区域编辑</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>

    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.query.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //窗口API
        var api = frameElement.api, W = api.opener;
        api.button({
            name: '确定',
            focus: true,
            callback: function () {
                $("#btnSure").click();
                return false;
            }
        }, {
            name: '取消'
        });



        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            $("#btnSure").click(function () {
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div-content">
        <div class="dl-attach-box">
            <dl>
                <dt>名称</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" 
                        CssClass=" input txt upload-name" datatype="*1-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*类别中文名称</span>
                </dd>
            </dl>
            <dl>
                <dt>排序数字</dt>
                <dd>
                    <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                    <span class="Validform_checktip">*数字，越小越向前</span>
                </dd>
            </dl>

        </div>
    </div>
    <div style=" display:none;">
    <asp:Button ID="btnSure" runat="server"  OnClick="btnSure_Click" />
    </div>
    </form>
</body>
</html>
