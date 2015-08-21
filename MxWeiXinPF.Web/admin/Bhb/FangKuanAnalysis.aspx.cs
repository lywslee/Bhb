using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Common;
using System.IO;

namespace Web.admin.Bhb
{
    public partial class FangKuanAnalysis : Web.UI.ManagePage
    {
        protected int totalCount;                 //记录总条数
        protected int page;                       //当前页码
        protected int pageSize;                   //一页显示的条数
     

        //导航菜单 检测用户相关权限
        private const string NAV_NAME = "jcfx_fkfx";
        //页面名称
        private string pageName = "FangKuanAnalysis.aspx";

        public string beginTime = "";      //开始时间
        public string endTime = "";        //结束时间
        private string date = "";      //日期间隔
        private string product = "";        //产品
        private string productStandard = "";//规格
        private string wareHouse = "";      //仓库
        protected string content = string.Empty; //查询内容

        public string contentName = "";
        public string dateName = "";
        public string dateArray = "";//横坐标显示的时间
        public string sumArray = "";//曲线显示的数据
        //业务逻辑
        BLL.T_Bill bll = new BLL.T_Bill();
        //Model
        Model.T_Bill model = new Model.T_Bill();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.content = MXRequest.GetQueryString("content");
             this.beginTime = MXRequest.GetQueryString("beginTime");
            this.endTime = MXRequest.GetQueryString("endTime");
            this.date = MXRequest.GetQueryString("date");
            this.product = MXRequest.GetQueryString("product");
            this.productStandard = MXRequest.GetQueryString("productStandard");
            this.wareHouse = MXRequest.GetQueryString("wareHouse");

            if (!Page.IsPostBack)
            {
                SetDefaultValue();
                BindDropDownList(ddl_WareHouse, "D02");  //绑定仓库

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
            this.txt_BeginTime.Text = beginTime;
            this.txt_EndTime.Text = endTime;
            this.ddl_ProductName.SelectedValue = product;

            BindDDL_ProductStand(ddl_ProductStandard, ddl_ProductName.SelectedItem.Value);//产品规格

            this.ddl_ProductStandard.SelectedValue = productStandard;//产品规格
            this.ddl_WareHouse.SelectedValue = wareHouse;//仓库

            ddlDate.SelectedValue = this.date;
            dateName = ddlDate.SelectedItem.Text;
            ddlContent.SelectedValue = this.content;
            contentName = ddlContent.SelectedItem.Text;

        }

        #endregion

        #region 数据绑定=================================

        private void BindData()
        {
            string sumFeild = "";
            if (ddlContent.SelectedValue == "1")
            {
                sumFeild = "1";
            }
            else
            {
                sumFeild = "Amount";
            }
            string dateNum = "10";
            if (ddlDate.SelectedValue == "1")
            {
                dateNum = "10";
            }
            else if (ddlDate.SelectedValue == "2")
            {
                dateNum = "7";
            }
            else
            {
                dateNum = "4";
            }
            DataTable data = bll.GetListGroupBy(sumFeild, dateNum, "LoanDate", WhereSql());
            if (data.Rows.Count > 0)
            {
                StringBuilder sumSb = new StringBuilder("");
                StringBuilder dateSb = new StringBuilder("");
                foreach (DataRow row in data.Rows)
                {
                    sumSb.Append(row["sumField"]);
                    sumSb.Append(",");
                    dateSb.Append("'");
                    dateSb.Append(row["DateGroup"]);
                    dateSb.Append("'");
                    dateSb.Append(",");
                }
                sumArray = sumSb.ToString().Trim(',');
                dateArray = dateSb.ToString().Trim(',');
            }
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
            if (beginTime == "")
            {
                beginTime = txt_BeginTime.Text;
            }
            if (endTime == "")
            {
                endTime = txt_EndTime.Text;
            }
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


        #region 组合SQL查询语句==========================

        protected string WhereSql()
        {
            StringBuilder strTemp = new StringBuilder("");
            strTemp.Append(" and LoanMark=1 ");
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
       

            string strBeginTime = "";//收料开始时间
            string strEndTime = "";  //收料结束时间
            strBeginTime = txt_BeginTime.Text.Trim();
            strEndTime = txt_EndTime.Text.Trim();

            if (strBeginTime != "" && strEndTime != "")
            {
                strTemp.Append(" and  convert(varchar(10),LoanDate,121)>='" + strBeginTime + "' and convert(varchar(10),LoanDate,121)<='" + strEndTime + "'");
            }
            else if (strBeginTime != "")
            {
                strTemp.Append(" and  convert(varchar(10),LoanDate,121)>='" + strBeginTime + "'");
            }
            else if (strEndTime != "")
            {
                strTemp.Append(" and  convert(varchar(10),LoanDate,121)<='" + strEndTime + "'");
            }

            return strTemp.ToString();
        }

        #endregion




        /// <summary>
        /// 关键字查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt(pageName, "content={0}&beginTime={1}&endTime={2}&date={3}&product={4}&productStandard={5}&wareHouse={6}", ddlContent.Text, this.txt_BeginTime.Text, this.txt_EndTime.Text, ddlDate.SelectedValue, this.ddl_ProductName.SelectedValue, this.ddl_ProductStandard.SelectedValue, this.ddl_WareHouse.SelectedValue));

            //BindData();
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
    }
}