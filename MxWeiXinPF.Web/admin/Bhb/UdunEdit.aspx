<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UdunEdit.aspx.cs" Inherits="Web.admin.Bhb.UdunEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑</title>
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
                <dt>u盾名称</dt>
                <dd>
                    <asp:TextBox ID="txtUName" runat="server" 
                        CssClass=" input txt upload-name" datatype="*1-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>硬件编码</dt>
                <dd>
                    <asp:TextBox ID="txtHardWareCode" runat="server" 
                        CssClass=" input txt upload-name"></asp:TextBox>
                </dd>
            </dl>
              <dl>
                <dt>种子码</dt>
                <dd>
                    <asp:TextBox ID="txtSeed" runat="server" 
                        CssClass=" input txt upload-name"></asp:TextBox>
                </dd>
            </dl>
              <dl>
                <dt>3des密钥</dt>
                <dd>
                    <asp:TextBox ID="txtUKey" runat="server" 
                        CssClass=" input txt upload-name"></asp:TextBox>
                </dd>
            </dl>
              <dl>
                <dt>备注</dt>
                <dd>
                    <asp:TextBox ID="txtRemark" runat="server" 
                        CssClass=" input txt upload-name"></asp:TextBox>
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