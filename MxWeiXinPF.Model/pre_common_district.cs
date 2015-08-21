using System;
using System.Collections.Generic;
using System.Data;
namespace Model
{
	/// <summary>
	/// 中国省市县镇4级数据表
	/// </summary>
	[Serializable]
	public partial class pre_common_district
	{
		public pre_common_district()
		{}
		#region Model

        #region 数据库私有字段
        private int _id = 0;//id
        private string _name = string.Empty;//name
        private int _level = 0;//level
        private int _upid = 0;//upid
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _name_IsEdit = false;
        private bool _level_IsEdit = false;
        private bool _upid_IsEdit = false;
        #endregion
        #region  公开属性
        /// <summary>
        /// id
        /// </summary>		
        public int id
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
        /// name
        /// </summary>		
        public string name
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
        /// level
        /// </summary>		
        public int level
        {
            get
            {
                return _level;
            }
            set
            {
                _level_IsEdit = true;
                _isEdit = true;
                _level = value;
            }
        }
        /// <summary>
        /// upid
        /// </summary>		
        public int upid
        {
            get
            {
                return _upid;
            }
            set
            {
                _upid_IsEdit = true;
                _isEdit = true;
                _upid = value;
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
                    _level_IsEdit = false;
                    _upid_IsEdit = false;
                }
            }
        }
        /// <summary>
        /// id是否已修改
        /// </summary>		
        public bool id_IsEdit
        {
            get
            {
                return _id_IsEdit;
            }
        }
        /// <summary>
        /// name是否已修改
        /// </summary>		
        public bool name_IsEdit
        {
            get
            {
                return _name_IsEdit;
            }
        }
        /// <summary>
        /// level是否已修改
        /// </summary>		
        public bool level_IsEdit
        {
            get
            {
                return _level_IsEdit;
            }
        }
        /// <summary>
        /// upid是否已修改
        /// </summary>		
        public bool upid_IsEdit
        {
            get
            {
                return _upid_IsEdit;
            }
        }
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public Model.pre_common_district FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public Model.pre_common_district FillModelByRow(DataRow row)
        {
            Model.pre_common_district model = new Model.pre_common_district();
            if (row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }
            model.name = row["name"].ToString

();
            if (row["level"].ToString() != "")
            {
                model.level = int.Parse(row["level"].ToString());
            }
            if (row["upid"].ToString() != "")
            {
                model.upid = int.Parse(row["upid"].ToString());
            }

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public List<Model.pre_common_district> FillList(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                List<Model.pre_common_district> list = new List<Model.pre_common_district>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(FillModelByRow(row));
                }
                return list;
            }
            else
            {
                return null;
            }
        }
        #endregion 
		#endregion Model

	}
}

