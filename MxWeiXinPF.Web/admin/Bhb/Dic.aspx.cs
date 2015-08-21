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
    public partial class Dic : Web.UI.ManagePage
    {
        #region 自有字段
        string LevelName = "xtsz_sjzd";//菜单权限调用Id
        public string ThisUrl = "Dic.aspx";//当前页面Url  
        public string EditUrl = "DicEdit.aspx";//当前编辑页面Url
        public string PageName = "数据字典管理";//当前页面名称

        protected string keywords = string.Empty;//搜索字段
        #endregion
        #region 新增字段
        #endregion


        BLL.T_Dictionary bll = new BLL.T_Dictionary();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel(LevelName, MXEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        #region 数据绑定=================================
        private void RptBind()
        {
            List<Model.T_Dictionary> list = bll.GetListByOrder("00");
            this.rptList.DataSource = list;
            this.rptList.DataBind();
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string WhereSql()
        {
            StringBuilder strTemp = new StringBuilder("");


            return strTemp.ToString();
        }
        #endregion



        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
                string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
                string LitImg1 = "<span class=\"folder-open\"></span>";
                string LitImg2 = "<span class=\"folder-line\"></span>";

                int classLayer = Convert.ToInt32(hidLayer.Value);
                if (classLayer == 1)
                {
                    LitFirst.Text = LitImg1;
                }
                else
                {
                    LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
                }
            }
        }


        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(LevelName, MXEnums.ActionEnum.Edit.ToString()); //检查权限
            Model.T_Dictionary model = new Model.T_Dictionary();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                model.ID = id;
                model.dSortNum = sortId;
                bll.Update(model);
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存数据字典排序"); //记录日志
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