using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace BLL {
	 	//部门表
		public partial class Section:SectionBase
	{
   		     
		private readonly DAL.Section dal=new DAL.Section();
		public Section():base()
		{}
		#region 扩展方法
             /// <summary>
        /// 获得上下级顺序列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Model.SectionView> GetListByOrder(int parentId)
        {
            return dal.GetListByOrder(parentId);
        }
        #endregion
	}
}