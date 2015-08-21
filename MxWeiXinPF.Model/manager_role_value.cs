using System;
using System.Data;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// 管理角色权限:实体类
    /// </summary>
    [Serializable]
    public partial class manager_role_value
    {
        public manager_role_value()
        { }
        #region Model

        #region 数据库私有字段
        private int _id = 0;//自增ID
        private int _role_id = 0;//角色ID
        private string _nav_name = string.Empty;//导航名称
        private string _action_type = string.Empty;//权限类型
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _role_id_IsEdit = false;
        private bool _nav_name_IsEdit = false;
        private bool _action_type_IsEdit = false;
        #endregion
        #region  公开属性
        /// <summary>
        /// 自增ID
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
        /// 角色ID
        /// </summary>		
        public int role_id
        {
            get
            {
                return _role_id;
            }
            set
            {
                _role_id_IsEdit = true;
                _isEdit = true;
                _role_id = value;
            }
        }
        /// <summary>
        /// 导航名称
        /// </summary>		
        public string nav_name
        {
            get
            {
                return _nav_name;
            }
            set
            {
                _nav_name_IsEdit = true;
                _isEdit = true;
                _nav_name = value;
            }
        }
        /// <summary>
        /// 权限类型
        /// </summary>		
        public string action_type
        {
            get
            {
                return _action_type;
            }
            set
            {
                _action_type_IsEdit = true;
                _isEdit = true;
                _action_type = value;
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
                    _role_id_IsEdit = false;
                    _nav_name_IsEdit = false;
                    _action_type_IsEdit = false;
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
        /// role_id是否已修改
        /// </summary>		
        public bool role_id_IsEdit
        {
            get
            {
                return _role_id_IsEdit;
            }
        }
        /// <summary>
        /// nav_name是否已修改
        /// </summary>		
        public bool nav_name_IsEdit
        {
            get
            {
                return _nav_name_IsEdit;
            }
        }
        /// <summary>
        /// action_type是否已修改
        /// </summary>		
        public bool action_type_IsEdit
        {
            get
            {
                return _action_type_IsEdit;
            }
        }
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public Model.manager_role_value FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public Model.manager_role_value FillModelByRow(DataRow row)
        {
            Model.manager_role_value model = new Model.manager_role_value();
            if (row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }
            if (row["role_id"].ToString() != "")
            {
                model.role_id = int.Parse(row["role_id"].ToString());
            }
            model.nav_name = row["nav_name"].ToString

();
            model.action_type = row["action_type"].ToString

();

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public List<Model.manager_role_value> FillList(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                List<Model.manager_role_value> list = new List<Model.manager_role_value>();
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