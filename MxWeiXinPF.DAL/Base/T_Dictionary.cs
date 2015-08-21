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
	 	//数据字典表
		public class T_DictionaryBase
	{				
		#region (公开)数据修改(添加、修改、删除)
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Insert(Model.T_Dictionary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [T_Dictionary](");			
            strSql.Append("dNum,dName,dType,dLevel,dMark,dSortNum,dRemark");
			strSql.Append(") values (");
            strSql.Append("@dNum,@dName,@dType,@dLevel,@dMark,@dSortNum,@dRemark");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@dNum", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@dType", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dLevel", SqlDbType.Int,4) ,            
                        new SqlParameter("@dMark", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@dSortNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@dRemark", SqlDbType.VarChar,200)             
              
            };
			            
            parameters[0].Value = model.dNum;                        
            parameters[1].Value = model.dName;                        
            parameters[2].Value = model.dType;                        
            parameters[3].Value = model.dLevel;                        
            parameters[4].Value = model.dMark;                        
            parameters[5].Value = model.dSortNum;                        
            parameters[6].Value = model.dRemark;                        
			   
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
		public bool Update(Model.T_Dictionary model)
		{
			StringBuilder strSql=new StringBuilder();
			Collection<SqlParameter> parameters = new Collection<SqlParameter>
();
			SqlParameter parameter = null;
			int count = 0;
			strSql.Append("update [T_Dictionary] set ");
			                         parameter = new SqlParameter("@ID", 
SqlDbType.Int,4 ); 
                parameter.Value = model.ID;
                parameters.Add(parameter);
             
             
                         
             
            if(model.dNum_IsEdit)
            {
            strSql.Append(" dNum = @dNum,");
             parameter = new SqlParameter("@dNum", 
SqlDbType.VarChar,20 ); 
                parameter.Value = model.dNum;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.dName_IsEdit)
            {
            strSql.Append(" dName = @dName,");
             parameter = new SqlParameter("@dName", 
SqlDbType.VarChar,100 ); 
                parameter.Value = model.dName;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.dType_IsEdit)
            {
            strSql.Append(" dType = @dType,");
             parameter = new SqlParameter("@dType", 
SqlDbType.VarChar,10 ); 
                parameter.Value = model.dType;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.dLevel_IsEdit)
            {
            strSql.Append(" dLevel = @dLevel,");
             parameter = new SqlParameter("@dLevel", 
SqlDbType.Int,4 ); 
                parameter.Value = model.dLevel;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.dMark_IsEdit)
            {
            strSql.Append(" dMark = @dMark,");
             parameter = new SqlParameter("@dMark", 
SqlDbType.VarChar,10 ); 
                parameter.Value = model.dMark;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.dSortNum_IsEdit)
            {
            strSql.Append(" dSortNum = @dSortNum,");
             parameter = new SqlParameter("@dSortNum", 
SqlDbType.Int,4 ); 
                parameter.Value = model.dSortNum;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.dRemark_IsEdit)
            {
            strSql.Append(" dRemark = @dRemark,");
             parameter = new SqlParameter("@dRemark", 
SqlDbType.VarChar,200 ); 
                parameter.Value = model.dRemark;
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
			strSql.Append("delete from [T_Dictionary] ");
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
			strSql.Append("delete from [T_Dictionary] ");
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
		public bool Exists(int ID,string dNum,string dName,string dType)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [T_Dictionary]");
			strSql.Append(" where ");
			                                       strSql.Append(" ID = @ID and  ");
                                                                   strSql.Append(" dNum = @dNum and  ");
                                                                   strSql.Append(" dName = @dName and  ");
                                                                   strSql.Append(" dType = @dType  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@dNum", SqlDbType.VarChar,20),
					new SqlParameter("@dName", SqlDbType.VarChar,100),
					new SqlParameter("@dType", SqlDbType.VarChar,10)			};
			parameters[0].Value = ID;
			parameters[1].Value = dNum;
			parameters[2].Value = dName;
			parameters[3].Value = dType;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 根据Id得到一个对象实体
		/// </summary>
		public Model.T_Dictionary GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, dNum, dName, dType, dLevel, dMark, dSortNum, dRemark  ");			
			strSql.Append("  from [T_Dictionary] ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;
			
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			return Model.T_Dictionary.FillModel(ds.Tables[0]);
		}
		
		/// <summary>
		/// 获得指定条件的唯一一条数据实体
		/// </summary>
		public Model.T_Dictionary GetModel(string strWhere)
		{	
			StringBuilder sql = new StringBuilder();
			sql.Append(@"select * from [T_Dictionary] ");
			if(strWhere.Trim()!="")
			{
				sql.Append(" where 1=1 "+strWhere);
			}
			return Model.T_Dictionary.FillModel(DbHelperSQL.Query(sql.ToString()).Tables[0]);
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
		public List<Model.T_Dictionary> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{     
                StringBuilder strSql = new StringBuilder();
            strSql.Append("select   m.*  FROM [T_Dictionary] m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

			return Model.T_Dictionary.FillList(DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0]);
		}
		/// <summary>
		/// 获得记录总数
		/// </summary>
		public int GetCount(string strWhere)
		{
			StringBuilder sql = new StringBuilder();
            sql.Append(@"select count(1) from [T_Dictionary] ");
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
		public List<Model.T_Dictionary> GetList(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [T_Dictionary] ");
			if(where.Trim()!="")
			{
				strSql.Append(" where 1=1 " + where);
			}
			return Model.T_Dictionary.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Model.T_Dictionary> GetTopList(int top,string 
where,string orderField)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(top>0)
			{
				strSql.Append(" top "+top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM [T_Dictionary] ");
			if(where.Trim()!="")
			{
				strSql.Append(" where 1=1 " + where);
			}
			strSql.Append(" order by " + orderField);
			return Model.T_Dictionary.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
		}
		
		/// <summary>
		/// 获得数据列表DataTable 
		/// </summary>
		public DataTable GetDataTable(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [T_Dictionary] ");
			if(where.Trim()!="")
			{
				strSql.Append(" where 1=1 " + where);
			}
			return DbHelperSQL.Query(strSql.ToString()).Tables[0];
		}
		#endregion 
		
	}
}

