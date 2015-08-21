using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;

namespace Item.DAL.Common
{
    /// <summary>
    /// 获取最小编号 数据访问层
    /// </summary>
    public class DGetMinSerial
    {
        /// <summary>
        /// 调用存储过程 获取最小编号
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="columnName">获取编号的列</param>
        /// <param name="leftStr">左侧预定义数据</param>
        /// <param name="lsLength">右侧流水编号的长度</param>
        /// <returns>20120802000001</returns>
        public string GetMinBh(string tableName, string columnName, string leftStr, int lsLength)
        {

            SqlParameter[] parmas = new SqlParameter[]{
                 new SqlParameter ("@tableName",SqlDbType .VarChar ,100),
                 new SqlParameter ("@columnName",SqlDbType .VarChar ,100),
                 new SqlParameter ("@left",SqlDbType .VarChar ,100),
                 new SqlParameter("@lsLength",SqlDbType.Int)
            };
            parmas[0].Value = tableName;
            parmas[1].Value = columnName;
            parmas[2].Value = leftStr;
            parmas[3].Value = lsLength;

            DataTable dt = DbHelperSQL.ExecuteDataTable(CommandType.StoredProcedure, "PROC_GetMinSerial_Common", parmas);
            return dt.Rows[0][0].ToString();
        }

       
    }
}
