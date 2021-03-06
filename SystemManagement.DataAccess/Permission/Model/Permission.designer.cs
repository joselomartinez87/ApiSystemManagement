﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SystemManagement.DataAccess.Permission.Model
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="systemManagementAPI")]
	public partial class PermissionDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    #endregion
		
		public PermissionDataContext() : 
				base(global::SystemManagement.DataAccess.Properties.Settings.Default.systemManagementAPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PermissionDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PermissionDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PermissionDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PermissionDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spr_getPermissionByCode")]
		public ISingleResult<spr_getPermissionByCodeResult> spr_getPermissionByCode([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pm_code)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pm_code);
			return ((ISingleResult<spr_getPermissionByCodeResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spr_getPermissionByRole")]
		public ISingleResult<spr_getPermissionByRoleResult> spr_getPermissionByRole([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string rl_code)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), rl_code);
			return ((ISingleResult<spr_getPermissionByRoleResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spr_setPermission")]
		public int spr_setPermission([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pm_code, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string pm_name, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(100)")] string pm_description, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string pm_creationUser)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pm_code, pm_name, pm_description, pm_creationUser);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spr_updatePermission")]
		public int spr_updatePermission([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pm_code, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string pm_name, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string pm_description, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string pm_modificationUser, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(2)")] string pm_status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pm_code, pm_name, pm_description, pm_modificationUser, pm_status);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class spr_getPermissionByCodeResult
	{
		
		private decimal _pmID;
		
		private string _pm_code;
		
		private string _pm_name;
		
		private string _pm_description;
		
		private string _pm_creationUser;
		
		private System.Nullable<System.DateTime> _pm_creationDate;
		
		private string _pm_modificationUser;
		
		private System.Nullable<System.DateTime> _pm_modificationDate;
		
		private string _pm_status;
		
		public spr_getPermissionByCodeResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pmID", DbType="Decimal(18,0) NOT NULL")]
		public decimal pmID
		{
			get
			{
				return this._pmID;
			}
			set
			{
				if ((this._pmID != value))
				{
					this._pmID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pm_code", DbType="VarChar(10)")]
		public string pm_code
		{
			get
			{
				return this._pm_code;
			}
			set
			{
				if ((this._pm_code != value))
				{
					this._pm_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pm_name", DbType="VarChar(50)")]
		public string pm_name
		{
			get
			{
				return this._pm_name;
			}
			set
			{
				if ((this._pm_name != value))
				{
					this._pm_name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pm_description", DbType="VarChar(100)")]
		public string pm_description
		{
			get
			{
				return this._pm_description;
			}
			set
			{
				if ((this._pm_description != value))
				{
					this._pm_description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pm_creationUser", DbType="VarChar(50)")]
		public string pm_creationUser
		{
			get
			{
				return this._pm_creationUser;
			}
			set
			{
				if ((this._pm_creationUser != value))
				{
					this._pm_creationUser = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pm_creationDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> pm_creationDate
		{
			get
			{
				return this._pm_creationDate;
			}
			set
			{
				if ((this._pm_creationDate != value))
				{
					this._pm_creationDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pm_modificationUser", DbType="VarChar(50)")]
		public string pm_modificationUser
		{
			get
			{
				return this._pm_modificationUser;
			}
			set
			{
				if ((this._pm_modificationUser != value))
				{
					this._pm_modificationUser = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pm_modificationDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> pm_modificationDate
		{
			get
			{
				return this._pm_modificationDate;
			}
			set
			{
				if ((this._pm_modificationDate != value))
				{
					this._pm_modificationDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pm_status", DbType="VarChar(1)")]
		public string pm_status
		{
			get
			{
				return this._pm_status;
			}
			set
			{
				if ((this._pm_status != value))
				{
					this._pm_status = value;
				}
			}
		}
	}
	
	public partial class spr_getPermissionByRoleResult
	{
		
		private string _pm_code;
		
		private string _pm_name;
		
		private string _rl_code;
		
		private string _rl_name;
		
		private decimal _rpID;
		
		public spr_getPermissionByRoleResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pm_code", DbType="VarChar(10)")]
		public string pm_code
		{
			get
			{
				return this._pm_code;
			}
			set
			{
				if ((this._pm_code != value))
				{
					this._pm_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pm_name", DbType="VarChar(50)")]
		public string pm_name
		{
			get
			{
				return this._pm_name;
			}
			set
			{
				if ((this._pm_name != value))
				{
					this._pm_name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rl_code", DbType="VarChar(10)")]
		public string rl_code
		{
			get
			{
				return this._rl_code;
			}
			set
			{
				if ((this._rl_code != value))
				{
					this._rl_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rl_name", DbType="VarChar(50)")]
		public string rl_name
		{
			get
			{
				return this._rl_name;
			}
			set
			{
				if ((this._rl_name != value))
				{
					this._rl_name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rpID", DbType="Decimal(18,0) NOT NULL")]
		public decimal rpID
		{
			get
			{
				return this._rpID;
			}
			set
			{
				if ((this._rpID != value))
				{
					this._rpID = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
