


--�������ݱ�
	
--1.������ T_Bill ���ϵ�
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'id', @value=N'ȫ��Ψһ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'bnum', @value=N'���ϱ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'warehouse', @value=N'��Ųֿ�' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'customername', @value=N'�ͻ���λ' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'CardNumber', @value=N'���֤��' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'mobile', @value=N'�ƶ��绰' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'tel', @value=N'�̶��绰' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'bankname', @value=N'��������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'bankaccount', @value=N'�����˺�' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'accountname', @value=N'����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'productname', @value=N'��Ʒ����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'productstandard', @value=N'��Ʒ���' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'unit', @value=N'��λ' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'grossweight', @value=N'��Ʒë��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'tare', @value=N'Ƥ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'netweight', @value=N'��Ʒ����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'price', @value=N'����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'amount', @value=N'���' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'remark', @value=N'���ϱ�ע' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'pricingman', @value=N'������Ա' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'loanmark', @value=N'�ſ���' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'loanman', @value=N'�ſ���Ա' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'loandate', @value=N'�ſ�ʱ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'loantype', @value=N'�ſ�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'loanremark', @value=N'�ſע' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'deletemark', @value=N'ɾ�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'addtime', @value=N'�������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'addperson', @value=N'�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'modifytime', @value=N'�޸�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'modifyperson', @value=N'�޸���' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'u1', @value=N'�����ֶ�1' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'u2', @value=N'�����ֶ�2' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'u3', @value=N'�����ֶ�3' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Bill',  @level2name=N'u4', @value=N'�����ֶ�4' 


	
--2.������ T_Customer �ͻ���
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'id', @value=N'ȫ��Ψһ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'cname', @value=N'�ͻ�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'zjm', @value=N'������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'clevel', @value=N'�ͻ�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'oneregional', @value=N'һ������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'tworegional', @value=N'��������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'cardnumber', @value=N'���֤��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'tel', @value=N'�̶��绰' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'mobile', @value=N'�ƶ��绰' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'address', @value=N'סַ' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'bankname', @value=N'��������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'bankaccount', @value=N'�����˺�' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'acountname', @value=N'����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'addtime', @value=N'�������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'addperson', @value=N'�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'modifytime', @value=N'�޸�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'modifyperson', @value=N'�޸���' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'mergedmark', @value=N'�ϲ����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'deletemark', @value=N'ɾ�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'sortnum', @value=N'�������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'remark', @value=N'��ע' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'u1', @value=N'�����ֶ�1' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'u2', @value=N'�����ֶ�2' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'u3', @value=N'�����ֶ�3' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Customer',  @level2name=N'u4', @value=N'�����ֶ�4' 


	
--3.������ T_Regional �����
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'id', @value=N'ȫ��Ψһ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'rname', @value=N'��������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'zjm', @value=N'������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'rlevel', @value=N'����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'sortnum', @value=N'�������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'parentid', @value=N'�ϼ�id' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'remark', @value=N'���˵��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'deletemark', @value=N'ɾ�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'addtime', @value=N'�������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'addperson', @value=N'�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'modifytime', @value=N'�޸�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'modifyperson', @value=N'�޸���' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'u1', @value=N'�����ֶ�1' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'u2', @value=N'�����ֶ�2' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'u3', @value=N'�����ֶ�3' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Regional',  @level2name=N'u4', @value=N'�����ֶ�4' 


	
--4.������ T_Ushield U�ܹ����
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'id', @value=N'ȫ��Ψһ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'uname', @value=N'u������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'hardwarecode', @value=N'Ӳ������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'seed', @value=N'������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'ukey', @value=N'3des��Կ' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'remark', @value=N'��ע' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Ushield',  @level2name=N'deletemark', @value=N'ɾ�����' 


	
--5.������ T_SytemSet ϵͳ���ñ�
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'id', @value=N'ȫ��Ψһ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'snum', @value=N'�������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'sname', @value=N'��������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'svalue', @value=N'����ֵ' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'sreamrk', @value=N'���òο�' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'sdeletemark', @value=N'ɾ�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'u1', @value=N'�����ֶ�1' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'u2', @value=N'�����ֶ�2' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'u3', @value=N'�����ֶ�3' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_SytemSet',  @level2name=N'u4', @value=N'�����ֶ�4' 





--6.�����ֵ�� T_Dictionary �����ֵ��
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'id', @value=N'ȫ��Ψһ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dnum', @value=N'������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dname', @value=N'��������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dtype', @value=N'�������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dlevel', @value=N'���뼶��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dmark', @value=N'������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dsortnum', @value=N'�����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Dictionary',  @level2name=N'dremark', @value=N'��ע' 


--����Ψһ����
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[T_Dictionary]') AND name = N'IDX_T_Dictionary_dType')
DROP INDEX [IDX_T_Dictionary_dType] ON [dbo].[T_Dictionary] WITH ( ONLINE = OFF )
GO

CREATE  INDEX [IDX_T_Dictionary_dType] ON [dbo].[T_Dictionary] 
(
    [dNum] asc,
	[dName] asc,
	[dType] asc
)

	
--8 ������ T_Product ��Ʒ��
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'id', @value=N'ȫ��Ψһ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'pnum', @value=N'��Ʒ���' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'pname', @value=N'��Ʒ����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'pzjm', @value=N'������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'psortnum', @value=N'�������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'premark', @value=N'��ע' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Product',  @level2name=N'sremark', @value=N'��ע' 



	
--9 ������ T_Standard ����
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'id', @value=N'ȫ��Ψһ��' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'sproductnum', @value=N'��Ʒ���' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'sname', @value=N'�������' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'sunit', @value=N'������λ' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'sweight', @value=N'����' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'svolume', @value=N'���' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'sprice', @value=N'�۸�' 

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE',@level2type=N'COLUMN', @level1name=N'T_Standard',  @level2name=N'ssortnum', @value=N'�������' 



truncate table T_Dictionary
insert into T_Dictionary(dNum,dName,dType,dLevel,dRemark)
values('D01','�ͻ�����','00',1,'�������')
--�ͻ�����
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('01','A��','D01',1,1)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('02','B��','D01',1,2)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('03','C��','D01',1,3)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('04','D��','D01',1,4)

insert into T_Dictionary(dNum,dName,dType,dLevel,dRemark)
values('D02','��Ųֿ�','00',1,'�ֿ�')
--��Ųֿ�
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('01','����','D02',1,1)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('02','����','D02',1,2)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('03','�Ͽ�','D02',1,3)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('04','����','D02',1,4)

--��������
insert into T_Dictionary(dNum,dName,dType,dLevel,dRemark)
values('D03','��������','00',1,'������������')

insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('01','�й�ũҵ����','D03',1,1)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('02','��������','D03',1,2)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('03','�й�����','D03',1,3)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('04','�й���������','D03',1,4)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('05','�й���������','D03',1,5)
insert into T_Dictionary(dNum,dName,dType,dLevel,dSortNum)
values('06','�й���������','D03',1,6)


select * from T_Dictionary




