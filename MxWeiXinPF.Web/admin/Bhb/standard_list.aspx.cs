﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Web.admin.Bhb
{
    public partial class standard_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        //导航菜单 检测用户相关权限
        private const string NAV_NAME = "xtsz_cpwh";
        //页面名称
        private string pageName = "standard_list.aspx";
        //业务逻辑
        BLL.T_Standard bll = new BLL.T_Standard();
        //Model
        Model.T_Standard model = new Model.T_Standard();
        //关键字
        protected string keywords = string.Empty;
        //产品ID
        public string strProductNum = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
            this.strProductNum = MXRequest.GetQueryString("productID");

            this.pageSize = GetPageSize(10); //每页数量
            
            if (!Page.IsPostBack)
            {
                //检查权限
                ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.View.ToString());
                //RptBind();
                BindData(" and sProductNum="+strProductNum+" "+CombSqlTxt(keywords), "ID");
            }
        }

        #region 数据绑定=================================

        private void BindData(string _strWhere, string _orderby)
        {
            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;

            this.rptList.DataSource = bll.GetListByPage(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt(pageName, "keywords={0}&page={1}", this.keywords, "__id__");

            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

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

        #region 保存排序、删除
        /// <summary>
        /// 保存排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.Edit.ToString()); //检查权限
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sSortNum=" + sortId.ToString());
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存排序"); //记录日志

            JscriptMsg("保存排序成功！", pageName + "?productID=" + strProductNum, "Success");
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

            JscriptMsg("删除数据成功！", pageName + "?productID=" + strProductNum, "Success");
        }
        #endregion 

        #region 组合SQL查询语句==========================

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
                strTemp.Append(" and (pName like  '%" + _keywords + "%')");
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
            Response.Redirect(Utils.CombUrlTxt(pageName + "?productID=" + strProductNum, "keywords={0}", this.keywords));
        }
        #endregion

        /// <summary>
        /// 关键字查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt(pageName + "?productID=" + strProductNum, "keywords={0}", txtKeywords.Text));
        }
    }
}