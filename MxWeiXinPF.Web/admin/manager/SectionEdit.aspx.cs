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
    public partial class SectionEdit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        string levelName = "section";
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            this.id = MXRequest.GetQueryInt("id");

            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel(levelName, MXEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(MXEnums.NavigationEnum.System.ToString()); //绑定导航菜单
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    if (this.id > 0)
                    {
                        this.ddlParentId.SelectedValue = this.id.ToString();
                    }
                }
            }
        }

        #region 绑定部门菜单=============================
        private void TreeBind(string nav_type)
        {
            BLL.Section bll = new BLL.Section();

            List<Model.SectionView> list = bll.GetListByOrder(0);

            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("无父级部门", "0"));
            foreach (var m in list)
            {
                string Id = m.Id.ToString();
                int ClassLayer = m.LevelNum;
                string Title = m.Name;

                if (ClassLayer == 1)
                {
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion


        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Section bll = new BLL.Section();
            Model.Section model = bll.GetModel(_id);

            ddlParentId.SelectedValue = model.ParentId.ToString();
            txtSortId.Text = model.Sort.ToString();
            txtName.Text = model.Name;
            txtRemark.Text = model.Ext1;

        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                Model.Section model = new Model.Section();
                BLL.Section bll = new BLL.Section();

                model.Name = txtName.Text.Trim();
                model.Sort = int.Parse(txtSortId.Text.Trim());
                model.Ext1 = txtRemark.Text.Trim();
                model.ParentId = int.Parse(ddlParentId.SelectedValue);
                model.LevelNum = 1;
                if (model.ParentId != 0)
                {
                    Model.Section ParModel = bll.GetModel(model.ParentId);
                    if (ParModel != null)
                    {
                        model.LevelNum = ParModel.LevelNum + 1;
                    }
                }

                if (bll.Insert(model) > 0)
                {
                    AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加部门信息:" + model.Name); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.Section bll = new BLL.Section();
                Model.Section model = new Model.Section();
                model.Id = _id;
                model.Name = txtName.Text.Trim();
                model.Sort = int.Parse(txtSortId.Text.Trim());

                model.Ext1 = txtRemark.Text.Trim();

                int parentId = int.Parse(ddlParentId.SelectedValue);
                //如果选择的父ID不是自己,则更改
                if (parentId != model.Id)
                {
                    model.ParentId = parentId;
                    model.LevelNum = 1;
                    if (parentId != 0)
                    {
                        Model.Section ParModel = bll.GetModel(parentId);
                        if (ParModel != null)
                        {
                            model.LevelNum = ParModel.LevelNum + 1;
                        }
                    }
                }
                if (bll.Update(model))
                {
                    AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "修改部门信息:" + model.Name); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel(levelName, MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改部门菜单成功！", "SectionList.aspx", "Success", "parent.loadMenuTree");
            }
            else //添加
            {
                ChkAdminLevel(levelName, MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加部门菜单成功！", "SectionList.aspx", "Success", "parent.loadMenuTree");
            }
        }

    }
}