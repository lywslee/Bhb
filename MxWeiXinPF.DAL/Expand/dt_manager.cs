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
	 	//管理员表
		public class dt_manager:dt_managerBase
	{
		public dt_manager():base()
		{}
		#region 扩展方法
        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_manager");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.dt_manager GetModel(string user_name, string password)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select id from dt_manager");
            strSql.Append(" where user_name=@user_name and password=@password and is_lock=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@password", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            parameters[1].Value = password;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   m.*,s.Name  FROM dt_manager m left join Section s on m.SectionId=s.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where m.id!=1 and " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        public string GetSalt(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 salt from dt_manager");
            strSql.Append(" where user_name=@user_name");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            string salt = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(salt))
            {
                return "";
            }
            return salt;
        }
        #endregion
	}
}