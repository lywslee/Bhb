using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.Text;

namespace Web.admin.Bhb
{
    public partial class Uban : Web.UI.ManagePage
    {
        #region 自有字段
        string LevelName = "xtsz_u";//菜单权限调用Id
        public string ThisUrl = "Udun.aspx";//当前页面Url  
        public string EditUrl = "UdunEdit.aspx";//当前编辑页面Url
        public string PageName = "U盾管理";//当前页面名称

        protected int totalCount;//记录总条数
        protected int page;//当前页码
        protected int pageSize;//一页显示的条数
        protected string keywords = string.Empty;//搜索字段
        #endregion
        #region 新增字段
        #endregion


        BLL.T_Ushield bll = new BLL.T_Ushield();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel(LevelName, MXEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定类别
                SearchBind();
                RptBind();
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {

        }
        #endregion
        #region 绑定查询=================================
        private void SearchBind()
        {

        }
        #endregion

        #region 数据绑定=================================
        private void RptBind()
        {

            this.page = MXRequest.GetQueryInt("page", 1);
            // this.txtKeywords.Text = this.keywords;
            string _orderby = " ID asc";
            List<Model.T_Ushield> list = bll.GetListByPage(pageSize, page, WhereSql(), _orderby, out this.totalCount);
            this.rptList.DataSource = list;
            this.rptList.DataBind();


            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt(ThisUrl, "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string WhereSql()
        {
            StringBuilder strTemp = new StringBuilder("");

            
            return strTemp.ToString();
        }
        #endregion

        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie(LevelName), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            //Response.Redirect(Utils.CombUrlTxt(ThisUrl, "keywords={0}", txtKeywords.Text));
        }




        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie(LevelName, _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt(ThisUrl, "keywords={0}", this.keywords));
        }
        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(LevelName, MXEnums.ActionEnum.Edit.ToString()); //检查权限
            Model.Section model = new Model.Section();
            BLL.Section bll = new BLL.Section();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                model.Id = id;
                model.Sort = sortId;
                bll.Update(model);
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存区域排序"); //记录日志
            JscriptMsg("保存排序成功！", ThisUrl, "Success");
        }
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(LevelName, MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int did = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(did))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除" + PageName + "成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt(ThisUrl, "keywords={0}", this.keywords), "Success");
        }

    }
}