<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoFangKuangAnalysis.aspx.cs"
    Inherits="Web.admin.Bhb.NoFangKuangAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>未放款分析</title>
    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../scripts/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script src="js/highcharts.js" type="text/javascript"></script>
    <script src="js/modules/exporting.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });


        //        $(function () {
        //            $('#container').highcharts({
        //                chart: {
        //                    type: 'line'
        //                },
        //                title: {
        //                    text: '收料放款分析图表 -- <%=dateName %>'
        //                },
        //                subtitle: {
        //                    text: '<%=beginTime %> -- <%=endTime %>'
        //                },
        //                xAxis: {
        //                    categories: [<%=dateArray %>]
        //                },
        //                yAxis: {
        //                    title: {
        //                        text: '单位：<%=contentName %>'
        //                    }
        //                },
        //                plotOptions: {
        //                    line: {
        //                        dataLabels: {
        //                            enabled: true                   //是否显示数据
        //                        },
        //                        enableMouseTracking: true           //鼠标放上显示 标题
        //                    }
        //                },
        //                series: [{
        //                    name: '<%=contentName %>',
        //                    data: [<%=sumArray %>]
        //                }]
        //            });
        //        });



        $(function () {
            $('#container').highcharts({
                chart: {
                    type: 'column'
                },
                title: {
                    text: '收料放款分析图表 -- <%=dateName %>'
                },
                subtitle: {
                    text: '<%=beginTime %> -- <%=endTime %>'
                },
                xAxis: {
                    categories: [<%=dateArray %>]
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: '单位：<%=contentName %>'
                    },
                    stackLabels: {
                        enabled: true,
                        style: {
                            fontWeight: 'bold',
                            color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                        }
                    }
                },
                legend: {
                    align: 'right',
                    x: -70,
                    verticalAlign: 'top',
                    y: 20,
                    floating: true,
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                    borderColor: '#CCC',
                    borderWidth: 1,
                    shadow: false
                },
                tooltip: {
                    formatter: function () {
                        return '<b>' + this.x + '</b><br/>' +
                        this.series.name + ': ' + this.y
                        // + '<br/>' +'共: ' + this.point.stackTotal;
                    }
                },
                plotOptions: {
                    column: {
                        stacking: 'normal',
                        dataLabels: {
                            enabled: true,
                            color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
                            style: {
                                textShadow: '0 0 3px black, 0 0 3px black'
                            }
                        }
                    }
                },
                series: [{
                    name: '未放款',
                    data: [<%=sumArrayNo %>]
                }, {
                    name: '已放款',
                    data: [<%=sumArray %>]
                }]
            });
        });
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>收料放款分析图</span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
            </div>
            <div class="location-search">
                &nbsp;&nbsp;&nbsp; 收料日期:<asp:TextBox ID="txt_BeginTime" runat="server" onFocus="WdatePicker({maxDate:'#F{$dp.$D(\'txt_EndTime\');}'})"
                    datatype="*" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " CssClass="input1 Wdate"
                    Width="110px" />-
                <asp:TextBox ID="txt_EndTime" runat="server" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'txt_BeginTime\');}'})"
                    datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " CssClass="input1 Wdate"
                    Width="110px" />
                产品:
                <asp:DropDownList ID="ddl_ProductName" runat="server" Width="80px" AutoPostBack="true"
                    OnSelectedIndexChanged="ddl_ProductName_SelectedIndexChanged">
                </asp:DropDownList>
                规格:
                <asp:DropDownList ID="ddl_ProductStandard" runat="server" Width="80px">
                </asp:DropDownList>
                仓库:
                <asp:DropDownList ID="ddl_WareHouse" runat="server" Width="80px">
                </asp:DropDownList>
                分析内容：
                <asp:DropDownList ID="ddlContent" runat="server" Width="80px">
                    <asp:ListItem Value="1" Text="单数"></asp:ListItem>
                    <asp:ListItem Value="2" Text="金额"></asp:ListItem>
                </asp:DropDownList>
                时间跨度：
                <asp:DropDownList ID="ddlDate" runat="server" Width="80px">
                    <asp:ListItem Value="1" Text="按日"></asp:ListItem>
                    <asp:ListItem Value="2" Text="按月"></asp:ListItem>
                    <asp:ListItem Value="3" Text="按年"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btn_search" runat="server" Text="生成图" Width="70px" ToolTip="生成图"
                    OnClick="btnSearch_Click" Style="cursor: pointer" />
            </div>
        </div>
    </div>
    <!--/工具栏-->
    <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto">
    </div>
    </form>
</body>
</html>
