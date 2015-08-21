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
    //T_Bill
    public class T_BillBase
    {
        #region (公开)数据修改(添加、修改、删除)
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Insert(Model.T_Bill model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_Bill](");
            strSql.Append("AccountName,ProductName,ProductStandard,Unit,GrossWeight,Tare,NetWeight,Price,Amount,Remark,BNum,PricingMan,LoanMark,LoanMan,LoanDate,LoanType,LoanRemark,DeleteMark,AddTime,AddPerson,ModifyTime,WareHouse,ModifyPerson,U1,U2,U3,U4,CustomerID,ProjectId,ProductStandardId,CustomerName,CardNumber,Mobile,Tel,BankName,BankAccount");
            strSql.Append(") values (");
            strSql.Append("@AccountName,@ProductName,@ProductStandard,@Unit,@GrossWeight,@Tare,@NetWeight,@Price,@Amount,@Remark,@BNum,@PricingMan,@LoanMark,@LoanMan,@LoanDate,@LoanType,@LoanRemark,@DeleteMark,@AddTime,@AddPerson,@ModifyTime,@WareHouse,@ModifyPerson,@U1,@U2,@U3,@U4,@CustomerID,@ProjectId,@ProductStandardId,@CustomerName,@CardNumber,@Mobile,@Tel,@BankName,@BankAccount");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@AccountName", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@ProductName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ProductStandard", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Unit", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@GrossWeight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Tare", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@NetWeight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Amount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@BNum", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@PricingMan", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@LoanMark", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@LoanMan", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@LoanDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@LoanType", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@LoanRemark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@DeleteMark", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AddPerson", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WareHouse", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ModifyPerson", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@U1", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@U2", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@U3", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@U4", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CustomerID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProjectId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProductStandardId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@CardNumber", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Mobile", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Tel", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@BankName", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@BankAccount", SqlDbType.VarChar,40)             
              
            };

            parameters[0].Value = model.AccountName;
            parameters[1].Value = model.ProductName;
            parameters[2].Value = model.ProductStandard;
            parameters[3].Value = model.Unit;
            parameters[4].Value = model.GrossWeight;
            parameters[5].Value = model.Tare;
            parameters[6].Value = model.NetWeight;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.Amount;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.BNum;
            parameters[11].Value = model.PricingMan;
            parameters[12].Value = model.LoanMark;
            parameters[13].Value = model.LoanMan;
            parameters[14].Value = model.LoanDate;
            parameters[15].Value = model.LoanType;
            parameters[16].Value = model.LoanRemark;
            parameters[17].Value = model.DeleteMark;
            parameters[18].Value = model.AddTime;
            parameters[19].Value = model.AddPerson;
            parameters[20].Value = model.ModifyTime;
            parameters[21].Value = model.WareHouse;
            parameters[22].Value = model.ModifyPerson;
            parameters[23].Value = model.U1;
            parameters[24].Value = model.U2;
            parameters[25].Value = model.U3;
            parameters[26].Value = model.U4;
            parameters[27].Value = model.CustomerID;
            parameters[28].Value = model.ProjectId;
            parameters[29].Value = model.ProductStandardId;
            parameters[30].Value = model.CustomerName;
            parameters[31].Value = model.CardNumber;
            parameters[32].Value = model.Mobile;
            parameters[33].Value = model.Tel;
            parameters[34].Value = model.BankName;
            parameters[35].Value = model.BankAccount;

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
        public bool Update(Model.T_Bill model)
        {
            StringBuilder strSql = new StringBuilder();
            Collection<SqlParameter> parameters = new Collection<SqlParameter>

();
            SqlParameter parameter = null;
            int count = 0;
            strSql.Append("update [T_Bill] set ");
            parameter = new SqlParameter("@ID",

SqlDbType.Int, 4);
            parameter.Value = model.ID;
            parameters.Add(parameter);




            if (model.AccountName_IsEdit)
            {
                strSql.Append(" AccountName = @AccountName,");
                parameter = new SqlParameter("@AccountName",

   SqlDbType.VarChar, 40);
                parameter.Value = model.AccountName;
                parameters.Add(parameter);
                count++;
            }



            if (model.ProductName_IsEdit)
            {
                strSql.Append(" ProductName = @ProductName,");
                parameter = new SqlParameter("@ProductName",

   SqlDbType.VarChar, 100);
                parameter.Value = model.ProductName;
                parameters.Add(parameter);
                count++;
            }



            if (model.ProductStandard_IsEdit)
            {
                strSql.Append(" ProductStandard = @ProductStandard,");
                parameter = new SqlParameter("@ProductStandard",

   SqlDbType.VarChar, 100);
                parameter.Value = model.ProductStandard;
                parameters.Add(parameter);
                count++;
            }



            if (model.Unit_IsEdit)
            {
                strSql.Append(" Unit = @Unit,");
                parameter = new SqlParameter("@Unit",

   SqlDbType.VarChar, 20);
                parameter.Value = model.Unit;
                parameters.Add(parameter);
                count++;
            }



            if (model.GrossWeight_IsEdit)
            {
                strSql.Append(" GrossWeight = @GrossWeight,");
                parameter = new SqlParameter("@GrossWeight",

   SqlDbType.Decimal, 9);
                parameter.Value = model.GrossWeight;
                parameters.Add(parameter);
                count++;
            }



            if (model.Tare_IsEdit)
            {
                strSql.Append(" Tare = @Tare,");
                parameter = new SqlParameter("@Tare",

   SqlDbType.Decimal, 9);
                parameter.Value = model.Tare;
                parameters.Add(parameter);
                count++;
            }



            if (model.NetWeight_IsEdit)
            {
                strSql.Append(" NetWeight = @NetWeight,");
                parameter = new SqlParameter("@NetWeight",

   SqlDbType.Decimal, 9);
                parameter.Value = model.NetWeight;
                parameters.Add(parameter);
                count++;
            }



            if (model.Price_IsEdit)
            {
                strSql.Append(" Price = @Price,");
                parameter = new SqlParameter("@Price",

   SqlDbType.Decimal, 9);
                parameter.Value = model.Price;
                parameters.Add(parameter);
                count++;
            }



            if (model.Amount_IsEdit)
            {
                strSql.Append(" Amount = @Amount,");
                parameter = new SqlParameter("@Amount",

   SqlDbType.Decimal, 9);
                parameter.Value = model.Amount;
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



            if (model.BNum_IsEdit)
            {
                strSql.Append(" BNum = @BNum,");
                parameter = new SqlParameter("@BNum",

   SqlDbType.VarChar, 20);
                parameter.Value = model.BNum;
                parameters.Add(parameter);
                count++;
            }



            if (model.PricingMan_IsEdit)
            {
                strSql.Append(" PricingMan = @PricingMan,");
                parameter = new SqlParameter("@PricingMan",

   SqlDbType.VarChar, 50);
                parameter.Value = model.PricingMan;
                parameters.Add(parameter);
                count++;
            }



            if (model.LoanMark_IsEdit)
            {
                strSql.Append(" LoanMark = @LoanMark,");
                parameter = new SqlParameter("@LoanMark",

   SqlDbType.TinyInt, 1);
                parameter.Value = model.LoanMark;
                parameters.Add(parameter);
                count++;
            }



            if (model.LoanMan_IsEdit)
            {
                strSql.Append(" LoanMan = @LoanMan,");
                parameter = new SqlParameter("@LoanMan",

   SqlDbType.VarChar, 50);
                parameter.Value = model.LoanMan;
                parameters.Add(parameter);
                count++;
            }



            if (model.LoanDate_IsEdit)
            {
                strSql.Append(" LoanDate = @LoanDate,");
                parameter = new SqlParameter("@LoanDate",

   SqlDbType.DateTime);
                parameter.Value = model.LoanDate;
                parameters.Add(parameter);
                count++;
            }



            if (model.LoanType_IsEdit)
            {
                strSql.Append(" LoanType = @LoanType,");
                parameter = new SqlParameter("@LoanType",

   SqlDbType.VarChar, 20);
                parameter.Value = model.LoanType;
                parameters.Add(parameter);
                count++;
            }



            if (model.LoanRemark_IsEdit)
            {
                strSql.Append(" LoanRemark = @LoanRemark,");
                parameter = new SqlParameter("@LoanRemark",

   SqlDbType.VarChar, 500);
                parameter.Value = model.LoanRemark;
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



            if (model.WareHouse_IsEdit)
            {
                strSql.Append(" WareHouse = @WareHouse,");
                parameter = new SqlParameter("@WareHouse",

   SqlDbType.VarChar, 20);
                parameter.Value = model.WareHouse;
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



            if (model.CustomerID_IsEdit)
            {
                strSql.Append(" CustomerID = @CustomerID,");
                parameter = new SqlParameter("@CustomerID",

   SqlDbType.Int, 4);
                parameter.Value = model.CustomerID;
                parameters.Add(parameter);
                count++;
            }



            if (model.ProjectId_IsEdit)
            {
                strSql.Append(" ProjectId = @ProjectId,");
                parameter = new SqlParameter("@ProjectId",

   SqlDbType.Int, 4);
                parameter.Value = model.ProjectId;
                parameters.Add(parameter);
                count++;
            }



            if (model.ProductStandardId_IsEdit)
            {
                strSql.Append(" ProductStandardId = @ProductStandardId,");
                parameter = new SqlParameter("@ProductStandardId",

   SqlDbType.Int, 4);
                parameter.Value = model.ProductStandardId;
                parameters.Add(parameter);
                count++;
            }



            if (model.CustomerName_IsEdit)
            {
                strSql.Append(" CustomerName = @CustomerName,");
                parameter = new SqlParameter("@CustomerName",

   SqlDbType.VarChar, 100);
                parameter.Value = model.CustomerName;
                parameters.Add(parameter);
                count++;
            }



            if (model.CardNumber_IsEdit)
            {
                strSql.Append(" CardNumber = @CardNumber,");
                parameter = new SqlParameter("@CardNumber",

   SqlDbType.VarChar, 20);
                parameter.Value = model.CardNumber;
                parameters.Add(parameter);
                count++;
            }



            if (model.Mobile_IsEdit)
            {
                strSql.Append(" Mobile = @Mobile,");
                parameter = new SqlParameter("@Mobile",

   SqlDbType.VarChar, 20);
                parameter.Value = model.Mobile;
                parameters.Add(parameter);
                count++;
            }



            if (model.Tel_IsEdit)
            {
                strSql.Append(" Tel = @Tel,");
                parameter = new SqlParameter("@Tel",

   SqlDbType.VarChar, 40);
                parameter.Value = model.Tel;
                parameters.Add(parameter);
                count++;
            }



            if (model.BankName_IsEdit)
            {
                strSql.Append(" BankName = @BankName,");
                parameter = new SqlParameter("@BankName",

   SqlDbType.VarChar, 200);
                parameter.Value = model.BankName;
                parameters.Add(parameter);
                count++;
            }



            if (model.BankAccount_IsEdit)
            {
                strSql.Append(" BankAccount = @BankAccount,");
                parameter = new SqlParameter("@BankAccount",

   SqlDbType.VarChar, 40);
                parameter.Value = model.BankAccount;
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
            strSql.Append("delete from [T_Bill] ");
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
            strSql.Append("delete from [T_Bill] ");
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
            strSql.Append("select count(1) from [T_Bill]");
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
        public Model.T_Bill GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AccountName, ProductName, ProductStandard, Unit, GrossWeight, Tare, NetWeight, Price, Amount, Remark, BNum, PricingMan, LoanMark, LoanMan, LoanDate, LoanType, LoanRemark, DeleteMark, AddTime, AddPerson, ModifyTime, WareHouse, ModifyPerson, U1, U2, U3, U4, CustomerID, ProjectId, ProductStandardId, CustomerName, CardNumber, Mobile, Tel, BankName, BankAccount  ");
            strSql.Append("  from [T_Bill] ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return Model.T_Bill.FillModel(ds.Tables[0]);
        }

        /// <summary>
        /// 获得指定条件的唯一一条数据实体
        /// </summary>
        public Model.T_Bill GetModel(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select * from [T_Bill] ");
            if (strWhere.Trim() != "")
            {
                sql.Append(" where 1=1 " + strWhere);
            }
            return Model.T_Bill.FillModel(DbHelperSQL.Query(sql.ToString()).Tables[0]);
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
        public List<Model.T_Bill> GetListByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   m.*  FROM [T_Bill] m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return Model.T_Bill.FillList(DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0]);
        }
        /// <summary>
        /// 获得记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select count(1) from [T_Bill] ");
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
        public List<Model.T_Bill> GetList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_Bill] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return Model.T_Bill.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Model.T_Bill> GetTopList(int top, string

where, string orderField)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM [T_Bill] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            strSql.Append(" order by " + orderField);
            return Model.T_Bill.FillList(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }

        /// <summary>
        /// 获得数据列表DataTable 
        /// </summary>
        public DataTable GetDataTable(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_Bill] ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion

    }
}

