using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Model
{
    /// <summary>
    /// 管理日志:实体类
    /// </summary>
    [Serializable]
    public partial class manager_log
    {

        public manager_log()
		{}
		#region Model
        #region 数据库私有字段
        private int _id = 0;//自增ID
        private int _user_id = 0;//用户ID
        private string _user_name = string.Empty;//用户名
        private string _action_type = string.Empty;//操作类型
        private string _remark = string.Empty;//备注
        private string _user_ip = string.Empty;//用户IP
        private DateTime _add_time = DateTime.Now;//操作时间
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _user_id_IsEdit = false;
        private bool _user_name_IsEdit = false;
        private bool _action_type_IsEdit = false;
        private bool _remark_IsEdit = false;
        private bool _user_ip_IsEdit = false;
        private bool _add_time_IsEdit = false;
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
        /// 用户ID
        /// </summary>		
        public int user_id
        {
            get
            {
                return _user_id;
            }
            set
            {
                _user_id_IsEdit = true;
                _isEdit = true;
                _user_id = value;
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>		
        public string user_name
        {
            get
            {
                return _user_name;
            }
            set
            {
                _user_name_IsEdit = true;
                _isEdit = true;
                _user_name = value;
            }
        }
        /// <summary>
        /// 操作类型
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
        /// <summary>
        /// 备注
        /// </summary>		
        public string remark
        {
            get
            {
                return _remark;
            }
            set
            {
                _remark_IsEdit = true;
                _isEdit = true;
                _remark = value;
            }
        }
        /// <summary>
        /// 用户IP
        /// </summary>		
        public string user_ip
        {
            get
            {
                return _user_ip;
            }
            set
            {
                _user_ip_IsEdit = true;
                _isEdit = true;
                _user_ip = value;
            }
        }
        /// <summary>
        /// 操作时间
        /// </summary>		
        public DateTime add_time
        {
            get
            {
                return _add_time;
            }
            set
            {
                _add_time_IsEdit = true;
                _isEdit = true;
                _add_time = value;
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
                    _user_id_IsEdit = false;
                    _user_name_IsEdit = false;
                    _action_type_IsEdit = false;
                    _remark_IsEdit = false;
                    _user_ip_IsEdit = false;
                    _add_time_IsEdit = false;
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
        /// user_id是否已修改
        /// </summary>		
        public bool user_id_IsEdit
        {
            get
            {
                return _user_id_IsEdit;
            }
        }
        /// <summary>
        /// user_name是否已修改
        /// </summary>		
        public bool user_name_IsEdit
        {
            get
            {
                return _user_name_IsEdit;
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
        /// <summary>
        /// remark是否已修改
        /// </summary>		
        public bool remark_IsEdit
        {
            get
            {
                return _remark_IsEdit;
            }
        }
        /// <summary>
        /// user_ip是否已修改
        /// </summary>		
        public bool user_ip_IsEdit
        {
            get
            {
                return _user_ip_IsEdit;
            }
        }
        /// <summary>
        /// add_time是否已修改
        /// </summary>		
        public bool add_time_IsEdit
        {
            get
            {
                return _add_time_IsEdit;
            }
        }
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public Model.manager_log FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public Model.manager_log FillModelByRow(DataRow row)
        {
            Model.manager_log model = new Model.manager_log();
            if (row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }
            if (row["user_id"].ToString() != "")
            {
                model.user_id = int.Parse(row["user_id"].ToString());
            }
            model.user_name = row["user_name"].ToString

();
            model.action_type = row["action_type"].ToString

();
            model.remark = row["remark"].ToString

();
            model.user_ip = row["user_ip"].ToString

();
            if (row["add_time"].ToString() != "")
            {
                model.add_time = DateTime.Parse(row["add_time"].ToString());
            }

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public List<Model.manager_log> FillList(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                List<Model.manager_log> list = new List<Model.manager_log>();
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
