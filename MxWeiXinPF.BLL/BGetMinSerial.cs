using System;
using System.Collections.Generic;
using System.Text;

namespace Item.BLL.Common
{
    /// <summary>
    /// 获取数据表中最编号（符合一定规则）
    /// </summary>
    public  class GetMinSerial
    {
        private static readonly Item.DAL.Common.DGetMinSerial dal = new DAL.Common.DGetMinSerial();

        /// <summary>
        /// 得到一张表中的最小编号
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">字段名</param>
        /// <param name="len">长度</param>
        /// <param name="left">起始位置</param>
        /// <returns>string类型的编号</returns>
        public static string GetMinBH(string tableName, string columnName, string left, int length)
        {
            return dal.GetMinBh(tableName, columnName, left, length);
        }
    }
}
