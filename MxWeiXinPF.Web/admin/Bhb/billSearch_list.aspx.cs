using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.IO;

namespace Web.admin.Bhb
{
    public partial class billSearch_list : Web.UI.ManagePage
    {
        protected int totalCount;                 //记录总条数
        protected int page;                       //当前页码
        protected int pageSize;                   //一页显示的条数
        protected string keywords = string.Empty; //关键字

        //导航菜单 检测用户相关权限
        private const string NAV_NAME = "cwtj_sltj";
        //页面名称
        private string pageName = "billSearch_list.aspx";
        //编辑页面
        private string editPageName = "billSearch_look.aspx";
  
        private string beginTime = "";      //开始时间
        private string endTime = "";        //结束时间
        private string addPerson = "";      //收料员
        private string product = "";        //产品
        private string productStandard = "";//规格
        private string wareHouse = "";      //仓库

        //业务逻辑
        BLL.T_Bill bll = new BLL.T_Bill();
        //Model
        Model.T_Bill model = new Model.T_Bill();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            this.beginTime = MXRequest.GetQueryString("beginTime");
            this.endTime = MXRequest.GetQueryString("endTime");
            this.addPerson = MXRequest.GetQueryString("addPerson");
            this.product = MXRequest.GetQueryString("product");
            this.productStandard = MXRequest.GetQueryString("productStandard");
            this.wareHouse = MXRequest.GetQueryString("wareHouse");
           
            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                //SetDefaultValue();
                BindDropDownList(ddl_WareHouse, "D02");  //绑定仓库
                BindDDL_Person(ddl_AddPerson);          //绑定收料员

                BindDDL_Product(ddl_ProductName);       //绑定产品   
                BindDDL_ProductStand(ddl_ProductStandard, ddl_ProductName.SelectedItem.Value);//产品规格
               
