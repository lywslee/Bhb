using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Model
{
    //客户表
    public class T_Customer
    {

        #region 数据库私有字段
        private int _id = 0;//全局唯一键
        private string _cname = string.Empty;//客户姓名
        private string _zjm = string.Empty;//助记码
        private int _clevel = 0;//客户类型
        private int _oneregional = 0;//一级区域
        private int _tworegional = 0;//二级区域
        private string _cardnumber = string.Empty;//身份证号
        private string _tel = string.Empty;//固定电话
        private string _mobile = string.Empty;//移动电话
        private string _address = string.Empty;//住址
        private string _bankname = string.Empty;//代发银行
        private string _bankaccount = string.Empty;//银行账号
        private string _acountname = string.Empty;//户名
        private DateTime _addtime = new DateTime(1900, 1, 1);//添加日期
        private string _addperson = string.Empty;//添加人
        private DateTime _modifytime = new DateTime(1900, 1, 1);//修改日期
        private string _modifyperson = string.Empty;//修改人
        private int _mergedmark = 0;//合并标记（0：未合并，1：已合并）
        private int _deletemark = 0;//删除标记
        private int _sortnum = 0;//排序序号
        private string _remark = string.Empty;//备注
        private string _u1 = string.Empty;//备用字段1
        private string _u2 = string.Empty;//备用字段2
        private decimal _u3 = 0;//备用字段3
        private decimal _u4 = 0;//备用字段4
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _cname_IsEdit = false;
        private bool _zjm_IsEdit = false;
        private bool _clevel_IsEdit = false;
        private bool _oneregional_IsEdit = false;
        private bool _tworegional_IsEdit = false;
        private bool _cardnumber_IsEdit = false;
        private bool _tel_IsEdit = false;
        private bool _mobile_IsEdit = false;
        private bool _address_IsEdit = false;
        private bool _bankname_IsEdit = false;
        private bool _bankaccount_IsEdit = false;
        private bool _acountname_IsEdit = false;
        private bool _addtime_IsEdit = false;
        private bool _addperson_IsEdit = false;
        private bool _modifytime_IsEdit = false;
        private bool _modifyperson_IsEdit = false;
        private bool _mergedmark_IsEdit = false;
        private bool _deletemark_IsEdit = false;
        private bool _sortnum_IsEdit = false;
        private bool _remark_IsEdit = false;
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
        /// 客户姓名
        /// </summary>		
        public string CName
        {
            get
            {
                return _cname;
            }
            set
            {
                _cname_IsEdit = true;
                _isEdit = true;
                _cname = value;
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
        /// 客户类型
        /// </summary>		
        public int CLevel
        {
            get
            {
                return _clevel;
            }
            set
            {
                _clevel_IsEdit = true;
                _isEdit = true;
                _clevel = value;
            }
        }
        /// <summary>
        /// 一级区域
        /// </summary>		
        public int OneRegional
        {
            get
            {
                return _oneregional;
            }
            set
            {
                _oneregional_IsEdit = true;
                _isEdit = true;
                _oneregional = value;
            }
        }
        /// <summary>
        /// 二级区域
        /// </summary>		
        public int TwoRegional
        {
            get
            {
                return _tworegional;
            }
            set
            {
                _tworegional_IsEdit = true;
                _isEdit = true;
                _tworegional = value;
            }
        }
        /// <summary>
        /// 身份证号
        /// </summary>		
        public string CardNumber
        {
            get
            {
                return _cardnumber;
            }
            set
            {
                _cardnumber_IsEdit = true;
                _isEdit = true;
                _cardnumber = value;
            }
        }
        /// <summary>
        /// 固定电话
        /// </summary>		
        public string Tel
        {
            get
            {
                return _tel;
            }
            set
            {
                _tel_IsEdit = true;
                _isEdit = true;
                _tel = value;
            }
        }
        /// <summary>
        /// 移动电话
        /// </summary>		
        public string Mobile
        {
            get
            {
                return _mobile;
            }
            set
            {
                _mobile_IsEdit = true;
                _isEdit = true;
                _mobile = value;
            }
        }
        /// <summary>
        /// 住址
        /// </summary>		
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address_IsEdit = true;
                _isEdit = true;
                _address = value;
            }
        }
        /// <summary>
        /// 代发银行
        /// </summary>		
        public string BankName
        {
            get
            {
                return _bankname;
            }
            set
            {
                _bankname_IsEdit = true;
                _isEdit = true;
                _bankname = value;
            }
        }
        /// <summary>
        /// 银行账号
        /// </summary>		
        public string BankAccount
        {
            get
            {
                return _bankaccount;
            }
            set
            {
                _bankaccount_IsEdit = true;
                _isEdit = true;
                _bankaccount = value;
            }
        }
        /// <summary>
        /// 户名
        /// </summary>		
        public string AcountName
        {
            get
            {
                return _acountname;
            }
            set
            {
                _acountname_IsEdit = true;
                _isEdit = true;
                _acountname = value;
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
        /// 合并标记（0：未合并，1：已合并）
        /// </summary>		
        public int MergedMark
        {
            get
            {
                return _mergedmark;
            }
            set
            {
                _mergedmark_IsEdit = true;
                _isEdit = true;
                _mergedmark = value;
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
        /// 备注
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
                    _cname_IsEdit = false;
                    _zjm_IsEdit = false;
                    _clevel_IsEdit = false;
                    _oneregional_IsEdit = false;
                    _tworegional_IsEdit = false;
                    _cardnumber_IsEdit = false;
                    _tel_IsEdit = false;
                    _mobile_IsEdit = false;
                    _address_IsEdit = false;
                    _bankname_IsEdit = false;
                    _bankaccount_IsEdit = false;
                    _acountname_IsEdit = false;
                    _addtime_IsEdit = false;
                    _addperson_IsEdit = false;
                    _modifytime_IsEdit = false;
                    _modifyperson_IsEdit = false;
                    _mergedmark_IsEdit = false;
                    _deletemark_IsEdit = false;
                    _sortnum_IsEdit = false;
                    _remark_IsEdit = false;
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
        /// CName是否已修改
        /// </summary>		
        public bool CName_IsEdit
        {
            get
            {
                return _cname_IsEdit;
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
        /// CLevel是否已修改
        /// </summary>		
        public bool CLevel_IsEdit
        {
            get
            {
                return _clevel_IsEdit;
            }
        }
        /// <summary>
        /// OneRegional是否已修改
        /// </summary>		
        public bool OneRegional_IsEdit
        {
            get
            {
                return _oneregional_IsEdit;
            }
        }
        /// <summary>
        /// TwoRegional是否已修改
        /// </summary>		
        public bool TwoRegional_IsEdit
        {
            get
            {
                return _tworegional_IsEdit;
            }
        }
        /// <summary>
        /// CardNumber是否已修改
        /// </summary>		
        public bool CardNumber_IsEdit
        {
            get
            {
                return _cardnumber_IsEdit;
            }
        }
        /// <summary>
        /// Tel是否已修改
        /// </summary>		
        public bool Tel_IsEdit
        {
            get
            {
                return _tel_IsEdit;
            }
        }
        /// <summary>
        /// Mobile是否已修改
        /// </summary>		
        public bool Mobile_IsEdit
        {
            get
            {
                return _mobile_IsEdit;
            }
        }
        /// <summary>
        /// Address是否已修改
        /// </summary>		
        public bool Address_IsEdit
        {
            get
            {
                return _address_IsEdit;
            }
        }
        /// <summary>
        /// BankName是否已修改
        /// </summary>		
        public bool BankName_IsEdit
        {
            get
            {
                return _bankname_IsEdit;
            }
        }
        /// <summary>
        /// BankAccount是否已修改
        /// </summary>		
        public bool BankAccount_IsEdit
        {
            get
            {
                return _bankaccount_IsEdit;
            }
        }
        /// <summary>
        /// AcountName是否已修改
        /// </summary>		
        public bool AcountName_IsEdit
        {
            get
            {
                return _acountname_IsEdit;
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
        /// MergedMark是否已修改
        /// </summary>		
        public bool MergedMark_IsEdit
        {
            get
            {
                return _mergedmark_IsEdit;
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
        public static Model.T_Customer FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public static Model.T_Customer FillModelByRow(DataRow row)
        {
            Model.T_Customer model = new Model.T_Customer();
            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            model.CName = row["CName"].ToString

();
            model.ZJM = row["ZJM"].ToString

();
            if (row["CLevel"].ToString() != "")
            {
                model.CLevel = int.Parse(row["CLevel"].ToString());
            }
            if (row["OneRegional"].ToString() != "")
            {
                model.OneRegional = int.Parse(row["OneRegional"].ToString());
            }
            if (row["TwoRegional"].ToString() != "")
            {
                model.TwoRegional = int.Parse(row["TwoRegional"].ToString());
            }
            model.CardNumber = row["CardNumber"].ToString

();
            model.Tel = row["Tel"].ToString

();
            model.Mobile = row["Mobile"].ToString

();
            model.Address = row["Address"].ToString

();
            model.BankName = row["BankName"].ToString

();
            model.BankAccount = row["BankAccount"].ToString

();
            model.AcountName = row["AcountName"].ToString

();
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
            if (row["MergedMark"].ToString() != "")
            {
                model.MergedMark = int.Parse(row["MergedMark"].ToString());
            }
            if (row["DeleteMark"].ToString() != "")
            {
                model.DeleteMark = int.Parse(row["DeleteMark"].ToString());
            }
            if (row["SortNum"].ToString() != "")
            {
                model.SortNum = int.Parse(row["SortNum"].ToString());
            }
            model.Remark = row["Remark"].ToString

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
        public static List<Model.T_Customer> FillList(DataTable dt)
        {
            List<Model.T_Customer> list = new List<Model.T_Customer>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(FillModelByRow(row));
            }
            return list;
        }
        #endregion
    }
}