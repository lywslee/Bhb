using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Model
{
    //区域表
    public class T_Regional
    {

        #region 数据库私有字段
        private int _id = 0;//全局唯一键
        private string _rname = string.Empty;//乡镇名称
        private string _zjm = string.Empty;//助记码
        private string _rlevel = string.Empty;//级别
        private int _sortnum = 0;//排序序号
        private int _parentid = 0;//上级id
        private string _remark = string.Empty;//相关说明
        private int _deletemark = 0;//删除标记
        private DateTime _addtime = new DateTime(1900, 1, 1);//添加日期
        private string _addperson = string.Empty;//添加人
        private DateTime _modifytime = new DateTime(1900, 1, 1);//修改日期
        private string _modifyperson = string.Empty;//修改人
        private string _u1 = string.Empty;//备用字段1
        private string _u2 = string.Empty;//备用字段2
        private decimal _u3 = 0;//备用字段3
        private decimal _u4 = 0;//备用字段4
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _rname_IsEdit = false;
        private bool _zjm_IsEdit = false;
        private bool _rlevel_IsEdit = false;
        private bool _sortnum_IsEdit = false;
        private bool _parentid_IsEdit = false;
        private bool _remark_IsEdit = false;
        private bool _deletemark_IsEdit = false;
        private bool _addtime_IsEdit = false;
        private bool _addperson_IsEdit = false;
        private bool _modifytime_IsEdit = false;
        private bool _modifyperson_IsEdit = false;
        private bool _u1_IsEdit = false;
        private bool _u2_IsEdit = false;
        private bool _u3_IsEdit = false;
        private bool _u4_IsEdit = false;
        #endregion
        #region  公开属性
        /// <summary>
        /// 全局唯一键
        /// </summary>		
        public int ID
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
        /// 乡镇名称
        /// </summary>		
        public string RName
        {
            get
            {
                return _rname;
            }
            set
            {
                _rname_IsEdit = true;
                _isEdit = true;
                _rname = value;
            }
        }
        /// <summary>
        /// 助记码
        /// </summary>		
        public string ZJM
        {
            get
            {
                return _zjm;
            }
            set
            {
                _zjm_IsEdit = true;
                _isEdit = true;
                _zjm = value;
            }
        }
        /// <summary>
        /// 级别
        /// </summary>		
        public string RLevel
        {
            get
            {
                return _rlevel;
            }
            set
            {
                _rlevel_IsEdit = true;
                _isEdit = true;
                _rlevel = value;
            }
        }
        /// <summary>
        /// 排序序号
        /// </summary>		
        public int SortNum
        {
            get
            {
                return _sortnum;
            }
            set
            {
                _sortnum_IsEdit = true;
                _isEdit = true;
                _sortnum = value;
            }
        }
        /// <summary>
        /// 上级id
        /// </summary>		
        public int ParentID
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
        /// 相关说明
        /// </summary>		
        public string Remark
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
        /// 删除标记
        /// </summary>		
        public int DeleteMark
        {
            get
            {
                return _deletemark;
            }
            set
            {
                _deletemark_IsEdit = true;
                _isEdit = true;
                _deletemark = value;
            }
        }
        /// <summary>
        /// 添加日期
        /// </summary>		
        public DateTime AddTime
        {
            get
            {
                return _addtime;
            }
            set
            {
                _addtime_IsEdit = true;
                _isEdit = true;
                _addtime = value;
            }
        }
        /// <summary>
        /// 添加人
        /// </summary>		
        public string AddPerson
        {
            get
            {
                return _addperson;
            }
            set
            {
                _addperson_IsEdit = true;
                _isEdit = true;
                _addperson = value;
            }
        }
        /// <summary>
        /// 修改日期
        /// </summary>		
        public DateTime ModifyTime
        {
            get
            {
                return _modifytime;
            }
            set
            {
                _modifytime_IsEdit = true;
                _isEdit = true;
                _modifytime = value;
            }
        }
        /// <summary>
        /// 修改人
        /// </summary>		
        public string ModifyPerson
        {
            get
            {
                return _modifyperson;
            }
            set
            {
                _modifyperson_IsEdit = true;
                _isEdit = true;
                _modifyperson = value;
            }
        }
        /// <summary>
        /// 备用字段1
        /// </summary>		
        public string U1
        {
            get
            {
                return _u1;
            }
            set
            {
                _u1_IsEdit = true;
                _isEdit = true;
                _u1 = value;
            }
        }
        /// <summary>
        /// 备用字段2
        /// </summary>		
        public string U2
        {
            get
            {
                return _u2;
            }
            set
            {
                _u2_IsEdit = true;
                _isEdit = true;
                _u2 = value;
            }
        }
        /// <summary>
        /// 备用字段3
        /// </summary>		
        public decimal U3
        {
            get
            {
                return _u3;
            }
            set
            {
                _u3_IsEdit = true;
                _isEdit = true;
                _u3 = value;
            }
        }
        /// <summary>
        /// 备用字段4
        /// </summary>		
        public decimal U4
        {
            get
            {
                return _u4;
            }
            set
            {
                _u4_IsEdit = true;
                _isEdit = true;
                _u4 = value;
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
                    _rname_IsEdit = false;
                    _zjm_IsEdit = false;
                    _rlevel_IsEdit = false;
                    _sortnum_IsEdit = false;
                    _parentid_IsEdit = false;
                    _remark_IsEdit = false;
                    _deletemark_IsEdit = false;
                    _addtime_IsEdit = false;
                    _addperson_IsEdit = false;
                    _modifytime_IsEdit = false;
                    _modifyperson_IsEdit = false;
                    _u1_IsEdit = false;
                    _u2_IsEdit = false;
                    _u3_IsEdit = false;
                    _u4_IsEdit = false;
                }
            }
        }
        /// <summary>
        /// ID是否已修改
        /// </summary>		
        public bool ID_IsEdit
        {
            get
            {
                return _id_IsEdit;
            }
        }
        /// <summary>
        /// RName是否已修改
        /// </summary>		
        public bool RName_IsEdit
        {
            get
            {
                return _rname_IsEdit;
            }
        }
        /// <summary>
        /// ZJM是否已修改
        /// </summary>		
        public bool ZJM_IsEdit
        {
            get
            {
                return _zjm_IsEdit;
            }
        }
        /// <summary>
        /// RLevel是否已修改
        /// </summary>		
        public bool RLevel_IsEdit
        {
            get
            {
                return _rlevel_IsEdit;
            }
        }
        /// <summary>
        /// SortNum是否已修改
        /// </summary>		
        public bool SortNum_IsEdit
        {
            get
            {
                return _sortnum_IsEdit;
            }
        }
        /// <summary>
        /// ParentID是否已修改
        /// </summary>		
        public bool ParentID_IsEdit
        {
            get
            {
                return _parentid_IsEdit;
            }
        }
        /// <summary>
        /// Remark是否已修改
        /// </summary>		
        public bool Remark_IsEdit
        {
            get
            {
                return _remark_IsEdit;
            }
        }
        /// <summary>
        /// DeleteMark是否已修改
        /// </summary>		
        public bool DeleteMark_IsEdit
        {
            get
            {
                return _deletemark_IsEdit;
            }
        }
        /// <summary>
        /// AddTime是否已修改
        /// </summary>		
        public bool AddTime_IsEdit
        {
            get
            {
                return _addtime_IsEdit;
            }
        }
        /// <summary>
        /// AddPerson是否已修改
        /// </summary>		
        public bool AddPerson_IsEdit
        {
            get
            {
                return _addperson_IsEdit;
            }
        }
        /// <summary>
        /// ModifyTime是否已修改
        /// </summary>		
        public bool ModifyTime_IsEdit
        {
            get
            {
                return _modifytime_IsEdit;
            }
        }
        /// <summary>
        /// ModifyPerson是否已修改
        /// </summary>		
        public bool ModifyPerson_IsEdit
        {
            get
            {
                return _modifyperson_IsEdit;
            }
        }
        /// <summary>
        /// U1是否已修改
        /// </summary>		
        public bool U1_IsEdit
        {
            get
            {
                return _u1_IsEdit;
            }
        }
        /// <summary>
        /// U2是否已修改
        /// </summary>		
        public bool U2_IsEdit
        {
            get
            {
                return _u2_IsEdit;
            }
        }
        /// <summary>
        /// U3是否已修改
        /// </summary>		
        public bool U3_IsEdit
        {
            get
            {
                return _u3_IsEdit;
            }
        }
        /// <summary>
        /// U4是否已修改
        /// </summary>		
        public bool U4_IsEdit
        {
            get
            {
                return _u4_IsEdit;
            }
        }
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public static Model.T_Regional FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public static Model.T_Regional FillModelByRow(DataRow row)
        {
            Model.T_Regional model = new Model.T_Regional();
            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            model.RName = row["RName"].ToString

();
            model.ZJM = row["ZJM"].ToString

();
            model.RLevel = row["RLevel"].ToString

();
            if (row["SortNum"].ToString() != "")
            {
                model.SortNum = int.Parse(row["SortNum"].ToString());
            }
            if (row["ParentID"].ToString() != "")
            {
                model.ParentID = int.Parse(row["ParentID"].ToString());
            }
            model.Remark = row["Remark"].ToString

();
            if (row["DeleteMark"].ToString() != "")
            {
                model.DeleteMark = int.Parse(row["DeleteMark"].ToString());
            }
            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }
            model.AddPerson = row["AddPerson"].ToString

();
            if (row["ModifyTime"].ToString() != "")
            {
                model.ModifyTime = DateTime.Parse(row["ModifyTime"].ToString());
            }
            model.ModifyPerson = row["ModifyPerson"].ToString

();
            model.U1 = row["U1"].ToString

();
            model.U2 = row["U2"].ToString

();
            if (row["U3"].ToString() != "")
            {
                model.U3 = decimal.Parse(row["U3"].ToString());
            }
            if (row["U4"].ToString() != "")
            {
                model.U4 = decimal.Parse(row["U4"].ToString());
            }

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public static List<Model.T_Regional> FillList(DataTable dt)
        {
            List<Model.T_Regional> list = new List<Model.T_Regional>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(FillModelByRow(row));
            }
            return list;
        }
        #endregion
    }
}