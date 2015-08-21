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
    /// 编辑收料单
    /// </summary>
    public partial class bill_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        //导航菜单 检测用户相关权限
        private const string NAV_NAME = "cggl_sldj";
        //列表URL
        private const string pageListUrl = "bill_list.aspx";
        //业务逻辑
        BLL.T_Bill bll = new BLL.T_Bill();
        //Model
        Model.T_Bill ModelInfo = new Model.T_Bill();
        //管理员信息
        Model.dt_manager manager_model = new Model.dt_manager();

        public int result = 0;//增加时的ID

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
            }

            manager_model = GetAdminInfo();         //取得管理员信息

            if (!Page.IsPostBack)
            {
                ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.View.ToString()); //检查权限

                BindDropDownList(ddl_WareHouse, "D02");  //绑定仓库
                BindDropDownList(ddl_BankName, "D03");  //绑定代发银行
                BindDDL_Product(ddl_ProductName);       //绑定产品
                if (ddl_ProductName.Items.Count > 0)
                {
                    BindDDL_ProductStand(ddl_ProductStandard, ddl_ProductName.SelectedItem.Value);//产品规格
                }
                else
                {
                    BindDDL_ProductStand(ddl_ProductStandard, "0");//产品规格
                }

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定下拉框

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dType">数据字典类型</param>
        private void BindDropDownList(DropDownList ddl, string dType)
        {
            string strWhere = "";//条件
            strWhere = " and dType='" + dType + "'";
            BLL.T_Dictionary bll = new BLL.T_Dictionary();
            DataTable dt = bll.GetDataTable(strWhere);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("无", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["dName"].ToString(), dr["dNum"].ToString()));
            }
        }
        /// <summary>
        /// 绑定产品
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dType">数据字典类型</param>
        private void BindDDL_Product(DropDownList ddl)
        {

            BLL.T_Product bll = new BLL.T_Product();
            DataTable dt = bll.GetDataTable("");

            ddl.Items.Clear();
            //ddl.Items.Add(new ListItem("无", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["pName"].ToString(), dr["ID"].ToString()));
            }
        }

        /// <summary>
        /// 绑定规格
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dType">数据字典类型</param>
        private void BindDDL_ProductStand(DropDownList ddl, string productID)
        {
            string strWhere = "";//条件
            strWhere = " and sProductNum='" + productID + "'";
            BLL.T_Standard bll = new BLL.T_Standard();
            DataTable dt = bll.GetDataTable(strWhere);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["sName"].ToString(), dr["ID"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================

        private void ShowInfo(int _id)
        {
            //获取实体对象
            ModelInfo = bll.GetModel(_id);

            //收料编号
            txt_BNum.Text = ModelInfo.BNum;
            //存放仓库
            ddl_WareHouse.SelectedValue = ModelInfo.WareHouse;
            //客户姓名
            txt_CustomerName.Text = ModelInfo.CustomerName;
            //移动电话
            txt_Mobile.Text = ModelInfo.Mobile;
            //固定电话
            txt_Tel.Text = ModelInfo.Tel;
            //代发银行
            ddl_BankName.SelectedValue = ModelInfo.BankName;
            //银行账号
            txt_BankAccount.Text = ModelInfo.BankAccount;
            //户名
            txt_AccountName.Text = ModelInfo.AccountName;
            //产品名称ID
            ddl_ProductName.SelectedValue = MyCommFun.ObjToStr(ModelInfo.ProjectId);
            //产品规格ID
            ddl_ProductStandard.SelectedValue = MyCommFun.ObjToStr(ModelInfo.ProductStandardId);
            //单位
            txt_Unit.Text = ModelInfo.Unit;
            //毛重
            txt_GrossWeight.Text = MyCommFun.ObjToStr(ModelInfo.GrossWeight);
            //皮重
            txt_Tare.Text = MyCommFun.ObjToStr(ModelInfo.Tare);
            //净重
            txt_NetWeight.Value = MyCommFun.ObjToStr(ModelInfo.NetWeight);
            //价格
            txt_Price.Text = MyCommFun.ObjToStr(ModelInfo.Price);
            //金额
            txt_Amount.Value = MyCommFun.ObjToStr(ModelInfo.Amount);

            //备注
            this.txt_Remark.Text = ModelInfo.Remark;
        }

        #endregion

        #region 增加操作=================================

        private bool DoAdd()
        {
            #region Model 赋值

            //收料编号
            ModelInfo.BNum = Item.BLL.Common.GetMinSerial.GetMinBH("T_Bill", "BNum", DateTime.Now.ToString("yyMMdd"), 4);
            //存放仓库
            ModelInfo.WareHouse = ddl_WareHouse.SelectedValue;
            //客户姓名
            ModelInfo.CustomerName = txt_CustomerName.Text.Trim();
            //移动电话
            ModelInfo.Mobile = txt_Mobile.Text.Trim();
            //固定电话
            ModelInfo.Tel = txt_Tel.Text.Trim();
            //代发银行
            ModelInfo.BankName = ddl_BankName.SelectedValue;
            //银行账号
            ModelInfo.BankAccount = txt_BankAccount.Text.Trim();
            //户名
            ModelInfo.AccountName = txt_AccountName.Text.Trim();
            //产品名称ID
            ModelInfo.ProjectId = MyCommFun.Obj2Int(ddl_ProductName.SelectedValue);
            //产品名称
            ModelInfo.ProductName = ddl_ProductName.SelectedItem.Text;
            //产品规格ID
            ModelInfo.ProductStandardId = MyCommFun.Obj2Int(ddl_ProductStandard.SelectedValue);
            //产品规格名称
            ModelInfo.ProductStandard = ddl_ProductStandard.SelectedItem.Text;
            //单位
            ModelInfo.Unit = txt_Unit.Text.Trim();
            //毛重
            ModelInfo.GrossWeight = MyCommFun.Obj2Decimal(txt_GrossWeight.Text, 0);
            //皮重
            ModelInfo.Tare = MyCommFun.Obj2Decimal(txt_Tare.Text, 0);
            //净重
            ModelInfo.NetWeight = MyCommFun.Obj2Decimal(txt_NetWeight.Value, 0);
            //价格
            ModelInfo.Price = MyCommFun.Obj2Decimal(txt_Price.Text, 0);
            //金额
            ModelInfo.Amount = MyCommFun.Obj2Decimal(txt_Amount.Value, 0);
            //备注
            ModelInfo.Remark = this.txt_Remark.Text.Trim();
            //添加人
            ModelInfo.AddPerson = manager_model.real_name;
            //添加时间
            ModelInfo.AddTime = DateTime.Now;

            #endregion

            result = bll.Insert(ModelInfo);
            if (result > 0)
            {

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加收料单:" + ModelInfo.BNum); //记录日志
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
            //存放仓库
            ModelInfo.WareHouse = ddl_WareHouse.SelectedValue;
            //客户姓名
            ModelInfo.CustomerName = txt_CustomerName.Text.Trim();
            //移动电话
            ModelInfo.Mobile = txt_Mobile.Text.Trim();
            //固定电话
            ModelInfo.Tel = txt_Tel.Text.Trim();
            //代发银行
            ModelInfo.BankName = ddl_BankName.SelectedValue;
            //银行账号
            ModelInfo.BankAccount = txt_BankAccount.Text.Trim();
            //户名
            ModelInfo.AccountName = txt_AccountName.Text.Trim();
            //产品名称ID
            ModelInfo.ProjectId = MyCommFun.Obj2Int(ddl_ProductName.SelectedValue);
            //产品名称
            ModelInfo.ProductName = ddl_ProductName.SelectedItem.Text;
            //产品规格ID
            ModelInfo.ProductStandardId = MyCommFun.Obj2Int(ddl_ProductStandard.SelectedValue);
            //产品规格名称
            ModelInfo.ProductStandard = ddl_ProductStandard.SelectedItem.Text;
            //单位
            ModelInfo.Unit = txt_Unit.Text.Trim();
            //毛重
            ModelInfo.GrossWeight = MyCommFun.Obj2Decimal(txt_GrossWeight.Text, 0);
            //皮重
            ModelInfo.Tare = MyCommFun.Obj2Decimal(txt_Tare.Text, 0);
            //净重
            ModelInfo.NetWeight = MyCommFun.Obj2Decimal(txt_NetWeight.Value, 0);
            //价格
            ModelInfo.Price = MyCommFun.Obj2Decimal(txt_Price.Text, 0);
            //金额
            ModelInfo.Amount = MyCommFun.Obj2Decimal(txt_Amount.Value, 0);

            //备注
            ModelInfo.Remark = this.txt_Remark.Text.Trim();
            //修改人
            ModelInfo.ModifyPerson = manager_model.real_name;
            //修改时间
            ModelInfo.ModifyTime = DateTime.Now;

            #endregion

            if (bll.Update(ModelInfo))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改收料单:" + ModelInfo.BNum); //记录日志
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
                //如果打印
                if (ck_print.Checked)
                {
                    //JscriptMsg(ModelInfo.BNum, "", "Error");
                    MessageBox.ResponseScript(this, "window.showModalDialog('../print/Print.aspx?id=" + id + "', '', 'dialogWidth:900px;DialogHeight=500px;status:no;help:no;resizable:yes;');window.location.href='bill_list.aspx'");
                    return;
                }
                JscriptMsg("修改收料信息成功！", pageListUrl, "Success");
            }
            else //添加
            {
                ChkAdminLevel(NAV_NAME, MXEnums.ActionEnum.Add.ToString()); //检查权限


                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                //如果打印
                if (ck_print.Checked)
                {
                    //JscriptMsg(ModelInfo.BNum, "", "Error");
                    MessageBox.ResponseScript(this, "window.showModalDialog('../print/Print.aspx?id=" + result + "', '', 'dialogWidth:900px;DialogHeight=500px;status:no;help:no;resizable:yes;');");
                    return;
                }
                JscriptMsg("添加收料信息成功！", pageListUrl, "Success");
            }
        }

        /// <summary>
        /// 产品变化时，规格也变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_ProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //产品编号
            string productID = ddl_ProductName.SelectedItem.Value;
            BindDDL_ProductStand(ddl_ProductStandard, productID);
        }
    }
}