                //检查权限
                ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.View.ToString());
                SearchBind();
                BindData();
            }
        }

        #region 绑定查询=================================

        private void SearchBind()
        {
            txtKeywords.Text = keywords;
            this.txt_BeginTime.Text = beginTime;
            this.txt_EndTime.Text = endTime;
            this.ddl_ProductName.SelectedValue = product;

            BindDDL_ProductStand(ddl_ProductStandard, ddl_ProductName.SelectedItem.Value);//产品规格

            this.ddl_ProductStandard.SelectedValue = productStandard;
            this.ddl_AddPerson.SelectedItem.Text = addPerson;
            this.ddl_WareHouse.SelectedValue = wareHouse;
        }

        #endregion

        #region 数据绑定=================================

        private void BindData()
        {
            this.page = MXRequest.GetQueryInt("page", 1);

            this.rptList.DataSource = bll.GetListTable(this.pageSize, this.page, WhereSql(), "BNum desc", out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt(pageName, "keywords={0}&page={1}&beginTime={2}&endTime={3}&addPerson={4}&product={5}&productStandard={6}&wareHouse={7}", this.keywords, "__id__",this.beginTime,this.endTime,this.addPerson,this.product,this.productStandard,this.wareHouse);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

            //合计
            DataTable dt =bll.GetSum(WhereSql());
            if (dt.Rows.Count == 1)
            {
                lbl_hj.Text = "<b>单数合计:</b>  " + dt.Rows[0]["count"].ToString() + "        <b>数量合计:</b>  " + String.Format("{0:#,###0.000}", double.Parse(dt.Rows[0]["NetWeight"].ToString())) + "       <b>金额合计:</b>  " + String.Format("{0:#,##0.00}", double.Parse(dt.Rows[0]["Amount"].ToString()));
            }

            //lbl_hj.Text = String.Format("{0:#,###0.000}", 1234567.891);

        }

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            //{
            //    Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
            //    HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
            //    string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
            //    string LitImg1 = "<span class=\"folder-open\"></span>";
            //    string LitImg2 = "<span class=\"folder-line\"></span>";

            //    int classLayer = Convert.ToInt32(hidLayer.Value);
            //    if (classLayer == 1)
            //    {
            //        LitFirst.Text = LitImg1;
            //    }
            //    else
            //    {
            //        LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
            //    }
            //}
        }
        #endregion

        #region 设置初始默认值
        protected void SetDefaultValue()
        {          
            DateTime dt = DateTime.Now;                                 //当前时间
            DateTime startMonth = dt.AddDays(1 - dt.Day);               //本月月初
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);    //本月月末
            this.txt_BeginTime.Text = startMonth.ToString("yyyy-MM-dd");
            this.txt_EndTime.Text = dt.ToString("yyyy-MM-dd");
        }
        #endregion 

        #region 绑定下拉框

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dType">数据字典类型</param>
        private void BindDropDownList(DropDownList ddl, string dType)
        {
            string strWhere = "";//条件
            strWhere = " and dType='" + dType + "'";
            BLL.T_Dictionary bll = new BLL.T_Dictionary();
            DataTable dt = bll.GetDataTable(strWhere);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--不限--", "00"));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["dName"].ToString(), dr["dNum"].ToString()));
            }
        }

        /// <summary>
        /// 绑定收料员
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dType">数据字典类型</param>
        private void BindDDL_Person(DropDownList ddl)
        {
            string strWhere = "";//条件
            BLL.dt_manager bll = new BLL.dt_manager();
            DataTable dt = bll.GetDataTable(strWhere);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--不限--", "00"));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["real_name"].ToString(), dr["id"].ToString()));
            }
        }
       
       
        /// <summary>
        /// 绑定产品
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dType">数据字典类型</param>
        private void BindDDL_Product(DropDownList ddl)
        {
            BLL.T_Product bll = new BLL.T_Product();
            DataTable dt = bll.GetDataTable("");

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--不限--", "00"));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["pName"].ToString(), dr["ID"].ToString()));
            }
        }

        /// <summary>
        /// 绑定规格
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dType">数据字典类型</param>
        private void BindDDL_ProductStand(DropDownList ddl, string productID)
        {
            string strWhere = "";//条件
            strWhere = " and sProductNum='" + productID + "'";
            BLL.T_Standard bll = new BLL.T_Standard();
            DataTable dt = bll.GetDataTable(strWhere);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--不限--", "00"));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["sName"].ToString(), dr["ID"].ToString()));
            }
        }
        #endregion

        #region 保存排序、删除
        /// <summary>
        /// 保存排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.Edit.ToString()); //检查权限
            //for (int i = 0; i < rptList.Items.Count; i++)
            //{
            //    int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            //    int sortId;
            //    if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            //    {
            //        sortId = 99;
            //    }
            //    bll.UpdateField(id, "pSortNum=" + sortId.ToString());
            //}
            //AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存排序"); //记录日志

            //JscriptMsg("保存排序成功！", pageName, "Success");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.Delete.ToString()); //检查权限
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                    AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除产品信息:主键" + id); //记录日志
                }
            }

            JscriptMsg("删除数据成功！", pageName, "Success");
        }
        #endregion

        #region 组合SQL查询语句==========================

        protected string WhereSql()
        {
            StringBuilder strTemp = new StringBuilder("");

            //收料员
            if (ddl_AddPerson.SelectedValue != "00")
            {
                strTemp.Append(" and AddPerson=" + ddl_AddPerson.SelectedItem.Text);
            }
            //产品
            if (ddl_ProductName.SelectedValue != "00")
            {
                strTemp.Append(" and ProjectID=" + ddl_ProductName.SelectedValue);
            }
            //规格
            if (ddl_ProductStandard.SelectedValue != "00")
            {
                strTemp.Append(" and ProductStandardID=" + ddl_ProductStandard.SelectedValue);
            }
            //仓库
            if (ddl_WareHouse.SelectedValue != "00")
            {
                strTemp.Append(" and WareHouse=" + ddl_WareHouse.SelectedValue);
            }

            //关键字查询
            string _keywords = txtKeywords.Text.Trim();
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (BNum like  '%" + _keywords + "%' or Mobile like  '%" + _keywords + "%' or CustomerName like  '%" + _keywords + "%' )");
            }

            string strBeginTime = "";//收料开始时间
            string strEndTime = "";  //收料结束时间
            strBeginTime = txt_BeginTime.Text.Trim();
            strEndTime = txt_EndTime.Text.Trim();

            if (strBeginTime != "" && strEndTime != "")
            {
                strTemp.Append(" and  convert(varchar(10),AddTime,121)>='" + strBeginTime + "' and convert(varchar(10),AddTime,121)<='" + strEndTime + "'");
            }
            else if (strBeginTime != "")
            {
                strTemp.Append(" and  convert(varchar(10),AddTime,121)>='" + strBeginTime + "'");
            }
            else if (strEndTime != "")
            {
                strTemp.Append(" and  convert(varchar(10),AddTime,121)<='" + strEndTime + "'");
            }

            return strTemp.ToString();
        }

        /// <summary>
        /// 关键字
        /// </summary>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (BNum like  '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量、设置分页数量=============================

        /// <summary>
        /// 每页记录条数
        /// </summary>
        /// <param name="_default_size"></param>
        /// <returns></returns>
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie(NAV_NAME), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        /// <summary>
        /// 设置分页数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie(NAV_NAME, _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt(pageName, "keywords={0}&beginTime={1}&endTime={2}&addPerson={3}&product={4}&productStandard={5}&wareHouse={6}", this.txtKeywords.Text, this.beginTime, this.endTime, this.addPerson, this.product, this.productStandard, this.wareHouse));
        }

        /// <summary>
        /// 关键字查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt(pageName, "keywords={0}&beginTime={1}&endTime={2}&addPerson={3}&product={4}&productStandard={5}&wareHouse={6}", this.txtKeywords.Text, this.txt_BeginTime.Text,this.txt_EndTime.Text,this.ddl_AddPerson.SelectedItem.Text,this.ddl_ProductName.SelectedValue,this.ddl_ProductStandard.SelectedValue,this.ddl_WareHouse.SelectedValue));
            
            //BindData();
        }

        #endregion

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_print_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int id = 0;
            int count = 0;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                    count++;
                }
            }
            if (count > 1)
            {
                JscriptMsg("请选择一条记录打印！", "", "Error");
                return;
            }
            //打印
            MessageBox.ResponseScript(this, "window.showModalDialog('../print/Print.aspx?id=" + id + "', '', 'dialogWidth:900px;DialogHeight=500px;status:no;help:no;resizable:yes;');");

        }

        /// <summary>
        /// 产品变化时，规格也变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_ProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //产品编号
            string productID = ddl_ProductName.SelectedItem.Value;
            BindDDL_ProductStand(ddl_ProductStandard, productID);
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_exportExcel_Click(object sender, EventArgs e)
        {
            string FilePath = "../../upload/收料单统计.xls";

            StringBuilder sb = new StringBuilder();

            //组合Table
            sb = ImportExcel();

            string strFullPath = System.Web.HttpContext.Current.Server.MapPath(FilePath);

            if (File.Exists(strFullPath))
            {
                // 如果有就删除它
                File.Delete(strFullPath);
            }

            File.AppendAllText(strFullPath, sb.ToString(), Encoding.UTF8);
            MessageBox.DownLoadExcel(this, FilePath);
        }


        /// <summary>
        /// 导出Excel
        /// </summary>
        private StringBuilder ImportExcel()
        {
            //收料数据集
            DataSet ds = new DataSet();

            ds = bll.GetTableToExcel(WhereSql()," BNum desc");
            StringBuilder sb = new StringBuilder();

            string colHeaders = "";//列标题
            string rowItems = ""; //行记录
            string headerTitle = "山东凯华收料单";// PubConstant.GetAppSettingValue("JiaoBanBillTitle");
            int colspan = 18;    //表格跨列数

            sb.Append("<table x:str border=1  cellpadding=0 cellspacing=0 style='border-collapse: collapse;width:636px;'>\n");

            //头标题
            colHeaders = "<td style='vnd.ms-excel.numberformat:@' colspan='"+colspan+"' align='center'>" + headerTitle + "</td>";
            colHeaders = "<tr style='font-weight:bold;font-size:20px;'>" + colHeaders + "</tr>\n";
            sb.Append(colHeaders);
            colHeaders = "";

            colHeaders = "<td style='vnd.ms-excel.numberformat:@'  align='center'>序号</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>收料编号</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>产品名称</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>规格</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>单位</td>";

            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>数量</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>价格</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>金额</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>客户姓名</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>身份证号</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>移动电话</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>固定电话</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>代发银行</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>银行账号</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>户名</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>仓库</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>收料员</td>";
            colHeaders += "<td style='vnd.ms-excel.numberformat:@' align='center'>收料时间</td>";
            colHeaders = "<tr style='font-size:14px;'>" + colHeaders + "</tr>\n";
            sb.Append(colHeaders);

            #region 数据

            //循环输出记录数
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //序号
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='center'>" + (i + 1) + "</td>";
                    //收料编号
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["BNum"].ToString() + "</td>";
                    //产品名称
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["ProductName"].ToString() + "</td>";
                    //规格
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["ProductStandard"].ToString() + "</td>";
                    //单位
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["Unit"].ToString() + "</td>";
                    //数量
                    rowItems += "<td style='vnd.ms-excel.numberformat:#,###0.000' align='right'>" + ds.Tables[0].Rows[i]["NetWeight"].ToString() + "</td>";
                    //价格
                    rowItems += "<td style='vnd.ms-excel.numberformat:#,###0.00' align='right'>" + ds.Tables[0].Rows[i]["Price"].ToString() + "</td>";
                    //金额
                    rowItems += "<td style='vnd.ms-excel.numberformat:#,###0.00' align='right'>" + ds.Tables[0].Rows[i]["Amount"].ToString() + "</td>";
                    //客户名称
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["CustomerName"].ToString() + "</td>";
                    //身份证号
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["CardNumber"].ToString() + "</td>";
                    //移动电话
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["Mobile"].ToString() + "</td>";
                    //固定电话
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["Tel"].ToString() + "</td>";
                    //代发银行
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["BankName"].ToString() + "</td>";
                    //银行账号
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["BankAccount"].ToString() + "</td>";
                    //户名
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["AccountName"].ToString() + "</td>";
                    //仓库
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["WareHouse"].ToString() + "</td>";
                    //收料员
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["AddPerson"].ToString() + "</td>";
                    //收料时间
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='left'>" + ds.Tables[0].Rows[i]["AddTime"].ToString() + "</td>";

                    rowItems = "<tr  style='font-size:14px;'>" + rowItems + "</tr>\n";
                    sb.Append(rowItems);
                    rowItems = "";
                }
              
                #region 合计行
                rowItems = "";
                //合计：
                if (ds.Tables[1].Rows.Count == 1)
                {
                    //合计
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='center'><b>合计</b></td>";

                    //单数合计
                    rowItems += "<td style='vnd.ms-excel.numberformat:#,###' align='right'>" + ds.Tables[1].Rows[0]["count"].ToString() + "</td>";
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='center' >&nbsp;</td>";
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='center' >&nbsp;</td>";
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='center' >&nbsp;</td>";
                    //单数合计
                    rowItems += "<td style='vnd.ms-excel.numberformat:#,###0.000' align='right'>" + ds.Tables[1].Rows[0]["NetWeight"].ToString() + "</td>";
                    rowItems += "<td style='vnd.ms-excel.numberformat:@' align='center' >&nbsp;</td>";
                    //金额合计
                    rowItems += "<td style='vnd.ms-excel.numberformat:#,###0.00' align='right'>" + ds.Tables[1].Rows[0]["Amount"].ToString() + "</td>";

                    for (int i = 0; i < 10; i++)
                    {
                        rowItems += "<td style='vnd.ms-excel.numberformat:@' align='center' >&nbsp;</td>";
                    }
                    rowItems = "<tr  style='font-size:14px;'>" + rowItems + "</tr>\n";

                }
                sb.Append(rowItems);
                rowItems = "";
                #endregion

            }
            #endregion

            sb.Append("</table>");

            return sb;
        }
    }
}