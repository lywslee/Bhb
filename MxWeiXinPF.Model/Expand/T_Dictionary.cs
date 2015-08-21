using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//数据字典表
		public class T_Dictionary
	{
   		
   		#region 数据库私有字段 	
   				private int _id=0;//全局唯一键
				private string _dnum=string.Empty;//代码编号
				private string _dname=string.Empty;//代码名称
				private string _dtype=string.Empty;//代码类别
				private int _dlevel=0;//代码级次
				private string _dmark=string.Empty;//代码标记
				private int _dsortnum=0;//排序号
				private string _dremark=string.Empty;//备注
				#endregion 
		#region IsEdit私有字段 
		private bool _isEdit = false;
   				private bool _id_IsEdit = false;
				private bool _dnum_IsEdit = false;
				private bool _dname_IsEdit = false;
				private bool _dtype_IsEdit = false;
				private bool _dlevel_IsEdit = false;
				private bool _dmark_IsEdit = false;
				private bool _dsortnum_IsEdit = false;
				private bool _dremark_IsEdit = false;
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
		/// 代码编号
        /// </summary>		
        public string dNum
        {
            get
            {
            	return _dnum;
            }
            set
            {
            	_dnum_IsEdit = true;
            	_isEdit=true;
           		_dnum = value;
            }
        }        
				/// <summary>
		/// 代码名称
        /// </summary>		
        public string dName
        {
            get
            {
            	return _dname;
            }
            set
            {
            	_dname_IsEdit = true;
            	_isEdit=true;
           		_dname = value;
            }
        }        
				/// <summary>
		/// 代码类别
        /// </summary>		
        public string dType
        {
            get
            {
            	return _dtype;
            }
            set
            {
            	_dtype_IsEdit = true;
            	_isEdit=true;
           		_dtype = value;
            }
        }        
				/// <summary>
		/// 代码级次
        /// </summary>		
        public int dLevel
        {
            get
            {
            	return _dlevel;
            }
            set
            {
            	_dlevel_IsEdit = true;
            	_isEdit=true;
           		_dlevel = value;
            }
        }        
				/// <summary>
		/// 代码标记
        /// </summary>		
        public string dMark
        {
            get
            {
            	return _dmark;
            }
            set
            {
            	_dmark_IsEdit = true;
            	_isEdit=true;
           		_dmark = value;
            }
        }        
				/// <summary>
		/// 排序号
        /// </summary>		
        public int dSortNum
        {
            get
            {
            	return _dsortnum;
            }
            set
            {
            	_dsortnum_IsEdit = true;
            	_isEdit=true;
           		_dsortnum = value;
            }
        }        
				/// <summary>
		/// 备注
        /// </summary>		
        public string dRemark
        {
            get
            {
            	return _dremark;
            }
            set
            {
            	_dremark_IsEdit = true;
            	_isEdit=true;
           		_dremark = value;
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
							_dnum_IsEdit=false;
							_dname_IsEdit=false;
							_dtype_IsEdit=false;
							_dlevel_IsEdit=false;
							_dmark_IsEdit=false;
							_dsortnum_IsEdit=false;
							_dremark_IsEdit=false;
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
		/// dNum是否已修改
        /// </summary>		
        public bool dNum_IsEdit
        {
            get
            {
            	return _dnum_IsEdit; 
            }
        }        
				/// <summary>
		/// dName是否已修改
        /// </summary>		
        public bool dName_IsEdit
        {
            get
            {
            	return _dname_IsEdit; 
            }
        }        
				/// <summary>
		/// dType是否已修改
        /// </summary>		
        public bool dType_IsEdit
        {
            get
            {
            	return _dtype_IsEdit; 
            }
        }        
				/// <summary>
		/// dLevel是否已修改
        /// </summary>		
        public bool dLevel_IsEdit
        {
            get
            {
            	return _dlevel_IsEdit; 
            }
        }        
				/// <summary>
		/// dMark是否已修改
        /// </summary>		
        public bool dMark_IsEdit
        {
            get
            {
            	return _dmark_IsEdit; 
            }
        }        
				/// <summary>
		/// dSortNum是否已修改
        /// </summary>		
        public bool dSortNum_IsEdit
        {
            get
            {
            	return _dsortnum_IsEdit; 
            }
        }        
				/// <summary>
		/// dRemark是否已修改
        /// </summary>		
        public bool dRemark_IsEdit
        {
            get
            {
            	return _dremark_IsEdit; 
            }
        }        
		   		#endregion 	
   		#region 填充实体
		/// <summary>
		/// 用DataRow填充一个实体
		/// </summary>
		public static Model.T_Dictionary FillModel(DataTable table)
		{
			if(table.Rows.Count<=0)
			{return null;}
			return FillModelByRow(table.Rows[0]);
		}
		public static Model.T_Dictionary FillModelByRow(DataRow row)
		{
			Model.T_Dictionary model = new Model.T_Dictionary();
											if(row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
																																				model.dNum= row["dNum"].ToString
();
																																model.dName= row["dName"].ToString
();
																																model.dType= row["dType"].ToString
();
																												if(row["dLevel"].ToString()!="")
				{
					model.dLevel=int.Parse(row["dLevel"].ToString());
				}
																																				model.dMark= row["dMark"].ToString
();
																												if(row["dSortNum"].ToString()!="")
				{
					model.dSortNum=int.Parse(row["dSortNum"].ToString());
				}
																																				model.dRemark= row["dRemark"].ToString
();
																					
				return model;
		}
		/// <summary>
		/// 用DataTable填充一个实体集合
		/// </summary>
  		public static List<Model.T_Dictionary> FillList(DataTable dt)
		{
				List<Model.T_Dictionary> list =new List<Model.T_Dictionary>();
				foreach(DataRow row in dt.Rows)
				{
					list.Add(FillModelByRow(row));
				}
				return list;
		}
		#endregion 
	}
}