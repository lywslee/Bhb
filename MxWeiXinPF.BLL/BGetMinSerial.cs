using System;
using System.Collections.Generic;
using System.Text;

namespace Item.BLL.Common
{
    /// <summary>
    /// ��ȡ���ݱ������ţ�����һ������
    /// </summary>
    public  class GetMinSerial
    {
        private static readonly Item.DAL.Common.DGetMinSerial dal = new DAL.Common.DGetMinSerial();

        /// <summary>
        /// �õ�һ�ű��е���С���
        /// </summary>
        /// <param name="tableName">����</param>
        /// <param name="columnName">�ֶ���</param>
        /// <param name="len">����</param>
        /// <param name="left">��ʼλ��</param>
        /// <returns>string���͵ı��</returns>
        public static string GetMinBH(string tableName, string columnName, string left, int length)
        {
            return dal.GetMinBh(tableName, columnName, left, length);
        }
    }
}
