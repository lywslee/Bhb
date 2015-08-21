using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace BLL {
	 	//T_Dictionary
		public partial class T_Dictionary:T_DictionaryBase
	{
   		     
		private readonly DAL.T_Dictionary dal=new DAL.T_Dictionary();
		public T_Dictionary():base()
		{}
		#region 扩展方法
            /// <summary>
        /// 获得上下级顺序列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Model.T_Dictionary> GetListByOrder(string dNum)
        {
            return dal.GetListByOrder(dNum);
        }
        #endregion
	}
}