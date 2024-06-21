﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LostAndFound
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Lost&Found Database")]
	public partial class LostAndFoundDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertClaim(Claim instance);
    partial void UpdateClaim(Claim instance);
    partial void DeleteClaim(Claim instance);
    partial void InsertItem(Item instance);
    partial void UpdateItem(Item instance);
    partial void DeleteItem(Item instance);
    partial void InsertLog(Log instance);
    partial void UpdateLog(Log instance);
    partial void DeleteLog(Log instance);
    partial void InsertStaff(Staff instance);
    partial void UpdateStaff(Staff instance);
    partial void DeleteStaff(Staff instance);
    partial void InsertStaffRole(StaffRole instance);
    partial void UpdateStaffRole(StaffRole instance);
    partial void DeleteStaffRole(StaffRole instance);
    #endregion
		
		public LostAndFoundDataContext() : 
				base(global::LostAndFound.Properties.Settings.Default.Lost_Found_DatabaseConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LostAndFoundDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LostAndFoundDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LostAndFoundDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LostAndFoundDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Claim> Claims
		{
			get
			{
				return this.GetTable<Claim>();
			}
		}
		
		public System.Data.Linq.Table<Item> Items
		{
			get
			{
				return this.GetTable<Item>();
			}
		}
		
		public System.Data.Linq.Table<Log> Logs
		{
			get
			{
				return this.GetTable<Log>();
			}
		}
		
		public System.Data.Linq.Table<Staff> Staffs
		{
			get
			{
				return this.GetTable<Staff>();
			}
		}
		
		public System.Data.Linq.Table<StaffRole> StaffRoles
		{
			get
			{
				return this.GetTable<StaffRole>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Claim")]
	public partial class Claim : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Claim_ID;
		
		private string _Claim_FirstName;
		
		private string _Claim_LastName;
		
		private string _Claim_Role;
		
		private System.Nullable<System.DateTime> _Claim_Date;
		
		private string _Staff_ID;
		
		private EntitySet<Item> _Items;
		
		private EntitySet<Log> _Logs;
		
		private EntityRef<Staff> _Staff;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnClaim_IDChanging(string value);
    partial void OnClaim_IDChanged();
    partial void OnClaim_FirstNameChanging(string value);
    partial void OnClaim_FirstNameChanged();
    partial void OnClaim_LastNameChanging(string value);
    partial void OnClaim_LastNameChanged();
    partial void OnClaim_RoleChanging(string value);
    partial void OnClaim_RoleChanged();
    partial void OnClaim_DateChanging(System.Nullable<System.DateTime> value);
    partial void OnClaim_DateChanged();
    partial void OnStaff_IDChanging(string value);
    partial void OnStaff_IDChanged();
    #endregion
		
		public Claim()
		{
			this._Items = new EntitySet<Item>(new Action<Item>(this.attach_Items), new Action<Item>(this.detach_Items));
			this._Logs = new EntitySet<Log>(new Action<Log>(this.attach_Logs), new Action<Log>(this.detach_Logs));
			this._Staff = default(EntityRef<Staff>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Claim_ID", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Claim_ID
		{
			get
			{
				return this._Claim_ID;
			}
			set
			{
				if ((this._Claim_ID != value))
				{
					this.OnClaim_IDChanging(value);
					this.SendPropertyChanging();
					this._Claim_ID = value;
					this.SendPropertyChanged("Claim_ID");
					this.OnClaim_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Claim_FirstName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Claim_FirstName
		{
			get
			{
				return this._Claim_FirstName;
			}
			set
			{
				if ((this._Claim_FirstName != value))
				{
					this.OnClaim_FirstNameChanging(value);
					this.SendPropertyChanging();
					this._Claim_FirstName = value;
					this.SendPropertyChanged("Claim_FirstName");
					this.OnClaim_FirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Claim_LastName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Claim_LastName
		{
			get
			{
				return this._Claim_LastName;
			}
			set
			{
				if ((this._Claim_LastName != value))
				{
					this.OnClaim_LastNameChanging(value);
					this.SendPropertyChanging();
					this._Claim_LastName = value;
					this.SendPropertyChanged("Claim_LastName");
					this.OnClaim_LastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Claim_Role", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Claim_Role
		{
			get
			{
				return this._Claim_Role;
			}
			set
			{
				if ((this._Claim_Role != value))
				{
					this.OnClaim_RoleChanging(value);
					this.SendPropertyChanging();
					this._Claim_Role = value;
					this.SendPropertyChanged("Claim_Role");
					this.OnClaim_RoleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Claim_Date", DbType="DateTime")]
		public System.Nullable<System.DateTime> Claim_Date
		{
			get
			{
				return this._Claim_Date;
			}
			set
			{
				if ((this._Claim_Date != value))
				{
					this.OnClaim_DateChanging(value);
					this.SendPropertyChanging();
					this._Claim_Date = value;
					this.SendPropertyChanged("Claim_Date");
					this.OnClaim_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Staff_ID", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Staff_ID
		{
			get
			{
				return this._Staff_ID;
			}
			set
			{
				if ((this._Staff_ID != value))
				{
					if (this._Staff.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStaff_IDChanging(value);
					this.SendPropertyChanging();
					this._Staff_ID = value;
					this.SendPropertyChanged("Staff_ID");
					this.OnStaff_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Claim_Item", Storage="_Items", ThisKey="Claim_ID", OtherKey="Claim_ID")]
		public EntitySet<Item> Items
		{
			get
			{
				return this._Items;
			}
			set
			{
				this._Items.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Claim_Log", Storage="_Logs", ThisKey="Claim_ID", OtherKey="Claim_ID")]
		public EntitySet<Log> Logs
		{
			get
			{
				return this._Logs;
			}
			set
			{
				this._Logs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Staff_Claim", Storage="_Staff", ThisKey="Staff_ID", OtherKey="Staff_ID", IsForeignKey=true)]
		public Staff Staff
		{
			get
			{
				return this._Staff.Entity;
			}
			set
			{
				Staff previousValue = this._Staff.Entity;
				if (((previousValue != value) 
							|| (this._Staff.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Staff.Entity = null;
						previousValue.Claims.Remove(this);
					}
					this._Staff.Entity = value;
					if ((value != null))
					{
						value.Claims.Add(this);
						this._Staff_ID = value.Staff_ID;
					}
					else
					{
						this._Staff_ID = default(string);
					}
					this.SendPropertyChanged("Staff");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Items(Item entity)
		{
			this.SendPropertyChanging();
			entity.Claim = this;
		}
		
		private void detach_Items(Item entity)
		{
			this.SendPropertyChanging();
			entity.Claim = null;
		}
		
		private void attach_Logs(Log entity)
		{
			this.SendPropertyChanging();
			entity.Claim = this;
		}
		
		private void detach_Logs(Log entity)
		{
			this.SendPropertyChanging();
			entity.Claim = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Item")]
	public partial class Item : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Item_ID;
		
		private string _Item_Name;
		
		private string _Item_Color;
		
		private string _Item_Desc;
		
		private string _Item_Location;
		
		private string _Surrender_FirstName;
		
		private string _Surrender_LastName;
		
		private string _Surrender_Role;
		
		private System.DateTime _Surrender_Date;
		
		private string _Staff_ID;
		
		private string _Claim_ID;
		
		private string _Item_Status;
		
		private string _Item_Photo;
		
		private EntitySet<Log> _Logs;
		
		private EntityRef<Claim> _Claim;
		
		private EntityRef<Staff> _Staff;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnItem_IDChanging(string value);
    partial void OnItem_IDChanged();
    partial void OnItem_NameChanging(string value);
    partial void OnItem_NameChanged();
    partial void OnItem_ColorChanging(string value);
    partial void OnItem_ColorChanged();
    partial void OnItem_DescChanging(string value);
    partial void OnItem_DescChanged();
    partial void OnItem_LocationChanging(string value);
    partial void OnItem_LocationChanged();
    partial void OnSurrender_FirstNameChanging(string value);
    partial void OnSurrender_FirstNameChanged();
    partial void OnSurrender_LastNameChanging(string value);
    partial void OnSurrender_LastNameChanged();
    partial void OnSurrender_RoleChanging(string value);
    partial void OnSurrender_RoleChanged();
    partial void OnSurrender_DateChanging(System.DateTime value);
    partial void OnSurrender_DateChanged();
    partial void OnStaff_IDChanging(string value);
    partial void OnStaff_IDChanged();
    partial void OnClaim_IDChanging(string value);
    partial void OnClaim_IDChanged();
    partial void OnItem_StatusChanging(string value);
    partial void OnItem_StatusChanged();
    partial void OnItem_PhotoChanging(string value);
    partial void OnItem_PhotoChanged();
    #endregion
		
		public Item()
		{
			this._Logs = new EntitySet<Log>(new Action<Log>(this.attach_Logs), new Action<Log>(this.detach_Logs));
			this._Claim = default(EntityRef<Claim>);
			this._Staff = default(EntityRef<Staff>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Item_ID", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Item_ID
		{
			get
			{
				return this._Item_ID;
			}
			set
			{
				if ((this._Item_ID != value))
				{
					this.OnItem_IDChanging(value);
					this.SendPropertyChanging();
					this._Item_ID = value;
					this.SendPropertyChanged("Item_ID");
					this.OnItem_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Item_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Item_Name
		{
			get
			{
				return this._Item_Name;
			}
			set
			{
				if ((this._Item_Name != value))
				{
					this.OnItem_NameChanging(value);
					this.SendPropertyChanging();
					this._Item_Name = value;
					this.SendPropertyChanged("Item_Name");
					this.OnItem_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Item_Color", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Item_Color
		{
			get
			{
				return this._Item_Color;
			}
			set
			{
				if ((this._Item_Color != value))
				{
					this.OnItem_ColorChanging(value);
					this.SendPropertyChanging();
					this._Item_Color = value;
					this.SendPropertyChanged("Item_Color");
					this.OnItem_ColorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Item_Desc", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Item_Desc
		{
			get
			{
				return this._Item_Desc;
			}
			set
			{
				if ((this._Item_Desc != value))
				{
					this.OnItem_DescChanging(value);
					this.SendPropertyChanging();
					this._Item_Desc = value;
					this.SendPropertyChanged("Item_Desc");
					this.OnItem_DescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Item_Location", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Item_Location
		{
			get
			{
				return this._Item_Location;
			}
			set
			{
				if ((this._Item_Location != value))
				{
					this.OnItem_LocationChanging(value);
					this.SendPropertyChanging();
					this._Item_Location = value;
					this.SendPropertyChanged("Item_Location");
					this.OnItem_LocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surrender_FirstName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Surrender_FirstName
		{
			get
			{
				return this._Surrender_FirstName;
			}
			set
			{
				if ((this._Surrender_FirstName != value))
				{
					this.OnSurrender_FirstNameChanging(value);
					this.SendPropertyChanging();
					this._Surrender_FirstName = value;
					this.SendPropertyChanged("Surrender_FirstName");
					this.OnSurrender_FirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surrender_LastName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Surrender_LastName
		{
			get
			{
				return this._Surrender_LastName;
			}
			set
			{
				if ((this._Surrender_LastName != value))
				{
					this.OnSurrender_LastNameChanging(value);
					this.SendPropertyChanging();
					this._Surrender_LastName = value;
					this.SendPropertyChanged("Surrender_LastName");
					this.OnSurrender_LastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surrender_Role", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Surrender_Role
		{
			get
			{
				return this._Surrender_Role;
			}
			set
			{
				if ((this._Surrender_Role != value))
				{
					this.OnSurrender_RoleChanging(value);
					this.SendPropertyChanging();
					this._Surrender_Role = value;
					this.SendPropertyChanged("Surrender_Role");
					this.OnSurrender_RoleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surrender_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Surrender_Date
		{
			get
			{
				return this._Surrender_Date;
			}
			set
			{
				if ((this._Surrender_Date != value))
				{
					this.OnSurrender_DateChanging(value);
					this.SendPropertyChanging();
					this._Surrender_Date = value;
					this.SendPropertyChanged("Surrender_Date");
					this.OnSurrender_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Staff_ID", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Staff_ID
		{
			get
			{
				return this._Staff_ID;
			}
			set
			{
				if ((this._Staff_ID != value))
				{
					if (this._Staff.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStaff_IDChanging(value);
					this.SendPropertyChanging();
					this._Staff_ID = value;
					this.SendPropertyChanged("Staff_ID");
					this.OnStaff_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Claim_ID", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Claim_ID
		{
			get
			{
				return this._Claim_ID;
			}
			set
			{
				if ((this._Claim_ID != value))
				{
					if (this._Claim.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnClaim_IDChanging(value);
					this.SendPropertyChanging();
					this._Claim_ID = value;
					this.SendPropertyChanged("Claim_ID");
					this.OnClaim_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Item_Status", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Item_Status
		{
			get
			{
				return this._Item_Status;
			}
			set
			{
				if ((this._Item_Status != value))
				{
					this.OnItem_StatusChanging(value);
					this.SendPropertyChanging();
					this._Item_Status = value;
					this.SendPropertyChanged("Item_Status");
					this.OnItem_StatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Item_Photo", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Item_Photo
		{
			get
			{
				return this._Item_Photo;
			}
			set
			{
				if ((this._Item_Photo != value))
				{
					this.OnItem_PhotoChanging(value);
					this.SendPropertyChanging();
					this._Item_Photo = value;
					this.SendPropertyChanged("Item_Photo");
					this.OnItem_PhotoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Item_Log", Storage="_Logs", ThisKey="Item_ID", OtherKey="Item_ID")]
		public EntitySet<Log> Logs
		{
			get
			{
				return this._Logs;
			}
			set
			{
				this._Logs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Claim_Item", Storage="_Claim", ThisKey="Claim_ID", OtherKey="Claim_ID", IsForeignKey=true)]
		public Claim Claim
		{
			get
			{
				return this._Claim.Entity;
			}
			set
			{
				Claim previousValue = this._Claim.Entity;
				if (((previousValue != value) 
							|| (this._Claim.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Claim.Entity = null;
						previousValue.Items.Remove(this);
					}
					this._Claim.Entity = value;
					if ((value != null))
					{
						value.Items.Add(this);
						this._Claim_ID = value.Claim_ID;
					}
					else
					{
						this._Claim_ID = default(string);
					}
					this.SendPropertyChanged("Claim");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Staff_Item", Storage="_Staff", ThisKey="Staff_ID", OtherKey="Staff_ID", IsForeignKey=true)]
		public Staff Staff
		{
			get
			{
				return this._Staff.Entity;
			}
			set
			{
				Staff previousValue = this._Staff.Entity;
				if (((previousValue != value) 
							|| (this._Staff.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Staff.Entity = null;
						previousValue.Items.Remove(this);
					}
					this._Staff.Entity = value;
					if ((value != null))
					{
						value.Items.Add(this);
						this._Staff_ID = value.Staff_ID;
					}
					else
					{
						this._Staff_ID = default(string);
					}
					this.SendPropertyChanged("Staff");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Logs(Log entity)
		{
			this.SendPropertyChanging();
			entity.Item = this;
		}
		
		private void detach_Logs(Log entity)
		{
			this.SendPropertyChanging();
			entity.Item = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Logs")]
	public partial class Log : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Logs_ID;
		
		private System.DateTime _Logs_Date;
		
		private string _Logs_Desc;
		
		private string _Item_ID;
		
		private string _Claim_ID;
		
		private string _Staff_ID;
		
		private EntityRef<Claim> _Claim;
		
		private EntityRef<Item> _Item;
		
		private EntityRef<Staff> _Staff;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLogs_IDChanging(int value);
    partial void OnLogs_IDChanged();
    partial void OnLogs_DateChanging(System.DateTime value);
    partial void OnLogs_DateChanged();
    partial void OnLogs_DescChanging(string value);
    partial void OnLogs_DescChanged();
    partial void OnItem_IDChanging(string value);
    partial void OnItem_IDChanged();
    partial void OnClaim_IDChanging(string value);
    partial void OnClaim_IDChanged();
    partial void OnStaff_IDChanging(string value);
    partial void OnStaff_IDChanged();
    #endregion
		
		public Log()
		{
			this._Claim = default(EntityRef<Claim>);
			this._Item = default(EntityRef<Item>);
			this._Staff = default(EntityRef<Staff>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Logs_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Logs_ID
		{
			get
			{
				return this._Logs_ID;
			}
			set
			{
				if ((this._Logs_ID != value))
				{
					this.OnLogs_IDChanging(value);
					this.SendPropertyChanging();
					this._Logs_ID = value;
					this.SendPropertyChanged("Logs_ID");
					this.OnLogs_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Logs_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Logs_Date
		{
			get
			{
				return this._Logs_Date;
			}
			set
			{
				if ((this._Logs_Date != value))
				{
					this.OnLogs_DateChanging(value);
					this.SendPropertyChanging();
					this._Logs_Date = value;
					this.SendPropertyChanged("Logs_Date");
					this.OnLogs_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Logs_Desc", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Logs_Desc
		{
			get
			{
				return this._Logs_Desc;
			}
			set
			{
				if ((this._Logs_Desc != value))
				{
					this.OnLogs_DescChanging(value);
					this.SendPropertyChanging();
					this._Logs_Desc = value;
					this.SendPropertyChanged("Logs_Desc");
					this.OnLogs_DescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Item_ID", DbType="VarChar(50)")]
		public string Item_ID
		{
			get
			{
				return this._Item_ID;
			}
			set
			{
				if ((this._Item_ID != value))
				{
					if (this._Item.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnItem_IDChanging(value);
					this.SendPropertyChanging();
					this._Item_ID = value;
					this.SendPropertyChanged("Item_ID");
					this.OnItem_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Claim_ID", DbType="VarChar(50)")]
		public string Claim_ID
		{
			get
			{
				return this._Claim_ID;
			}
			set
			{
				if ((this._Claim_ID != value))
				{
					if (this._Claim.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnClaim_IDChanging(value);
					this.SendPropertyChanging();
					this._Claim_ID = value;
					this.SendPropertyChanged("Claim_ID");
					this.OnClaim_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Staff_ID", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Staff_ID
		{
			get
			{
				return this._Staff_ID;
			}
			set
			{
				if ((this._Staff_ID != value))
				{
					if (this._Staff.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStaff_IDChanging(value);
					this.SendPropertyChanging();
					this._Staff_ID = value;
					this.SendPropertyChanged("Staff_ID");
					this.OnStaff_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Claim_Log", Storage="_Claim", ThisKey="Claim_ID", OtherKey="Claim_ID", IsForeignKey=true)]
		public Claim Claim
		{
			get
			{
				return this._Claim.Entity;
			}
			set
			{
				Claim previousValue = this._Claim.Entity;
				if (((previousValue != value) 
							|| (this._Claim.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Claim.Entity = null;
						previousValue.Logs.Remove(this);
					}
					this._Claim.Entity = value;
					if ((value != null))
					{
						value.Logs.Add(this);
						this._Claim_ID = value.Claim_ID;
					}
					else
					{
						this._Claim_ID = default(string);
					}
					this.SendPropertyChanged("Claim");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Item_Log", Storage="_Item", ThisKey="Item_ID", OtherKey="Item_ID", IsForeignKey=true)]
		public Item Item
		{
			get
			{
				return this._Item.Entity;
			}
			set
			{
				Item previousValue = this._Item.Entity;
				if (((previousValue != value) 
							|| (this._Item.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Item.Entity = null;
						previousValue.Logs.Remove(this);
					}
					this._Item.Entity = value;
					if ((value != null))
					{
						value.Logs.Add(this);
						this._Item_ID = value.Item_ID;
					}
					else
					{
						this._Item_ID = default(string);
					}
					this.SendPropertyChanged("Item");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Staff_Log", Storage="_Staff", ThisKey="Staff_ID", OtherKey="Staff_ID", IsForeignKey=true)]
		public Staff Staff
		{
			get
			{
				return this._Staff.Entity;
			}
			set
			{
				Staff previousValue = this._Staff.Entity;
				if (((previousValue != value) 
							|| (this._Staff.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Staff.Entity = null;
						previousValue.Logs.Remove(this);
					}
					this._Staff.Entity = value;
					if ((value != null))
					{
						value.Logs.Add(this);
						this._Staff_ID = value.Staff_ID;
					}
					else
					{
						this._Staff_ID = default(string);
					}
					this.SendPropertyChanged("Staff");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Staff")]
	public partial class Staff : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Staff_ID;
		
		private string _Staff_FirstName;
		
		private string _Staff_LastName;
		
		private string _StaffRole_ID;
		
		private string _Staff_Status;
		
		private string _Staff_Password;
		
		private EntitySet<Claim> _Claims;
		
		private EntitySet<Item> _Items;
		
		private EntitySet<Log> _Logs;
		
		private EntityRef<StaffRole> _StaffRole;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnStaff_IDChanging(string value);
    partial void OnStaff_IDChanged();
    partial void OnStaff_FirstNameChanging(string value);
    partial void OnStaff_FirstNameChanged();
    partial void OnStaff_LastNameChanging(string value);
    partial void OnStaff_LastNameChanged();
    partial void OnStaffRole_IDChanging(string value);
    partial void OnStaffRole_IDChanged();
    partial void OnStaff_StatusChanging(string value);
    partial void OnStaff_StatusChanged();
    partial void OnStaff_PasswordChanging(string value);
    partial void OnStaff_PasswordChanged();
    #endregion
		
		public Staff()
		{
			this._Claims = new EntitySet<Claim>(new Action<Claim>(this.attach_Claims), new Action<Claim>(this.detach_Claims));
			this._Items = new EntitySet<Item>(new Action<Item>(this.attach_Items), new Action<Item>(this.detach_Items));
			this._Logs = new EntitySet<Log>(new Action<Log>(this.attach_Logs), new Action<Log>(this.detach_Logs));
			this._StaffRole = default(EntityRef<StaffRole>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Staff_ID", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Staff_ID
		{
			get
			{
				return this._Staff_ID;
			}
			set
			{
				if ((this._Staff_ID != value))
				{
					this.OnStaff_IDChanging(value);
					this.SendPropertyChanging();
					this._Staff_ID = value;
					this.SendPropertyChanged("Staff_ID");
					this.OnStaff_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Staff_FirstName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Staff_FirstName
		{
			get
			{
				return this._Staff_FirstName;
			}
			set
			{
				if ((this._Staff_FirstName != value))
				{
					this.OnStaff_FirstNameChanging(value);
					this.SendPropertyChanging();
					this._Staff_FirstName = value;
					this.SendPropertyChanged("Staff_FirstName");
					this.OnStaff_FirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Staff_LastName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Staff_LastName
		{
			get
			{
				return this._Staff_LastName;
			}
			set
			{
				if ((this._Staff_LastName != value))
				{
					this.OnStaff_LastNameChanging(value);
					this.SendPropertyChanging();
					this._Staff_LastName = value;
					this.SendPropertyChanged("Staff_LastName");
					this.OnStaff_LastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StaffRole_ID", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string StaffRole_ID
		{
			get
			{
				return this._StaffRole_ID;
			}
			set
			{
				if ((this._StaffRole_ID != value))
				{
					if (this._StaffRole.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStaffRole_IDChanging(value);
					this.SendPropertyChanging();
					this._StaffRole_ID = value;
					this.SendPropertyChanged("StaffRole_ID");
					this.OnStaffRole_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Staff_Status", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Staff_Status
		{
			get
			{
				return this._Staff_Status;
			}
			set
			{
				if ((this._Staff_Status != value))
				{
					this.OnStaff_StatusChanging(value);
					this.SendPropertyChanging();
					this._Staff_Status = value;
					this.SendPropertyChanged("Staff_Status");
					this.OnStaff_StatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Staff_Password", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Staff_Password
		{
			get
			{
				return this._Staff_Password;
			}
			set
			{
				if ((this._Staff_Password != value))
				{
					this.OnStaff_PasswordChanging(value);
					this.SendPropertyChanging();
					this._Staff_Password = value;
					this.SendPropertyChanged("Staff_Password");
					this.OnStaff_PasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Staff_Claim", Storage="_Claims", ThisKey="Staff_ID", OtherKey="Staff_ID")]
		public EntitySet<Claim> Claims
		{
			get
			{
				return this._Claims;
			}
			set
			{
				this._Claims.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Staff_Item", Storage="_Items", ThisKey="Staff_ID", OtherKey="Staff_ID")]
		public EntitySet<Item> Items
		{
			get
			{
				return this._Items;
			}
			set
			{
				this._Items.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Staff_Log", Storage="_Logs", ThisKey="Staff_ID", OtherKey="Staff_ID")]
		public EntitySet<Log> Logs
		{
			get
			{
				return this._Logs;
			}
			set
			{
				this._Logs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="StaffRole_Staff", Storage="_StaffRole", ThisKey="StaffRole_ID", OtherKey="StaffRole_ID", IsForeignKey=true)]
		public StaffRole StaffRole
		{
			get
			{
				return this._StaffRole.Entity;
			}
			set
			{
				StaffRole previousValue = this._StaffRole.Entity;
				if (((previousValue != value) 
							|| (this._StaffRole.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._StaffRole.Entity = null;
						previousValue.Staffs.Remove(this);
					}
					this._StaffRole.Entity = value;
					if ((value != null))
					{
						value.Staffs.Add(this);
						this._StaffRole_ID = value.StaffRole_ID;
					}
					else
					{
						this._StaffRole_ID = default(string);
					}
					this.SendPropertyChanged("StaffRole");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Claims(Claim entity)
		{
			this.SendPropertyChanging();
			entity.Staff = this;
		}
		
		private void detach_Claims(Claim entity)
		{
			this.SendPropertyChanging();
			entity.Staff = null;
		}
		
		private void attach_Items(Item entity)
		{
			this.SendPropertyChanging();
			entity.Staff = this;
		}
		
		private void detach_Items(Item entity)
		{
			this.SendPropertyChanging();
			entity.Staff = null;
		}
		
		private void attach_Logs(Log entity)
		{
			this.SendPropertyChanging();
			entity.Staff = this;
		}
		
		private void detach_Logs(Log entity)
		{
			this.SendPropertyChanging();
			entity.Staff = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StaffRole")]
	public partial class StaffRole : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _StaffRole_ID;
		
		private string _StaffRole_Desc;
		
		private EntitySet<Staff> _Staffs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnStaffRole_IDChanging(string value);
    partial void OnStaffRole_IDChanged();
    partial void OnStaffRole_DescChanging(string value);
    partial void OnStaffRole_DescChanged();
    #endregion
		
		public StaffRole()
		{
			this._Staffs = new EntitySet<Staff>(new Action<Staff>(this.attach_Staffs), new Action<Staff>(this.detach_Staffs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StaffRole_ID", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string StaffRole_ID
		{
			get
			{
				return this._StaffRole_ID;
			}
			set
			{
				if ((this._StaffRole_ID != value))
				{
					this.OnStaffRole_IDChanging(value);
					this.SendPropertyChanging();
					this._StaffRole_ID = value;
					this.SendPropertyChanged("StaffRole_ID");
					this.OnStaffRole_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StaffRole_Desc", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string StaffRole_Desc
		{
			get
			{
				return this._StaffRole_Desc;
			}
			set
			{
				if ((this._StaffRole_Desc != value))
				{
					this.OnStaffRole_DescChanging(value);
					this.SendPropertyChanging();
					this._StaffRole_Desc = value;
					this.SendPropertyChanged("StaffRole_Desc");
					this.OnStaffRole_DescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="StaffRole_Staff", Storage="_Staffs", ThisKey="StaffRole_ID", OtherKey="StaffRole_ID")]
		public EntitySet<Staff> Staffs
		{
			get
			{
				return this._Staffs;
			}
			set
			{
				this._Staffs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Staffs(Staff entity)
		{
			this.SendPropertyChanging();
			entity.StaffRole = this;
		}
		
		private void detach_Staffs(Staff entity)
		{
			this.SendPropertyChanging();
			entity.StaffRole = null;
		}
	}
}
#pragma warning restore 1591
