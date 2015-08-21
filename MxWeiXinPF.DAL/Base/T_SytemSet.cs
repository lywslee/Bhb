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
	 	//系统参数表
		public class T_SytemSetBase
	{				
		#region (公开)数据修改(添加、修改、删除)
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Insert(Model.T_SytemSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [T_SytemSet](");			
            strSql.Append("sNum,sName,sValue,sReamrk,sDeleteMark,U1,U2,U3,U4");
			strSql.Append(") values (");
            strSql.Append("@sNum,@sName,@sValue,@sReamrk,@sDeleteMark,@U1,@U2,@U3,@U4");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@sNum", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@sName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@sValue", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@sReamrk", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@sDeleteMark", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@U1", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@U2", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@U3", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@U4", SqlDbType.VarChar,200)             
              
            };
			            
            parameters[0].Value = model.sNum;                        
            parameters[1].Value = model.sName;                        
            parameters[2].Value = model.sValue;                        
            parameters[3].Value = model.sReamrk;                        
            parameters[4].Value = model.sDeleteMark;                        
            parameters[5].Value = model.U1;                        
            parameters[6].Value = model.U2;                        
            parameters[7].Value = model.U3;                        
            parameters[8].Value = model.U4;                        
			   
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
		public bool Update(Model.T_SytemSet model)
		{
			StringBuilder strSql=new StringBuilder();
			Collection<SqlParameter> parameters = new Collection<SqlParameter>
();
			SqlParameter parameter = null;
			int count = 0;
			strSql.Append("update [T_SytemSet] set ");
			                         parameter = new SqlParameter("@ID", 
SqlDbType.Int,4 ); 
                parameter.Value = model.ID;
                parameters.Add(parameter);
             
             
                         
             
            if(model.sNum_IsEdit)
            {
            strSql.Append(" sNum = @sNum,");
             parameter = new SqlParameter("@sNum", 
SqlDbType.VarChar,20 ); 
                parameter.Value = model.sNum;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.sName_IsEdit)
            {
            strSql.Append(" sName = @sName,");
             parameter = new SqlParameter("@sName", 
SqlDbType.VarChar,100 ); 
                parameter.Value = model.sName;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.sValue_IsEdit)
            {
            strSql.Append(" sValue = @sValue,");
             parameter = new SqlParameter("@sValue", 
SqlDbType.VarChar,200 ); 
                parameter.Value = model.sValue;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.sReamrk_IsEdit)
            {
            strSql.Append(" sReamrk = @sReamrk,");
             parameter = new SqlParameter("@sReamrk", 
SqlDbType.VarChar,200 ); 
                parameter.Value = model.sReamrk;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.sDeleteMark_IsEdit)
            {
            strSql.Append(" sDeleteMark = @sDeleteMark,");
             parameter = new SqlParameter("@sDeleteMark", 
SqlDbType.TinyInt,1 ); 
                parameter.Value = model.sDeleteMark;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.U1_IsEdit)
            {
            strSql.Append(" U1 = @U1,");
             parameter = new SqlParameter("@U1", 
SqlDbType.VarChar,200 ); 
                parameter.Value = model.U1;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.U2_IsEdit)
            {
            strSql.Append(" U2 = @U2,");
             parameter = new SqlParameter("@U2", 
SqlDbType.VarChar,200 ); 
                parameter.Value = model.U2;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.U3_IsEdit)
            {
            strSql.Append(" U3 = @U3,");
             parameter = new SqlParameter("@U3", 
SqlDbType.VarChar,200 ); 
                parameter.Value = model.U3;
                parameters.Add(parameter);
                count++;
            }
             
                         
             
            if(model.U4_IsEdit)
            {
            strSql.Append(" U4 = @U4,");
             parameter = new SqlParameter("@U4", 
SqlDbType.VarChar,200 ); 
                parameter.Value = model.U4;
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
			strSql.Append("delete from [T_SytemSet] ");
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
			strSql.Append("delete from [T_SytemSet] ");
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
			strSql.Append("select count(1) from [T_SytemSet]");
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
		public Model.T_SytemSet GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, sNum, sName, sValue, sReamrk, sDeleteMark, U1, U2, U3, U4  ");			
			strSql.Append("  from [T_SytemSet] ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;
			
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			return Model.T_SytemSet.FillModel(ds.Tables[0]);
		}
		
		/// <summary>
		/// 获得指定条件的唯一一条数据实体
		/// </summary>
		public Model.T_SytemSet GetModel(string strWhere)
		{	
			StringBuilder sql = new StringBuilder();
			sql.Append(@"select * from [T_SytemSet] ");
			if(strWhere.Trim()!="")
			{
				sql.Append(" where 1=1 "+strWhere);
			}
			return Model.T_SytemSet.FillModel(DbHelperSQL.Query(sql.ToString()).Tables[0]);
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
		public List<Model.T_SytemSet> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{     
                StringBuilder strSql = new StringBuilder();
            strSql.Append("select   m.*  FROM [T_SytemSet] m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

			return Model.T_SytemSet.FillList(DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0]);
		}
		/// <summary>
		/// 获得记录总数
		/// </summary>
		public int GetCount(string strWhere)
		{
			StringBuilder sql = new StringBuilder();
            sql.Append(@"select count(1) from [T_SytemSet] ");
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
		public List<Model.T_SytemSet> GetList(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [T_SytemSet] ");
			if(where.Trim()!="")
			{
				strSql.Append(" where 1=1 " + where);
			}
			return Model.T_SytemSet.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Model.T_SytemSet> GetTopList(int top,string 
where,string orderField)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(top>0)
			{
				strSql.Append(" top "+top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM [T_SytemSet] ");
			if(where.Trim()!="")
			{
				strSql.Append(" where 1=1 " + where);
			}
			strSql.Append(" order by " + orderField);
			return Model.T_SytemSet.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
		}
		
		/// <summary>
		/// 获得数据列表DataTable 
		/// </summary>
		public DataTable GetDataTable(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [T_SytemSet] ");
			if(where.Trim()!="")
			{
				strSql.Append(" where 1=1 " + where);
			}
			return DbHelperSQL.Query(strSql.ToString()).Tables[0];
		}
		#endregion 
		
	}
}

