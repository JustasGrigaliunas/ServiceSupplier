using System;
using ServiceSupplier.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceSupplier.Repositories;
using ServiceSupplier.Controllers;
using System.Collections.Generic;

namespace ServiceSupplierTest
{
    [TestClass]
    public class UnitTest1
    {
        private ClientRepository _clientRepository  = new ClientRepository();
        private SupplierRepository _supplierRepository = new SupplierRepository();
        [TestMethod]
        public void Add_ClientRepository_ClientAdded()
        {
            // Arrange
            ClientEntity clientEntity = new ClientEntity(1,"Pirma",1,true,true,21);
            InvoiceController invoiceController = new InvoiceController(_clientRepository, _supplierRepository);

            // Act
            _clientRepository.Add(clientEntity);

            // Assert
            
            Assert.AreEqual("Pirma",_clientRepository.GetBy(1).Name);
            Assert.AreEqual(1,_clientRepository.GetBy(1).Id);
            Assert.AreEqual(1,_clientRepository.GetBy(1).IdCountry, 1);
            Assert.AreEqual(true,_clientRepository.GetBy(1).IsInEuropeanUnion);
            Assert.AreEqual(true,_clientRepository.GetBy(1).IsVATPayer);
            Assert.AreEqual(21,_clientRepository.GetBy(1).VATPercentage);
            Assert.AreEqual(1,_clientRepository.GetCount());
        }
        [TestMethod]
        public void Add_SupplierRepository_SupplierAdded()
        {
            // Arrange
            SupplierEntity supplierEntity = new SupplierEntity(1, "Pirma", 1, true, true, 21);
            SupplierEntity supplierEntity2 = new SupplierEntity(2, "Antra", 1, true, false, 21);
            SupplierEntity supplierEntity3 = new SupplierEntity(3, "Trecia", 2, false, true, 18);
            InvoiceController invoiceController = new InvoiceController(_clientRepository, _supplierRepository);

            // Act
            _supplierRepository.Add(supplierEntity);
            _supplierRepository.Add(supplierEntity2);
            _supplierRepository.Add(supplierEntity3);

            // Assert

            Assert.AreEqual("Pirma", _supplierRepository.GetBy(1).Name);
            Assert.AreEqual(false, _supplierRepository.GetBy(2).IsVATPayer);
            Assert.AreEqual("Trecia", _supplierRepository.GetBy(3).Name);
            Assert.AreEqual(3, _supplierRepository.GetBy(3).Id);
            Assert.AreEqual(3, _supplierRepository.GetCount());
        }
        [TestMethod]
        public void MakeInvoice_InvoiceController_SupplierNotVATPayer()
        {
            // Arrange
            ClientEntity clientEntity = new ClientEntity(1, "PirmasKlientas", 1, true, true, 21);
            SupplierEntity supplierEntity = new SupplierEntity(1, "PirmasSupplier", 1, true, false, 21);
            _clientRepository.Add(clientEntity);
            _supplierRepository.Add(supplierEntity);
            InvoiceController invoiceController = new InvoiceController(_clientRepository, _supplierRepository);

            // Act
            double sumResult = invoiceController.MakeInvoice(1, 1, 100);

            // Assert

            Assert.AreEqual(100, sumResult);
        }
        [TestMethod]
        public void MakeInvoice_InvoiceController_SuplierVATPayer_ClientNotInEU()
        {
            // Arrange
            ClientEntity clientEntity = new ClientEntity(1, "PirmasKlientas", 20, false, true, 21);
            SupplierEntity supplierEntity = new SupplierEntity(1, "PirmasSupplier", 1, true, true, 21);
            _clientRepository.Add(clientEntity);
            _supplierRepository.Add(supplierEntity);
            InvoiceController invoiceController = new InvoiceController(_clientRepository, _supplierRepository);

            // Act
            double sumResult = invoiceController.MakeInvoice(1, 1, 100);

            // Assert

            Assert.AreEqual(100, sumResult);
        }
        [TestMethod]
        public void MakeInvoice_InvoiceController_SuplierVATPayer_ClientInEU_IsNotVATPayer_DifferentCountries()
        {
            // Arrange
            ClientEntity clientEntity = new ClientEntity(1, "PirmasKlientas", 3, true, false, 17);
            SupplierEntity supplierEntity = new SupplierEntity(1, "PirmasSupplier", 1, true, true, 21);
            _clientRepository.Add(clientEntity);
            _supplierRepository.Add(supplierEntity);
            InvoiceController invoiceController = new InvoiceController(_clientRepository, _supplierRepository);

            // Act
            double sumResult = invoiceController.MakeInvoice(1, 1, 100);

            // Assert

            Assert.AreEqual(117, sumResult);
        }
        [TestMethod]
        public void MakeInvoice_InvoiceController_SuplierVATPayer_ClientInEU_IsVATPayer_DifferentCountries()
        {
            // Arrange
            ClientEntity clientEntity = new ClientEntity(1, "PirmasKlientas", 3, true, true, 17);
            SupplierEntity supplierEntity = new SupplierEntity(1, "PirmasSupplier", 1, true, true, 21);
            _clientRepository.Add(clientEntity);
            _supplierRepository.Add(supplierEntity);
            InvoiceController invoiceController = new InvoiceController(_clientRepository, _supplierRepository);

            // Act
            double sumResult = invoiceController.MakeInvoice(1, 1, 100);

            // Assert

            Assert.AreEqual(100, sumResult);
        }
        [TestMethod]
        public void MakeInvoice_InvoiceController_SuplierAndClientSameCountry()
        {
            // Arrange
            ClientEntity clientEntity = new ClientEntity(1, "PirmasKlientas", 1, true, false, 21);
            SupplierEntity supplierEntity = new SupplierEntity(1, "PirmasSupplier", 1, true, true, 21);
            _clientRepository.Add(clientEntity);
            _supplierRepository.Add(supplierEntity);
            InvoiceController invoiceController = new InvoiceController(_clientRepository, _supplierRepository);

            // Act
            double sumResult = invoiceController.MakeInvoice(1, 1, 100);

            // Assert

            Assert.AreEqual(121, sumResult);
        }
    }
}
