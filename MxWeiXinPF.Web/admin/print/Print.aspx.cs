using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Web.admin.Bhb
{
    /// <summary>
    /// 收料单打印
    /// </summary>
    public partial class Print : Web.UI.ManagePage
    {
        //业务逻辑
        public BLL.T_Bill bll = new BLL.T_Bill();
        //Model
        public Model.T_Bill ModelInfo = new Model.T_Bill();
        //管理员信息
        Model.dt_manager manager_model = new Model.dt_manager();

        public string je = "0.00";
        public int id =0;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            id = MyCommFun.Obj2Int(MXRequest.GetQueryString("id"));
            ModelInfo = bll.GetModelToPrint(id);
            if (ModelInfo != null)
            {
                //金额大小写转换
                je = RMBUtil.CmycurD(ModelInfo.Amount);
            }
            else
            {
                ModelInfo = new Model.T_Bill();
            }

            base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script> PrintTable();</script>");
        }
    }
}