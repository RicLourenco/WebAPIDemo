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

namespace WebAPIDemo
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
    using Newtonsoft.Json;

    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DemoVideoClube")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertcategoria(categoria instance);
    partial void Updatecategoria(categoria instance);
    partial void Deletecategoria(categoria instance);
    partial void Insertfilme(filme instance);
    partial void Updatefilme(filme instance);
    partial void Deletefilme(filme instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DemoVideoClubeConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<categoria> categorias
		{
			get
			{
				return this.GetTable<categoria>();
			}
		}
		
		public System.Data.Linq.Table<filme> filmes
		{
			get
			{
				return this.GetTable<filme>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.categorias")]
	public partial class categoria : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _sigla;
		
		private string _categoria1;
		
		private EntitySet<filme> _filmes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnsiglaChanging(string value);
    partial void OnsiglaChanged();
    partial void Oncategoria1Changing(string value);
    partial void Oncategoria1Changed();
    #endregion
		
		public categoria()
		{
			this._filmes = new EntitySet<filme>(new Action<filme>(this.attach_filmes), new Action<filme>(this.detach_filmes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sigla", DbType="VarChar(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string sigla
		{
			get
			{
				return this._sigla;
			}
			set
			{
				if ((this._sigla != value))
				{
					this.OnsiglaChanging(value);
					this.SendPropertyChanging();
					this._sigla = value;
					this.SendPropertyChanged("sigla");
					this.OnsiglaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="categoria", Storage="_categoria1", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string categoria1
		{
			get
			{
				return this._categoria1;
			}
			set
			{
				if ((this._categoria1 != value))
				{
					this.Oncategoria1Changing(value);
					this.SendPropertyChanging();
					this._categoria1 = value;
					this.SendPropertyChanged("categoria1");
					this.Oncategoria1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="categoria_filme", Storage="_filmes", ThisKey="sigla", OtherKey="categoria")]
		[JsonIgnore]
		public EntitySet<filme> filmes
		{
			get
			{
				return this._filmes;
			}
			set
			{
				this._filmes.Assign(value);
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
		
		private void attach_filmes(filme entity)
		{
			this.SendPropertyChanging();
			entity.categoria1 = this;
		}
		
		private void detach_filmes(filme entity)
		{
			this.SendPropertyChanging();
			entity.categoria1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.filme")]
	public partial class filme : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _titulo;
		
		private string _categoria;
		
		private EntityRef<categoria> _categoria1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OntituloChanging(string value);
    partial void OntituloChanged();
    partial void OncategoriaChanging(string value);
    partial void OncategoriaChanged();
    #endregion
		
		public filme()
		{
			this._categoria1 = default(EntityRef<categoria>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_titulo", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string titulo
		{
			get
			{
				return this._titulo;
			}
			set
			{
				if ((this._titulo != value))
				{
					this.OntituloChanging(value);
					this.SendPropertyChanging();
					this._titulo = value;
					this.SendPropertyChanged("titulo");
					this.OntituloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_categoria", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string categoria
		{
			get
			{
				return this._categoria;
			}
			set
			{
				if ((this._categoria != value))
				{
					if (this._categoria1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncategoriaChanging(value);
					this.SendPropertyChanging();
					this._categoria = value;
					this.SendPropertyChanged("categoria");
					this.OncategoriaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="categoria_filme", Storage="_categoria1", ThisKey="categoria", OtherKey="sigla", IsForeignKey=true)]
		[JsonIgnore]
		public categoria categoria1
		{
			get
			{
				return this._categoria1.Entity;
			}
			set
			{
				categoria previousValue = this._categoria1.Entity;
				if (((previousValue != value) 
							|| (this._categoria1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._categoria1.Entity = null;
						previousValue.filmes.Remove(this);
					}
					this._categoria1.Entity = value;
					if ((value != null))
					{
						value.filmes.Add(this);
						this._categoria = value.sigla;
					}
					else
					{
						this._categoria = default(string);
					}
					this.SendPropertyChanged("categoria1");
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
}
#pragma warning restore 1591
