using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace BLL
{
    //T_Standard
    public partial class T_Standard : T_StandardBase
    {

        private readonly DAL.T_Standard dal = new DAL.T_Standard();
        public T_Standard()
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