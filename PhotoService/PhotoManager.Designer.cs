﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace PhotoService
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class PhotoManagerEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new PhotoManagerEntities object using the connection string found in the 'PhotoManagerEntities' section of the application configuration file.
        /// </summary>
        public PhotoManagerEntities() : base("name=PhotoManagerEntities", "PhotoManagerEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new PhotoManagerEntities object.
        /// </summary>
        public PhotoManagerEntities(string connectionString) : base(connectionString, "PhotoManagerEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new PhotoManagerEntities object.
        /// </summary>
        public PhotoManagerEntities(EntityConnection connection) : base(connection, "PhotoManagerEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Photo> Photos
        {
            get
            {
                if ((_Photos == null))
                {
                    _Photos = base.CreateObjectSet<Photo>("Photos");
                }
                return _Photos;
            }
        }
        private ObjectSet<Photo> _Photos;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Photos EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPhotos(Photo photo)
        {
            base.AddObject("Photos", photo);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PhotoManagerModel", Name="Photo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Photo : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Photo object.
        /// </summary>
        /// <param name="photoID">Initial value of the PhotoID property.</param>
        /// <param name="data">Initial value of the Data property.</param>
        /// <param name="dateTime">Initial value of the DateTime property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static Photo CreatePhoto(global::System.Int32 photoID, global::System.Byte[] data, global::System.DateTime dateTime, global::System.String name)
        {
            Photo photo = new Photo();
            photo.PhotoID = photoID;
            photo.Data = data;
            photo.DateTime = dateTime;
            photo.Name = name;
            return photo;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PhotoID
        {
            get
            {
                return _PhotoID;
            }
            set
            {
                if (_PhotoID != value)
                {
                    OnPhotoIDChanging(value);
                    ReportPropertyChanging("PhotoID");
                    _PhotoID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PhotoID");
                    OnPhotoIDChanged();
                }
            }
        }
        private global::System.Int32 _PhotoID;
        partial void OnPhotoIDChanging(global::System.Int32 value);
        partial void OnPhotoIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte[] Data
        {
            get
            {
                return StructuralObject.GetValidValue(_Data);
            }
            set
            {
                OnDataChanging(value);
                ReportPropertyChanging("Data");
                _Data = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Data");
                OnDataChanged();
            }
        }
        private global::System.Byte[] _Data;
        partial void OnDataChanging(global::System.Byte[] value);
        partial void OnDataChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateTime
        {
            get
            {
                return _DateTime;
            }
            set
            {
                OnDateTimeChanging(value);
                ReportPropertyChanging("DateTime");
                _DateTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateTime");
                OnDateTimeChanged();
            }
        }
        private global::System.DateTime _DateTime;
        partial void OnDateTimeChanging(global::System.DateTime value);
        partial void OnDateTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();

        #endregion

    
    }

    #endregion

    
}
