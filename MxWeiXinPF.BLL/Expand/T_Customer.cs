using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace BLL {
	 	//T_Customer
		public partial class T_Customer:T_CustomerBase
	{
   		     
		private readonly DAL.T_Customer dal=new DAL.T_Customer();
		public T_Customer():base()
		{}
		#region 扩展方法
             /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="filedOrder">排序语句</param>
        /// <param name="recordCount">记录总数</param>
        /// <returns></returns>
        public DataTable GetListByView(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetListByView(pageSize,pageIndex,strWhere,filedOrder,out recordCount);
        }
        public bool Exists(string idCard)
        {
            return dal.Exists(idCard);
        }
        #endregion
	}
}