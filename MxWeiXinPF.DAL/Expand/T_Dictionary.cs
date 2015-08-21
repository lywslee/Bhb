using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DBUtility;
using System.Collections.ObjectModel;
using Model;
using System.Linq;
namespace DAL  
{
	 	//T_Dictionary
		public class T_Dictionary:T_DictionaryBase
	{
		public T_Dictionary():base()
		{}
		#region 扩展方法
        /// <summary>
        /// 获得上下级顺序列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Model.T_Dictionary> GetListByOrder(string dType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Dictionary   order by dSortNum asc");
            List<Model.T_Dictionary> listAll = Model.T_Dictionary.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);

            List<Model.T_Dictionary> listNew = new List<Model.T_Dictionary>();
            //调用迭代组合成DAGATABLE
            GetChilds(listAll, listNew, dType);
            return listNew;
        }
        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(List<Model.T_Dictionary> oldData, List<Model.T_Dictionary> newData, string dType)
        {
            List<Model.T_Dictionary> listChild = oldData.Where(o => o.dType == dType).ToList();
            foreach (var model in listChild)
            {

                newData.Add(model);
                //调用自身迭代
                this.GetChilds(oldData, newData, model.dNum);
            }
        }
        #endregion
	}
}