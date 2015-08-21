using System;
using System.Collections.Generic;
using System.Data;

namespace Model
{
    /// <summary>
    /// �����ɫ:ʵ����
    /// </summary>
    [Serializable]
    public partial class manager_role
    {
        public manager_role()
        { }
        #region Model
        #region ���ݿ�˽���ֶ�
        private int _id = 0;//����ID
        private string _role_name = string.Empty;//��ɫ����
        private int _role_type = 1;//��ɫ����
        private int _is_sys = 0;//�Ƿ�ϵͳĬ��0��1��
        private int _agentid = 0;//�����Ĵ�����Id
        #endregion
        #region IsEdit˽���ֶ�
        private bool _isEdit = false;
        private bool _id_IsEdit = false;
        private bool _role_name_IsEdit = false;
        private bool _role_type_IsEdit = false;
        private bool _is_sys_IsEdit = false;
        private bool _agentid_IsEdit = false;
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
        /// ��ɫ����
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
        /// ��ɫ����
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
        /// �Ƿ�ϵͳĬ��0��1��
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
        /// �����Ĵ�����Id
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
                    // ��ȫ���ֶε�IsDirtyֵ����Ϊfalse
                    _id_IsEdit = false;
                    _role_name_IsEdit = false;
                    _role_type_IsEdit = false;
                    _is_sys_IsEdit = false;
                    _agentid_IsEdit = false;
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
        /// role_name�Ƿ����޸�
        /// </summary>		
        public bool role_name_IsEdit
        {
            get
            {
                return _role_name_IsEdit;
            }
        }
        /// <summary>
        /// role_type�Ƿ����޸�
        /// </summary>		
        public bool role_type_IsEdit
        {
            get
            {
                return _role_type_IsEdit;
            }
        }
        /// <summary>
        /// is_sys�Ƿ����޸�
        /// </summary>		
        public bool is_sys_IsEdit
        {
            get
            {
                return _is_sys_IsEdit;
            }
        }
        /// <summary>
        /// agentId�Ƿ����޸�
        /// </summary>		
        public bool agentId_IsEdit
        {
            get
            {
                return _agentid_IsEdit;
            }
        }
        #endregion
        #region ���ʵ��
        /// <summary>
        /// ��DataRow���һ��ʵ��
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
        /// ��DataTable���һ��ʵ�弯��
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
        /// Ȩ������ 
        /// </summary>
        public List<manager_role_value> manager_role_values
        {
            set { _manager_role_values = value; }
            get { return _manager_role_values; }
        }
    }
}