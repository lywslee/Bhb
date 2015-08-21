using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;

namespace Item.DAL.Common
{
    /// <summary>
    /// ��ȡ��С��� ���ݷ��ʲ�
    /// </summary>
    public class DGetMinSerial
    {
        /// <summary>
        /// ���ô洢���� ��ȡ��С���
        /// </summary>
        /// <param name="tableName">���ݱ���</param>
        /// <param name="columnName">��ȡ��ŵ���</param>
        /// <param name="leftStr">���Ԥ��������</param>
        /// <param name="lsLength">�Ҳ���ˮ��ŵĳ���</param>
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
