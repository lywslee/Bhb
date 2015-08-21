using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Model
{
    //T_Bill
    public class T_Bill
    {

        #region 数据库私有字段
        private int _id = 0;//全局唯一键
        private string _bnum = string.Empty;//收料编号
        private string _warehouse = string.Empty;//存放仓库
        private string _customername = string.Empty;//客户单位
        private string _cardnumber = string.Empty;//身份证号
        private string _mobile = string.Empty;//移动电话
        private string _tel = string.Empty;//固定电话
        private string _bankname = string.Empty;//代发银行
        private string _bankaccount = string.Empty;//银行账号
        private string _accountname = string.Empty;//户名
        private string _productname = string.Empty;//产品名称
        private string _productstandard = string.Empty;//产品规格
        private string _unit = string.Empty;//单位
        private decimal _grossweight = 0;//产品毛重
        private decimal _tare = 0;//皮重
        private decimal _netweight = 0;//产品净重
        private decimal _price = 0;//单价
        private decimal _amount = 0;//金额
        private string _remark = string.Empty;//收料备注
        private string _pricingman = string.Empty;//划价人员
        private int _loanmark = 0;//放款标记（0：未放款，1：已放款）
        private string _loanman = string.Empty;//放款人员
        private DateTime _loandate = new DateTime(1900, 1, 1);//放款时间
        private string _loantype = string.Empty;//放款类型
        private string _loanremark = string.Empty;//放款备注
        private int _deletemark = 0;//删除标记
        private DateTime _addtime = new DateTime(1900, 1, 1);//添加日期
        private string _addperson = string.Empty;//添加人
        private DateTime _modifytime = new DateTime(1900, 1, 1);//修改日期
        private string _modifyperson = string.Empty;//修改人
        private string _u1 = string.Empty;//备用字段1
        private string _u2 = string.Empty;//备用字段2
        private decimal _u3 = 0;//备用字段3
        private decimal _u4 = 0;//备用字段4
        private int _customerid = 0;//客户Id
        private int _projectid = 0;//产品名称Id
        private int _productstandardid = 0;//产品规格Id
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _bnum_IsEdit = false;
        private bool _warehouse_IsEdit = false;
        private bool _customername_IsEdit = false;
        private bool _cardnumber_IsEdit = false;
        private bool _mobile_IsEdit = false;
        private bool _tel_IsEdit = false;
        private bool _bankname_IsEdit = false;
        private bool _bankaccount_IsEdit = false;
        private bool _accountname_IsEdit = false;
        private bool _productname_IsEdit = false;
        private bool _productstandard_IsEdit = false;
        private bool _unit_IsEdit = false;
        private bool _grossweight_IsEdit = false;
        private bool _tare_IsEdit = false;
        private bool _netweight_IsEdit = false;
        private bool _price_IsEdit = false;
        private bool _amount_IsEdit = false;
        private bool _remark_IsEdit = false;
        private bool _pricingman_IsEdit = false;
        private bool _loanmark_IsEdit = false;
        private bool _loanman_IsEdit = false;
        private bool _loandate_IsEdit = false;
        private bool _loantype_IsEdit = false;
        private bool _loanremark_IsEdit = false;
        private bool _deletemark_IsEdit = false;
        private bool _addtime_IsEdit = false;
        private bool _addperson_IsEdit = false;
        private bool _modifytime_IsEdit = false;
        private bool _modifyperson_IsEdit = false;
        private bool _u1_IsEdit = false;
        private bool _u2_IsEdit = false;
        private bool _u3_IsEdit = false;
        private bool _u4_IsEdit = false;
        private bool _customerid_IsEdit = false;
        private bool _projectid_IsEdit = false;
        private bool _productstandardid_IsEdit = false;
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
        /// 收料编号
        /// </summary>		
        public string BNum
        {
            get
            {
                return _bnum;
            }
            set
            {
                _bnum_IsEdit = true;
                _isEdit = true;
                _bnum = value;
            }
        }
        /// <summary>
        /// 存放仓库
        /// </summary>		
        public string WareHouse
        {
            get
            {
                return _warehouse;
            }
            set
            {
                _warehouse_IsEdit = true;
                _isEdit = true;
                _warehouse = value;
            }
        }
        /// <summary>
        /// 客户单位
        /// </summary>		
        public string CustomerName
        {
            get
            {
                return _customername;
            }
            set
            {
                _customername_IsEdit = true;
                _isEdit = true;
                _customername = value;
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
        public string AccountName
        {
            get
            {
                return _accountname;
            }
            set
            {
                _accountname_IsEdit = true;
                _isEdit = true;
                _accountname = value;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>		
        public string ProductName
        {
            get
            {
                return _productname;
            }
            set
            {
                _productname_IsEdit = true;
                _isEdit = true;
                _productname = value;
            }
        }
        /// <summary>
        /// 产品规格
        /// </summary>		
        public string ProductStandard
        {
            get
            {
                return _productstandard;
            }
            set
            {
                _productstandard_IsEdit = true;
                _isEdit = true;
                _productstandard = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>		
        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit_IsEdit = true;
                _isEdit = true;
                _unit = value;
            }
        }
        /// <summary>
        /// 产品毛重
        /// </summary>		
        public decimal GrossWeight
        {
            get
            {
                return _grossweight;
            }
            set
            {
                _grossweight_IsEdit = true;
                _isEdit = true;
                _grossweight = value;
            }
        }
        /// <summary>
        /// 皮重
        /// </summary>		
        public decimal Tare
        {
            get
            {
                return _tare;
            }
            set
            {
                _tare_IsEdit = true;
                _isEdit = true;
                _tare = value;
            }
        }
        /// <summary>
        /// 产品净重
        /// </summary>		
        public decimal NetWeight
        {
            get
            {
                return _netweight;
            }
            set
            {
                _netweight_IsEdit = true;
                _isEdit = true;
                _netweight = value;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>		
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price_IsEdit = true;
                _isEdit = true;
                _price = value;
            }
        }
        /// <summary>
        /// 金额
        /// </summary>		
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount_IsEdit = true;
                _isEdit = true;
                _amount = value;
            }
        }
        /// <summary>
        /// 收料备注
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
        /// 划价人员
        /// </summary>		
        public string PricingMan
        {
            get
            {
                return _pricingman;
            }
            set
            {
                _pricingman_IsEdit = true;
                _isEdit = true;
                _pricingman = value;
            }
        }
        /// <summary>
        /// 放款标记（0：未放款，1：已放款）
        /// </summary>		
        public int LoanMark
        {
            get
            {
                return _loanmark;
            }
            set
            {
                _loanmark_IsEdit = true;
                _isEdit = true;
                _loanmark = value;
            }
        }
        /// <summary>
        /// 放款人员
        /// </summary>		
        public string LoanMan
        {
            get
            {
                return _loanman;
            }
            set
            {
                _loanman_IsEdit = true;
                _isEdit = true;
                _loanman = value;
            }
        }
        /// <summary>
        /// 放款时间
        /// </summary>		
        public DateTime LoanDate
        {
            get
            {
                return _loandate;
            }
            set
            {
                _loandate_IsEdit = true;
                _isEdit = true;
                _loandate = value;
            }
        }
        /// <summary>
        /// 放款类型
        /// </summary>		
        public string LoanType
        {
            get
            {
                return _loantype;
            }
            set
            {
                _loantype_IsEdit = true;
                _isEdit = true;
                _loantype = value;
            }
        }
        /// <summary>
        /// 放款备注
        /// </summary>		
        public string LoanRemark
        {
            get
            {
                return _loanremark;
            }
            set
            {
                _loanremark_IsEdit = true;
                _isEdit = true;
                _loanremark = value;
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
        /// <summary>
        /// 客户Id
        /// </summary>		
        public int CustomerID
        {
            get
            {
                return _customerid;
            }
            set
            {
                _customerid_IsEdit = true;
                _isEdit = true;
                _customerid = value;
            }
        }
        /// <summary>
        /// 产品名称Id
        /// </summary>		
        public int ProjectId
        {
            get
            {
                return _projectid;
            }
            set
            {
                _projectid_IsEdit = true;
                _isEdit = true;
                _projectid = value;
            }
        }
        /// <summary>
        /// 产品规格Id
        /// </summary>		
        public int ProductStandardId
        {
            get
            {
                return _productstandardid;
            }
            set
            {
                _productstandardid_IsEdit = true;
                _isEdit = true;
                _productstandardid = value;
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
                    _bnum_IsEdit = false;
                    _warehouse_IsEdit = false;
                    _customername_IsEdit = false;
                    _cardnumber_IsEdit = false;
                    _mobile_IsEdit = false;
                    _tel_IsEdit = false;
                    _bankname_IsEdit = false;
                    _bankaccount_IsEdit = false;
                    _accountname_IsEdit = false;
                    _productname_IsEdit = false;
                    _productstandard_IsEdit = false;
                    _unit_IsEdit = false;
                    _grossweight_IsEdit = false;
                    _tare_IsEdit = false;
                    _netweight_IsEdit = false;
                    _price_IsEdit = false;
                    _amount_IsEdit = false;
                    _remark_IsEdit = false;
                    _pricingman_IsEdit = false;
                    _loanmark_IsEdit = false;
                    _loanman_IsEdit = false;
                    _loandate_IsEdit = false;
                    _loantype_IsEdit = false;
                    _loanremark_IsEdit = false;
                    _deletemark_IsEdit = false;
                    _addtime_IsEdit = false;
                    _addperson_IsEdit = false;
                    _modifytime_IsEdit = false;
                    _modifyperson_IsEdit = false;
                    _u1_IsEdit = false;
                    _u2_IsEdit = false;
                    _u3_IsEdit = false;
                    _u4_IsEdit = false;
                    _customerid_IsEdit = false;
                    _projectid_IsEdit = false;
                    _productstandardid_IsEdit = false;
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
        /// BNum是否已修改
        /// </summary>		
        public bool BNum_IsEdit
        {
            get
            {
                return _bnum_IsEdit;
            }
        }
        /// <summary>
        /// WareHouse是否已修改
        /// </summary>		
        public bool WareHouse_IsEdit
        {
            get
            {
                return _warehouse_IsEdit;
            }
        }
        /// <summary>
        /// CustomerName是否已修改
        /// </summary>		
        public bool CustomerName_IsEdit
        {
            get
            {
                return _customername_IsEdit;
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
        /// AccountName是否已修改
        /// </summary>		
        public bool AccountName_IsEdit
        {
            get
            {
                return _accountname_IsEdit;
            }
        }
        /// <summary>
        /// ProductName是否已修改
        /// </summary>		
        public bool ProductName_IsEdit
        {
            get
            {
                return _productname_IsEdit;
            }
        }
        /// <summary>
        /// ProductStandard是否已修改
        /// </summary>		
        public bool ProductStandard_IsEdit
        {
            get
            {
                return _productstandard_IsEdit;
            }
        }
        /// <summary>
        /// Unit是否已修改
        /// </summary>		
        public bool Unit_IsEdit
        {
            get
            {
                return _unit_IsEdit;
            }
        }
        /// <summary>
        /// GrossWeight是否已修改
        /// </summary>		
        public bool GrossWeight_IsEdit
        {
            get
            {
                return _grossweight_IsEdit;
            }
        }
        /// <summary>
        /// Tare是否已修改
        /// </summary>		
        public bool Tare_IsEdit
        {
            get
            {
                return _tare_IsEdit;
            }
        }
        /// <summary>
        /// NetWeight是否已修改
        /// </summary>		
        public bool NetWeight_IsEdit
        {
            get
            {
                return _netweight_IsEdit;
            }
        }
        /// <summary>
        /// Price是否已修改
        /// </summary>		
        public bool Price_IsEdit
        {
            get
            {
                return _price_IsEdit;
            }
        }
        /// <summary>
        /// Amount是否已修改
        /// </summary>		
        public bool Amount_IsEdit
        {
            get
            {
                return _amount_IsEdit;
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
        /// PricingMan是否已修改
        /// </summary>		
        public bool PricingMan_IsEdit
        {
            get
            {
                return _pricingman_IsEdit;
            }
        }
        /// <summary>
        /// LoanMark是否已修改
        /// </summary>		
        public bool LoanMark_IsEdit
        {
            get
            {
                return _loanmark_IsEdit;
            }
        }
        /// <summary>
        /// LoanMan是否已修改
        /// </summary>		
        public bool LoanMan_IsEdit
        {
            get
            {
                return _loanman_IsEdit;
            }
        }
        /// <summary>
        /// LoanDate是否已修改
        /// </summary>		
        public bool LoanDate_IsEdit
        {
            get
            {
                return _loandate_IsEdit;
            }
        }
        /// <summary>
        /// LoanType是否已修改
        /// </summary>		
        public bool LoanType_IsEdit
        {
            get
            {
                return _loantype_IsEdit;
            }
        }
        /// <summary>
        /// LoanRemark是否已修改
        /// </summary>		
        public bool LoanRemark_IsEdit
        {
            get
            {
                return _loanremark_IsEdit;
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
        /// <summary>
        /// CustomerID是否已修改
        /// </summary>		
        public bool CustomerID_IsEdit
        {
            get
            {
                return _customerid_IsEdit;
            }
        }
        /// <summary>
        /// ProjectId是否已修改
        /// </summary>		
        public bool ProjectId_IsEdit
        {
            get
            {
                return _projectid_IsEdit;
            }
        }
        /// <summary>
        /// ProductStandardId是否已修改
        /// </summary>		
        public bool ProductStandardId_IsEdit
        {
            get
            {
                return _productstandardid_IsEdit;
            }
        }
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public static Model.T_Bill FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public static Model.T_Bill FillModelByRow(DataRow row)
        {
            Model.T_Bill model = new Model.T_Bill();
            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            model.BNum = row["BNum"].ToString

();
            model.WareHouse = row["WareHouse"].ToString

();
            model.CustomerName = row["CustomerName"].ToString

();
            model.CardNumber = row["CardNumber"].ToString

();
            model.Mobile = row["Mobile"].ToString

();
            model.Tel = row["Tel"].ToString

();
            model.BankName = row["BankName"].ToString

();
            model.BankAccount = row["BankAccount"].ToString

();
            model.AccountName = row["AccountName"].ToString

();
            model.ProductName = row["ProductName"].ToString

();
            model.ProductStandard = row["ProductStandard"].ToString

();
            model.Unit = row["Unit"].ToString

();
            if (row["GrossWeight"].ToString() != "")
            {
                model.GrossWeight = decimal.Parse(row["GrossWeight"].ToString());
            }
            if (row["Tare"].ToString() != "")
            {
                model.Tare = decimal.Parse(row["Tare"].ToString());
            }
            if (row["NetWeight"].ToString() != "")
            {
                model.NetWeight = decimal.Parse(row["NetWeight"].ToString());
            }
            if (row["Price"].ToString() != "")
            {
                model.Price = decimal.Parse(row["Price"].ToString());
            }
            if (row["Amount"].ToString() != "")
            {
                model.Amount = decimal.Parse(row["Amount"].ToString());
            }
            model.Remark = row["Remark"].ToString

();
            model.PricingMan = row["PricingMan"].ToString

();
            if (row["LoanMark"].ToString() != "")
            {
                model.LoanMark = int.Parse(row["LoanMark"].ToString());
            }
            model.LoanMan = row["LoanMan"].ToString

();
            if (row["LoanDate"].ToString() != "")
            {
                model.LoanDate = DateTime.Parse(row["LoanDate"].ToString());
            }
            model.LoanType = row["LoanType"].ToString

();
            model.LoanRemark = row["LoanRemark"].ToString

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
            if (row["CustomerID"].ToString() != "")
            {
                model.CustomerID = int.Parse(row["CustomerID"].ToString());
            }
            if (row["ProjectId"].ToString() != "")
            {
                model.ProjectId = int.Parse(row["ProjectId"].ToString());
            }
            if (row["ProductStandardId"].ToString() != "")
            {
                model.ProductStandardId = int.Parse(row["ProductStandardId"].ToString());
            }

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public static List<Model.T_Bill> FillList(DataTable dt)
        {
            List<Model.T_Bill> list = new List<Model.T_Bill>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(FillModelByRow(row));
            }
            return list;
        }
        #endregion
    }
}