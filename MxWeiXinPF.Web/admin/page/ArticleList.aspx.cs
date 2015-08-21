using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Web.admin.page
{
    public partial class ArticleList : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string prolistview = string.Empty;

        public string pageLevelName = "";
        string thisPage = "ArticleList.aspx";
        public string editPage = "ArticleEdit.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
 
            this.category_id = MXRequest.GetQueryInt("category_id");
            this.keywords = MXRequest.GetQueryString("keywords");
            this.property = MXRequest.GetQueryString("property");
            pageLevelName = MXRequest.GetQueryString("levelName");

            this.pageSize = GetPageSize(10); //每页数量
            this.prolistview = Utils.GetCookie(pageLevelName+"_view"); //显示方式
            if (!Page.IsPostBack)
            {
                ChkAdminLevel(pageLevelName, MXEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定类别
                RptBind(this.category_id, "id>0" + CombSqlTxt(this.keywords, this.property), "sort_id asc,add_time desc,id desc");
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetWCodeList(" and class_list like '%," + category_id + ",%'");

            this.ddlCategoryId.Items.Clear();
            //this.ddlCategoryId.Items.Add(new ListItem("所有类别", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(int _category_id, string _strWhere, string _orderby)
        {

            this.page = MXRequest.GetQueryInt("page", 1);
            if (this.category_id > 0)
            {
                this.ddlCategoryId.SelectedValue = _category_id.ToString();
            }
            this.ddlProperty.SelectedValue = this.property;
            this.txtKeywords.Text = this.keywords;
            //图表或列表显示
            BLL.article bll = new BLL.article();
            DataSet artDs = bll.GetWCodeList(_category_id, this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            //url链接地址处理
            if (artDs != null && artDs.Tables.Count > 0 && artDs.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                int count = artDs.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    dr = artDs.Tables[0].Rows[i];
                    string linkUrl = MyCommFun.ObjToStr(dr["link_url"]);

                    if (linkUrl.Length > 0)
                    {
                        //外链地址
                        dr["link_url"] = "<span class=\"lianjie_wai\">[外]</span>" + " <a href=\"javascript:;\">" + linkUrl + "</a>";
                    }
                    else
                    {
                        dr["link_url"] = "<span class=\"lianjie_ben\">[本]</span>" + " <a href=\"javascript:;\">" + MyCommFun.getWebSite() + "/detail.aspx?wid=" + MyCommFun.ObjToStr(dr["wid"]) + "&aid=" + dr["id"] + "</a>";
                    }
                }
                artDs.AcceptChanges();
            }

            switch (this.prolistview)
            {
                case "Img":
                    this.rptList1.Visible = false;
                    this.rptList2.DataSource = artDs;
                    this.rptList2.DataBind();
                    Utils.WriteCookie(pageLevelName+"_view", "Img", 14400);
                    break;
                default:
                    this.rptList2.Visible = false;
                    this.rptList1.DataSource = artDs;
                    this.rptList1.DataBind();
                    Utils.WriteCookie(pageLevelName+"_view", "Txt", 14400);
                    break;

            }
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt(thisPage, "category_id={0}&keywords={1}&property={2}&page={3}&levelName={4}",
                _category_id.ToString(), this.keywords, this.property, "__id__",pageLevelName);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and title like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                switch (_property)
                {
                    case "isLock":
                        strTemp.Append(" and is_lock=1");
                        break;
                    case "unIsLock":
                        strTemp.Append(" and is_lock=0");
                        break;
                    case "isMsg":
                        strTemp.Append(" and is_msg=1");
                        break;
                    case "isTop":
                        strTemp.Append(" and is_top=1");
                        break;
                    case "isRed":
                        strTemp.Append(" and is_red=1");
                        break;
                    case "isHot":
                        strTemp.Append(" and is_hot=1");
                        break;
                    case "isSlide":
                        strTemp.Append(" and is_slide=1");
                        break;
                }
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie(pageLevelName+"_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ChkAdminLevel(pageLevelName, MXEnums.ActionEnum.Edit.ToString()); //检查权限
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
            BLL.article bll = new BLL.article();
            Model.article model = bll.GetModel(id);
            switch (e.CommandName)
            {
                case "lbtnIsMsg":
                    if (model.is_msg == 1)
                        bll.UpdateField(id, "is_msg=0");
                    else
                        bll.UpdateField(id, "is_msg=1");
                    break;
                case "lbtnIsTop":
                    if (model.is_top == 1)
                        bll.UpdateField(id, "is_top=0");
                    else
                        bll.UpdateField(id, "is_top=1");
                    break;
                case "lbtnIsRed":
                    if (model.is_red == 1)
                        bll.UpdateField(id, "is_red=0");
                    else
                        bll.UpdateField(id, "is_red=1");
                    break;
                case "lbtnIsHot":
                    if (model.is_hot == 1)
                        bll.UpdateField(id, "is_hot=0");
                    else
                        bll.UpdateField(id, "is_hot=1");
                    break;
                case "lbtnIsSlide":
                    if (model.is_slide == 1)
                        bll.UpdateField(id, "is_slide=0");
                    else
                        bll.UpdateField(id, "is_slide=1");
                    break;
            }
            this.RptBind(this.category_id, "id>0" + CombSqlTxt(this.keywords, this.property), "sort_id asc,add_time desc,id desc");
        }

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt(thisPage, "category_id={0}&keywords={1}&property={2}&levelName={3}",
                this.category_id.ToString(), txtKeywords.Text, this.property,pageLevelName));
        }

        //筛选类别
        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt(thisPage, "category_id={0}&keywords={1}&property={2}&levelName={3}",
                ddlCategoryId.SelectedValue, this.keywords, this.property,pageLevelName));
        }

        //筛选属性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt(thisPage, "category_id={0}&keywords={1}&property={2}&levelName={3}",
               this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue,pageLevelName));
        }

        //设置文字列表显示
        protected void lbtnViewTxt_Click(object sender, EventArgs e)
        {
            Utils.WriteCookie(pageLevelName+"_view", "Txt", 14400);
            Response.Redirect(Utils.CombUrlTxt(thisPage, "category_id={0}&keywords={1}&property={2}&page={3}&levelName={4}",
                this.category_id.ToString(), this.keywords, this.property, this.page.ToString(),pageLevelName));
        }

        //设置图文列表显示
        protected void lbtnViewImg_Click(object sender, EventArgs e)
        {
            Utils.WriteCookie(pageLevelName+"_view", "Img", 14400);
            Response.Redirect(Utils.CombUrlTxt(thisPage, "category_id={0}&keywords={1}&property={2}&page={3}&levelName={4}",
                 this.category_id.ToString(), this.keywords, this.property, this.page.ToString(),pageLevelName));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie(pageLevelName+"_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt(thisPage, "category_id={0}&keywords={1}&property={2}&levelName={3}",
                this.category_id.ToString(), this.keywords, this.property,pageLevelName));
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(pageLevelName, MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.article bll = new BLL.article();
            Repeater rptList = new Repeater();
            switch (this.prolistview)
            {
                case "Txt":
                    rptList = this.rptList1;
                    break;
                default:
                    rptList = this.rptList2;
                    break;
            }
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存"+pageLevelName+"内容排序"); //记录日志
            JscriptMsg("保存排序成功啦！", Utils.CombUrlTxt(thisPage, "category_id={0}&keywords={1}&property={2}&levelName={3}",
                this.category_id.ToString(), this.keywords, this.property,pageLevelName), "Success");
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(pageLevelName, MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量
            BLL.article bll = new BLL.article();
            Repeater rptList = new Repeater();
            switch (this.prolistview)
            {
                case "Txt":
                    rptList = this.rptList1;
                    break;
                default:
                    rptList = this.rptList2;
                    break;
            }
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除"+pageLevelName+"内容成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt(thisPage, "category_id={0}&keywords={1}&property={2}&levelName={3}",
               this.category_id.ToString(), this.keywords, this.property,pageLevelName), "Success");
        }
    }
}