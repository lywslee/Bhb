using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DBUtility;
using System.Collections.ObjectModel;
using Model;
using Common;
namespace DAL  
{
	 	//T_Customer
		public class T_Customer:T_CustomerBase
	{
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   c.*,d.dName,r.RName as OneRName,tr.RName as TwoRName,td.dName as BankNameDic   FROM [T_Customer] c left join [T_Dictionary] d on c.CLevel=d.ID left join T_Regional r on c.OneRegional=r.ID left join T_Regional tr on c.TwoRegional=tr.ID  left join T_Dictionary td on c.BankName=td.ID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0];
        }
        public bool Exists(string idCard)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_Customer]");
            strSql.Append(" where ");
            strSql.Append(" CardNumber = @CardNumber  ");
            SqlParameter[] parameters = {
					new SqlParameter("@CardNumber", SqlDbType.VarChar,50)
			};
            parameters[0].Value = idCard;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion
	}
}