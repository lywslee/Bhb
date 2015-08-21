using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Model
{
    //管理员表
    public class dt_manager
    {

        #region 数据库私有字段
        private int _id = 0;//id
        private int _role_id = 0;//角色Id
        private int _role_type = 0;//角色类型
        private string _user_name = string.Empty;//用户名
        private string _password = string.Empty;//密码
        private string _salt = string.Empty;//salt
        private string _real_name = string.Empty;//真实姓名
        private string _telephone = string.Empty;//联系方式
        private string _email = string.Empty;//邮箱
        private int _is_lock = 0;//是否锁定
        private DateTime _add_time = new DateTime(1900, 1, 1);//添加时间
        private int _wxnum = 0;//wxNum
        private int _agentid = 0;//agentId
        private string _reg_ip = string.Empty;//reg_ip
        private string _qq = string.Empty;//qq
        private string _province = string.Empty;//省
        private string _city = string.Empty;//市
        private string _county = string.Empty;//详细地址
        private string _remark = string.Empty;//备注
        private int _sort_id = 0;//排序序号
        private int _agentlevel = 0;//agentLevel
        private int _sectionid = 0;//部门Id
        private string _ext1 = string.Empty;//Ext1
        private int _isdelete = 0;//是否删除（0否 1是）
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _role_id_IsEdit = false;
        private bool _role_type_IsEdit = false;
        private bool _user_name_IsEdit = false;
        private bool _password_IsEdit = false;
        private bool _salt_IsEdit = false;
        private bool _real_name_IsEdit = false;
        private bool _telephone_IsEdit = false;
        private bool _email_IsEdit = false;
        private bool _is_lock_IsEdit = false;
        private bool _add_time_IsEdit = false;
        private bool _wxnum_IsEdit = false;
        private bool _agentid_IsEdit = false;
        private bool _reg_ip_IsEdit = false;
        private bool _qq_IsEdit = false;
        private bool _province_IsEdit = false;
        private bool _city_IsEdit = false;
        private bool _county_IsEdit = false;
        private bool _remark_IsEdit = false;
        private bool _sort_id_IsEdit = false;
        private bool _agentlevel_IsEdit = false;
        private bool _sectionid_IsEdit = false;
        private bool _ext1_IsEdit = false;
        private bool _isdelete_IsEdit = false;
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
        /// 角色Id
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
        /// 密码
        /// </summary>		
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password_IsEdit = true;
                _isEdit = true;
                _password = value;
            }
        }
        /// <summary>
        /// salt
        /// </summary>		
        public string salt
        {
            get
            {
                return _salt;
            }
            set
            {
                _salt_IsEdit = true;
                _isEdit = true;
                _salt = value;
            }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>		
        public string real_name
        {
            get
            {
                return _real_name;
            }
            set
            {
                _real_name_IsEdit = true;
                _isEdit = true;
                _real_name = value;
            }
        }
        /// <summary>
        /// 联系方式
        /// </summary>		
        public string telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                _telephone_IsEdit = true;
                _isEdit = true;
                _telephone = value;
            }
        }
        /// <summary>
        /// 邮箱
        /// </summary>		
        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email_IsEdit = true;
                _isEdit = true;
                _email = value;
            }
        }
        /// <summary>
        /// 是否锁定
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
        /// 添加时间
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
        /// <summary>
        /// wxNum
        /// </summary>		
        public int wxNum
        {
            get
            {
                return _wxnum;
            }
            set
            {
                _wxnum_IsEdit = true;
                _isEdit = true;
                _wxnum = value;
            }
        }
        /// <summary>
        /// agentId
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
        /// <summary>
        /// reg_ip
        /// </summary>		
        public string reg_ip
        {
            get
            {
                return _reg_ip;
            }
            set
            {
                _reg_ip_IsEdit = true;
                _isEdit = true;
                _reg_ip = value;
            }
        }
        /// <summary>
        /// qq
        /// </summary>		
        public string qq
        {
            get
            {
                return _qq;
            }
            set
            {
                _qq_IsEdit = true;
                _isEdit = true;
                _qq = value;
            }
        }
        /// <summary>
        /// 省
        /// </summary>		
        public string province
        {
            get
            {
                return _province;
            }
            set
            {
                _province_IsEdit = true;
                _isEdit = true;
                _province = value;
            }
        }
        /// <summary>
        /// 市
        /// </summary>		
        public string city
        {
            get
            {
                return _city;
            }
            set
            {
                _city_IsEdit = true;
                _isEdit = true;
                _city = value;
            }
        }
        /// <summary>
        /// 详细地址
        /// </summary>		
        public string county
        {
            get
            {
                return _county;
            }
            set
            {
                _county_IsEdit = true;
                _isEdit = true;
                _county = value;
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
        /// 排序序号
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
        /// agentLevel
        /// </summary>		
        public int agentLevel
        {
            get
            {
                return _agentlevel;
            }
            set
            {
                _agentlevel_IsEdit = true;
                _isEdit = true;
                _agentlevel = value;
            }
        }
        /// <summary>
        /// 部门Id
        /// </summary>		
        public int SectionId
        {
            get
            {
                return _sectionid;
            }
            set
            {
                _sectionid_IsEdit = true;
                _isEdit = true;
                _sectionid = value;
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
        /// 是否删除（0否 1是）
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
                    _role_type_IsEdit = false;
                    _user_name_IsEdit = false;
                    _password_IsEdit = false;
                    _salt_IsEdit = false;
                    _real_name_IsEdit = false;
                    _telephone_IsEdit = false;
                    _email_IsEdit = false;
                    _is_lock_IsEdit = false;
                    _add_time_IsEdit = false;
                    _wxnum_IsEdit = false;
                    _agentid_IsEdit = false;
                    _reg_ip_IsEdit = false;
                    _qq_IsEdit = false;
                    _province_IsEdit = false;
                    _city_IsEdit = false;
                    _county_IsEdit = false;
                    _remark_IsEdit = false;
                    _sort_id_IsEdit = false;
                    _agentlevel_IsEdit = false;
                    _sectionid_IsEdit = false;
                    _ext1_IsEdit = false;
                    _isdelete_IsEdit = false;
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
        /// password是否已修改
        /// </summary>		
        public bool password_IsEdit
        {
            get
            {
                return _password_IsEdit;
            }
        }
        /// <summary>
        /// salt是否已修改
        /// </summary>		
        public bool salt_IsEdit
        {
            get
            {
                return _salt_IsEdit;
            }
        }
        /// <summary>
        /// real_name是否已修改
        /// </summary>		
        public bool real_name_IsEdit
        {
            get
            {
                return _real_name_IsEdit;
            }
        }
        /// <summary>
        /// telephone是否已修改
        /// </summary>		
        public bool telephone_IsEdit
        {
            get
            {
                return _telephone_IsEdit;
            }
        }
        /// <summary>
        /// email是否已修改
        /// </summary>		
        public bool email_IsEdit
        {
            get
            {
                return _email_IsEdit;
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
        /// add_time是否已修改
        /// </summary>		
        public bool add_time_IsEdit
        {
            get
            {
                return _add_time_IsEdit;
            }
        }
        /// <summary>
        /// wxNum是否已修改
        /// </summary>		
        public bool wxNum_IsEdit
        {
            get
            {
                return _wxnum_IsEdit;
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
        /// <summary>
        /// reg_ip是否已修改
        /// </summary>		
        public bool reg_ip_IsEdit
        {
            get
            {
                return _reg_ip_IsEdit;
            }
        }
        /// <summary>
        /// qq是否已修改
        /// </summary>		
        public bool qq_IsEdit
        {
            get
            {
                return _qq_IsEdit;
            }
        }
        /// <summary>
        /// province是否已修改
        /// </summary>		
        public bool province_IsEdit
        {
            get
            {
                return _province_IsEdit;
            }
        }
        /// <summary>
        /// city是否已修改
        /// </summary>		
        public bool city_IsEdit
        {
            get
            {
                return _city_IsEdit;
            }
        }
        /// <summary>
        /// county是否已修改
        /// </summary>		
        public bool county_IsEdit
        {
            get
            {
                return _county_IsEdit;
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
        /// agentLevel是否已修改
        /// </summary>		
        public bool agentLevel_IsEdit
        {
            get
            {
                return _agentlevel_IsEdit;
            }
        }
        /// <summary>
        /// SectionId是否已修改
        /// </summary>		
        public bool SectionId_IsEdit
        {
            get
            {
                return _sectionid_IsEdit;
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
        /// IsDelete是否已修改
        /// </summary>		
        public bool IsDelete_IsEdit
        {
            get
            {
                return _isdelete_IsEdit;
            }
        }
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public static Model.dt_manager FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public static Model.dt_manager FillModelByRow(DataRow row)
        {
            Model.dt_manager model = new Model.dt_manager();
            if (row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }
            if (row["role_id"].ToString() != "")
            {
                model.role_id = int.Parse(row["role_id"].ToString());
            }
            if (row["role_type"].ToString() != "")
            {
                model.role_type = int.Parse(row["role_type"].ToString());
            }
            model.user_name = row["user_name"].ToString

();
            model.password = row["password"].ToString

();
            model.salt = row["salt"].ToString

();
            model.real_name = row["real_name"].ToString

();
            model.telephone = row["telephone"].ToString

();
            model.email = row["email"].ToString

();
            if (row["is_lock"].ToString() != "")
            {
                model.is_lock = int.Parse(row["is_lock"].ToString());
            }
            if (row["add_time"].ToString() != "")
            {
                model.add_time = DateTime.Parse(row["add_time"].ToString());
            }
            if (row["wxNum"].ToString() != "")
            {
                model.wxNum = int.Parse(row["wxNum"].ToString());
            }
            if (row["agentId"].ToString() != "")
            {
                model.agentId = int.Parse(row["agentId"].ToString());
            }
            model.reg_ip = row["reg_ip"].ToString

();
            model.qq = row["qq"].ToString

();
            model.province = row["province"].ToString

();
            model.city = row["city"].ToString

();
            model.county = row["county"].ToString

();
            model.remark = row["remark"].ToString

();
            if (row["sort_id"].ToString() != "")
            {
                model.sort_id = int.Parse(row["sort_id"].ToString());
            }
            if (row["agentLevel"].ToString() != "")
            {
                model.agentLevel = int.Parse(row["agentLevel"].ToString());
            }
            if (row["SectionId"].ToString() != "")
            {
                model.SectionId = int.Parse(row["SectionId"].ToString());
            }
            model.Ext1 = row["Ext1"].ToString

();
            if (row["IsDelete"].ToString() != "")
            {
                model.IsDelete = int.Parse(row["IsDelete"].ToString());
            }

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public static List<Model.dt_manager> FillList(DataTable dt)
        {
            List<Model.dt_manager> list = new List<Model.dt_manager>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(FillModelByRow(row));
            }
            return list;
        }
        #endregion
    }
}