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
    //产品分类表
    public class T_ProductBase
    {
        #region (公开)数据修改(添加、修改、删除)
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Insert(Model.T_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_Product](");
            strSql.Append("pNum,pName,pZjm,pSortNum,pRemark,sRemark");
            strSql.Append(") values (");
            strSql.Append("@pNum,@pName,@pZjm,@pSortNum,@pRemark,@sRemark");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@pNum", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@pName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@pZjm", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@pSortNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@pRemark", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@sRemark", SqlDbType.VarChar,200)             
              
            };

            parameters[0].Value = model.pNum;
            parameters[1].Value = model.pName;
            parameters[2].Value = model.pZjm;
            parameters[3].Value = model.pSortNum;
            parameters[4].Value = model.pRemark;
            parameters[5].Value = model.sRemark;

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
        public bool Update(Model.T_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            Collection<SqlParameter> parameters = new Collection<SqlParameter>

();
            SqlParameter parameter = null;
            int count = 0;
            strSql.Append("update [T_Product] set ");
            parameter = new SqlParameter("@ID",

SqlDbType.Int, 4);
            parameter.Value = model.ID;
            parameters.Add(parameter);




            if (model.pNum_IsEdit)
            {
                strSql.Append(" pNum = @pNum,");
                parameter = new SqlParameter("@pNum",

   SqlDbType.VarChar, 20);
                parameter.Value = model.pNum;
                parameters.Add(parameter);
                count++;
            }



            if (model.pName_IsEdit)
            {
                strSql.Append(" pName = @pName,");
                parameter = new SqlParameter("@pName",

   SqlDbType.VarChar, 100);
                parameter.Value = model.pName;
                parameters.Add(parameter);
                count++;
            }



            if (model.pZjm_IsEdit)
            {
                strSql.Append(" pZjm = @pZjm,");
                parameter = new SqlParameter("@pZjm",

   SqlDbType.VarChar, 100);
                parameter.Value = model.pZjm;
                parameters.Add(parameter);
                count++;
            }



            if (model.pSortNum_IsEdit)
            {
                strSql.Append(" pSortNum = @pSortNum,");
                parameter = new SqlParameter("@pSortNum",

   SqlDbType.Int, 4);
                parameter.Value = model.pSortNum;
                parameters.Add(parameter);
                count++;
            }



            if (model.pRemark_IsEdit)
            {
                strSql.Append(" pRemark = @pRemark,");
                parameter = new SqlParameter("@pRemark",

   SqlDbType.VarChar, 200);
                parameter.Value = model.pRemark;
                parameters.Add(parameter);
                count++;
            }



            if (model.sRemark_IsEdit)
            {
                strSql.Append(" sRemark = @sRemark,");
                parameter = new SqlParameter("@sRemark",

   SqlDbType.VarChar, 200);
                parameter.Value = model.sRemark;
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
            strSql.Append(" where ID=@ID ");
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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [T_Product] ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [T_Product] ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_Product]");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        public Model.T_Product GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, pNum, pName, pZjm, pSortNum, pRemark, sRemark  ");
            strSql.Append("  from [T_Product] ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return Model.T_Product.FillModel(ds.Tables[0]);
        }

        /// <summary>
        /// 获得指定条件的唯一一条数据实体
        /// </summary>
        public Model.T_Product GetModel(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select * from [T_Product] ");
            if (strWhere.Trim() != "")
            {
                sql.Append(" where 1=1 " + strWhere);
            }
            return Model.T_Product.FillModel(DbHelperSQL.Query(sql.ToString()).Tables[0]);
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
        public List<Model.T_Product> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   m.*  FROM [T_Product] m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return Model.T_Product.FillList(DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0]);
        }
        /// <summary>
        /// 获得记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select count(1) from [T_Product] ");
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
        public List<Model.T_Product> GetList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_Product] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return Model.T_Product.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Model.T_Product> GetTopList(int top, string

where, string orderField)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM [T_Product] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            strSql.Append(" order by " + orderField);
            return Model.T_Product.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }

        /// <summary>
        /// 获得数据列表DataTable 
        /// </summary>
        public DataTable GetDataTable(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_Product] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion

    }
}