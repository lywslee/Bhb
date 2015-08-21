using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace Web.admin.Bhb.ajax
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            switch (action)
            {
                case "CheckIdCard":
                    {
                        IdCard_validate(context);
                        break;
                    }
            }
        }
        #region 验证管理员用户名是否重复========================
        private void IdCard_validate(HttpContext context)
        {
            string idCard = MXRequest.GetString("param").Trim();
            int id = MXRequest.GetQueryInt("id");
            if (string.IsNullOrEmpty(idCard))
            {
                context.Response.Write("{ \"info\":\"请输入身份证号\", \"status\":\"n\" }");
                return;
            }
            BLL.T_Customer bll = new BLL.T_Customer();
            if (bll.GetCount(" and ID<>" + id + " and CardNumber='" + idCard + "'") > 0)
            {
                context.Response.Write("{ \"info\":\"客户身份证号码重复，请核对客户信息！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"身份证号码可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}