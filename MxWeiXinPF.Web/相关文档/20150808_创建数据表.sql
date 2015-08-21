


--创建数据表
	
--1.创建表 T_Bill 收料单
IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE XTYPE='U' AND NAME='T_Bill')
DROP TABLE T_Bill
GO
Create table T_Bill
(
	 ID int identity(1,1),
	 BNum varchar(20),
	 WareHouse varchar(20),
	 CustomerName varchar(100),
	 CardNumber varchar(20),
	 Mobile varchar(20),
	 Tel varchar(40),
	 BankName varchar(200),
	 BankAccount varchar(40),
	 AccountName varchar(40),
	 ProductName varchar(100),
	 ProductStandard varchar(100),
	 Unit varchar(20),
	 GrossWeight decimal(18,4),
	 Tare decimal(18,4),
	 NetWeight decimal(18,4),
	 Price decimal(18,2),
	 Amount decimal(18,2),
	 Remark varchar(500),
	 PricingMan varchar(50),
	 LoanMark varchar(2) default ('0'),
	 LoanMan varchar(50),
	 LoanDate datetime,
	 LoanType varchar(20),
	 LoanRemark varchar(500),
	 DeleteMark varchar(2) default ('1'),
	 AddTime datetime,
	 AddPerson varchar(50),
	 ModifyTime datetime,
	 ModifyPerson varchar(50),
	 U1 varchar(200),
	 U2 varchar(200),
	 U3 decimal(18,2),
	 U4 decimal(18,2),
	
	CONSTRAINT PK_T_Bill PRIMARY KEY CLUSTERED 
	(
		 [ID] ASC 
	
	)	WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'id', @value=N'全局唯一键' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'bnum', @value=N'收料编号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'warehouse', @value=N'存放仓库' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'customername', @value=N'客户单位' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'CardNumber', @value=N'身份证号' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'mobile', @value=N'移动电话' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'tel', @value=N'固定电话' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'bankname', @value=N'代发银行' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'bankaccount', @value=N'银行账号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'accountname', @value=N'户名' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'productname', @value=N'产品名称' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'productstandard', @value=N'产品规格' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'unit', @value=N'单位' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'grossweight', @value=N'产品毛重' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'tare', @value=N'皮重' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'netweight', @value=N'产品净重' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'price', @value=N'单价' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'amount', @value=N'金额' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'remark', @value=N'收料备注' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'pricingman', @value=N'划价人员' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'loanmark', @value=N'放款标记' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'loanman', @value=N'放款人员' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'loandate', @value=N'放款时间' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'loantype', @value=N'放款类型' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'loanremark', @value=N'放款备注' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'deletemark', @value=N'删除标记' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'addtime', @value=N'添加日期' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'addperson', @value=N'添加人' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'modifytime', @value=N'修改日期' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'modifyperson', @value=N'修改人' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'u1', @value=N'备用字段1' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'u2', @value=N'备用字段2' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'u3', @value=N'备用字段3' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'u4', @value=N'备用字段4' 


	
--2.创建表 T_Customer 客户表
IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE XTYPE='U' AND NAME='T_Customer')
DROP TABLE T_Customer
GO
Create table T_Customer
(
	 ID int identity(1,1),
	 CName varchar(100),
	 ZJM varchar(100),
	 CLevel varchar(20),
	 OneRegional varchar(40),
	 TwoRegional varchar(40),
	 CardNumber varchar(20),
	 Tel varchar(40),
	 Mobile varchar(20),
	 Address varchar(200),
	 BankName varchar(200),
	 BankAccount varchar(40),
	 AcountName varchar(40),
	 AddTime datetime,
	 AddPerson varchar(50),
	 ModifyTime datetime,
	 ModifyPerson varchar(50),
	 MergedMark varchar(2),
	 DeleteMark varchar(2) default('1'),
	 SortNum int,
	 Remark varchar(500),
	 U1 varchar(200),
	 U2 varchar(200),
	 U3 decimal(18,2),
	 U4 decimal(18,2),
	
	CONSTRAINT PK_T_Customer PRIMARY KEY CLUSTERED 
	(
		 [ID] ASC 
	
	)	WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'id', @value=N'全局唯一键' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'cname', @value=N'客户姓名' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'zjm', @value=N'助记码' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'clevel', @value=N'客户类型' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'oneregional', @value=N'一级区域' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'tworegional', @value=N'二级区域' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'cardnumber', @value=N'身份证号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'tel', @value=N'固定电话' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'mobile', @value=N'移动电话' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'address', @value=N'住址' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'bankname', @value=N'代发银行' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'bankaccount', @value=N'银行账号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'acountname', @value=N'户名' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'addtime', @value=N'添加日期' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'addperson', @value=N'添加人' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'modifytime', @value=N'修改日期' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'modifyperson', @value=N'修改人' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'mergedmark', @value=N'合并标记' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'deletemark', @value=N'删除标记' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'sortnum', @value=N'排序序号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'remark', @value=N'备注' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'u1', @value=N'备用字段1' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'u2', @value=N'备用字段2' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'u3', @value=N'备用字段3' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'u4', @value=N'备用字段4' 


	
--3.创建表 T_Regional 区域表
IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE XTYPE='U' AND NAME='T_Regional')
DROP TABLE T_Regional
GO
Create table T_Regional
(
	 ID int identity(1,1),
	 RName varchar(100),
	 ZJM varchar(100),
	 RLevel varchar(4),
	 SortNum int,
	 ParentID varchar(50),
	 Remark varchar(500),
	 DeleteMark varchar(2) default('1'),
	 AddTime datetime,
	 AddPerson varchar(50),
	 ModifyTime datetime,
	 ModifyPerson varchar(50),
	 U1 varchar(200),
	 U2 varchar(200),
	 U3 decimal(18,2),
	 U4 decimal(18,2),
	
	CONSTRAINT PK_T_Regional PRIMARY KEY CLUSTERED 
	(
		 [ID] ASC 
	
	)	WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'id', @value=N'全局唯一键' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'rname', @value=N'乡镇名称' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'zjm', @value=N'助记码' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'rlevel', @value=N'级别' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'sortnum', @value=N'排序序号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'parentid', @value=N'上级id' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'remark', @value=N'相关说明' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'deletemark', @value=N'删除标记' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'addtime', @value=N'添加日期' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'addperson', @value=N'添加人' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'modifytime', @value=N'修改日期' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'modifyperson', @value=N'修改人' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'u1', @value=N'备用字段1' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'u2', @value=N'备用字段2' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'u3', @value=N'备用字段3' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'u4', @value=N'备用字段4' 


	
--4.创建表 T_Ushield U盾管理表
IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE XTYPE='U' AND NAME='T_Ushield')
DROP TABLE T_Ushield
GO
Create table T_Ushield
(
	 ID int identity(1,1),
	 UName varchar(100),
	 HardWareCode varchar(100),
	 Seed varchar(100),
	 UKey varchar(100),
	 Remark varchar(200),
	 DeleteMark varchar(2)  default('1'),
	
	CONSTRAINT PK_T_Ushield PRIMARY KEY CLUSTERED 
	(
		 [ID] ASC 
	
	)	WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'id', @value=N'全局唯一键' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'uname', @value=N'u盾名称' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'hardwarecode', @value=N'硬件编码' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'seed', @value=N'种子码' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'ukey', @value=N'3des密钥' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'remark', @value=N'备注' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'deletemark', @value=N'删除标记' 


	
--5.创建表 T_SytemSet 系统设置表
IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE XTYPE='U' AND NAME='T_SytemSet')
DROP TABLE T_SytemSet
GO
Create table T_SytemSet
(
	 ID int identity(1,1),
	 sNum varchar(20),
	 sName varchar(100),
	 sValue varchar(200),
	 sReamrk varchar(200),
	 sDeleteMark varchar(2) default('1'),
	 U1 varchar(200),
	 U2 varchar(200),
	 U3 varchar(200),
	 U4 varchar(200),
	
	CONSTRAINT PK_T_SytemSet PRIMARY KEY CLUSTERED 
	(
		 [ID] ASC 
	
	)	WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'id', @value=N'全局唯一键' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'snum', @value=N'参数编号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'sname', @value=N'参数名称' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'svalue', @value=N'参数值' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'sreamrk', @value=N'设置参考' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'sdeletemark', @value=N'删除标记' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'u1', @value=N'备用字段1' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'u2', @value=N'备用字段2' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'u3', @value=N'备用字段3' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'u4', @value=N'备用字段4' 





--6.数据字典表 T_Dictionary 数据字典表
IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE XTYPE='U' AND NAME='T_Dictionary')
DROP TABLE T_Dictionary
GO
Create table T_Dictionary
(
	 ID int identity(1,1),
	 dNum varchar(20),
	 dName varchar(100),
	 dType varchar(10),
	 dLevel int,
	 dMark varchar(10),
	 dSortNum int,
	 dRemark varchar(200),
	
	CONSTRAINT PK_T_Dictionary PRIMARY KEY CLUSTERED 
	(
		 [ID] ASC 
	
	)	WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'id', @value=N'全局唯一键' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dnum', @value=N'代码编号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dname', @value=N'代码名称' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dtype', @value=N'代码类别' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dlevel', @value=N'代码级次' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dmark', @value=N'代码标记' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dsortnum', @value=N'排序号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dremark', @value=N'备注' 


--创建唯一索引
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[T_Dictionary]') AND name = N'IDX_T_Dictionary_dType')
DROP INDEX [IDX_T_Dictionary_dType] ON [dbo].[T_Dictionary] WITH ( ONLINE = OFF )
GO

CREATE  INDEX [IDX_T_Dictionary_dType] ON [dbo].[T_Dictionary] 
(
    [dNum] asc,
	[dName] asc,
	[dType] asc
)

	
--8 创建表 T_Product 产品表
IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE XTYPE='U' AND NAME='T_Product')
DROP TABLE T_Product
GO
Create table T_Product
(
	 ID int identity(1,1),
	 pNum varchar(20),
	 pName varchar(100),
	 pZjm varchar(100),
	 pSortNum int,
	 pRemark varchar(200),
	 sRemark varchar(200),
	
	CONSTRAINT PK_T_Product PRIMARY KEY CLUSTERED 
	(
		 [ID] ASC 
	
	)	WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'id', @value=N'全局唯一键' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'pnum', @value=N'产品编号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'pname', @value=N'产品名称' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'pzjm', @value=N'助记码' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'psortnum', @value=N'排序序号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'premark', @value=N'备注' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'sremark', @value=N'备注' 



	
--9 创建表 T_Standard 规格表
IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE XTYPE='U' AND NAME='T_Standard')
DROP TABLE T_Standard
GO
Create table T_Standard
(
	 ID int identity(1,1),
	 sProductNum varchar(20),
	 sName varchar(100),
	 sUnit varchar(10),
	 sWeight decimal(18,4),
	 sVolume decimal(18,4),
	 sPrice decimal(18,2),
	 sSortNum int,
	
	CONSTRAINT PK_T_Standard PRIMARY KEY CLUSTERED 
	(
		 [ID] ASC 
	
	)	WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'id', @value=N'全局唯一键' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'sproductnum', @value=N'产品编号' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'sname', @value=N'规格名称' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'sunit', @value=N'计量单位' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'sweight', @value=N'重量' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'svolume', @value=N'体积' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'sprice', @value=N'价格' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'ssortnum', @value=N'排序序号' 



truncate table T_Dictionary
insert into T_Dictionary(dNum,dName,dType,dLevel,dRemark)
values('D01','客户类型','00',1,'顶级类别')
--客户类型
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('01','A级','D01',1,1)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('02','B级','D01',1,2)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('03','C级','D01',1,3)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('04','D级','D01',1,4)

insert into T_Dictionary(dNum,dName,dType,dLevel,dRemark)
values('D02','存放仓库','00',1,'仓库')
--存放仓库
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('01','东库','D02',1,1)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('02','西库','D02',1,2)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('03','南库','D02',1,3)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('04','北库','D02',1,4)

--代发银行
insert into T_Dictionary(dNum,dName,dType,dLevel,dRemark)
values('D03','代发银行','00',1,'代发银行名称')

insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('01','中国农业银行','D03',1,1)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('02','临商银行','D03',1,2)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('03','中国银行','D03',1,3)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('04','中国工商银行','D03',1,4)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('05','中国建设银行','D03',1,5)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('06','中国民生银行','D03',1,6)


select * from T_Dictionary




