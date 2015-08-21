using System;
using System.Data;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// 系统导航菜单
    /// </summary>
    [Serializable]
    public partial class navigation
    {
        public navigation()
        { }
        #region Model

        #region 数据库私有字段
        private int _id = 0;//自增ID
        private string _nav_type = string.Empty;//导航类别
        private string _name = string.Empty;//导航ID
        private string _title = string.Empty;//标题
        private string _sub_title = string.Empty;//副标题
        private string _link_url = string.Empty;//链接地址
        private int _sort_id = 99;//排序数字
        private int _is_lock = 0;//是否隐藏0显示1隐藏
        private string _remark = string.Empty;//备注说明
        private int _parent_id = 0;//所属父导航ID
        private string _class_list = string.Empty;//菜单ID列表(逗号分隔开)
        private int _class_layer = 1;//导航深度
        private int _channel_id = 0;//所属频道ID
        private string _action_type = string.Empty;//权限资源
        private int _is_sys = 0;//系统默认
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _nav_type_IsEdit = false;
        private bool _name_IsEdit = false;
        private bool _title_IsEdit = false;
        private bool _sub_title_IsEdit = false;
        private bool _link_url_IsEdit = false;
        private bool _sort_id_IsEdit = false;
        private bool _is_lock_IsEdit = false;
        private bool _remark_IsEdit = false;
        private bool _parent_id_IsEdit = false;
        private bool _class_list_IsEdit = false;
        private bool _class_layer_IsEdit = false;
        private bool _channel_id_IsEdit = false;
        private bool _action_type_IsEdit = false;
        private bool _is_sys_IsEdit = false;
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
        /// 导航类别
        /// </summary>		
        public string nav_type
        {
            get
            {
                return _nav_type;
            }
            set
            {
                _nav_type_IsEdit = true;
                _isEdit = true;
                _nav_type = value;
            }
        }
        /// <summary>
        /// 导航ID
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
        /// 标题
        /// </summary>		
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title_IsEdit = true;
                _isEdit = true;
                _title = value;
            }
        }
        /// <summary>
        /// 副标题
        /// </summary>		
        public string sub_title
        {
            get
            {
                return _sub_title;
            }
            set
            {
                _sub_title_IsEdit = true;
                _isEdit = true;
                _sub_title = value;
            }
        }
        /// <summary>
        /// 链接地址
        /// </summary>		
        public string link_url
        {
            get
            {
                return _link_url;
            }
            set
            {
                _link_url_IsEdit = true;
                _isEdit = true;
                _link_url = value;
            }
        }
        /// <summary>
        /// 排序数字
        /// </summary>		
        public int sort_id
        {
            get
            {
                return _sort_id;
            }
            set
            {
                _sort_id_IsEdit = true;
                _isEdit = true;
                _sort_id = value;
            }
        }
        /// <summary>
        /// 是否隐藏0显示1隐藏
        /// </summary>		
        public int is_lock
        {
            get
            {
                return _is_lock;
            }
            set
            {
                _is_lock_IsEdit = true;
                _isEdit = true;
                _is_lock = value;
            }
        }
        /// <summary>
        /// 备注说明
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
        /// 所属父导航ID
        /// </summary>		
        public int parent_id
        {
            get
            {
                return _parent_id;
            }
            set
            {
                _parent_id_IsEdit = true;
                _isEdit = true;
                _parent_id = value;
            }
        }
        /// <summary>
        /// 菜单ID列表(逗号分隔开)
        /// </summary>		
        public string class_list
        {
            get
            {
                return _class_list;
            }
            set
            {
                _class_list_IsEdit = true;
                _isEdit = true;
                _class_list = value;
            }
        }
        /// <summary>
        /// 导航深度
        /// </summary>		
        public int class_layer
        {
            get
            {
                return _class_layer;
            }
            set
            {
                _class_layer_IsEdit = true;
                _isEdit = true;
                _class_layer = value;
            }
        }
        /// <summary>
        /// 所属频道ID
        /// </summary>		
        public int channel_id
        {
            get
            {
                return _channel_id;
            }
            set
            {
                _channel_id_IsEdit = true;
                _isEdit = true;
                _channel_id = value;
            }
        }
        /// <summary>
        /// 权限资源
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
        /// 系统默认
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
                    _nav_type_IsEdit = false;
                    _name_IsEdit = false;
                    _title_IsEdit = false;
                    _sub_title_IsEdit = false;
                    _link_url_IsEdit = false;
                    _sort_id_IsEdit = false;
                    _is_lock_IsEdit = false;
                    _remark_IsEdit = false;
                    _parent_id_IsEdit = false;
                    _class_list_IsEdit = false;
                    _class_layer_IsEdit = false;
                    _channel_id_IsEdit = false;
                    _action_type_IsEdit = false;
                    _is_sys_IsEdit = false;
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
        /// nav_type是否已修改
        /// </summary>		
        public bool nav_type_IsEdit
        {
            get
            {
                return _nav_type_IsEdit;
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
        /// title是否已修改
        /// </summary>		
        public bool title_IsEdit
        {
            get
            {
                return _title_IsEdit;
            }
        }
        /// <summary>
        /// sub_title是否已修改
        /// </summary>		
        public bool sub_title_IsEdit
        {
            get
            {
                return _sub_title_IsEdit;
            }
        }
        /// <summary>
        /// link_url是否已修改
        /// </summary>		
        public bool link_url_IsEdit
        {
            get
            {
                return _link_url_IsEdit;
            }
        }
        /// <summary>
        /// sort_id是否已修改
        /// </summary>		
        public bool sort_id_IsEdit
        {
            get
            {
                return _sort_id_IsEdit;
            }
        }
        /// <summary>
        /// is_lock是否已修改
        /// </summary>		
        public bool is_lock_IsEdit
        {
            get
            {
                return _is_lock_IsEdit;
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
        /// parent_id是否已修改
        /// </summary>		
        public bool parent_id_IsEdit
        {
            get
            {
                return _parent_id_IsEdit;
            }
        }
        /// <summary>
        /// class_list是否已修改
        /// </summary>		
        public bool class_list_IsEdit
        {
            get
            {
                return _class_list_IsEdit;
            }
        }
        /// <summary>
        /// class_layer是否已修改
        /// </summary>		
        public bool class_layer_IsEdit
        {
            get
            {
                return _class_layer_IsEdit;
            }
        }
        /// <summary>
        /// channel_id是否已修改
        /// </summary>		
        public bool channel_id_IsEdit
        {
            get
            {
                return _channel_id_IsEdit;
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
        /// is_sys是否已修改
        /// </summary>		
        public bool is_sys_IsEdit
        {
            get
            {
                return _is_sys_IsEdit;
            }
        }
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public Model.navigation FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public Model.navigation FillModelByRow(DataRow row)
        {
            Model.navigation model = new Model.navigation();
            if (row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }
            model.nav_type = row["nav_type"].ToString

();
            model.name = row["name"].ToString

();
            model.title = row["title"].ToString

();
            model.sub_title = row["sub_title"].ToString

();
            model.link_url = row["link_url"].ToString

();
            if (row["sort_id"].ToString() != "")
            {
                model.sort_id = int.Parse(row["sort_id"].ToString());
            }
            if (row["is_lock"].ToString() != "")
            {
                model.is_lock = int.Parse(row["is_lock"].ToString());
            }
            model.remark = row["remark"].ToString

();
            if (row["parent_id"].ToString() != "")
            {
                model.parent_id = int.Parse(row["parent_id"].ToString());
            }
            model.class_list = row["class_list"].ToString

();
            if (row["class_layer"].ToString() != "")
            {
                model.class_layer = int.Parse(row["class_layer"].ToString());
            }
            if (row["channel_id"].ToString() != "")
            {
                model.channel_id = int.Parse(row["channel_id"].ToString());
            }
            model.action_type = row["action_type"].ToString

();
            if (row["is_sys"].ToString() != "")
            {
                model.is_sys = int.Parse(row["is_sys"].ToString());
            }

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public List<Model.navigation> FillList(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                List<Model.navigation> list = new List<Model.navigation>();
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