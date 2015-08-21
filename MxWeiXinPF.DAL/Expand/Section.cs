using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DBUtility;
using System.Collections.ObjectModel;
using Model;
namespace DAL
{
    //部门表
    public class Section : SectionBase
    {
        public Section()
            : base()
        { }
        #region 扩展方法
        /// <summary>
        /// 获得上下级顺序列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Model.SectionView> GetListByOrder(int parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SectionView where IsDelete=0 order by Sort asc,Id asc");
            List<Model.SectionView> listAll = Model.SectionView.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);

            //DataSet ds = DbHelperSQL.Query(strSql.ToString());
            //DataTable oldData = ds.Tables[0] as DataTable;
            //if (oldData == null)
            //{
            //    return null;
            //}
            ////复制结构
            //DataTable newData = oldData.Clone();
            List<Model.SectionView> listNew = new List<SectionView>();
            //调用迭代组合成DAGATABLE
            GetChilds(listAll, listNew, parentId);
            return listNew;
        }
        #endregion

        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(List<Model.SectionView> oldData, List<Model.SectionView> newData, int parent_id)
        {
            List<Model.SectionView> listChild = oldData.Where(o => o.ParentId == parent_id).ToList();
            foreach (var model in listChild)
            {

                newData.Add(model);
                //调用自身迭代
                this.GetChilds(oldData, newData, model.Id);
            }
        }
    }
}