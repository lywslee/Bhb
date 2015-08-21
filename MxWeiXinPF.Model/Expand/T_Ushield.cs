using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//U盾管理表
		public class T_Ushield
	{
   		
   		#region 数据库私有字段 	
   				private int _id=0;//全局唯一键
				private string _uname=string.Empty;//u盾名称
				private string _hardwarecode=string.Empty;//硬件编码
				private string _seed=string.Empty;//种子码
				private string _ukey=string.Empty;//3des密钥
				private string _remark=string.Empty;//备注
				private int _deletemark=0;//删除标记
				#endregion 
		#region IsEdit私有字段 
		private bool _isEdit = false;
   				private bool _id_IsEdit = false;
				private bool _uname_IsEdit = false;
				private bool _hardwarecode_IsEdit = false;
				private bool _seed_IsEdit = false;
				private bool _ukey_IsEdit = false;
				private bool _remark_IsEdit = false;
				private bool _deletemark_IsEdit = false;
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
            	_isEdit=true;
           		_id = value;
            }
        }        
				/// <summary>
		/// u盾名称
        /// </summary>		
        public string UName
        {
            get
            {
            	return _uname;
            }
            set
            {
            	_uname_IsEdit = true;
            	_isEdit=true;
           		_uname = value;
            }
        }        
				/// <summary>
		/// 硬件编码
        /// </summary>		
        public string HardWareCode
        {
            get
            {
            	return _hardwarecode;
            }
            set
            {
            	_hardwarecode_IsEdit = true;
            	_isEdit=true;
           		_hardwarecode = value;
            }
        }        
				/// <summary>
		/// 种子码
        /// </summary>		
        public string Seed
        {
            get
            {
            	return _seed;
            }
            set
            {
            	_seed_IsEdit = true;
            	_isEdit=true;
           		_seed = value;
            }
        }        
				/// <summary>
		/// 3des密钥
        /// </summary>		
        public string UKey
        {
            get
            {
            	return _ukey;
            }
            set
            {
            	_ukey_IsEdit = true;
            	_isEdit=true;
           		_ukey = value;
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
            	_isEdit=true;
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
            	_isEdit=true;
           		_deletemark = value;
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
   				if(value==false)
				{
				// 将全部字段的IsDirty值设置为false
   									_id_IsEdit=false;
							_uname_IsEdit=false;
							_hardwarecode_IsEdit=false;
							_seed_IsEdit=false;
							_ukey_IsEdit=false;
							_remark_IsEdit=false;
							_deletemark_IsEdit=false;
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
		/// UName是否已修改
        /// </summary>		
        public bool UName_IsEdit
        {
            get
            {
            	return _uname_IsEdit; 
            }
        }        
				/// <summary>
		/// HardWareCode是否已修改
        /// </summary>		
        public bool HardWareCode_IsEdit
        {
            get
            {
            	return _hardwarecode_IsEdit; 
            }
        }        
				/// <summary>
		/// Seed是否已修改
        /// </summary>		
        public bool Seed_IsEdit
        {
            get
            {
            	return _seed_IsEdit; 
            }
        }        
				/// <summary>
		/// UKey是否已修改
        /// </summary>		
        public bool UKey_IsEdit
        {
            get
            {
            	return _ukey_IsEdit; 
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
		   		#endregion 	
   		#region 填充实体
		/// <summary>
		/// 用DataRow填充一个实体
		/// </summary>
		public static Model.T_Ushield FillModel(DataTable table)
		{
			if(table.Rows.Count<=0)
			{return null;}
			return FillModelByRow(table.Rows[0]);
		}
		public static Model.T_Ushield FillModelByRow(DataRow row)
		{
			Model.T_Ushield model = new Model.T_Ushield();
											if(row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
																																				model.UName= row["UName"].ToString
();
																																model.HardWareCode= row["HardWareCode"].ToString
();
																																model.Seed= row["Seed"].ToString
();
																																model.UKey= row["UKey"].ToString
();
																																model.Remark= row["Remark"].ToString
();
																												if(row["DeleteMark"].ToString()!="")
				{
					model.DeleteMark=int.Parse(row["DeleteMark"].ToString());
				}
																									
				return model;
		}
		/// <summary>
		/// 用DataTable填充一个实体集合
		/// </summary>
  		public static List<Model.T_Ushield> FillList(DataTable dt)
		{
				List<Model.T_Ushield> list =new List<Model.T_Ushield>();
				foreach(DataRow row in dt.Rows)
				{
					list.Add(FillModelByRow(row));
				}
				return list;
		}
		#endregion 
	}
}