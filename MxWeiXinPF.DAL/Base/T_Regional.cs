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
    //区域表
    public class T_RegionalBase
    {
        #region (公开)数据修改(添加、修改、删除)
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Insert(Model.T_Regional model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_Regional](");
            strSql.Append("AddPerson,ModifyTime,ModifyPerson,U1,U2,U3,U4,RName,ZJM,RLevel,SortNum,ParentID,Remark,DeleteMark,AddTime");
            strSql.Append(") values (");
            strSql.Append("@AddPerson,@ModifyTime,@ModifyPerson,@U1,@U2,@U3,@U4,@RName,@ZJM,@RLevel,@SortNum,@ParentID,@Remark,@DeleteMark,@AddTime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@AddPerson", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyPerson", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@U1", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@U2", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@U3", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@U4", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@RName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ZJM", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@RLevel", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@SortNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@ParentID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@DeleteMark", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.AddPerson;
            parameters[1].Value = model.ModifyTime;
            parameters[2].Value = model.ModifyPerson;
            parameters[3].Value = model.U1;
            parameters[4].Value = model.U2;
            parameters[5].Value = model.U3;
            parameters[6].Value = model.U4;
            parameters[7].Value = model.RName;
            parameters[8].Value = model.ZJM;
            parameters[9].Value = model.RLevel;
            parameters[10].Value = model.SortNum;
            parameters[11].Value = model.ParentID;
            parameters[12].Value = model.Remark;
            parameters[13].Value = model.DeleteMark;
            parameters[14].Value = model.AddTime;

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
        public bool Update(Model.T_Regional model)
        {
            StringBuilder strSql = new StringBuilder();
            Collection<SqlParameter> parameters = new Collection<SqlParameter>

();
            SqlParameter parameter = null;
            int count = 0;
            strSql.Append("update [T_Regional] set ");
            parameter = new SqlParameter("@ID",

SqlDbType.Int, 4);
            parameter.Value = model.ID;
            parameters.Add(parameter);




            if (model.AddPerson_IsEdit)
            {
                strSql.Append(" AddPerson = @AddPerson,");
                parameter = new SqlParameter("@AddPerson",

   SqlDbType.VarChar, 50);
                parameter.Value = model.AddPerson;
                parameters.Add(parameter);
                count++;
            }



            if (model.ModifyTime_IsEdit)
            {
                strSql.Append(" ModifyTime = @ModifyTime,");
                parameter = new SqlParameter("@ModifyTime",

   SqlDbType.DateTime);
                parameter.Value = model.ModifyTime;
                parameters.Add(parameter);
                count++;
            }



            if (model.ModifyPerson_IsEdit)
            {
                strSql.Append(" ModifyPerson = @ModifyPerson,");
                parameter = new SqlParameter("@ModifyPerson",

   SqlDbType.VarChar, 50);
                parameter.Value = model.ModifyPerson;
                parameters.Add(parameter);
                count++;
            }



            if (model.U1_IsEdit)
            {
                strSql.Append(" U1 = @U1,");
                parameter = new SqlParameter("@U1",

   SqlDbType.VarChar, 200);
                parameter.Value = model.U1;
                parameters.Add(parameter);
                count++;
            }



            if (model.U2_IsEdit)
            {
                strSql.Append(" U2 = @U2,");
                parameter = new SqlParameter("@U2",

   SqlDbType.VarChar, 200);
                parameter.Value = model.U2;
                parameters.Add(parameter);
                count++;
            }



            if (model.U3_IsEdit)
            {
                strSql.Append(" U3 = @U3,");
                parameter = new SqlParameter("@U3",

   SqlDbType.Decimal, 9);
                parameter.Value = model.U3;
                parameters.Add(parameter);
                count++;
            }



            if (model.U4_IsEdit)
            {
                strSql.Append(" U4 = @U4,");
                parameter = new SqlParameter("@U4",

   SqlDbType.Decimal, 9);
                parameter.Value = model.U4;
                parameters.Add(parameter);
                count++;
            }



            if (model.RName_IsEdit)
            {
                strSql.Append(" RName = @RName,");
                parameter = new SqlParameter("@RName",

   SqlDbType.VarChar, 100);
                parameter.Value = model.RName;
                parameters.Add(parameter);
                count++;
            }



            if (model.ZJM_IsEdit)
            {
                strSql.Append(" ZJM = @ZJM,");
                parameter = new SqlParameter("@ZJM",

   SqlDbType.VarChar, 100);
                parameter.Value = model.ZJM;
                parameters.Add(parameter);
                count++;
            }



            if (model.RLevel_IsEdit)
            {
                strSql.Append(" RLevel = @RLevel,");
                parameter = new SqlParameter("@RLevel",

   SqlDbType.VarChar, 4);
                parameter.Value = model.RLevel;
                parameters.Add(parameter);
                count++;
            }



            if (model.SortNum_IsEdit)
            {
                strSql.Append(" SortNum = @SortNum,");
                parameter = new SqlParameter("@SortNum",

   SqlDbType.Int, 4);
                parameter.Value = model.SortNum;
                parameters.Add(parameter);
                count++;
            }



            if (model.ParentID_IsEdit)
            {
                strSql.Append(" ParentID = @ParentID,");
                parameter = new SqlParameter("@ParentID",

   SqlDbType.Int, 4);
                parameter.Value = model.ParentID;
                parameters.Add(parameter);
                count++;
            }



            if (model.Remark_IsEdit)
            {
                strSql.Append(" Remark = @Remark,");
                parameter = new SqlParameter("@Remark",

   SqlDbType.VarChar, 500);
                parameter.Value = model.Remark;
                parameters.Add(parameter);
                count++;
            }



            if (model.DeleteMark_IsEdit)
            {
                strSql.Append(" DeleteMark = @DeleteMark,");
                parameter = new SqlParameter("@DeleteMark",

   SqlDbType.TinyInt, 1);
                parameter.Value = model.DeleteMark;
                parameters.Add(parameter);
                count++;
            }



            if (model.AddTime_IsEdit)
            {
                strSql.Append(" AddTime = @AddTime,");
                parameter = new SqlParameter("@AddTime",

   SqlDbType.DateTime);
                parameter.Value = model.AddTime;
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
            strSql.Append("delete from [T_Regional] ");
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
            strSql.Append("delete from [T_Regional] ");
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
            strSql.Append("select count(1) from [T_Regional]");
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
        public Model.T_Regional GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AddPerson, ModifyTime, ModifyPerson, U1, U2, U3, U4, RName, ZJM, RLevel, SortNum, ParentID, Remark, DeleteMark, AddTime  ");
            strSql.Append("  from [T_Regional] ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return Model.T_Regional.FillModel(ds.Tables[0]);
        }

        /// <summary>
        /// 获得指定条件的唯一一条数据实体
        /// </summary>
        public Model.T_Regional GetModel(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select * from [T_Regional] ");
            if (strWhere.Trim() != "")
            {
                sql.Append(" where 1=1 " + strWhere);
            }
            return Model.T_Regional.FillModel(DbHelperSQL.Query(sql.ToString()).Tables[0]);
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
        public List<Model.T_Regional> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   m.*  FROM [T_Regional] m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return Model.T_Regional.FillList(DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0]);
        }
        /// <summary>
        /// 获得记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select count(1) from [T_Regional] ");
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
        public List<Model.T_Regional> GetList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_Regional] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return Model.T_Regional.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Model.T_Regional> GetTopList(int top, string

where, string orderField)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM [T_Regional] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            strSql.Append(" order by " + orderField);
            return Model.T_Regional.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }

        /// <summary>
        /// 获得数据列表DataTable 
        /// </summary>
        public DataTable GetDataTable(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_Regional] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion

    }
}

