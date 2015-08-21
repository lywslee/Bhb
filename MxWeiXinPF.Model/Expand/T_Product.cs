using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Model
{
    //产品分类表
    public class T_Product
    {

        #region 数据库私有字段
        private int _id = 0;//全局唯一键
        private string _pnum = string.Empty;//产品编号
        private string _pname = string.Empty;//产品名称
        private string _pzjm = string.Empty;//助记码
        private int _psortnum = 0;//排序序号
        private string _premark = string.Empty;//备注
        private string _sremark = string.Empty;//备注
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _pnum_IsEdit = false;
        private bool _pname_IsEdit = false;
        private bool _pzjm_IsEdit = false;
        private bool _psortnum_IsEdit = false;
        private bool _premark_IsEdit = false;
        private bool _sremark_IsEdit = false;
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
        /// 产品编号
        /// </summary>		
        public string pNum
        {
            get
            {
                return _pnum;
            }
            set
            {
                _pnum_IsEdit = true;
                _isEdit = true;
                _pnum = value;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>		
        public string pName
        {
            get
            {
                return _pname;
            }
            set
            {
                _pname_IsEdit = true;
                _isEdit = true;
                _pname = value;
            }
        }
        /// <summary>
        /// 助记码
        /// </summary>		
        public string pZjm
        {
            get
            {
                return _pzjm;
            }
            set
            {
                _pzjm_IsEdit = true;
                _isEdit = true;
                _pzjm = value;
            }
        }
        /// <summary>
        /// 排序序号
        /// </summary>		
        public int pSortNum
        {
            get
            {
                return _psortnum;
            }
            set
            {
                _psortnum_IsEdit = true;
                _isEdit = true;
                _psortnum = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        public string pRemark
        {
            get
            {
                return _premark;
            }
            set
            {
                _premark_IsEdit = true;
                _isEdit = true;
                _premark = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        public string sRemark
        {
            get
            {
                return _sremark;
            }
            set
            {
                _sremark_IsEdit = true;
                _isEdit = true;
                _sremark = value;
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
                    _pnum_IsEdit = false;
                    _pname_IsEdit = false;
                    _pzjm_IsEdit = false;
                    _psortnum_IsEdit = false;
                    _premark_IsEdit = false;
                    _sremark_IsEdit = false;
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
        /// pNum是否已修改
        /// </summary>		
        public bool pNum_IsEdit
        {
            get
            {
                return _pnum_IsEdit;
            }
        }
        /// <summary>
        /// pName是否已修改
        /// </summary>		
        public bool pName_IsEdit
        {
            get
            {
                return _pname_IsEdit;
            }
        }
        /// <summary>
        /// pZjm是否已修改
        /// </summary>		
        public bool pZjm_IsEdit
        {
            get
            {
                return _pzjm_IsEdit;
            }
        }
        /// <summary>
        /// pSortNum是否已修改
        /// </summary>		
        public bool pSortNum_IsEdit
        {
            get
            {
                return _psortnum_IsEdit;
            }
        }
        /// <summary>
        /// pRemark是否已修改
        /// </summary>		
        public bool pRemark_IsEdit
        {
            get
            {
                return _premark_IsEdit;
            }
        }
        /// <summary>
        /// sRemark是否已修改
        /// </summary>		
        public bool sRemark_IsEdit
        {
            get
            {
                return _sremark_IsEdit;
            }
        }
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public static Model.T_Product FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public static Model.T_Product FillModelByRow(DataRow row)
        {
            Model.T_Product model = new Model.T_Product();
            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            model.pNum = row["pNum"].ToString

();
            model.pName = row["pName"].ToString

();
            model.pZjm = row["pZjm"].ToString

();
            if (row["pSortNum"].ToString() != "")
            {
                model.pSortNum = int.Parse(row["pSortNum"].ToString());
            }
            model.pRemark = row["pRemark"].ToString

();
            model.sRemark = row["sRemark"].ToString

();

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public static List<Model.T_Product> FillList(DataTable dt)
        {
            List<Model.T_Product> list = new List<Model.T_Product>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(FillModelByRow(row));
            }
            return list;
        }
        #endregion
    }
}