using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace BLL {
	 	//部门表
		public partial class SectionBase
	{
   		     
		private readonly DAL.SectionBase dal=new DAL.SectionBase();
		public SectionBase()
		{}
		
		#region  生成代码
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Insert(Model.Section model)
		{
						return dal.Insert(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Section model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}
		
		/// <summary>
		/// 根据Id得到一个对象实体
		/// </summary>
		public Model.Section GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}
  		/// <summary>
		/// 获得指定条件的唯一一条数据实体
		/// </summary>
		public Model.Section GetModel(string strWhere)
		{
			return dal.GetModel(strWhere);
		}
		/// <summary>
        /// 分页查询
		/// </summary>
		/// <param name="pageSize">每页数据条数</param>
		/// <param name="pageIndex">当前页码</param>
		/// <param name="strWhere">查询条件</param>
		/// <param name="filedOrder">排序语句</param>
		/// <param name="recordCount">记录总数</param>
		/// <returns></returns>
		public List<Model.Section> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{
			return dal.GetListByPage(pageSize,pageIndex,strWhere,filedOrder,out recordCount);
		}
		/// <summary>
		/// 获得记录总数
		/// </summary>
		public int GetCount(string strWhere)
		{
			return dal.GetCount(strWhere);
		}
		/// <summary>
		/// 获得数据列表List 
		/// </summary>
		public List<Model.Section> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Model.Section> GetTopList(int top,string 
strWhere,string orderField)
		{
			return dal.GetTopList(top,strWhere,orderField);
		}
		
		/// <summary>
		/// 获得数据列表DataTable 
		/// </summary>
		public DataTable GetDataTable(string where)
		{
			return dal.GetDataTable(where);
		}
#endregion
   
	}
}