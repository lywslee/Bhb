using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Web.admin.Bhb
{
    public partial class AreaEdit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private string pageLevelName = "khqy";
        string backPage = "Area.aspx";

        #region 自增字段
        int parentId = 0;
        #endregion

        BLL.T_Regional bll = new BLL.T_Regional();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            this.id = MXRequest.GetQueryInt("id");
            this.parentId = MXRequest.GetQueryInt("parentId");
            backPage = backPage + "?id=" + parentId;
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
                ChkAdminLevel(pageLevelName, MXEnums.ActionEnum.View.ToString()); //检查权限

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        void ShowInfo(int id)
        {
            Model.T_Regional model = bll.GetModel(id);
            txtTitle.Text = model.RName;
            txtSortId.Text = model.SortNum.ToString();
        }

        void DoAdd()
        {

            Model.T_Regional model = new Model.T_Regional();
            model.RName = txtTitle.Text.Trim();
            model.SortNum = Convert.ToInt32(txtSortId.Text.Trim());
            if (parentId > 0)
            {
                model.ParentID = parentId;
            }
            bll.Insert(model);
        }

        void DoEdit(int id)
        {
            Model.T_Regional model = new Model.T_Regional();
            model.ID = id;
            model.RName = txtTitle.Text.Trim();
            model.SortNum = Convert.ToInt32(txtSortId.Text.Trim());
            bll.Update(model);
        }
        protected void btnSure_Click(object sender, EventArgs e)
        {


            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel(pageLevelName, MXEnums.ActionEnum.Edit.ToString()); //检查权限
                DoEdit(this.id);
                JscriptMsg("修改成功！", backPage, "Success");
            }
            else //添加
            {
                ChkAdminLevel(pageLevelName, MXEnums.ActionEnum.Add.ToString()); //检查权限
                DoAdd();
                JscriptMsg("添加成功！", backPage, "Success");
            }
            // MessageBox.ResponseScript(this, " W.document.location='" + backPage + "';api.close();");
        }
    }
}