using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//系统参数表
		public class T_SytemSet
	{
   		
   		#region 数据库私有字段 	
   				private int _id=0;//全局唯一键
				private string _snum=string.Empty;//参数编号
				private string _sname=string.Empty;//参数名称
				private string _svalue=string.Empty;//参数值
				private string _sreamrk=string.Empty;//设置参考
				private int _sdeletemark=0;//删除标记
				private string _u1=string.Empty;//备用字段1
				private string _u2=string.Empty;//备用字段2
				private string _u3=string.Empty;//备用字段3
				private string _u4=string.Empty;//备用字段4
				#endregion 
		#region IsEdit私有字段 
		private bool _isEdit = false;
   				private bool _id_IsEdit = false;
				private bool _snum_IsEdit = false;
				private bool _sname_IsEdit = false;
				private bool _svalue_IsEdit = false;
				private bool _sreamrk_IsEdit = false;
				private bool _sdeletemark_IsEdit = false;
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
            	_isEdit=true;
           		_id = value;
            }
        }        
				/// <summary>
		/// 参数编号
        /// </summary>		
        public string sNum
        {
            get
            {
            	return _snum;
            }
            set
            {
            	_snum_IsEdit = true;
            	_isEdit=true;
           		_snum = value;
            }
        }        
				/// <summary>
		/// 参数名称
        /// </summary>		
        public string sName
        {
            get
            {
            	return _sname;
            }
            set
            {
            	_sname_IsEdit = true;
            	_isEdit=true;
           		_sname = value;
            }
        }        
				/// <summary>
		/// 参数值
        /// </summary>		
        public string sValue
        {
            get
            {
            	return _svalue;
            }
            set
            {
            	_svalue_IsEdit = true;
            	_isEdit=true;
           		_svalue = value;
            }
        }        
				/// <summary>
		/// 设置参考
        /// </summary>		
        public string sReamrk
        {
            get
            {
            	return _sreamrk;
            }
            set
            {
            	_sreamrk_IsEdit = true;
            	_isEdit=true;
           		_sreamrk = value;
            }
        }        
				/// <summary>
		/// 删除标记
        /// </summary>		
        public int sDeleteMark
        {
            get
            {
            	return _sdeletemark;
            }
            set
            {
            	_sdeletemark_IsEdit = true;
            	_isEdit=true;
           		_sdeletemark = value;
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
            	_isEdit=true;
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
            	_isEdit=true;
           		_u2 = value;
            }
        }        
				/// <summary>
		/// 备用字段3
        /// </summary>		
        public string U3
        {
            get
            {
            	return _u3;
            }
            set
            {
            	_u3_IsEdit = true;
            	_isEdit=true;
           		_u3 = value;
            }
        }        
				/// <summary>
		/// 备用字段4
        /// </summary>		
        public string U4
        {
            get
            {
            	return _u4;
            }
            set
            {
            	_u4_IsEdit = true;
            	_isEdit=true;
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
   				if(value==false)
				{
				// 将全部字段的IsDirty值设置为false
   									_id_IsEdit=false;
							_snum_IsEdit=false;
							_sname_IsEdit=false;
							_svalue_IsEdit=false;
							_sreamrk_IsEdit=false;
							_sdeletemark_IsEdit=false;
							_u1_IsEdit=false;
							_u2_IsEdit=false;
							_u3_IsEdit=false;
							_u4_IsEdit=false;
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
		/// sNum是否已修改
        /// </summary>		
        public bool sNum_IsEdit
        {
            get
            {
            	return _snum_IsEdit; 
            }
        }        
				/// <summary>
		/// sName是否已修改
        /// </summary>		
        public bool sName_IsEdit
        {
            get
            {
            	return _sname_IsEdit; 
            }
        }        
				/// <summary>
		/// sValue是否已修改
        /// </summary>		
        public bool sValue_IsEdit
        {
            get
            {
            	return _svalue_IsEdit; 
            }
        }        
				/// <summary>
		/// sReamrk是否已修改
        /// </summary>		
        public bool sReamrk_IsEdit
        {
            get
            {
            	return _sreamrk_IsEdit; 
            }
        }        
				/// <summary>
		/// sDeleteMark是否已修改
        /// </summary>		
        public bool sDeleteMark_IsEdit
        {
            get
            {
            	return _sdeletemark_IsEdit; 
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
		public static Model.T_SytemSet FillModel(DataTable table)
		{
			if(table.Rows.Count<=0)
			{return null;}
			return FillModelByRow(table.Rows[0]);
		}
		public static Model.T_SytemSet FillModelByRow(DataRow row)
		{
			Model.T_SytemSet model = new Model.T_SytemSet();
											if(row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
																																				model.sNum= row["sNum"].ToString
();
																																model.sName= row["sName"].ToString
();
																																model.sValue= row["sValue"].ToString
();
																																model.sReamrk= row["sReamrk"].ToString
();
																												if(row["sDeleteMark"].ToString()!="")
				{
					model.sDeleteMark=int.Parse(row["sDeleteMark"].ToString());
				}
																																				model.U1= row["U1"].ToString
();
																																model.U2= row["U2"].ToString
();
																																model.U3= row["U3"].ToString
();
																																model.U4= row["U4"].ToString
();
																					
				return model;
		}
		/// <summary>
		/// 用DataTable填充一个实体集合
		/// </summary>
  		public static List<Model.T_SytemSet> FillList(DataTable dt)
		{
				List<Model.T_SytemSet> list =new List<Model.T_SytemSet>();
				foreach(DataRow row in dt.Rows)
				{
					list.Add(FillModelByRow(row));
				}
				return list;
		}
		#endregion 
	}
}