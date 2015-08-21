using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Model
{
    //部门表
    public class Section
    {

        #region 数据库私有字段
        private int _id = 0;//主键
        private string _name = string.Empty;//部门名称
        private int _parentid = 0;//上级部门Id
        private string _num = string.Empty;//部门编号
        private string _ordernum = string.Empty;//级次编号（00010001）
        private int _sort = 0;//排序序号
        private int _leaderid = 0;//负责人Id
        private string _ext1 = string.Empty;//Ext1
        private string _ext2 = string.Empty;//Ext2
        private int _isdelete = 0;//是否删除（0：否 1：是）
        private int _levelnum = 0;//第几级，从1开始
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _name_IsEdit = false;
        private bool _parentid_IsEdit = false;
        private bool _num_IsEdit = false;
        private bool _ordernum_IsEdit = false;
        private bool _sort_IsEdit = false;
        private bool _leaderid_IsEdit = false;
        private bool _ext1_IsEdit = false;
        private bool _ext2_IsEdit = false;
        private bool _isdelete_IsEdit = false;
        private bool _levelnum_IsEdit = false;
        #endregion
        #region  公开属性
        /// <summary>
        /// 主键
        /// </summary>		
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id_IsEdit = true;
                _isEdit = true;
                _id = value;
            }
        }
        /// <summary>
        /// 部门名称
        /// </summary>		
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name_IsEdit = true;
                _isEdit = true;
                _name = value;
            }
        }
        /// <summary>
        /// 上级部门Id
        /// </summary>		
        public int ParentId
        {
            get
            {
                return _parentid;
            }
            set
            {
                _parentid_IsEdit = true;
                _isEdit = true;
                _parentid = value;
            }
        }
        /// <summary>
        /// 部门编号
        /// </summary>		
        public string Num
        {
            get
            {
                return _num;
            }
            set
            {
                _num_IsEdit = true;
                _isEdit = true;
                _num = value;
            }
        }
        /// <summary>
        /// 级次编号（00010001）
        /// </summary>		
        public string OrderNum
        {
            get
            {
                return _ordernum;
            }
            set
            {
                _ordernum_IsEdit = true;
                _isEdit = true;
                _ordernum = value;
            }
        }
        /// <summary>
        /// 排序序号
        /// </summary>		
        public int Sort
        {
            get
            {
                return _sort;
            }
            set
            {
                _sort_IsEdit = true;
                _isEdit = true;
                _sort = value;
            }
        }
        /// <summary>
        /// 负责人Id
        /// </summary>		
        public int LeaderId
        {
            get
            {
                return _leaderid;
            }
            set
            {
                _leaderid_IsEdit = true;
                _isEdit = true;
                _leaderid = value;
            }
        }
        /// <summary>
        /// Ext1
        /// </summary>		
        public string Ext1
        {
            get
            {
                return _ext1;
            }
            set
            {
                _ext1_IsEdit = true;
                _isEdit = true;
                _ext1 = value;
            }
        }
        /// <summary>
        /// Ext2
        /// </summary>		
        public string Ext2
        {
            get
            {
                return _ext2;
            }
            set
            {
                _ext2_IsEdit = true;
                _isEdit = true;
                _ext2 = value;
            }
        }
        /// <summary>
        /// 是否删除（0：否 1：是）
        /// </summary>		
        public int IsDelete
        {
            get
            {
                return _isdelete;
            }
            set
            {
                _isdelete_IsEdit = true;
                _isEdit = true;
                _isdelete = value;
            }
        }
        /// <summary>
        /// 第几级，从1开始
        /// </summary>		
        public int LevelNum
        {
            get
            {
                return _levelnum;
            }
            set
            {
                _levelnum_IsEdit = true;
                _isEdit = true;
                _levelnum = value;
            }
        }
        public bool IsEdit
        {
            get
            {
                return _isEdit;
            }
            set
            {
                if (value == false)
                {
                    // 将全部字段的IsDirty值设置为false
                    _id_IsEdit = false;
                    _name_IsEdit = false;
                    _parentid_IsEdit = false;
                    _num_IsEdit = false;
                    _ordernum_IsEdit = false;
                    _sort_IsEdit = false;
                    _leaderid_IsEdit = false;
                    _ext1_IsEdit = false;
                    _ext2_IsEdit = false;
                    _isdelete_IsEdit = false;
                    _levelnum_IsEdit = false;
                }
            }
        }
        /// <summary>
        /// Id是否已修改
        /// </summary>		
        public bool Id_IsEdit
        {
            get
            {
                return _id_IsEdit;
            }
        }
        /// <summary>
        /// Name是否已修改
        /// </summary>		
        public bool Name_IsEdit
        {
            get
            {
                return _name_IsEdit;
            }
        }
        /// <summary>
        /// ParentId是否已修改
        /// </summary>		
        public bool ParentId_IsEdit
        {
            get
            {
                return _parentid_IsEdit;
            }
        }
        /// <summary>
        /// Num是否已修改
        /// </summary>		
        public bool Num_IsEdit
        {
            get
            {
                return _num_IsEdit;
            }
        }
        /// <summary>
        /// OrderNum是否已修改
        /// </summary>		
        public bool OrderNum_IsEdit
        {
            get
            {
                return _ordernum_IsEdit;
            }
        }
        /// <summary>
        /// Sort是否已修改
        /// </summary>		
        public bool Sort_IsEdit
        {
            get
            {
                return _sort_IsEdit;
            }
        }
        /// <summary>
        /// LeaderId是否已修改
        /// </summary>		
        public bool LeaderId_IsEdit
        {
            get
            {
                return _leaderid_IsEdit;
            }
        }
        /// <summary>
        /// Ext1是否已修改
        /// </summary>		
        public bool Ext1_IsEdit
        {
            get
            {
                return _ext1_IsEdit;
            }
        }
        /// <summary>
        /// Ext2是否已修改
        /// </summary>		
        public bool Ext2_IsEdit
        {
            get
            {
                return _ext2_IsEdit;
            }
        }
        /// <summary>
        /// IsDelete是否已修改
        /// </summary>		
        public bool IsDelete_IsEdit
        {
            get
            {
                return _isdelete_IsEdit;
            }
        }
        /// <summary>
        /// LevelNum是否已修改
        /// </summary>		
        public bool LevelNum_IsEdit
        {
            get
            {
                return _levelnum_IsEdit;
            }
        }
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public static Model.Section FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public static Model.Section FillModelByRow(DataRow row)
        {
            Model.Section model = new Model.Section();
            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }
            model.Name = row["Name"].ToString

();
            if (row["ParentId"].ToString() != "")
            {
                model.ParentId = int.Parse(row["ParentId"].ToString());
            }
            model.Num = row["Num"].ToString

();
            model.OrderNum = row["OrderNum"].ToString

();
            if (row["Sort"].ToString() != "")
            {
                model.Sort = int.Parse(row["Sort"].ToString());
            }
            if (row["LeaderId"].ToString() != "")
            {
                model.LeaderId = int.Parse(row["LeaderId"].ToString());
            }
            model.Ext1 = row["Ext1"].ToString

();
            model.Ext2 = row["Ext2"].ToString

();
            if (row["IsDelete"].ToString() != "")
            {
                model.IsDelete = int.Parse(row["IsDelete"].ToString());
            }
            if (row["LevelNum"].ToString() != "")
            {
                model.LevelNum = int.Parse(row["LevelNum"].ToString());
            }

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public static List<Model.Section> FillList(DataTable dt)
        {
            List<Model.Section> list = new List<Model.Section>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(FillModelByRow(row));
            }
            return list;
        }
        #endregion
    }
}