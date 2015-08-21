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
    public class T_Bill : T_BillBase
    {
        public T_Bill()
            : base()
        { }
        #region 扩展方法

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="filedOrder">排序语句</param>
        /// <param name="recordCount">记录总数</param>
        /// <returns></returns>
        public DataTable GetTableByPage(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m.ID,m.BNum,(select dName from T_Dictionary where dType='D02' and dNum=m.WareHouse) AS WareHouse,m.CustomerName,m.CustomerID,m.CardNumber,m.Mobile,m.Tel,(select dName from T_Dictionary where dType='D03' and dNum=m.BankName) as BankName,m.BankAccount,m.AccountName,m.ProductName,m.ProjectId,m.ProductStandard,m.ProductStandardId,m.Unit,m.GrossWeight,m.Tare,m.NetWeight,m.Price,m.Amount,m.AddPerson,convert(varchar(8),m.AddTime,11) as AddTime,m.LoanMan,m.LoanDate,m.LoanMark,m.LoanType from [T_Bill] as m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder)).Tables[0];
        }

        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        public Model.T_Bill GetModelToPrint(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  m.ID,m.BNum,(select dName from T_Dictionary where dType='D02' and dNum=m.WareHouse) AS WareHouse,m.CustomerName,m.CustomerID,m.CardNumber,m.Mobile,m.Tel,(select dName from T_Dictionary where dType='D03' and dNum=m.BankName) as BankName,m.BankAccount,m.AccountName,m.ProductName,m.ProjectId,(case ProductStandardid when '0' then '无' else m.ProductStandard end ) as ProductStandard,m.ProductStandardId,m.Unit,m.GrossWeight,m.Tare,m.NetWeight,m.Price,m.Amount,m.AddPerson,convert(varchar(8),m.AddTime,11) as AddTime,m.LoanMan,m.LoanDate,m.LoanMark,m.LoanType,m.Remark,m.PricingMan,m.LoanRemark,m.DeleteMark,m.ModifyTime,m.ModifyPerson,m.U1,m.U2,m.U3,m.U4   ");
            strSql.Append("  from [T_Bill] as m ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return Model.T_Bill.FillModel(ds.Tables[0]);
        }

        /// <summary>
        /// 导出Excel数据集
        /// </summary>
        /// <param name="sWhere"></param>
        /// <param name="sOrderby"></param>
        /// <returns></returns>
        public DataSet GetTableToExcel(string strWhere, string strOrderby)
        {
            StringBuilder strSql = new StringBuilder();
            //数据集
            strSql.Append("select m.ID,m.BNum,(select dName from T_Dictionary where dType='D02' and dNum=m.WareHouse) AS WareHouse,m.CustomerName,m.CustomerID,m.CardNumber,m.Mobile,m.Tel,(select dName from T_Dictionary where dType='D03' and dNum=m.BankName) as BankName,m.BankAccount,m.AccountName,m.ProductName,m.ProjectId,m.ProductStandard,m.ProductStandardId,m.Unit,m.GrossWeight,m.Tare,m.NetWeight,m.Price,m.Amount,m.AddPerson,convert(varchar(8),m.AddTime,11) as AddTime,m.LoanMan,m.LoanDate,m.LoanMark,m.LoanType from [T_Bill] as m");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            if (strOrderby != "")
            {
                strSql.Append("  order by " + strOrderby);
            }
            //求合计
            strSql.Append(" ; ");

            strSql.Append("select COUNT(*) as [Count],ISNULL(SUM(ISNULL(GrossWeight,0)),0) as GrossWeight,ISNULL(SUM(ISNULL(Tare,0)),0) as Tare,ISNULL(SUM(ISNULL(NetWeight,0)),0) as NetWeight,ISNULL(SUM(ISNULL(Amount,0)),0) as Amount from T_Bill ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }

            return DbHelperSQL.Query(strSql.ToString());

        }

        /// <summary>
        /// 导出Excel数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*) as [Count],ISNULL(SUM(ISNULL(GrossWeight,0)),0) as GrossWeight,ISNULL(SUM(ISNULL(Tare,0)),0) as Tare,ISNULL(SUM(ISNULL(NetWeight,0)),0) as NetWeight,ISNULL(SUM(ISNULL(Amount,0)),0) as Amount from T_Bill ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }

            return DbHelperSQL.ExecuteDataTable(CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 根据条件统计
        /// </summary>
        /// <param name="sumFeild">统计字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="dateFeild">日期字段</param>
        /// <returns></returns>
        public DataTable GetListGroupBy(string sumFeild, string dateNum, string dateFeild, string strWhere)
        {
            string sql = " select sum(" + sumFeild + ") as sumField,convert(varchar(" + dateNum + ")," + dateFeild + ",121) as DateGroup from T_Bill where 1=1 " + strWhere + " group by  convert(varchar(" + dateNum + ")," + dateFeild + ",121) order by DateGroup asc";
            return DbHelperSQL.Query(sql).Tables[0];
        }
        #endregion
    }
}