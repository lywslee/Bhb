using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Web.admin.Bhb
{
    public partial class DicEdit : Web.UI.ManagePage
    {
        string levelName = "xtsz_sjzd";
        string backUrl = "Dic.aspx";

        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        BLL.T_Dictionary bll = new BLL.T_Dictionary();
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
                        this.ddlParentId.SelectedValue = bll.GetModel(id).dNum;
                    }
                }
            }
        }

        #region 绑定菜单=============================
        private void TreeBind(string nav_type)
        {


            List<Model.T_Dictionary> list = bll.GetList(" and dType='00' order by dSortNum asc");

            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("无父级菜单", "00"));
            foreach (var m in list)
            {

                this.ddlParentId.Items.Add(new ListItem(m.dName, m.dNum));

            }
        }
        #endregion


        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            Model.T_Dictionary model = bll.GetModel(_id);

            ddlParentId.SelectedValue = model.dType.ToString();
            txtSortId.Text = model.dSortNum.ToString();
            txtName.Text = model.dName;
            txtNum.Text = model.dNum;

        }
        #endregion

        protected void btnSure_Click(object sender, EventArgs e)
        {
            #region model赋值
            Model.T_Dictionary model = new Model.T_Dictionary();
            model.dType = ddlParentId.SelectedValue;
            model.dNum = txtNum.Text.Trim();
            model.dName = txtName.Text.Trim();
            model.dSortNum = Convert.ToInt32(txtSortId.Text);
            if (model.dType == "00")
            {
                model.dLevel = 1;
            }
            else
            {
                model.dLevel = 2;
            }
            if (bll.GetCount(" and dNum='" + model.dNum + "' and dType='" + model.dType + "' and ID!=" + id) > 0 || model.dNum == "00")
            {
                JscriptMsg("相同父级下的菜单标号不能重复！", "", "Error");
                return;
            }
            #endregion


            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                model.ID = id;

                ChkAdminLevel(levelName, MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!bll.Update(model))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), GetAdminInfo().real_name + " 修改数据字典:" + model.dName); //记录日志
                JscriptMsg("修改信息成功！", backUrl, "Success");
            }
            else //添加
            {
                ChkAdminLevel(levelName, MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (bll.Insert(model) <= 0)
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), GetAdminInfo().real_name + " 添加数据字典:" + model.dName); //记录日志
                JscriptMsg("添加信息成功！", backUrl, "Success");
            }
        }

    }
}