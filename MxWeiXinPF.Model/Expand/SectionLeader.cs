using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Model
{
    //部门其他负责人Id
    public class SectionLeader
    {

        #region 数据库私有字段
        private int _id = 0;//Id
        private int _peopleid = 0;//其他负责人Id
        private int _sectionid = 0;//部门Id
        private string _ext1 = string.Empty;//Ext1
        #endregion
        #region IsEdit私有字段
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _peopleid_IsEdit = false;
        private bool _sectionid_IsEdit = false;
        private bool _ext1_IsEdit = false;
        #endregion
        #region  公开属性
        /// <summary>
        /// Id
        /// </summary>		
        public int Id
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
        /// 其他负责人Id
        /// </summary>		
        public int PeopleId
        {
            get
            {
                return _peopleid;
            }
            set
            {
                _peopleid_IsEdit = true;
                _isEdit = true;
                _peopleid = value;
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
                    _peopleid_IsEdit = false;
                    _sectionid_IsEdit = false;
                    _ext1_IsEdit = false;
                }
            }
        }
        /// <summary>
        /// Id是否已修改
        /// </summary>		
        public bool Id_IsEdit
        {
            get
            {
                return _id_IsEdit;
            }
        }
        /// <summary>
        /// PeopleId是否已修改
        /// </summary>		
        public bool PeopleId_IsEdit
        {
            get
            {
                return _peopleid_IsEdit;
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
        #endregion
        #region 填充实体
        /// <summary>
        /// 用DataRow填充一个实体
        /// </summary>
        public static Model.SectionLeader FillModel(DataTable table)
        {
            if (table.Rows.Count <= 0)
            { return null; }
            return FillModelByRow(table.Rows[0]);
        }
        public static Model.SectionLeader FillModelByRow(DataRow row)
        {
            Model.SectionLeader model = new Model.SectionLeader();
            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }
            if (row["PeopleId"].ToString() != "")
            {
                model.PeopleId = int.Parse(row["PeopleId"].ToString());
            }
            if (row["SectionId"].ToString() != "")
            {
                model.SectionId = int.Parse(row["SectionId"].ToString());
            }
            model.Ext1 = row["Ext1"].ToString

();

            return model;
        }
        /// <summary>
        /// 用DataTable填充一个实体集合
        /// </summary>
        public static List<Model.SectionLeader> FillList(DataTable dt)
        {
            List<Model.SectionLeader> list = new List<Model.SectionLeader>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(FillModelByRow(row));
            }
            return list;
        }
        #endregion
    }
}