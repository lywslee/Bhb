using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.Data;

namespace Web.admin.Bhb
{
    public partial class CustomerEdit : Web.UI.ManagePage
    {
        #region 自有字段
        string levelName = "khgl_khxx";
        public string backUrl = "Customer.aspx";
        public string parentName = "客户管理";
        public string pageName = "客户编辑";
        #endregion
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        BLL.T_Customer bll = new BLL.T_Customer();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!bll.Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }

            }


            if (!Page.IsPostBack)
            {
                ChkAdminLevel(levelName, MXEnums.ActionEnum.View.ToString()); //检查权限
                DdlBind();

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定ddl=================================
        private void DdlBind()
        {
            //绑定客户类型
            BLL.T_Dictionary B_Dic = new BLL.T_Dictionary();
            List<Model.T_Dictionary> L_Dic = B_Dic.GetList(" and dType='D01'");
            ddlType.DataSource = L_Dic;
            ddlType.DataTextField = "dName";
            ddlType.DataValueField = "ID";
            ddlType.DataBind();

            //绑定一级区域
            BLL.T_Regional B_Reg = new BLL.T_Regional();
            List<Model.T_Regional> L_Reg = B_Reg.GetList(" and ParentID=0 order by SortNum asc,ID asc");
            Model.T_Regional M_Reg = new Model.T_Regional();
            M_Reg.ID = 0;
            M_Reg.RName = "无";
            M_Reg.SortNum = 0;
            L_Reg.Add(M_Reg);
            L_Reg = L_Reg.OrderBy(o => o.SortNum).ToList();
            ddlOneArea.DataSource = L_Reg;
            ddlOneArea.DataTextField = "RName";
            ddlOneArea.DataValueField = "ID";
            ddlOneArea.DataBind();

            //绑定二级区域
            List<Model.T_Regional> L_RegTwo = new List<Model.T_Regional>();
            L_RegTwo.Add(M_Reg);
            ddlTwoArea.DataSource = L_RegTwo;
            ddlTwoArea.DataTextField = "RName";
            ddlTwoArea.DataValueField = "ID";
            ddlTwoArea.DataBind();

            //绑定银行
            List<Model.T_Dictionary> L_DicBank = B_Dic.GetList(" and dType='D03'");
            Model.T_Dictionary M_Dic = new Model.T_Dictionary();
            M_Dic.ID = 0;
            M_Dic.dName = "无";
            M_Dic.dSortNum = 0;
            L_DicBank.Add(M_Dic);
            L_DicBank = L_DicBank.OrderBy(o => o.dSortNum).ToList();
            ddlBank.DataSource = L_DicBank;
            ddlBank.DataTextField = "dName";
            ddlBank.DataValueField = "ID";
            ddlBank.DataBind();
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {

            Model.T_Customer model = bll.GetModel(_id);
            ddlType.SelectedValue = model.CLevel.ToString();
            ddlOneArea.SelectedValue = model.OneRegional.ToString();
            ddlTwoArea.SelectedValue = model.TwoRegional.ToString();
            txtRealName.Text = model.CName;
            txtIdCard.Text = model.CardNumber;
            txtTelephone.Text = model.Tel;
            txtMobile.Text = model.Mobile;
            ddlBank.SelectedValue = model.BankName;
            txtBankAccount.Text = model.BankAccount;
            txtAcountName.Text = model.AcountName;
            txtArea.Text = model.Address;
        }
        #endregion 
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region model赋值
            Model.T_Customer model = new Model.T_Customer();
            model.CLevel = Convert.ToInt32(ddlType.SelectedValue);
            model.OneRegional = Convert.ToInt32(ddlOneArea.SelectedValue);
            model.TwoRegional = Convert.ToInt32(ddlTwoArea.SelectedValue);
            model.CName = txtRealName.Text.Trim();
            model.CardNumber = txtIdCard.Text.Trim();
            model.Tel = txtTelephone.Text.Trim();
            model.Mobile = txtMobile.Text.Trim();
            model.BankName = ddlBank.SelectedValue;
            model.BankAccount = txtBankAccount.Text.Trim();
            model.AcountName = txtAcountName.Text.Trim();
            model.Address = txtArea.Text.Trim();

            if (bll.GetCount(" and ID<>" + id + " and CardNumber='" + model.CardNumber + "'") > 0)
            {
                JscriptMsg("客户身份证号码重复，请核对客户信息！", "", "Error");
                return;
            }
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                model.ID = id;
            }
            else
            {
                model.AddTime = DateTime.Now;
                model.AddPerson = GetAdminInfo().real_name;
            }
            #endregion


            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel(levelName, MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!bll.Update(model))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), GetAdminInfo().real_name + " 修改客户:" + model.CName); //记录日志
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
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加客户:" + model.CName); //记录日志
                JscriptMsg("添加信息成功！", backUrl, "Success");
            }
        }

        protected void ddlOneArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parentId = Convert.ToInt32(ddlOneArea.SelectedValue);
            BLL.T_Regional bll = new BLL.T_Regional();
            List<Model.T_Regional> L_Reg = bll.GetList(" and ParentID=" + parentId);
            Model.T_Regional M_Reg = new Model.T_Regional();
            M_Reg.ID = 0;
            M_Reg.RName = "无";
            M_Reg.SortNum = 0;
            L_Reg.Add(M_Reg);
            L_Reg = L_Reg.OrderBy(o => o.SortNum).ToList();
            ddlTwoArea.DataSource = L_Reg;
            ddlTwoArea.DataTextField = "RName";
            ddlTwoArea.DataValueField = "ID";
            ddlTwoArea.DataBind();
        }
    }
}