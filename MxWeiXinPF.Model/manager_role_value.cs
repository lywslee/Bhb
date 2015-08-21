using System;
using System.Data;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// �����ɫȨ��:ʵ����
    /// </summary>
    [Serializable]
    public partial class manager_role_value
    {
        public manager_role_value()
        { }
        #region Model

        #region ���ݿ�˽���ֶ�
        private int _id = 0;//����ID
        private int _role_id = 0;//��ɫID
        private string _nav_name = string.Empty;//��������
        private string _action_type = string.Empty;//Ȩ������
        #endregion
        #region IsEdit˽���ֶ�
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _role_id_IsEdit = false;
        private bool _nav_name_IsEdit = false;
        private bool _action_type_IsEdit = false;
        #endregion
        #region  ��������
        /// <summary>
        /// ����ID
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
        /// ��ɫID
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
        /// ��������
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
        /// Ȩ������
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
                    // ��ȫ���ֶε�IsDirtyֵ����Ϊfalse
                    _id_IsEdit = false;
                    _role_id_IsEdit = false;
                    _nav_name_IsEdit = false;
                    _action_type_IsEdit = false;
                }
            }
        }
        /// <summary>
        /// id�Ƿ����޸�
        /// </summary>		
        public bool id_IsEdit
        {
            get
            {
                return _id_IsEdit;
            }
        }
        /// <summary>
        /// role_id�Ƿ����޸�
        /// </summary>		
        public bool role_id_IsEdit
        {
            get
            {
                return _role_id_IsEdit;
            }
        }
        /// <summary>
        /// nav_name�Ƿ����޸�
        /// </summary>		
        public bool nav_name_IsEdit
        {
            get
            {
                return _nav_name_IsEdit;
            }
        }
        /// <summary>
        /// action_type�Ƿ����޸�
        /// </summary>		
        public bool action_type_IsEdit
        {
            get
            {
                return _action_type_IsEdit;
            }
        }
        #endregion
        #region ���ʵ��
        /// <summary>
        /// ��DataRow���һ��ʵ��
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
        /// ��DataTable���һ��ʵ�弯��
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