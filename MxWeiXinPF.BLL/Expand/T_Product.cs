using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace BLL
{
    //T_Product
    public partial class T_Product : T_ProductBase
    {

        private readonly DAL.T_Product dal = new DAL.T_Product();
        public T_Product()
            : base()
        { }
        #region 扩展方法
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }
        #endregion
    }
}