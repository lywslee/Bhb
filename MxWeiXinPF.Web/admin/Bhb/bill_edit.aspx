<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bill_edit.aspx.cs" Inherits="Web.admin.manager.bill_edit"
    ValidateRequest="false" %>

<%@ Import Namespace="Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑收料信息</title>
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

            /*JQuery 限制文本框只能输入数字和小数点*/
            $(".small").keyup(function () {
                $(this).val($(this).val().replace(/[^0-9.]/g, ''));
            }).bind("paste", function () {  //CTR+V事件处理    
                $(this).val($(this).val().replace(/[^0-9.]/g, ''));
            }).css("ime-mode", "disabled"); //CSS设置输入法不可用   

            $(".small").each(function () {
                $(this).bind("keypress", function () {
                    if (/[^0-9.]/.test(String.fromCharCode(event.keyCode)))
                        event.keyCode = 0
                });
                $(this).bind("focus", function () {
                    if ($(this).val() == "0.00") {
                        $(this).val("");
                    }
                });
                $(this).bind("blur", function () {
                    if ($(this).val() == "") {
                        $(this).val("0.00");
                    }
                });

            });
            calculateNetWeight();
            calculateAmount();
        });

        //如果为空或者没数则返回0
        function ConvertToNumber(id) {
            var sz = document.getElementById(id).value;
            if (sz == undefined || sz == "" || sz == "NaN") {
                sz = 0;
            }
            return sz;
        }

        //计算金额
        function calculateAmount() {
            var jz = ConvertToNumber("txt_NetWeight");  //毛重
            var dj = ConvertToNumber("txt_Price");      //单价
            var je = 0;                                 //金额
            je = jz * dj;
            document.getElementById("txt_Amount").value = je.toFixed(2);
        }

        //计算净重
        function calculateNetWeight() {

            var mz = ConvertToNumber("txt_GrossWeight"); //毛重
            var pz = ConvertToNumber("txt_Tare");        //皮重
            var jz = 0;
            if (pz > mz) {
                alert("皮重不能大于毛重!");
                return;
            }

            jz = mz - pz;
            document.getElementById("txt_NetWeight").value = jz.toFixed(3);

        }
       
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="bill_list.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="bill_list.aspx">
                <span>收料列表</span></a> <i class="arrow"></i><span>编辑收料单</span>
    </div>
    <div class="line5">
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
        <table>
            <tr>
                <td>
                    <dl>
                        <dt>收料编号</dt>
                        <dd>
                            <asp:TextBox ID="txt_BNum" runat="server" CssClass="input normal1" sucmsg=" " Text="系统编号"
                                Enabled="false" Width=""></asp:TextBox>
                        </dd>
                    </dl>
                </td>
                <td>
                    <dl>
                        <dt>存放仓库</dt>
                        <dd>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddl_WareHouse" runat="server" Width="210px" datatype="*" errormsg="请选择"
                                    sucmsg=" ">
                                </asp:DropDownList>
                            </div>
                        </dd>
                    </dl>
                </td>
            </tr>
            <tr>
                <td>
                    <dl>
                        <dt>客户姓名</dt>
                        <dd>
                            <asp:TextBox ID="txt_CustomerName" runat="server" CssClass="input normal1" sucmsg=" "
                                Text=""></asp:TextBox>
                        </dd>
                    </dl>
                </td>
                <td>
                    <dl>
                        <dt>移动电话</dt>
                        <dd>
                            <asp:TextBox ID="txt_Mobile" runat="server" CssClass="input normal1" sucmsg=" " Text=""></asp:TextBox>
                        </dd>
                    </dl>
                </td>
            </tr>
            <tr>
                <td>
                    <dl>
                        <dt>固定电话</dt>
                        <dd>
                            <asp:TextBox ID="txt_Tel" runat="server" CssClass="input normal1" sucmsg=" " Text=""></asp:TextBox>
                        </dd>
                    </dl>
                </td>
                <td>
                    <dl>
                        <dt>代发银行</dt>
                        <dd>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddl_BankName" runat="server" Width="210px" datatype="*" errormsg="请选择"
                                    sucmsg=" ">
                                </asp:DropDownList>
                            </div>
                        </dd>
                    </dl>
                </td>
            </tr>
            <tr>
                <td>
                    <dl>
                        <dt>银行账号</dt>
                        <dd>
                            <asp:TextBox ID="txt_BankAccount" runat="server" CssClass="input normal1" sucmsg=" "
                                Text=""></asp:TextBox>
                        </dd>
                    </dl>
                </td>
                <td>
                    <dl>
                        <dt>户名</dt>
                        <dd>
                            <asp:TextBox ID="txt_AccountName" runat="server" CssClass="input normal1" sucmsg=" "
                                Text=""></asp:TextBox>
                        </dd>
                    </dl>
                </td>
            </tr>
            <tr>
                <td>
                    <dl>
                        <dt>产品名称</dt>
                        <dd>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddl_ProductName" AutoPostBack="True" runat="server" Width="210px"
                                    datatype="*" errormsg="请选择" sucmsg=" " OnSelectedIndexChanged="ddl_ProductName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </dd>
                    </dl>
                </td>
                <td>
                    <dl>
                        <dt>产品规格</dt>
                        <dd>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddl_ProductStandard" runat="server" Width="210px" errormsg="请选择"
                                   datatype="*" sucmsg=" ">
                                </asp:DropDownList>
                            </div>
                        </dd>
                    </dl>
                </td>
            </tr>
            <tr>
                <td>
                    <dl>
                        <dt>单位</dt>
                        <dd>
                            <asp:TextBox ID="txt_Unit" runat="server" CssClass="input normal1" sucmsg=" " Text=""
                                Width="200px"></asp:TextBox>
                        </dd>
                    </dl>
                </td>
                <td>
                    <dl>
                        <dt>产品毛重</dt>
                        <dd>
                            <asp:TextBox ID="txt_GrossWeight" runat="server" CssClass="input small" datatype="*1-50"
                                sucmsg=" " Text="0.00" Style="text-align: right; padding-right: 2px; width: 200px;"
                                onkeyup="calculateNetWeight();calculateAmount();"></asp:TextBox>
                        </dd>
                    </dl>
                </td>
            </tr>
            <tr>
                <td>
                    <dl>
                        <dt>产品皮重</dt>
                        <dd>
                            <asp:TextBox ID="txt_Tare" runat="server" CssClass="input small" datatype="*1-50"
                                sucmsg=" " Text="0.00" Style="text-align: right; padding-right: 2px; width: 200px;"
                                onkeyup="calculateNetWeight();calculateAmount();"></asp:TextBox>
                        </dd>
                    </dl>
                </td>
                <td>
                    <dl>
                        <dt>产品净重</dt>
                        <dd>
                            <input id="txt_NetWeight" type="text" runat="server" readonly="readonly" class="input small"
                                sucmsg=" " text="0.00" style="text-align: right; padding-right: 2px; width: 200px;" />
                        </dd>
                    </dl>
                </td>
            </tr>
            <tr>
                <td>
                    <dl>
                        <dt>价格</dt>
                        <dd>
                            <asp:TextBox ID="txt_Price" runat="server" CssClass="input small" datatype="*1-50"
                                sucmsg=" " Text="0.00" Style="text-align: right; padding-right: 2px; width: 200px;"
                                onkeyup="calculateAmount();"></asp:TextBox>
                        </dd>
                    </dl>
                </td>
                <td>
                    <dl>
                        <dt>金额</dt>
                        <dd>
                            <input id="txt_Amount" type="text" runat="server" readonly="readonly" class="input small"
                                sucmsg=" " text="0.00" style="text-align: right; padding-right: 2px; width: 200px;" />
                        </dd>
                    </dl>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <dl>
                        <dt>备注</dt>
                        <dd>
                            <asp:TextBox ID="txt_Remark" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                            <span class="Validform_checktip">非必填，可为空</span></dd>
                    </dl>
                </td>
            </tr>
        </table>
    </div>
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
            <asp:CheckBox ID="ck_print" runat="server" Text=" 打 印" Width="60px" Style="text-align: center;
                margin-bottom: 6px;" CssClass="btn" Checked="true" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>
