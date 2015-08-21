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
    //部门表
    public class SectionBase
    {
        #region (公开)数据修改(添加、修改、删除)
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Insert(Model.Section model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Section](");
            strSql.Append("IsDelete,LevelNum,Name,ParentId,Num,OrderNum,Sort,LeaderId,Ext1,Ext2");
            strSql.Append(") values (");
            strSql.Append("@IsDelete,@LevelNum,@Name,@ParentId,@Num,@OrderNum,@Sort,@LeaderId,@Ext1,@Ext2");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@IsDelete", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@LevelNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ParentId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Num", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrderNum", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@LeaderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ext1", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Ext2", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.IsDelete;
            parameters[1].Value = model.LevelNum;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.ParentId;
            parameters[4].Value = model.Num;
            parameters[5].Value = model.OrderNum;
            parameters[6].Value = model.Sort;
            parameters[7].Value = model.LeaderId;
            parameters[8].Value = model.Ext1;
            parameters[9].Value = model.Ext2;

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
        public bool Update(Model.Section model)
        {
            StringBuilder strSql = new StringBuilder();
            Collection<SqlParameter> parameters = new Collection<SqlParameter>

();
            SqlParameter parameter = null;
            int count = 0;
            strSql.Append("update [Section] set ");
            parameter = new SqlParameter("@Id",

SqlDbType.Int, 4);
            parameter.Value = model.Id;
            parameters.Add(parameter);




            if (model.IsDelete_IsEdit)
            {
                strSql.Append(" IsDelete = @IsDelete,");
                parameter = new SqlParameter("@IsDelete",

   SqlDbType.TinyInt, 1);
                parameter.Value = model.IsDelete;
                parameters.Add(parameter);
                count++;
            }



            if (model.LevelNum_IsEdit)
            {
                strSql.Append(" LevelNum = @LevelNum,");
                parameter = new SqlParameter("@LevelNum",

   SqlDbType.Int, 4);
                parameter.Value = model.LevelNum;
                parameters.Add(parameter);
                count++;
            }



            if (model.Name_IsEdit)
            {
                strSql.Append(" Name = @Name,");
                parameter = new SqlParameter("@Name",

   SqlDbType.NVarChar, 50);
                parameter.Value = model.Name;
                parameters.Add(parameter);
                count++;
            }



            if (model.ParentId_IsEdit)
            {
                strSql.Append(" ParentId = @ParentId,");
                parameter = new SqlParameter("@ParentId",

   SqlDbType.Int, 4);
                parameter.Value = model.ParentId;
                parameters.Add(parameter);
                count++;
            }



            if (model.Num_IsEdit)
            {
                strSql.Append(" Num = @Num,");
                parameter = new SqlParameter("@Num",

   SqlDbType.VarChar, 50);
                parameter.Value = model.Num;
                parameters.Add(parameter);
                count++;
            }



            if (model.OrderNum_IsEdit)
            {
                strSql.Append(" OrderNum = @OrderNum,");
                parameter = new SqlParameter("@OrderNum",

   SqlDbType.VarChar, 100);
                parameter.Value = model.OrderNum;
                parameters.Add(parameter);
                count++;
            }



            if (model.Sort_IsEdit)
            {
                strSql.Append(" Sort = @Sort,");
                parameter = new SqlParameter("@Sort",

   SqlDbType.Int, 4);
                parameter.Value = model.Sort;
                parameters.Add(parameter);
                count++;
            }



            if (model.LeaderId_IsEdit)
            {
                strSql.Append(" LeaderId = @LeaderId,");
                parameter = new SqlParameter("@LeaderId",

   SqlDbType.Int, 4);
                parameter.Value = model.LeaderId;
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



            if (model.Ext2_IsEdit)
            {
                strSql.Append(" Ext2 = @Ext2,");
                parameter = new SqlParameter("@Ext2",

   SqlDbType.VarChar, 50);
                parameter.Value = model.Ext2;
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
            strSql.Append("delete from [Section] ");
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
            strSql.Append("delete from [Section] ");
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
            strSql.Append("select count(1) from [Section]");
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
        public Model.Section GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, IsDelete, LevelNum, Name, ParentId, Num, OrderNum, Sort, LeaderId, Ext1, Ext2  ");
            strSql.Append("  from [Section] ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return Model.Section.FillModel(ds.Tables[0]);
        }

        /// <summary>
        /// 获得指定条件的唯一一条数据实体
        /// </summary>
        public Model.Section GetModel(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select * from [Section] ");
            if (strWhere.Trim() != "")
            {
                sql.Append(" where 1=1 " + strWhere);
            }
            return Model.Section.FillModel(DbHelperSQL.Query(sql.ToString()).Tables[0]);
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
        public List<Model.Section> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   m.*  FROM [Section] m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return Model.Section.FillList(DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0]);
        }
        /// <summary>
        /// 获得记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select count(1) from [Section] ");
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
        public List<Model.Section> GetList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [Section] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return Model.Section.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Model.Section> GetTopList(int top, string

where, string orderField)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM [Section] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            strSql.Append(" order by " + orderField);
            return Model.Section.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }

        /// <summary>
        /// 获得数据列表DataTable 
        /// </summary>
        public DataTable GetDataTable(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [Section] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion

    }
}

