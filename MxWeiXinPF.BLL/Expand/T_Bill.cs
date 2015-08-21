using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace BLL
{
    //T_Bill
    public partial class T_Bill : T_BillBase
    {

        private readonly DAL.T_Bill dal = new DAL.T_Bill();
        public T_Bill()
            : base()
        { }
        #region 扩展方法
        /// <summary>
        /// 根据条件统计
        /// </summary>
        /// <param name="sumFeild">统计字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="dateFeild">日期字段</param>
        /// <returns></returns>
        public DataTable GetListGroupBy(string sumFeild, string dateNum, string dateFeild, string strWhere)
        {
            return dal.GetListGroupBy(sumFeild,dateNum,dateFeild, strWhere);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetListTable(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetTableByPage(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        public Model.T_Bill GetModelToPrint(int ID)
        {
            return dal.GetModelToPrint(ID);
        }
        #endregion

        /// <summary>
        /// 导出Excel数据集
        /// </summary>
        /// <param name="sWhere"></param>
        /// <param name="sOrderby"></param>
        /// <returns></returns>
        public DataSet GetTableToExcel(string strWhere, string strOrderby)
        {
            return dal.GetTableToExcel(strWhere, strOrderby);
        }

        /// <summary>
        /// 导出Excel数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetSum(string strWhere)
        {
            return dal.GetSum(strWhere);
        }
    }
}