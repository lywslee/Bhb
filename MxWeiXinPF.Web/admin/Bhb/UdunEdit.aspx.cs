using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Web.admin.Bhb
{
    public partial class UdunEdit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private string levelName = "xtsz_u";
        string backUrl = "Udun.aspx";

        #region 自增字段
        #endregion

        BLL.T_Ushield bll = new BLL.T_Ushield();
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

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        void ShowInfo(int id)
        {
            Model.T_Ushield model = bll.GetModel(id);
            txtUName.Text = model.UName;
            txtHardWareCode.Text = model.HardWareCode;
            txtSeed.Text = model.Seed;
            txtUKey.Text = model.UKey;
            txtRemark.Text = model.Remark;
        }

        protected void btnSure_Click(object sender, EventArgs e)
        {
            #region model赋值
            Model.T_Ushield model = new Model.T_Ushield();
            model.Remark = txtRemark.Text;
            model.Seed = txtSeed.Text.Trim();
            model.UKey = txtUKey.Text.Trim();
            model.UName = txtUName.Text.Trim();
            model.HardWareCode = txtHardWareCode.Text.Trim();
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
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), GetAdminInfo().real_name + " 修改U盾:" + model.UName); //记录日志
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
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), GetAdminInfo().real_name + " 添加U盾:" + model.UName); //记录日志
                JscriptMsg("添加信息成功！", backUrl, "Success");
            }
        }
    }
}