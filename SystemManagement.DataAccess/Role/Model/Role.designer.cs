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

namespace SystemManagement.DataAccess.Role.Model
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
	public partial class RoleDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    #endregion
		
		public RoleDataContext() : 
				base(global::SystemManagement.DataAccess.Properties.Settings.Default.systemManagementAPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public RoleDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RoleDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RoleDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RoleDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spr_setRole")]
		public int spr_setRole([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string rl_code, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string rl_name, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string rl_creationUser)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), rl_code, rl_name, rl_creationUser);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spr_setRolePermission")]
		public int spr_setRolePermission([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string rl_code, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pm_code, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string rp_creationUser)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), rl_code, pm_code, rp_creationUser);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spr_updateRole")]
		public int spr_updateRole([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string rl_code, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string rl_name, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string rl_modificationUser, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(2)")] string rl_status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), rl_code, rl_name, rl_modificationUser, rl_status);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spr_updateRolePermission")]
		public int spr_updateRolePermission([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(18,0)")] System.Nullable<decimal> rpID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string rl_code, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pm_code, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string rp_modificationUser, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(2)")] string rp_status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), rpID, rl_code, pm_code, rp_modificationUser, rp_status);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spr_getRoleByCode")]
		public ISingleResult<spr_getRoleByCodeResult> spr_getRoleByCode([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string rl_code)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), rl_code);
			return ((ISingleResult<spr_getRoleByCodeResult>)(result.ReturnValue));
		}
	}
	
	public partial class spr_getRoleByCodeResult
	{
		
		private decimal _rlID;
		
		private string _rl_code;
		
		private string _rl_name;
		
		private string _rl_creationUser;
		
		private System.Nullable<System.DateTime> _rl_creationDate;
		
		private string _rl_modificationUser;
		
		private System.Nullable<System.DateTime> _rl_modificationDate;
		
		private string _rl_status;
		
		public spr_getRoleByCodeResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rlID", DbType="Decimal(18,0) NOT NULL")]
		public decimal rlID
		{
			get
			{
				return this._rlID;
			}
			set
			{
				if ((this._rlID != value))
				{
					this._rlID = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rl_creationUser", DbType="VarChar(100)")]
		public string rl_creationUser
		{
			get
			{
				return this._rl_creationUser;
			}
			set
			{
				if ((this._rl_creationUser != value))
				{
					this._rl_creationUser = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rl_creationDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> rl_creationDate
		{
			get
			{
				return this._rl_creationDate;
			}
			set
			{
				if ((this._rl_creationDate != value))
				{
					this._rl_creationDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rl_modificationUser", DbType="VarChar(50)")]
		public string rl_modificationUser
		{
			get
			{
				return this._rl_modificationUser;
			}
			set
			{
				if ((this._rl_modificationUser != value))
				{
					this._rl_modificationUser = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rl_modificationDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> rl_modificationDate
		{
			get
			{
				return this._rl_modificationDate;
			}
			set
			{
				if ((this._rl_modificationDate != value))
				{
					this._rl_modificationDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rl_status", DbType="VarChar(1)")]
		public string rl_status
		{
			get
			{
				return this._rl_status;
			}
			set
			{
				if ((this._rl_status != value))
				{
					this._rl_status = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
