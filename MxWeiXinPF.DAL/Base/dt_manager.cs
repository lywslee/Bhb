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
    //管理员表
    public class dt_managerBase
    {
        #region (公开)数据修改(添加、修改、删除)
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Insert(Model.dt_manager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [dt_manager](");
            strSql.Append("is_lock,add_time,wxNum,agentId,reg_ip,qq,province,city,county,remark,role_id,sort_id,agentLevel,SectionId,Ext1,IsDelete,role_type,user_name,password,salt,real_name,telephone,email");
            strSql.Append(") values (");
            strSql.Append("@is_lock,@add_time,@wxNum,@agentId,@reg_ip,@qq,@province,@city,@county,@remark,@role_id,@sort_id,@agentLevel,@SectionId,@Ext1,@IsDelete,@role_type,@user_name,@password,@salt,@real_name,@telephone,@email");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@is_lock", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@wxNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@agentId", SqlDbType.Int,4) ,            
                        new SqlParameter("@reg_ip", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@qq", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@province", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@city", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@county", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,1500) ,            
                        new SqlParameter("@role_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@sort_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@agentLevel", SqlDbType.Int,4) ,            
                        new SqlParameter("@SectionId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ext1", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IsDelete", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@role_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@user_name", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@password", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@salt", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@real_name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@telephone", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@email", SqlDbType.NVarChar,30)             
              
            };

            parameters[0].Value = model.is_lock;
            parameters[1].Value = model.add_time;
            parameters[2].Value = model.wxNum;
            parameters[3].Value = model.agentId;
            parameters[4].Value = model.reg_ip;
            parameters[5].Value = model.qq;
            parameters[6].Value = model.province;
            parameters[7].Value = model.city;
            parameters[8].Value = model.county;
            parameters[9].Value = model.remark;
            parameters[10].Value = model.role_id;
            parameters[11].Value = model.sort_id;
            parameters[12].Value = model.agentLevel;
            parameters[13].Value = model.SectionId;
            parameters[14].Value = model.Ext1;
            parameters[15].Value = model.IsDelete;
            parameters[16].Value = model.role_type;
            parameters[17].Value = model.user_name;
            parameters[18].Value = model.password;
            parameters[19].Value = model.salt;
            parameters[20].Value = model.real_name;
            parameters[21].Value = model.telephone;
            parameters[22].Value = model.email;

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
        public bool Update(Model.dt_manager model)
        {
            StringBuilder strSql = new StringBuilder();
            Collection<SqlParameter> parameters = new Collection<SqlParameter>

();
            SqlParameter parameter = null;
            int count = 0;
            strSql.Append("update [dt_manager] set ");
            parameter = new SqlParameter("@id",

SqlDbType.Int, 4);
            parameter.Value = model.id;
            parameters.Add(parameter);




            if (model.is_lock_IsEdit)
            {
                strSql.Append(" is_lock = @is_lock,");
                parameter = new SqlParameter("@is_lock",

   SqlDbType.Int, 4);
                parameter.Value = model.is_lock;
                parameters.Add(parameter);
                count++;
            }



            if (model.add_time_IsEdit)
            {
                strSql.Append(" add_time = @add_time,");
                parameter = new SqlParameter("@add_time",

   SqlDbType.DateTime);
                parameter.Value = model.add_time;
                parameters.Add(parameter);
                count++;
            }



            if (model.wxNum_IsEdit)
            {
                strSql.Append(" wxNum = @wxNum,");
                parameter = new SqlParameter("@wxNum",

   SqlDbType.Int, 4);
                parameter.Value = model.wxNum;
                parameters.Add(parameter);
                count++;
            }



            if (model.agentId_IsEdit)
            {
                strSql.Append(" agentId = @agentId,");
                parameter = new SqlParameter("@agentId",

   SqlDbType.Int, 4);
                parameter.Value = model.agentId;
                parameters.Add(parameter);
                count++;
            }



            if (model.reg_ip_IsEdit)
            {
                strSql.Append(" reg_ip = @reg_ip,");
                parameter = new SqlParameter("@reg_ip",

   SqlDbType.NVarChar, 30);
                parameter.Value = model.reg_ip;
                parameters.Add(parameter);
                count++;
            }



            if (model.qq_IsEdit)
            {
                strSql.Append(" qq = @qq,");
                parameter = new SqlParameter("@qq",

   SqlDbType.NVarChar, 30);
                parameter.Value = model.qq;
                parameters.Add(parameter);
                count++;
            }



            if (model.province_IsEdit)
            {
                strSql.Append(" province = @province,");
                parameter = new SqlParameter("@province",

   SqlDbType.NVarChar, 200);
                parameter.Value = model.province;
                parameters.Add(parameter);
                count++;
            }



            if (model.city_IsEdit)
            {
                strSql.Append(" city = @city,");
                parameter = new SqlParameter("@city",

   SqlDbType.NVarChar, 200);
                parameter.Value = model.city;
                parameters.Add(parameter);
                count++;
            }



            if (model.county_IsEdit)
            {
                strSql.Append(" county = @county,");
                parameter = new SqlParameter("@county",

   SqlDbType.NVarChar, 500);
                parameter.Value = model.county;
                parameters.Add(parameter);
                count++;
            }



            if (model.remark_IsEdit)
            {
                strSql.Append(" remark = @remark,");
                parameter = new SqlParameter("@remark",

   SqlDbType.NVarChar, 1500);
                parameter.Value = model.remark;
                parameters.Add(parameter);
                count++;
            }



            if (model.role_id_IsEdit)
            {
                strSql.Append(" role_id = @role_id,");
                parameter = new SqlParameter("@role_id",

   SqlDbType.Int, 4);
                parameter.Value = model.role_id;
                parameters.Add(parameter);
                count++;
            }



            if (model.sort_id_IsEdit)
            {
                strSql.Append(" sort_id = @sort_id,");
                parameter = new SqlParameter("@sort_id",

   SqlDbType.Int, 4);
                parameter.Value = model.sort_id;
                parameters.Add(parameter);
                count++;
            }



            if (model.agentLevel_IsEdit)
            {
                strSql.Append(" agentLevel = @agentLevel,");
                parameter = new SqlParameter("@agentLevel",

   SqlDbType.Int, 4);
                parameter.Value = model.agentLevel;
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



            if (model.IsDelete_IsEdit)
            {
                strSql.Append(" IsDelete = @IsDelete,");
                parameter = new SqlParameter("@IsDelete",

   SqlDbType.TinyInt, 1);
                parameter.Value = model.IsDelete;
                parameters.Add(parameter);
                count++;
            }



            if (model.role_type_IsEdit)
            {
                strSql.Append(" role_type = @role_type,");
                parameter = new SqlParameter("@role_type",

   SqlDbType.Int, 4);
                parameter.Value = model.role_type;
                parameters.Add(parameter);
                count++;
            }



            if (model.user_name_IsEdit)
            {
                strSql.Append(" user_name = @user_name,");
                parameter = new SqlParameter("@user_name",

   SqlDbType.NVarChar, 100);
                parameter.Value = model.user_name;
                parameters.Add(parameter);
                count++;
            }



            if (model.password_IsEdit)
            {
                strSql.Append(" password = @password,");
                parameter = new SqlParameter("@password",

   SqlDbType.NVarChar, 100);
                parameter.Value = model.password;
                parameters.Add(parameter);
                count++;
            }



            if (model.salt_IsEdit)
            {
                strSql.Append(" salt = @salt,");
                parameter = new SqlParameter("@salt",

   SqlDbType.NVarChar, 20);
                parameter.Value = model.salt;
                parameters.Add(parameter);
                count++;
            }



            if (model.real_name_IsEdit)
            {
                strSql.Append(" real_name = @real_name,");
                parameter = new SqlParameter("@real_name",

   SqlDbType.NVarChar, 50);
                parameter.Value = model.real_name;
                parameters.Add(parameter);
                count++;
            }



            if (model.telephone_IsEdit)
            {
                strSql.Append(" telephone = @telephone,");
                parameter = new SqlParameter("@telephone",

   SqlDbType.NVarChar, 30);
                parameter.Value = model.telephone;
                parameters.Add(parameter);
                count++;
            }



            if (model.email_IsEdit)
            {
                strSql.Append(" email = @email,");
                parameter = new SqlParameter("@email",

   SqlDbType.NVarChar, 30);
                parameter.Value = model.email;
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
            strSql.Append(" where id=@id ");
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [dt_manager] ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [dt_manager] ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [dt_manager]");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        public Model.dt_manager GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, is_lock, add_time, wxNum, agentId, reg_ip, qq, province, city, county, remark, role_id, sort_id, agentLevel, SectionId, Ext1, IsDelete, role_type, user_name, password, salt, real_name, telephone, email  ");
            strSql.Append("  from [dt_manager] ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return Model.dt_manager.FillModel(ds.Tables[0]);
        }

        /// <summary>
        /// 获得指定条件的唯一一条数据实体
        /// </summary>
        public Model.dt_manager GetModel(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select * from [dt_manager] ");
            if (strWhere.Trim() != "")
            {
                sql.Append(" where 1=1 " + strWhere);
            }
            return Model.dt_manager.FillModel(DbHelperSQL.Query(sql.ToString()).Tables[0]);
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
        public List<Model.dt_manager> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   m.*  FROM [dt_manager] m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return Model.dt_manager.FillList(DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0]);
        }
        /// <summary>
        /// 获得记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select count(1) from [dt_manager] ");
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
        public List<Model.dt_manager> GetList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [dt_manager] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return Model.dt_manager.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Model.dt_manager> GetTopList(int top, string

where, string orderField)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM [dt_manager] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            strSql.Append(" order by " + orderField);
            return Model.dt_manager.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }

        /// <summary>
        /// 获得数据列表DataTable 
        /// </summary>
        public DataTable GetDataTable(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [dt_manager] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion

    }
}

