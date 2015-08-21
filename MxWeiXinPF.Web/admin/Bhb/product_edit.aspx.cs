using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Web.admin.manager
{
    /// <summary>
    /// 编辑用户
    /// </summary>
    public partial class product_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        //导航菜单 检测用户相关权限
        private const string NAV_NAME = "xtsz_cpwh";
        //列表URL
        private const string pageListUrl = "product_list.aspx";
        //业务逻辑
        BLL.T_Product bll = new BLL.T_Product();
        //Model
        Model.T_Product ModelInfo = new Model.T_Product();
        //管理员信息
        Model.dt_manager model_manager = new Model.dt_manager();

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

                //if (!new BLL.manager().Exists(this.id))
                //{
                //    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                //    return;
                //}
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.View.ToString()); //检查权限
                model_manager = GetAdminInfo(); //取得管理员信息

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                    this.txt_pName.Enabled = false;//名称不可编辑
                }
            }
        }

        #region 赋值操作=================================

        private void ShowInfo(int _id)
        {
            //获取实体对象
            ModelInfo = bll.GetModel(_id);

            //产品名称
            this.txt_pName.Text = ModelInfo.pName;

            //排序序号
            this.txtSortid.Text = MyCommFun.ObjToStr(ModelInfo.pSortNum);

            //备注
            this.txt_Remark.Text = ModelInfo.sRemark;
        }

        #endregion

        #region 增加操作=================================

        private bool DoAdd()
        {
            #region Model 赋值

            //产品名称
            ModelInfo.pName = this.txt_pName.Text.Trim();

            //排序序号
            ModelInfo.pSortNum = MyCommFun.Obj2Int(this.txtSortid.Text.ToString());

            //备注
            ModelInfo.sRemark = this.txt_Remark.Text.Trim();

            #endregion

            if (bll.Insert(ModelInfo) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加产品:" + ModelInfo.pName); //记录日志
                return true;
            }
            return false;
        }

        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;

            #region Model 赋值
            //全局唯一键
            ModelInfo.ID = _id;

            //产品名称
            ModelInfo.pName = this.txt_pName.Text.Trim();

            //排序序号
            ModelInfo.pSortNum = MyCommFun.Obj2Int(this.txtSortid.Text.ToString());

            //备注
            ModelInfo.sRemark = this.txt_Remark.Text.Trim();

            #endregion

            if (bll.Update(ModelInfo))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改会员:" + ModelInfo.pName); //记录日志
                result = true;
            }

            return result;
        }
        #endregion


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.Edit.ToString()); //检查权限

                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改产品信息成功！", pageListUrl, "Success");
            }
            else //添加
            {
                ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.Add.ToString()); //检查权限

                //检测名称是否存在
                string strWhere = "";
                strWhere = " and pName='" + this.txt_pName.Text.Trim() + "'";
                if (bll.GetCount(strWhere) > 0)
                {
                    JscriptMsg("该产品名称已经存在，不能重复添加！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加产品信息成功！", pageListUrl, "Success");
            }
        }
    }
}