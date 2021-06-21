﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransportadoraMVC.MonedaReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Moneda", Namespace="http://schemas.datacontract.org/2004/07/TransportadoraService.Models")]
    [System.SerializableAttribute()]
    public partial class Moneda : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> FechaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> ValorField;
        
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
        public string Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoField, value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Fecha {
            get {
                return this.FechaField;
            }
            set {
                if ((this.FechaField.Equals(value) != true)) {
                    this.FechaField = value;
                    this.RaisePropertyChanged("Fecha");
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
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Valor {
            get {
                return this.ValorField;
            }
            set {
                if ((this.ValorField.Equals(value) != true)) {
                    this.ValorField = value;
                    this.RaisePropertyChanged("Valor");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MonedaReference.IMonedaService")]
    public interface IMonedaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/ListarMonedas", ReplyAction="http://tempuri.org/IMonedaService/ListarMonedasResponse")]
        TransportadoraMVC.MonedaReference.Moneda[] ListarMonedas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/ListarMonedas", ReplyAction="http://tempuri.org/IMonedaService/ListarMonedasResponse")]
        System.Threading.Tasks.Task<TransportadoraMVC.MonedaReference.Moneda[]> ListarMonedasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/BuscarMoneda", ReplyAction="http://tempuri.org/IMonedaService/BuscarMonedaResponse")]
        TransportadoraMVC.MonedaReference.Moneda BuscarMoneda(long Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/BuscarMoneda", ReplyAction="http://tempuri.org/IMonedaService/BuscarMonedaResponse")]
        System.Threading.Tasks.Task<TransportadoraMVC.MonedaReference.Moneda> BuscarMonedaAsync(long Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/AgregarMoneda", ReplyAction="http://tempuri.org/IMonedaService/AgregarMonedaResponse")]
        void AgregarMoneda(TransportadoraMVC.MonedaReference.Moneda moneda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/AgregarMoneda", ReplyAction="http://tempuri.org/IMonedaService/AgregarMonedaResponse")]
        System.Threading.Tasks.Task AgregarMonedaAsync(TransportadoraMVC.MonedaReference.Moneda moneda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/EditarMoneda", ReplyAction="http://tempuri.org/IMonedaService/EditarMonedaResponse")]
        void EditarMoneda(long Id, TransportadoraMVC.MonedaReference.Moneda moneda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/EditarMoneda", ReplyAction="http://tempuri.org/IMonedaService/EditarMonedaResponse")]
        System.Threading.Tasks.Task EditarMonedaAsync(long Id, TransportadoraMVC.MonedaReference.Moneda moneda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/EliminarMoneda", ReplyAction="http://tempuri.org/IMonedaService/EliminarMonedaResponse")]
        void EliminarMoneda(long Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/EliminarMoneda", ReplyAction="http://tempuri.org/IMonedaService/EliminarMonedaResponse")]
        System.Threading.Tasks.Task EliminarMonedaAsync(long Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/Confirmacion", ReplyAction="http://tempuri.org/IMonedaService/ConfirmacionResponse")]
        void Confirmacion(long Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonedaService/Confirmacion", ReplyAction="http://tempuri.org/IMonedaService/ConfirmacionResponse")]
        System.Threading.Tasks.Task ConfirmacionAsync(long Id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMonedaServiceChannel : TransportadoraMVC.MonedaReference.IMonedaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MonedaServiceClient : System.ServiceModel.ClientBase<TransportadoraMVC.MonedaReference.IMonedaService>, TransportadoraMVC.MonedaReference.IMonedaService {
        
        public MonedaServiceClient() {
        }
        
        public MonedaServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MonedaServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MonedaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MonedaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TransportadoraMVC.MonedaReference.Moneda[] ListarMonedas() {
            return base.Channel.ListarMonedas();
        }
        
        public System.Threading.Tasks.Task<TransportadoraMVC.MonedaReference.Moneda[]> ListarMonedasAsync() {
            return base.Channel.ListarMonedasAsync();
        }
        
        public TransportadoraMVC.MonedaReference.Moneda BuscarMoneda(long Id) {
            return base.Channel.BuscarMoneda(Id);
        }
        
        public System.Threading.Tasks.Task<TransportadoraMVC.MonedaReference.Moneda> BuscarMonedaAsync(long Id) {
            return base.Channel.BuscarMonedaAsync(Id);
        }
        
        public void AgregarMoneda(TransportadoraMVC.MonedaReference.Moneda moneda) {
            base.Channel.AgregarMoneda(moneda);
        }
        
        public System.Threading.Tasks.Task AgregarMonedaAsync(TransportadoraMVC.MonedaReference.Moneda moneda) {
            return base.Channel.AgregarMonedaAsync(moneda);
        }
        
        public void EditarMoneda(long Id, TransportadoraMVC.MonedaReference.Moneda moneda) {
            base.Channel.EditarMoneda(Id, moneda);
        }
        
        public System.Threading.Tasks.Task EditarMonedaAsync(long Id, TransportadoraMVC.MonedaReference.Moneda moneda) {
            return base.Channel.EditarMonedaAsync(Id, moneda);
        }
        
        public void EliminarMoneda(long Id) {
            base.Channel.EliminarMoneda(Id);
        }
        
        public System.Threading.Tasks.Task EliminarMonedaAsync(long Id) {
            return base.Channel.EliminarMonedaAsync(Id);
        }
        
        public void Confirmacion(long Id) {
            base.Channel.Confirmacion(Id);
        }
        
        public System.Threading.Tasks.Task ConfirmacionAsync(long Id) {
            return base.Channel.ConfirmacionAsync(Id);
        }
    }
}
