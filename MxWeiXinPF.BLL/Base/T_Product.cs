using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace BLL
{
    //T_Product
    public partial class T_ProductBase
    {

        private readonly DAL.T_ProductBase dal = new DAL.T_ProductBase();
        public T_ProductBase()
        { }

        #region  生成代码
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Insert(Model.T_Product model)
        {
            return dal.Insert(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.T_Product model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        public Model.T_Product GetModel(int ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 获得指定条件的唯一一条数据实体
        /// </summary>
        public Model.T_Product GetModel(string strWhere)
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
        public List<Model.T_Product> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetListByPage(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
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
        public List<Model.T_Product> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Model.T_Product> GetTopList(int top, string strWhere, string orderField)
        {
            return dal.GetTopList(top, strWhere, orderField);
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