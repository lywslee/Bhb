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
    //部门其他负责人Id
    public class SectionLeaderBase
    {
        #region (公开)数据修改(添加、修改、删除)
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Insert(Model.SectionLeader model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [SectionLeader](");
            strSql.Append("PeopleId,SectionId,Ext1");
            strSql.Append(") values (");
            strSql.Append("@PeopleId,@SectionId,@Ext1");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@PeopleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@SectionId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ext1", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.PeopleId;
            parameters[1].Value = model.SectionId;
            parameters[2].Value = model.Ext1;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Model.SectionLeader model)
        {
            StringBuilder strSql = new StringBuilder();
            Collection<SqlParameter> parameters = new Collection<SqlParameter>

();
            SqlParameter parameter = null;
            int count = 0;
            strSql.Append("update [SectionLeader] set ");
            parameter = new SqlParameter("@Id",

SqlDbType.Int, 4);
            parameter.Value = model.Id;
            parameters.Add(parameter);




            if (model.PeopleId_IsEdit)
            {
                strSql.Append(" PeopleId = @PeopleId,");
                parameter = new SqlParameter("@PeopleId",

   SqlDbType.Int, 4);
                parameter.Value = model.PeopleId;
                parameters.Add(parameter);
                count++;
            }



            if (model.SectionId_IsEdit)
            {
                strSql.Append(" SectionId = @SectionId,");
                parameter = new SqlParameter("@SectionId",

   SqlDbType.Int, 4);
                parameter.Value = model.SectionId;
                parameters.Add(parameter);
                count++;
            }



            if (model.Ext1_IsEdit)
            {
                strSql.Append(" Ext1 = @Ext1,");
                parameter = new SqlParameter("@Ext1",

   SqlDbType.VarChar, 50);
                parameter.Value = model.Ext1;
                parameters.Add(parameter);
                count++;
            }

            if (count > 0)
            {
                strSql.Remove(strSql.Length - 1, 1);
            }
            if (count == 0)
            {
                return false;
            }
            strSql.Append(" where Id=@Id ");
            // 将参数泛形集合转传为数组
            SqlParameter[] args = new SqlParameter[parameters.Count];
            parameters.CopyTo(args, 0);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), args);
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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [SectionLeader] ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [SectionLeader] ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [SectionLeader]");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        public Model.SectionLeader GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, PeopleId, SectionId, Ext1  ");
            strSql.Append("  from [SectionLeader] ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return Model.SectionLeader.FillModel(ds.Tables[0]);
        }

        /// <summary>
        /// 获得指定条件的唯一一条数据实体
        /// </summary>
        public Model.SectionLeader GetModel(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select * from [SectionLeader] ");
            if (strWhere.Trim() != "")
            {
                sql.Append(" where 1=1 " + strWhere);
            }
            return Model.SectionLeader.FillModel(DbHelperSQL.Query(sql.ToString()).Tables[0]);
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
        public List<Model.SectionLeader> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   m.*  FROM [SectionLeader] m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return Model.SectionLeader.FillList(DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0]);
        }
        /// <summary>
        /// 获得记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select count(1) from [SectionLeader] ");
            if (strWhere.Trim() != "")
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
        public List<Model.SectionLeader> GetList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [SectionLeader] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return Model.SectionLeader.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Model.SectionLeader> GetTopList(int top, string

where, string orderField)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM [SectionLeader] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            strSql.Append(" order by " + orderField);
            return Model.SectionLeader.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }

        /// <summary>
        /// 获得数据列表DataTable 
        /// </summary>
        public DataTable GetDataTable(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [SectionLeader] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion

    }
}

