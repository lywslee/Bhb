using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DBUtility;
using System.Collections.ObjectModel;
using Model;
using Common;
namespace DAL  
{
	 	//U盾管理表
		public class T_UshieldBase
	{				
		#region (公开)数据修改(添加、修改、删除)
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Insert(Model.T_Ushield model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [T_Ushield](");			
            strSql.Append("UName,HardWareCode,Seed,UKey,Remark,DeleteMark");
			strSql.Append(") values (");
            strSql.Append("@UName,@HardWareCode,@Seed,@UKey,@Remark,@DeleteMark");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@UName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@HardWareCode", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Seed", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@UKey", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@DeleteMark", SqlDbType.TinyInt,1)             
              
            };
			            
            parameters[0].Value = model.UName;                        
            parameters[1].Value = model.HardWareCode;                        
            parameters[2].Value = model.Seed;                        
            parameters[3].Value = model.UKey;                        
            parameters[4].Value = model.Remark;                        
            parameters[5].Value = model.DeleteMark;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                    
            	return Convert.ToInt32(obj);
                                                                  
			}			   
            			
		}
		
		
		 /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.T_Ushield model)
		{
			StringBuilder strSql=new StringBuilder();
			Collection<SqlParameter> parameters = new Collection<SqlParameter>

();
			SqlParameter parameter = null;
			int count = 0;
			strSql.Append("update [T_Ushield] set ");
			                         parameter = new SqlParameter("@ID", 

SqlDbType.Int,4 ); 
                parameter.Value = model.ID;
                parameters.Add(parameter);
             
             
                         
             
            if(model.UName_IsEdit)
            {
            strSql.Append(" UName = @UName,");
             parameter = new SqlParameter("@UName", 

SqlDbType.VarChar,100 ); 
                parameter.Value = model.UName;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.HardWareCode_IsEdit)
            {
            strSql.Append(" HardWareCode = @HardWareCode,");
             parameter = new SqlParameter("@HardWareCode", 

SqlDbType.VarChar,100 ); 
                parameter.Value = model.HardWareCode;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.Seed_IsEdit)
            {
            strSql.Append(" Seed = @Seed,");
             parameter = new SqlParameter("@Seed", 

SqlDbType.VarChar,100 ); 
                parameter.Value = model.Seed;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.UKey_IsEdit)
            {
            strSql.Append(" UKey = @UKey,");
             parameter = new SqlParameter("@UKey", 

SqlDbType.VarChar,100 ); 
                parameter.Value = model.UKey;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.Remark_IsEdit)
            {
            strSql.Append(" Remark = @Remark,");
             parameter = new SqlParameter("@Remark", 

SqlDbType.VarChar,200 ); 
                parameter.Value = model.Remark;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.DeleteMark_IsEdit)
            {
            strSql.Append(" DeleteMark = @DeleteMark,");
             parameter = new SqlParameter("@DeleteMark", 

SqlDbType.TinyInt,1 ); 
                parameter.Value = model.DeleteMark;
                parameters.Add(parameter);
                count++;
            }
             
                        if(count>0)
            {
                strSql.Remove(strSql.Length - 1, 1);
            }
            if(count==0)
            {
            	return false;
            }
			strSql.Append(" where ID=@ID ");
			 // 将参数泛形集合转传为数组
            SqlParameter[] args = new SqlParameter[parameters.Count];
            parameters.CopyTo(args, 0);	          
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),args);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [T_Ushield] ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [T_Ushield] ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				 #endregion 
		
		#region (公开)查询
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [T_Ushield]");
			strSql.Append(" where ");
			                                       strSql.Append(" ID = @ID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 根据Id得到一个对象实体
		/// </summary>
		public Model.T_Ushield GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, UName, HardWareCode, Seed, UKey, Remark, DeleteMark  ");			
			strSql.Append("  from [T_Ushield] ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;
			
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			return Model.T_Ushield.FillModel(ds.Tables[0]);
		}
		
		/// <summary>
		/// 获得指定条件的唯一一条数据实体
		/// </summary>
		public Model.T_Ushield GetModel(string strWhere)
		{	
			StringBuilder sql = new StringBuilder();
			sql.Append(@"select * from [T_Ushield] ");
			if(strWhere.Trim()!="")
			{
				sql.Append(" where 1=1 "+strWhere);
			}
			return Model.T_Ushield.FillModel(DbHelperSQL.Query(sql.ToString()).Tables[0]);
		}
		/// <summary>
        /// 分页查询
		/// </summary>
		/// <param name="pageSize">每页数据条数</param>
		/// <param name="pageIndex">当前页码</param>
		/// <param name="strWhere">查询条件</param>
		/// <param name="filedOrder">排序语句</param>
		/// <param name="recordCount">记录总数</param>
		/// <returns></returns>
		public List<Model.T_Ushield> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{     
                StringBuilder strSql = new StringBuilder();
            strSql.Append("select   m.*  FROM [T_Ushield] m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

			return Model.T_Ushield.FillList(DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0]);
		}
		/// <summary>
		/// 获得记录总数
		/// </summary>
		public int GetCount(string strWhere)
		{
			StringBuilder sql = new StringBuilder();
            sql.Append(@"select count(1) from [T_Ushield] ");
			if(strWhere.Trim()!="")
			{
				sql.Append(" where 1=1 " + strWhere);
			}
			object obj = DbHelperSQL.GetSingle(sql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		/// <summary>
		/// 获得数据列表List 
		/// </summary>
		public List<Model.T_Ushield> GetList(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [T_Ushield] ");
			if(where.Trim()!="")
			{
				strSql.Append(" where 1=1 " + where);
			}
			return Model.T_Ushield.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Model.T_Ushield> GetTopList(int top,string 

where,string orderField)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(top>0)
			{
				strSql.Append(" top "+top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM [T_Ushield] ");
			if(where.Trim()!="")
			{
				strSql.Append(" where 1=1 " + where);
			}
			strSql.Append(" order by " + orderField);
			return Model.T_Ushield.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
		}
		
		/// <summary>
		/// 获得数据列表DataTable 
		/// </summary>
		public DataTable GetDataTable(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [T_Ushield] ");
			if(where.Trim()!="")
			{
				strSql.Append(" where 1=1 " + where);
			}
			return DbHelperSQL.Query(strSql.ToString()).Tables[0];
		}
		#endregion 
		
	}
}

