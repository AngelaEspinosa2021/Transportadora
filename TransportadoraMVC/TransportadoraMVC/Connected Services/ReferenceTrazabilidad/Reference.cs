﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransportadoraMVC.ReferenceTrazabilidad {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Trazabilidad", Namespace="http://schemas.datacontract.org/2004/07/TranspService.Modelos")]
    [System.SerializableAttribute()]
    public partial class Trazabilidad : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CiudadDesstinoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CiudadOrigenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TransportadoraMVC.ReferenceTrazabilidad.Embarque EmbarqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> IdEmbarqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> KilosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PaisDestinoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PaisOrigenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> TeusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoOperacionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CiudadDesstino {
            get {
                return this.CiudadDesstinoField;
            }
            set {
                if ((object.ReferenceEquals(this.CiudadDesstinoField, value) != true)) {
                    this.CiudadDesstinoField = value;
                    this.RaisePropertyChanged("CiudadDesstino");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CiudadOrigen {
            get {
                return this.CiudadOrigenField;
            }
            set {
                if ((object.ReferenceEquals(this.CiudadOrigenField, value) != true)) {
                    this.CiudadOrigenField = value;
                    this.RaisePropertyChanged("CiudadOrigen");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TransportadoraMVC.ReferenceTrazabilidad.Embarque Embarque {
            get {
                return this.EmbarqueField;
            }
            set {
                if ((object.ReferenceEquals(this.EmbarqueField, value) != true)) {
                    this.EmbarqueField = value;
                    this.RaisePropertyChanged("Embarque");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> IdEmbarque {
            get {
                return this.IdEmbarqueField;
            }
            set {
                if ((this.IdEmbarqueField.Equals(value) != true)) {
                    this.IdEmbarqueField = value;
                    this.RaisePropertyChanged("IdEmbarque");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Kilos {
            get {
                return this.KilosField;
            }
            set {
                if ((this.KilosField.Equals(value) != true)) {
                    this.KilosField = value;
                    this.RaisePropertyChanged("Kilos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PaisDestino {
            get {
                return this.PaisDestinoField;
            }
            set {
                if ((object.ReferenceEquals(this.PaisDestinoField, value) != true)) {
                    this.PaisDestinoField = value;
                    this.RaisePropertyChanged("PaisDestino");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PaisOrigen {
            get {
                return this.PaisOrigenField;
            }
            set {
                if ((object.ReferenceEquals(this.PaisOrigenField, value) != true)) {
                    this.PaisOrigenField = value;
                    this.RaisePropertyChanged("PaisOrigen");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Teus {
            get {
                return this.TeusField;
            }
            set {
                if ((this.TeusField.Equals(value) != true)) {
                    this.TeusField = value;
                    this.RaisePropertyChanged("Teus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoOperacion {
            get {
                return this.TipoOperacionField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoOperacionField, value) != true)) {
                    this.TipoOperacionField = value;
                    this.RaisePropertyChanged("TipoOperacion");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Embarque", Namespace="http://schemas.datacontract.org/2004/07/TranspService.Modelos")]
    [System.SerializableAttribute()]
    public partial class Embarque : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ConsignatarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContactoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContenedorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DestinoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DireccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmbarqueAereoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmbarqueMaritimoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FaxField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string INCOTERMField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ObservacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrdenCompraField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrigenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad[] TrazabilidadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ZonaAduaneraField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Consignatario {
            get {
                return this.ConsignatarioField;
            }
            set {
                if ((object.ReferenceEquals(this.ConsignatarioField, value) != true)) {
                    this.ConsignatarioField = value;
                    this.RaisePropertyChanged("Consignatario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contacto {
            get {
                return this.ContactoField;
            }
            set {
                if ((object.ReferenceEquals(this.ContactoField, value) != true)) {
                    this.ContactoField = value;
                    this.RaisePropertyChanged("Contacto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contenedor {
            get {
                return this.ContenedorField;
            }
            set {
                if ((object.ReferenceEquals(this.ContenedorField, value) != true)) {
                    this.ContenedorField = value;
                    this.RaisePropertyChanged("Contenedor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Destino {
            get {
                return this.DestinoField;
            }
            set {
                if ((object.ReferenceEquals(this.DestinoField, value) != true)) {
                    this.DestinoField = value;
                    this.RaisePropertyChanged("Destino");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Direccion {
            get {
                return this.DireccionField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionField, value) != true)) {
                    this.DireccionField = value;
                    this.RaisePropertyChanged("Direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmbarqueAereo {
            get {
                return this.EmbarqueAereoField;
            }
            set {
                if ((object.ReferenceEquals(this.EmbarqueAereoField, value) != true)) {
                    this.EmbarqueAereoField = value;
                    this.RaisePropertyChanged("EmbarqueAereo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmbarqueMaritimo {
            get {
                return this.EmbarqueMaritimoField;
            }
            set {
                if ((object.ReferenceEquals(this.EmbarqueMaritimoField, value) != true)) {
                    this.EmbarqueMaritimoField = value;
                    this.RaisePropertyChanged("EmbarqueMaritimo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Fax {
            get {
                return this.FaxField;
            }
            set {
                if ((object.ReferenceEquals(this.FaxField, value) != true)) {
                    this.FaxField = value;
                    this.RaisePropertyChanged("Fax");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string INCOTERM {
            get {
                return this.INCOTERMField;
            }
            set {
                if ((object.ReferenceEquals(this.INCOTERMField, value) != true)) {
                    this.INCOTERMField = value;
                    this.RaisePropertyChanged("INCOTERM");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Observacion {
            get {
                return this.ObservacionField;
            }
            set {
                if ((object.ReferenceEquals(this.ObservacionField, value) != true)) {
                    this.ObservacionField = value;
                    this.RaisePropertyChanged("Observacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrdenCompra {
            get {
                return this.OrdenCompraField;
            }
            set {
                if ((object.ReferenceEquals(this.OrdenCompraField, value) != true)) {
                    this.OrdenCompraField = value;
                    this.RaisePropertyChanged("OrdenCompra");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Origen {
            get {
                return this.OrigenField;
            }
            set {
                if ((object.ReferenceEquals(this.OrigenField, value) != true)) {
                    this.OrigenField = value;
                    this.RaisePropertyChanged("Origen");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad[] Trazabilidad {
            get {
                return this.TrazabilidadField;
            }
            set {
                if ((object.ReferenceEquals(this.TrazabilidadField, value) != true)) {
                    this.TrazabilidadField = value;
                    this.RaisePropertyChanged("Trazabilidad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ZonaAduanera {
            get {
                return this.ZonaAduaneraField;
            }
            set {
                if ((object.ReferenceEquals(this.ZonaAduaneraField, value) != true)) {
                    this.ZonaAduaneraField = value;
                    this.RaisePropertyChanged("ZonaAduanera");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReferenceTrazabilidad.IServiceTrazabilidad")]
    public interface IServiceTrazabilidad {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTrazabilidad/ListarTrazabilidad", ReplyAction="http://tempuri.org/IServiceTrazabilidad/ListarTrazabilidadResponse")]
        TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad[] ListarTrazabilidad();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTrazabilidad/ListarTrazabilidad", ReplyAction="http://tempuri.org/IServiceTrazabilidad/ListarTrazabilidadResponse")]
        System.Threading.Tasks.Task<TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad[]> ListarTrazabilidadAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTrazabilidad/AgregarTrazabilidad", ReplyAction="http://tempuri.org/IServiceTrazabilidad/AgregarTrazabilidadResponse")]
        void AgregarTrazabilidad(TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad tra);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTrazabilidad/AgregarTrazabilidad", ReplyAction="http://tempuri.org/IServiceTrazabilidad/AgregarTrazabilidadResponse")]
        System.Threading.Tasks.Task AgregarTrazabilidadAsync(TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad tra);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTrazabilidad/EditarTrazabilidad", ReplyAction="http://tempuri.org/IServiceTrazabilidad/EditarTrazabilidadResponse")]
        void EditarTrazabilidad(long Id, TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad tra);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTrazabilidad/EditarTrazabilidad", ReplyAction="http://tempuri.org/IServiceTrazabilidad/EditarTrazabilidadResponse")]
        System.Threading.Tasks.Task EditarTrazabilidadAsync(long Id, TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad tra);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTrazabilidad/EliminarTrazabilidad", ReplyAction="http://tempuri.org/IServiceTrazabilidad/EliminarTrazabilidadResponse")]
        void EliminarTrazabilidad(long Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTrazabilidad/EliminarTrazabilidad", ReplyAction="http://tempuri.org/IServiceTrazabilidad/EliminarTrazabilidadResponse")]
        System.Threading.Tasks.Task EliminarTrazabilidadAsync(long Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTrazabilidad/BuscarTrazabilidad", ReplyAction="http://tempuri.org/IServiceTrazabilidad/BuscarTrazabilidadResponse")]
        TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad BuscarTrazabilidad(long Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTrazabilidad/BuscarTrazabilidad", ReplyAction="http://tempuri.org/IServiceTrazabilidad/BuscarTrazabilidadResponse")]
        System.Threading.Tasks.Task<TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad> BuscarTrazabilidadAsync(long Id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceTrazabilidadChannel : TransportadoraMVC.ReferenceTrazabilidad.IServiceTrazabilidad, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceTrazabilidadClient : System.ServiceModel.ClientBase<TransportadoraMVC.ReferenceTrazabilidad.IServiceTrazabilidad>, TransportadoraMVC.ReferenceTrazabilidad.IServiceTrazabilidad {
        
        public ServiceTrazabilidadClient() {
        }
        
        public ServiceTrazabilidadClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceTrazabilidadClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceTrazabilidadClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceTrazabilidadClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad[] ListarTrazabilidad() {
            return base.Channel.ListarTrazabilidad();
        }
        
        public System.Threading.Tasks.Task<TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad[]> ListarTrazabilidadAsync() {
            return base.Channel.ListarTrazabilidadAsync();
        }
        
        public void AgregarTrazabilidad(TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad tra) {
            base.Channel.AgregarTrazabilidad(tra);
        }
        
        public System.Threading.Tasks.Task AgregarTrazabilidadAsync(TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad tra) {
            return base.Channel.AgregarTrazabilidadAsync(tra);
        }
        
        public void EditarTrazabilidad(long Id, TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad tra) {
            base.Channel.EditarTrazabilidad(Id, tra);
        }
        
        public System.Threading.Tasks.Task EditarTrazabilidadAsync(long Id, TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad tra) {
            return base.Channel.EditarTrazabilidadAsync(Id, tra);
        }
        
        public void EliminarTrazabilidad(long Id) {
            base.Channel.EliminarTrazabilidad(Id);
        }
        
        public System.Threading.Tasks.Task EliminarTrazabilidadAsync(long Id) {
            return base.Channel.EliminarTrazabilidadAsync(Id);
        }
        
        public TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad BuscarTrazabilidad(long Id) {
            return base.Channel.BuscarTrazabilidad(Id);
        }
        
        public System.Threading.Tasks.Task<TransportadoraMVC.ReferenceTrazabilidad.Trazabilidad> BuscarTrazabilidadAsync(long Id) {
            return base.Channel.BuscarTrazabilidadAsync(Id);
        }
    }
}
