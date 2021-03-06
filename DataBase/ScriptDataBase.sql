USE [systemManagementAPI]
GO
/****** Object:  User [joselo]    Script Date: 14/06/2020 12:18:08 a. m. ******/
CREATE USER [joselo] FOR LOGIN [joselo] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [joselo]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [joselo]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [joselo]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [joselo]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [joselo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [joselo]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [joselo]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [joselo]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [joselo]
GO
/****** Object:  Table [dbo].[tbl_Permission]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Permission](
	[pmID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[pm_code] [varchar](10) NULL,
	[pm_name] [varchar](50) NULL,
	[pm_description] [varchar](100) NULL,
	[pm_creationUser] [varchar](50) NULL,
	[pm_creationDate] [datetime] NULL,
	[pm_modificationUser] [varchar](50) NULL,
	[pm_modificationDate] [datetime] NULL,
	[pm_status] [varchar](1) NULL,
 CONSTRAINT [PK_tbl_Permission] PRIMARY KEY CLUSTERED 
(
	[pmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Role]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Role](
	[rlID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[rl_code] [varchar](10) NULL,
	[rl_name] [varchar](50) NULL,
	[rl_creationUser] [varchar](100) NULL,
	[rl_creationDate] [datetime] NULL,
	[rl_modificationUser] [varchar](50) NULL,
	[rl_modificationDate] [datetime] NULL,
	[rl_status] [varchar](1) NULL,
 CONSTRAINT [PK_tbl_Role] PRIMARY KEY CLUSTERED 
(
	[rlID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_RolePermission]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_RolePermission](
	[rpID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[rl_code] [varchar](10) NULL,
	[pm_code] [varchar](10) NULL,
	[rp_creationUser] [varchar](50) NULL,
	[rp_creationDate] [datetime] NULL,
	[rp_modificationUser] [varchar](50) NULL,
	[rp_modificationDate] [datetime] NULL,
	[rp_status] [varchar](1) NULL,
 CONSTRAINT [PK_tbl_RolePermission] PRIMARY KEY CLUSTERED 
(
	[rpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Session]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Session](
	[sesID] [varchar](50) NOT NULL,
	[usrID] [decimal](18, 0) NOT NULL,
	[ses_status] [varchar](10) NOT NULL,
	[ses_date] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_Session] PRIMARY KEY CLUSTERED 
(
	[sesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[usrID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[usr_code] [varchar](10) NULL,
	[usr_userName] [varchar](50) NULL,
	[usr_password] [varchar](50) NULL,
	[usr_fullName] [varchar](100) NULL,
	[usr_documentType] [varchar](25) NULL,
	[usr_numberDocument] [varchar](10) NULL,
	[usr_email] [varchar](50) NULL,
	[usr_balance] [decimal](18, 2) NULL,
	[usr_role] [varchar](10) NULL,
	[usr_creationUser] [varchar](50) NULL,
	[usr_creationDate] [datetime] NULL,
	[usr_modificationUser] [varchar](50) NULL,
	[usr_modificationDate] [datetime] NULL,
	[usr_status] [varchar](1) NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[usrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserCode]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserCode](
	[uscID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[usc_code] [varchar](50) NULL,
	[usr_code] [varchar](10) NULL,
	[usc_creationUser] [varchar](50) NULL,
	[usc_creationDate] [datetime] NULL,
	[usc_status] [varchar](1) NULL,
 CONSTRAINT [PK_tbl_userCode] PRIMARY KEY CLUSTERED 
(
	[uscID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Permission] ON 

INSERT [dbo].[tbl_Permission] ([pmID], [pm_code], [pm_name], [pm_description], [pm_creationUser], [pm_creationDate], [pm_modificationUser], [pm_modificationDate], [pm_status]) VALUES (CAST(1 AS Decimal(18, 0)), N'01', N'CrearUsuario', N'Se gestiona la creación de un usuario en el sistema', NULL, NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_Permission] ([pmID], [pm_code], [pm_name], [pm_description], [pm_creationUser], [pm_creationDate], [pm_modificationUser], [pm_modificationDate], [pm_status]) VALUES (CAST(2 AS Decimal(18, 0)), N'02', N'ActualizarUsuario', N'Gestiona la actualización de información del usuario pero no el balance', NULL, NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_Permission] ([pmID], [pm_code], [pm_name], [pm_description], [pm_creationUser], [pm_creationDate], [pm_modificationUser], [pm_modificationDate], [pm_status]) VALUES (CAST(3 AS Decimal(18, 0)), N'03', N'AdicionarBalance', N'Operación por la cual se agrega balance a la cuenta del usuario', NULL, NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_Permission] ([pmID], [pm_code], [pm_name], [pm_description], [pm_creationUser], [pm_creationDate], [pm_modificationUser], [pm_modificationDate], [pm_status]) VALUES (CAST(4 AS Decimal(18, 0)), N'04', N'EliminaBalance', N'Operación por la cual se descuenta balance a la cuenta del usuario', NULL, NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_Permission] ([pmID], [pm_code], [pm_name], [pm_description], [pm_creationUser], [pm_creationDate], [pm_modificationUser], [pm_modificationDate], [pm_status]) VALUES (CAST(5 AS Decimal(18, 0)), N'05', N'ConsultaUsuario', N'Operación que permite conocer la información del usuario', NULL, NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_Permission] ([pmID], [pm_code], [pm_name], [pm_description], [pm_creationUser], [pm_creationDate], [pm_modificationUser], [pm_modificationDate], [pm_status]) VALUES (CAST(6 AS Decimal(18, 0)), N'06', N'TransferirBalance', N'Operación que gestiona la transferencia de balance de la cuenta de un usuario a otra', NULL, NULL, NULL, NULL, N'V')
SET IDENTITY_INSERT [dbo].[tbl_Permission] OFF
SET IDENTITY_INSERT [dbo].[tbl_Role] ON 

INSERT [dbo].[tbl_Role] ([rlID], [rl_code], [rl_name], [rl_creationUser], [rl_creationDate], [rl_modificationUser], [rl_modificationDate], [rl_status]) VALUES (CAST(1 AS Decimal(18, 0)), N'01', N'Administrador', N'01', NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_Role] ([rlID], [rl_code], [rl_name], [rl_creationUser], [rl_creationDate], [rl_modificationUser], [rl_modificationDate], [rl_status]) VALUES (CAST(2 AS Decimal(18, 0)), N'02', N'Usuario', N'01', NULL, NULL, NULL, N'V')
SET IDENTITY_INSERT [dbo].[tbl_Role] OFF
SET IDENTITY_INSERT [dbo].[tbl_RolePermission] ON 

INSERT [dbo].[tbl_RolePermission] ([rpID], [rl_code], [pm_code], [rp_creationUser], [rp_creationDate], [rp_modificationUser], [rp_modificationDate], [rp_status]) VALUES (CAST(1 AS Decimal(18, 0)), N'01', N'01', NULL, NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_RolePermission] ([rpID], [rl_code], [pm_code], [rp_creationUser], [rp_creationDate], [rp_modificationUser], [rp_modificationDate], [rp_status]) VALUES (CAST(2 AS Decimal(18, 0)), N'01', N'02', NULL, NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_RolePermission] ([rpID], [rl_code], [pm_code], [rp_creationUser], [rp_creationDate], [rp_modificationUser], [rp_modificationDate], [rp_status]) VALUES (CAST(3 AS Decimal(18, 0)), N'01', N'03', NULL, NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_RolePermission] ([rpID], [rl_code], [pm_code], [rp_creationUser], [rp_creationDate], [rp_modificationUser], [rp_modificationDate], [rp_status]) VALUES (CAST(4 AS Decimal(18, 0)), N'01', N'04', NULL, NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_RolePermission] ([rpID], [rl_code], [pm_code], [rp_creationUser], [rp_creationDate], [rp_modificationUser], [rp_modificationDate], [rp_status]) VALUES (CAST(5 AS Decimal(18, 0)), N'02', N'05', NULL, NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_RolePermission] ([rpID], [rl_code], [pm_code], [rp_creationUser], [rp_creationDate], [rp_modificationUser], [rp_modificationDate], [rp_status]) VALUES (CAST(6 AS Decimal(18, 0)), N'02', N'06', NULL, NULL, NULL, NULL, N'V')
SET IDENTITY_INSERT [dbo].[tbl_RolePermission] OFF
INSERT [dbo].[tbl_Session] ([sesID], [usrID], [ses_status], [ses_date]) VALUES (N'159ec535-bc7d-4715-82dc-09d8e213ed93', CAST(3 AS Decimal(18, 0)), N'V', CAST(N'2020-06-13T23:48:41.733' AS DateTime))
INSERT [dbo].[tbl_Session] ([sesID], [usrID], [ses_status], [ses_date]) VALUES (N'180ddfe2-fb94-4593-a594-1d21d9be31db', CAST(3 AS Decimal(18, 0)), N'N', CAST(N'2020-06-13T22:06:46.473' AS DateTime))
INSERT [dbo].[tbl_Session] ([sesID], [usrID], [ses_status], [ses_date]) VALUES (N'378e7998-9f89-48e5-a81a-8b88dea013c4', CAST(3 AS Decimal(18, 0)), N'N', CAST(N'2020-06-13T23:32:42.760' AS DateTime))
INSERT [dbo].[tbl_Session] ([sesID], [usrID], [ses_status], [ses_date]) VALUES (N'a3d8d4a6-1ae4-439d-94a8-2dd7c814171c', CAST(3 AS Decimal(18, 0)), N'N', CAST(N'2020-06-13T23:16:03.103' AS DateTime))
INSERT [dbo].[tbl_Session] ([sesID], [usrID], [ses_status], [ses_date]) VALUES (N'aea7d42b-1bf3-40b6-82d9-f88fde7b4863', CAST(1 AS Decimal(18, 0)), N'N', CAST(N'2020-06-13T22:01:18.223' AS DateTime))
INSERT [dbo].[tbl_Session] ([sesID], [usrID], [ses_status], [ses_date]) VALUES (N'cba41f2a-7f2b-46ab-b3df-cc9d6ebfd741', CAST(3 AS Decimal(18, 0)), N'N', CAST(N'2020-06-13T22:58:56.080' AS DateTime))
INSERT [dbo].[tbl_Session] ([sesID], [usrID], [ses_status], [ses_date]) VALUES (N'f0ac0969-7813-4c87-8c53-7758ed3f1c43', CAST(2 AS Decimal(18, 0)), N'N', CAST(N'2020-06-13T22:04:39.147' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_User] ON 

INSERT [dbo].[tbl_User] ([usrID], [usr_code], [usr_userName], [usr_password], [usr_fullName], [usr_documentType], [usr_numberDocument], [usr_email], [usr_balance], [usr_role], [usr_creationUser], [usr_creationDate], [usr_modificationUser], [usr_modificationDate], [usr_status]) VALUES (CAST(1 AS Decimal(18, 0)), N'01', N'admon', N'Y07Z+DuaRTfftWT6o8qvpg==', N'Administrador del Sistema', N'1', N'0123456789', N'admin@gmail.com', CAST(0.00 AS Decimal(18, 2)), N'01', N'01', NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_User] ([usrID], [usr_code], [usr_userName], [usr_password], [usr_fullName], [usr_documentType], [usr_numberDocument], [usr_email], [usr_balance], [usr_role], [usr_creationUser], [usr_creationDate], [usr_modificationUser], [usr_modificationDate], [usr_status]) VALUES (CAST(2 AS Decimal(18, 0)), N'02', N'usuario1', N'QKe1CFJrcxr6XeeyC9u+IA==', N'Usuario UNO', N'1', N'1123456789', N'usuario1@gmail.com', CAST(11000.00 AS Decimal(18, 2)), N'02', N'01', NULL, NULL, NULL, N'V')
INSERT [dbo].[tbl_User] ([usrID], [usr_code], [usr_userName], [usr_password], [usr_fullName], [usr_documentType], [usr_numberDocument], [usr_email], [usr_balance], [usr_role], [usr_creationUser], [usr_creationDate], [usr_modificationUser], [usr_modificationDate], [usr_status]) VALUES (CAST(3 AS Decimal(18, 0)), N'03', N'usuario2', N't92/vEznbbKwzU5sYCPcJQ==', N'Usuario DOS', N'1', N'1223456789', N'usuario2@gmail.com', CAST(11000.00 AS Decimal(18, 2)), N'02', N'01', NULL, NULL, NULL, N'V')
SET IDENTITY_INSERT [dbo].[tbl_User] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Permission]    Script Date: 14/06/2020 12:18:09 a. m. ******/
ALTER TABLE [dbo].[tbl_Permission] ADD  CONSTRAINT [UC_Permission] UNIQUE NONCLUSTERED 
(
	[pm_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Role]    Script Date: 14/06/2020 12:18:09 a. m. ******/
ALTER TABLE [dbo].[tbl_Role] ADD  CONSTRAINT [UC_Role] UNIQUE NONCLUSTERED 
(
	[rl_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Permission] ADD  CONSTRAINT [DF_tbl_Permission_pm_status]  DEFAULT ('V') FOR [pm_status]
GO
ALTER TABLE [dbo].[tbl_Role] ADD  CONSTRAINT [DF_tbl_Role_rl_status]  DEFAULT ('V') FOR [rl_status]
GO
ALTER TABLE [dbo].[tbl_RolePermission] ADD  CONSTRAINT [DF_tbl_RolePermission_rp_status]  DEFAULT ('V') FOR [rp_status]
GO
ALTER TABLE [dbo].[tbl_User] ADD  CONSTRAINT [DF_tbl_User_usr_balance]  DEFAULT ((0)) FOR [usr_balance]
GO
ALTER TABLE [dbo].[tbl_User] ADD  CONSTRAINT [DF_tbl_User_usr_status]  DEFAULT ('V') FOR [usr_status]
GO
ALTER TABLE [dbo].[tbl_RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RolePermission_tbl_Permission] FOREIGN KEY([pm_code])
REFERENCES [dbo].[tbl_Permission] ([pm_code])
GO
ALTER TABLE [dbo].[tbl_RolePermission] CHECK CONSTRAINT [FK_tbl_RolePermission_tbl_Permission]
GO
ALTER TABLE [dbo].[tbl_RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RolePermission_tbl_Role] FOREIGN KEY([rl_code])
REFERENCES [dbo].[tbl_Role] ([rl_code])
GO
ALTER TABLE [dbo].[tbl_RolePermission] CHECK CONSTRAINT [FK_tbl_RolePermission_tbl_Role]
GO
ALTER TABLE [dbo].[tbl_Session]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Session_tbl_User] FOREIGN KEY([usrID])
REFERENCES [dbo].[tbl_User] ([usrID])
GO
ALTER TABLE [dbo].[tbl_Session] CHECK CONSTRAINT [FK_tbl_Session_tbl_User]
GO
ALTER TABLE [dbo].[tbl_User]  WITH CHECK ADD  CONSTRAINT [FK_tbl_User_tbl_Role] FOREIGN KEY([usr_role])
REFERENCES [dbo].[tbl_Role] ([rl_code])
GO
ALTER TABLE [dbo].[tbl_User] CHECK CONSTRAINT [FK_tbl_User_tbl_Role]
GO
/****** Object:  StoredProcedure [dbo].[spr_closeSession]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	close session
-- =============================================
CREATE PROCEDURE [dbo].[spr_closeSession]
	@sesID VARCHAR(50)
AS
BEGIN

	UPDATE [dbo].[tbl_Session] SET 
		ses_status = 'N',
		ses_date = GETDATE()
	WHERE sesID = @sesID

	RETURN @@ROWCOUNT

END
GO
/****** Object:  StoredProcedure [dbo].[spr_createSession]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	create session
-- =============================================
CREATE PROCEDURE [dbo].[spr_createSession] 
	@sesID VARCHAR(50)
	,@usrID NUMERIC(18,0)
AS
BEGIN

	INSERT INTO tbl_Session (sesID,usrID,ses_status,ses_date) VALUES (@sesID,@usrID,'V',GETDATE())

	RETURN @@ROWCOUNT

END
GO
/****** Object:  StoredProcedure [dbo].[spr_getPermissionByCode]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	get permission information
-- =============================================
CREATE PROCEDURE [dbo].[spr_getPermissionByCode] 
	@pm_code			  VARCHAR(10)
AS
BEGIN

	SELECT
	 pmID
	,pm_code
	,pm_name
	,pm_description
	,pm_creationUser
	,pm_creationDate
	,pm_modificationUser
	,pm_modificationDate
	,pm_status
	FROM tbl_Permission (nolock)
	WHERE pm_code = @pm_code
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[spr_getPermissionByRole]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	get Permission by Role
-- =============================================
CREATE PROCEDURE [dbo].[spr_getPermissionByRole] 
	 @rl_code VARCHAR(10)
AS
BEGIN

	SELECT
	  pm.pm_code
	, pm.pm_name
	, r.rl_code
	, r.rl_name
	, rp.rpID
	FROM tbl_RolePermission rp (NOLOCK) 
	INNER JOIN tbl_Role r (NOLOCK) ON r.rl_code = rp.rl_code
	INNER JOIN tbl_Permission pm (NOLOCK) ON pm.pm_code = rp.pm_code 
	WHERE r.rl_code = @rl_code

END
GO
/****** Object:  StoredProcedure [dbo].[spr_getRoleByCode]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	get role information
-- =============================================
CREATE PROCEDURE [dbo].[spr_getRoleByCode] 
	 @rl_code VARCHAR(10)
AS
BEGIN

	SELECT
	 rlID
	,rl_code
	,rl_name
	,rl_creationUser
	,rl_creationDate
	,rl_modificationUser
	,rl_modificationDate
	,rl_status
	FROM  tbl_Role r (NOLOCK) 
	WHERE r.rl_code = @rl_code

END
GO
/****** Object:  StoredProcedure [dbo].[spr_getUser]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	get user information
-- =============================================
CREATE PROCEDURE [dbo].[spr_getUser] 
	 @usr_userName VARCHAR(128)
AS
BEGIN

	SELECT
	 u.usrID
	,u.usr_code
	,u.usr_userName
	,u.usr_password
	,u.usr_fullName
	,u.usr_documentType
	,u.usr_numberDocument
	,u.usr_email
	,u.usr_balance
	,u.usr_role
	,r.rl_name
	,u.usr_status
	FROM tbl_User u (NOLOCK) 
	INNER JOIN tbl_Role r (NOLOCK) ON r.rl_code = u.usr_role
	WHERE usr_userName = @usr_userName

END
GO
/****** Object:  StoredProcedure [dbo].[spr_getUsers]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	get users information
-- =============================================
CREATE PROCEDURE [dbo].[spr_getUsers] 
AS
BEGIN

	SELECT
	 u.usrID
	,u.usr_code
	,u.usr_userName
	,u.usr_fullName
	,u.usr_documentType
	,u.usr_numberDocument
	,u.usr_password
	,u.usr_email
	,u.usr_balance
	,u.usr_role
	,r.rl_name
	,u.usr_status
	FROM tbl_User u (NOLOCK) 
	INNER JOIN tbl_Role r (NOLOCK) ON r.rl_code = u.usr_role
	

END
GO
/****** Object:  StoredProcedure [dbo].[spr_setAddBalance]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	add balance
-- =============================================
CREATE PROCEDURE [dbo].[spr_setAddBalance] 
	 @usr_userNameDestiny VARCHAR(50),
	 @valueTransfer DECIMAL(18,2)
AS
BEGIN
	
	DECLARE 
	@balanceDestiny DECIMAL(18,2),
	@status INT

	SELECT
	@balanceDestiny = usr_balance
	FROM
	tbl_User
	WHERE usr_userName = @usr_userNameDestiny

	--Select @balanceDestiny AS BALANCEDESTINY_PRE

	UPDATE tbl_User
	SET usr_balance = @balanceDestiny + @valueTransfer
	WHERE usr_userName = @usr_userNameDestiny	

	--SELECT
	--@balanceDestiny = usr_balance
	--FROM
	--tbl_User
	--WHERE usr_userName = @usr_userNameDestiny

	--Select @balanceDestiny AS BALANCEDESTINY_POS

	RETURN @@ROWCOUNT

END
GO
/****** Object:  StoredProcedure [dbo].[spr_setDeleteBalance]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	delete balance
-- =============================================
CREATE PROCEDURE [dbo].[spr_setDeleteBalance] 
	 @usr_userNameDestiny VARCHAR(50),
	 @valueTransfer DECIMAL(18,2)
AS
BEGIN
	
	DECLARE 
	@balanceDestiny DECIMAL(18,2),
	@status INT

	SELECT
	@balanceDestiny = usr_balance
	FROM
	tbl_User
	WHERE usr_userName = @usr_userNameDestiny

	--Select @balanceDestiny AS BALANCEDESTINY_PRE
	IF(@valueTransfer <= @balanceDestiny)
		BEGIN
			UPDATE tbl_User
			SET usr_balance = @balanceDestiny - @valueTransfer
			WHERE usr_userName = @usr_userNameDestiny	
			SET @status = 1
		END
	ELSE
		BEGIN
			SET @status = 0
		END
	
	--SELECT
	--@balanceDestiny = usr_balance
	--FROM
	--tbl_User
	--WHERE usr_userName = @usr_userNameDestiny

	--Select @balanceDestiny AS BALANCEDESTINY_POS

	SELECT @status as result

END
GO
/****** Object:  StoredProcedure [dbo].[spr_setPermission]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	create permission
-- =============================================
CREATE PROCEDURE [dbo].[spr_setPermission] 
	 @pm_code VARCHAR(10)
	,@pm_name VARCHAR(50)
	,@pm_description VARCHAR(100)
	,@pm_creationUser VARCHAR(50)
AS
BEGIN


	SELECT @pm_code = MAX(pm_code) + 1 FROM tbl_Permission

	IF(@pm_code <= 9 AND @pm_code > 0)
		BEGIN
			SET @pm_code = CONCAT('0',@pm_code)
		END
	ELSE
		BEGIN
			SET @pm_code = @pm_code
		END

	IF( (ISNULL(@pm_creationUser,1) = 1) OR (@pm_creationUser = '' ))
		BEGIN
			SET @pm_creationUser = '01'
		END

	INSERT INTO tbl_Permission
	(
	 pm_code
	,pm_name
	,pm_description
	,pm_creationUser
	,pm_creationDate
	,pm_status
	)
	VALUES
	(
	 @pm_code 
	,@pm_description
	,@pm_name
	,@pm_creationUser
	,GETDATE()
	,'V'
	)

	RETURN SCOPE_IDENTITY()

END
GO
/****** Object:  StoredProcedure [dbo].[spr_setRole]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 03/06/2020
-- Description:	create role
-- =============================================
CREATE PROCEDURE [dbo].[spr_setRole] 
	 @rl_code VARCHAR(10)
	,@rl_name VARCHAR(20)
	,@rl_creationUser VARCHAR(20)
AS
BEGIN

	SELECT @rl_code = MAX(rl_code) + 1 FROM tbl_Role

	IF(@rl_code <= 9 AND @rl_code > 0)
		BEGIN
			SET @rl_code = CONCAT('0',@rl_code)
		END
	ELSE
		BEGIN
			SET @rl_code = @rl_code
		END

	IF( (ISNULL(@rl_creationUser,1) = 1) OR (@rl_creationUser = '' ))
		BEGIN
			SET @rl_creationUser = '01'
		END

	INSERT INTO tbl_Role
	(
	rl_code
	,rl_name
	,rl_creationUser
	,rl_creationDate
	,rl_status
	)
	VALUES
	(
	 @rl_code 
	,@rl_name
	,@rl_creationUser
	,GETDATE()
	,'V'
	)

	RETURN SCOPE_IDENTITY()

END
GO
/****** Object:  StoredProcedure [dbo].[spr_setRolePermission]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	create relation between role and permission
-- =============================================
CREATE PROCEDURE [dbo].[spr_setRolePermission] 
	 @rl_code VARCHAR(10)
	,@pm_code VARCHAR(10)
	,@rp_creationUser VARCHAR(10)
AS
BEGIN

	IF( (ISNULL(@rp_creationUser,1) = 1) OR (@rp_creationUser = '' ))
		BEGIN
			SET @rp_creationUser = '01'
		END

	INSERT INTO tbl_RolePermission
	(
	 rl_code
	,pm_code
	,rp_creationUser
	,rp_creationDate
	,rp_status
	)
	VALUES
	(
	 @rl_code 
	,@pm_code
	,@rp_creationUser
	,GETDATE()
	,'V'
	)

	RETURN SCOPE_IDENTITY()

END
GO
/****** Object:  StoredProcedure [dbo].[spr_setTransferBalance]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	transfer balance by username
-- =============================================
CREATE PROCEDURE [dbo].[spr_setTransferBalance] 
	 @usr_userNameOrigin VARCHAR(50),
	 @usr_userNameDestiny VARCHAR(50),
	 @valueTransfer DECIMAL(18,2)
AS
BEGIN
	
	DECLARE 
	@balanceOrigin DECIMAL(18,2),
	@balanceDestiny DECIMAL(18,2),
	@status INT

	SELECT
	@balanceOrigin = usr_balance
	FROM
	tbl_User
	WHERE usr_userName = @usr_userNameOrigin

	SELECT
	@balanceDestiny = usr_balance
	FROM
	tbl_User
	WHERE usr_userName = @usr_userNameDestiny

	--Select @balanceDestiny AS BALANCEDESTINY_PRE
	IF(@valueTransfer <= @balanceOrigin)
		BEGIN
			UPDATE tbl_User
			SET usr_balance = @balanceOrigin - @valueTransfer
			WHERE usr_userName = @usr_userNameOrigin	

			UPDATE tbl_User
			SET usr_balance = @balanceDestiny + @valueTransfer
			WHERE usr_userName = @usr_userNameDestiny	

			SET @status = 1
		END
	ELSE
		BEGIN
			SET @status = 0
		END
	
	--SELECT
	--@balanceDestiny = usr_balance
	--FROM
	--tbl_User
	--WHERE usr_userName = @usr_userNameDestiny

	--Select @balanceDestiny AS BALANCEDESTINY_POS

	SELECT @status as result

END
GO
/****** Object:  StoredProcedure [dbo].[spr_setUser]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	Create user
-- =============================================
CREATE PROCEDURE [dbo].[spr_setUser] 
	 @usr_userName VARCHAR(50)
	,@usr_password VARCHAR(50)
	,@usr_fullName VARCHAR(50)
	,@usr_documentType VARCHAR(25)
	,@usr_numberDocument VARCHAR(10)
	,@usr_email VARCHAR(50)
	,@usr_role VARCHAR(10)
	,@usr_creationUser VARCHAR(50)
AS
BEGIN
	
	DECLARE @usr_code VARCHAR(10)

	SELECT @usr_code = MAX(usr_code) + 1 FROM tbl_User

	IF(@usr_code <= 9 AND @usr_code > 0)
		BEGIN
			SET @usr_code = CONCAT('0',@usr_code)
		END
	ELSE
		BEGIN
			SET @usr_code = @usr_code
		END

	IF( (ISNULL(@usr_creationUser,1) = 1) OR (@usr_creationUser = '' ))
		BEGIN
			SET @usr_creationUser = '01'
		END

	INSERT INTO tbl_User
	(
	   usr_userName
	 , usr_password
	 , usr_code
	 , usr_fullName
	 , usr_documentType
	 , usr_numberDocument
	 , usr_email
	 , usr_role
	 , usr_creationUser
	 , usr_creationDate
	 , usr_status
	 )
	 VALUES
	 (
	  @usr_userName 
	 ,@usr_password
	 ,@usr_code
	 ,@usr_fullName 
	 ,@usr_documentType 
	 ,@usr_numberDocument
	 ,@usr_email
	 ,@usr_role
	 ,@usr_creationUser
	 , GETDATE()
	 , 'V'
	)

	RETURN SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[spr_updatePermission]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	update permission information
-- =============================================
CREATE PROCEDURE [dbo].[spr_updatePermission] 
	 @pm_code			  VARCHAR(10)
	,@pm_name			  VARCHAR(50)
	,@pm_description	  VARCHAR(50) 
	,@pm_modificationUser VARCHAR(50) 
	,@pm_status			  VARCHAR(2)
AS
BEGIN

	UPDATE tbl_Permission
	SET 
	  pm_name			  = @pm_name
	, pm_description	  = @pm_description
	, pm_modificationUser = @pm_modificationUser
	, pm_modificationDate = GETDATE()
	, pm_status			  = @pm_status
	WHERE pm_code = @pm_code
	

	RETURN @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[spr_updateRole]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	update role information
-- =============================================
CREATE PROCEDURE [dbo].[spr_updateRole] 
	 @rl_code			  VARCHAR(10)
	,@rl_name			  VARCHAR(50)
	,@rl_modificationUser VARCHAR(50) 
	,@rl_status			  VARCHAR(2)
AS
BEGIN

	UPDATE tbl_Role
	SET
	 rl_name			 = @rl_name
	,rl_modificationUser = @rl_modificationUser
	,rl_modificationDate = GETDATE()
	,rl_status			 = @rl_status
	WHERE rl_code = @rl_code
	

	RETURN @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[spr_updateRolePermission]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	update relation between role and permission
-- =============================================
CREATE PROCEDURE [dbo].[spr_updateRolePermission]
	 @rpID NUMERIC(18,0)
	,@rl_code VARCHAR(10)
	,@pm_code VARCHAR(10)
	,@rp_modificationUser VARCHAR(50)
	,@rp_status VARCHAR(2)
AS
BEGIN

	UPDATE
	tbl_RolePermission
	SET
	 rl_code				= @rl_code
	,pm_code				= @pm_code
	,rp_modificationUser	= @rp_modificationUser
	,rp_modificationDate	= GETDATE()
	,rp_status				= @rp_status
	WHERE
	rpID = @rpID
	
	RETURN @@ROWCOUNT

END
GO
/****** Object:  StoredProcedure [dbo].[spr_updateUser]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	update user information
-- =============================================
CREATE PROCEDURE [dbo].[spr_updateUser] 
	 @usr_userName VARCHAR(50)
	,@usr_password VARCHAR(50)
	,@usr_fullName VARCHAR(50)
	,@usr_documentType VARCHAR(25)
	,@usr_numberDocument VARCHAR(10)
	,@usr_email VARCHAR(50)
	,@usr_role VARCHAR(10)
	,@usr_modificationUser VARCHAR(50)
	,@usr_status VARCHAR(2)
AS
BEGIN

	UPDATE tbl_User
	SET
	   usr_password	 = @usr_password 
	 , usr_fullName	 = @usr_fullName 
	 , usr_documentType	 = @usr_documentType 
	 , usr_numberDocument	 = @usr_numberDocument
	 , usr_email	 = @usr_email
	 , usr_role	 = @usr_role
	 , usr_modificationUser	 =  @usr_modificationUser
	 , usr_modificationDate	 =  GETDATE()
	 , usr_status	 =  @usr_status
	WHERE usr_userName = @usr_userName
	

	RETURN @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[spr_validateSession]    Script Date: 14/06/2020 12:18:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Joselo Martínez
-- Create date: 13/06/2020
-- Description:	validate session
-- =============================================
CREATE PROCEDURE [dbo].[spr_validateSession] 
	 @sesID VARCHAR(50)
	,@usrID NUMERIC(18,0)
AS
BEGIN
	
	UPDATE		
	tbl_Session
	SET ses_status = 'N'
	WHERE 
		ses_status = 'V'
		AND DATEDIFF(minute, ses_date,GETDATE()) > 15

	SELECT 
		sesID
		,usrID
		,ses_status
		,ses_date
	FROM tbl_Session (NOLOCK)
	WHERE 
		sesID = @sesID
		AND usrID = @usrID
		AND ses_status = 'V'

END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del Rol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Permission', @level2type=N'COLUMN',@level2name=N'pmID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo del Rol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Permission', @level2type=N'COLUMN',@level2name=N'pm_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del Rol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Permission', @level2type=N'COLUMN',@level2name=N'pm_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción del permiso ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Permission', @level2type=N'COLUMN',@level2name=N'pm_description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que crea el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Permission', @level2type=N'COLUMN',@level2name=N'pm_creationUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Permission', @level2type=N'COLUMN',@level2name=N'pm_creationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que modifica el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Permission', @level2type=N'COLUMN',@level2name=N'pm_modificationUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de modificación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Permission', @level2type=N'COLUMN',@level2name=N'pm_modificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado Activo(V), Inactivo(N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Permission', @level2type=N'COLUMN',@level2name=N'pm_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del Rol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Role', @level2type=N'COLUMN',@level2name=N'rlID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo del Rol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Role', @level2type=N'COLUMN',@level2name=N'rl_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del Rol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Role', @level2type=N'COLUMN',@level2name=N'rl_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que crea el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Role', @level2type=N'COLUMN',@level2name=N'rl_creationUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Role', @level2type=N'COLUMN',@level2name=N'rl_creationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que modifica el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Role', @level2type=N'COLUMN',@level2name=N'rl_modificationUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de modificación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Role', @level2type=N'COLUMN',@level2name=N'rl_modificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado Activo(V), Inactivo(N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Role', @level2type=N'COLUMN',@level2name=N'rl_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del Rol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_RolePermission', @level2type=N'COLUMN',@level2name=N'rpID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo del Rol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_RolePermission', @level2type=N'COLUMN',@level2name=N'rl_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo del Permiso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_RolePermission', @level2type=N'COLUMN',@level2name=N'pm_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que crea el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_RolePermission', @level2type=N'COLUMN',@level2name=N'rp_creationUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_RolePermission', @level2type=N'COLUMN',@level2name=N'rp_creationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que modifica el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_RolePermission', @level2type=N'COLUMN',@level2name=N'rp_modificationUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de modificación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_RolePermission', @level2type=N'COLUMN',@level2name=N'rp_modificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado Activo(V), Inactivo(N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_RolePermission', @level2type=N'COLUMN',@level2name=N'rp_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado de la sessión V(Activo), N(Inactivo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Session', @level2type=N'COLUMN',@level2name=N'ses_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usrID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo de usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_userName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Password o contraseña' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre completo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_fullName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de documento de identificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_documentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de documento de identificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_numberDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Correo electrónico' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Almacena la información del balance de euros que tiene el usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_balance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que crea el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_creationUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_creationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que modifica el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_modificationUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de modificación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_modificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado Activo(V), Inactivo(N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_User', @level2type=N'COLUMN',@level2name=N'usr_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de tabla códigos de usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_UserCode', @level2type=N'COLUMN',@level2name=N'uscID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'código generado para confirmación de usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_UserCode', @level2type=N'COLUMN',@level2name=N'usc_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'código de identificación de usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_UserCode', @level2type=N'COLUMN',@level2name=N'usr_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'usuario que crea de código' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_UserCode', @level2type=N'COLUMN',@level2name=N'usc_creationUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'fecha de creación del código' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_UserCode', @level2type=N'COLUMN',@level2name=N'usc_creationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'estado del código V(Activo), N(Inactivo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_UserCode', @level2type=N'COLUMN',@level2name=N'usc_status'
GO
