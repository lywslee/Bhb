using System;
using System.Collections.Generic;
using System.Data;

namespace Model
{
    /// <summary>
    /// 管理角色:实体类
    /// </summary>
    [Serializable]
    public partial class manager_role
    {
        public manager_role()
        { }
        #region Model
        #region 数据库私有字段
        private int _id = 0;//自增ID
        private string _role_name = string.Empty;//角色名称
        private int _role_type = 1;//角色类型
        private int _is_sys = 0;//是否系统默认0否1是
        private int _agentid = 0;//所属的代理商Id
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _role_name_IsEdit = false;
        private bool _role_type_IsEdit = false;
        private bool _is_sys_IsEdit = false;
        private bool _agentid_IsEdit = false;
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
        /// 角色名称
        /// </summary>		
        public string role_name
        {
            get
            {
                return _role_name;
            }
            set
            {
                _role_name_IsEdit = true;
                _isEdit = true;
                _role_name = value;
            }
        }
        /// <summary>
        /// 角色类型
        /// </summary>		
        public int role_type
        {
            get
            {
                return _role_type;
            }
            set
            {
                _role_type_IsEdit = true;
                _isEdit = true;
                _role_type = value;
            }
        }
        /// <summary>
        /// 是否系统默认0否1是
        /// </summary>		
        public int is_sys
        {
            get
            {
                return _is_sys;
            }
            set
            {
                _is_sys_IsEdit = true;
                _isEdit = true;
                _is_sys = value;
            }
        }
        /// <summary>
        /// 所属的代理商Id
        /// </summary>		
        public int agentId
        {
            get
            {
                return _agentid;
            }
            set
            {
                _agentid_IsEdit = true;
                _isEdit = true;
                _agentid = value;
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
                    _role_name_IsEdit = false;
                    _role_type_IsEdit = false;
                    _is_sys_IsEdit = false;
                    _agentid_IsEdit = false;
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
        /// role_name是否已修改
        /// </summary>		
        public bool role_name_IsEdit
        {
            get
            {
                return _role_name_IsEdit;
            }
        }
        /// <summary>
        /// role_type是否已修改
        /// </summary>		
        public bool role_type_IsEdit
        {
            get
            {
                return _role_type_IsEdit;
            }
        }
        /// <summary>
        /// is_sys是否已修改
        /// </summary>		
        public bool is_sys_IsEdit
        {
            get
            {
                return _is_sys_IsEdit;
            }
        }
        /// <summary>
        /// agentId是否已修改
        /// </summary>		
        public bool agentId_IsEdit
        {
            get
            {
                return _agentid_IsEdit;
            }
        }
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public Model.manager_role FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public Model.manager_role FillModelByRow(DataRow row)
        {
            Model.manager_role model = new Model.manager_role();
            if (row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }
            model.role_name = row["role_name"].ToString

();
            if (row["role_type"].ToString() != "")
            {
                model.role_type = int.Parse(row["role_type"].ToString());
            }
            if (row["is_sys"].ToString() != "")
            {
                model.is_sys = int.Parse(row["is_sys"].ToString());
            }
            if (row["agentId"].ToString() != "")
            {
                model.agentId = int.Parse(row["agentId"].ToString());
            }

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public List<Model.manager_role> FillList(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                List<Model.manager_role> list = new List<Model.manager_role>();
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

        private List<manager_role_value> _manager_role_values;
        /// <summary>
        /// 权限子类 
        /// </summary>
        public List<manager_role_value> manager_role_values
        {
            set { _manager_role_values = value; }
            get { return _manager_role_values; }
        }
    }
}