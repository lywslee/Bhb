using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//产品规格表
		public class T_Standard
	{
   		
   		#region 数据库私有字段 	
   				private int _id=0;//全局唯一键
				private string _sproductnum=string.Empty;//产品编号
				private string _sname=string.Empty;//规格名称
				private string _sunit=string.Empty;//计量单位
				private decimal _sweight=0;//重量
				private decimal _svolume=0;//体积
				private decimal _sprice=0;//价格
				private int _ssortnum=0;//排序序号
				#endregion 
		#region IsEdit私有字段 
		private bool _isEdit = false;
   				private bool _id_IsEdit = false;
				private bool _sproductnum_IsEdit = false;
				private bool _sname_IsEdit = false;
				private bool _sunit_IsEdit = false;
				private bool _sweight_IsEdit = false;
				private bool _svolume_IsEdit = false;
				private bool _sprice_IsEdit = false;
				private bool _ssortnum_IsEdit = false;
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
		/// 产品编号
        /// </summary>		
        public string sProductNum
        {
            get
            {
            	return _sproductnum;
            }
            set
            {
            	_sproductnum_IsEdit = true;
            	_isEdit=true;
           		_sproductnum = value;
            }
        }        
				/// <summary>
		/// 规格名称
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
		/// 计量单位
        /// </summary>		
        public string sUnit
        {
            get
            {
            	return _sunit;
            }
            set
            {
            	_sunit_IsEdit = true;
            	_isEdit=true;
           		_sunit = value;
            }
        }        
				/// <summary>
		/// 重量
        /// </summary>		
        public decimal sWeight
        {
            get
            {
            	return _sweight;
            }
            set
            {
            	_sweight_IsEdit = true;
            	_isEdit=true;
           		_sweight = value;
            }
        }        
				/// <summary>
		/// 体积
        /// </summary>		
        public decimal sVolume
        {
            get
            {
            	return _svolume;
            }
            set
            {
            	_svolume_IsEdit = true;
            	_isEdit=true;
           		_svolume = value;
            }
        }        
				/// <summary>
		/// 价格
        /// </summary>		
        public decimal sPrice
        {
            get
            {
            	return _sprice;
            }
            set
            {
            	_sprice_IsEdit = true;
            	_isEdit=true;
           		_sprice = value;
            }
        }        
				/// <summary>
		/// 排序序号
        /// </summary>		
        public int sSortNum
        {
            get
            {
            	return _ssortnum;
            }
            set
            {
            	_ssortnum_IsEdit = true;
            	_isEdit=true;
           		_ssortnum = value;
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
							_sproductnum_IsEdit=false;
							_sname_IsEdit=false;
							_sunit_IsEdit=false;
							_sweight_IsEdit=false;
							_svolume_IsEdit=false;
							_sprice_IsEdit=false;
							_ssortnum_IsEdit=false;
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
		/// sProductNum是否已修改
        /// </summary>		
        public bool sProductNum_IsEdit
        {
            get
            {
            	return _sproductnum_IsEdit; 
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
		/// sUnit是否已修改
        /// </summary>		
        public bool sUnit_IsEdit
        {
            get
            {
            	return _sunit_IsEdit; 
            }
        }        
				/// <summary>
		/// sWeight是否已修改
        /// </summary>		
        public bool sWeight_IsEdit
        {
            get
            {
            	return _sweight_IsEdit; 
            }
        }        
				/// <summary>
		/// sVolume是否已修改
        /// </summary>		
        public bool sVolume_IsEdit
        {
            get
            {
            	return _svolume_IsEdit; 
            }
        }        
				/// <summary>
		/// sPrice是否已修改
        /// </summary>		
        public bool sPrice_IsEdit
        {
            get
            {
            	return _sprice_IsEdit; 
            }
        }        
				/// <summary>
		/// sSortNum是否已修改
        /// </summary>		
        public bool sSortNum_IsEdit
        {
            get
            {
            	return _ssortnum_IsEdit; 
            }
        }        
		   		#endregion 	
   		#region 填充实体
		/// <summary>
		/// 用DataRow填充一个实体
		/// </summary>
		public static Model.T_Standard FillModel(DataTable table)
		{
			if(table.Rows.Count<=0)
			{return null;}
			return FillModelByRow(table.Rows[0]);
		}
		public static Model.T_Standard FillModelByRow(DataRow row)
		{
			Model.T_Standard model = new Model.T_Standard();
											if(row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
																																				model.sProductNum= row["sProductNum"].ToString
();
																																model.sName= row["sName"].ToString
();
																																model.sUnit= row["sUnit"].ToString
();
																												if(row["sWeight"].ToString()!="")
				{
					model.sWeight=decimal.Parse(row["sWeight"].ToString());
				}
																																if(row["sVolume"].ToString()!="")
				{
					model.sVolume=decimal.Parse(row["sVolume"].ToString());
				}
																																if(row["sPrice"].ToString()!="")
				{
					model.sPrice=decimal.Parse(row["sPrice"].ToString());
				}
																																if(row["sSortNum"].ToString()!="")
				{
					model.sSortNum=int.Parse(row["sSortNum"].ToString());
				}
																									
				return model;
		}
		/// <summary>
		/// 用DataTable填充一个实体集合
		/// </summary>
  		public static List<Model.T_Standard> FillList(DataTable dt)
		{
				List<Model.T_Standard> list =new List<Model.T_Standard>();
				foreach(DataRow row in dt.Rows)
				{
					list.Add(FillModelByRow(row));
				}
				return list;
		}
		#endregion 
	}
}