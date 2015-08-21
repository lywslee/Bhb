using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.Data;

namespace Web.admin.manager
{
    public partial class SectionList : Web.UI.ManagePage
    {
        #region 自有字段
        string LevelName = "section";//菜单权限调用Id
        string backUrl = "SectionList.aspx";
        #endregion
        #region 新增字段

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel(LevelName, MXEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        //数据绑定
        private void RptBind()
        {
            BLL.Section B_Sect = new BLL.Section();
            List<Model.SectionView> list = B_Sect.GetListByOrder(0);
            rptList.DataSource = list;
            rptList.DataBind();


        }

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
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存部门排序"); //记录日志
            JscriptMsg("保存排序成功！", backUrl, "Success");
        }

        //删除导航
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel(LevelName, MXEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.Section bll = new BLL.Section();
            Model.Section model = new Model.Section();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    model.Id = id;
                    model.IsDelete = 1;
                    bll.Update(model);
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除部门信息"); //记录日志
            JscriptMsg("删除数据成功！", backUrl, "Success", "parent.loadMenuTree");
        }
    }
}