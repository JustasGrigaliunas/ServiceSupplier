using ServiceSupplier.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSupplier.Controllers
{
    public class InvoiceController
    {
        private readonly Repositories.IClientRepository _clientRepository;
        private readonly ISupplierRepository _supplierRepository;

        public InvoiceController(Repositories.IClientRepository clientRepository
            ,ISupplierRepository supplierRepository)
        {
            _clientRepository = clientRepository;
            
            _supplierRepository = supplierRepository;
        }
        
        public double  MakeInvoice(int idSupplier, int idClient
                                        , double priceWithoutVat)
        {
            double PriceWithVAT = 0;
            double VAT = 0;
            if (!_supplierRepository.GetBy(idSupplier).IsVATPayer)
            {
                VAT = 0;     
            }
            else if (_clientRepository.GetBy(idClient).IdCountry == _supplierRepository.GetBy(idClient).IdCountry)
            {
                VAT = _supplierRepository.GetBy(idClient).VATPercentage;
            }
            else if(!_clientRepository.GetBy(idClient).IsInEuropeanUnion ||
                    (_clientRepository.GetBy(idClient).IsInEuropeanUnion &&
                    _clientRepository.GetBy(idClient).IsVATPayer &&
                    _supplierRepository.GetBy(idSupplier).IdCountry != _clientRepository.GetBy(idClient).IdCountry ))
            {
                VAT = 0;
            }
            else if ((_clientRepository.GetBy(idClient).IsInEuropeanUnion &&
                    !_clientRepository.GetBy(idClient).IsVATPayer &&
                    _supplierRepository.GetBy(idSupplier).IdCountry != _clientRepository.GetBy(idClient).IdCountry))
            {
                VAT =_clientRepository.GetBy(idClient).VATPercentage; 
            }
            PriceWithVAT = priceWithoutVat *(VAT/100 +1);
            return PriceWithVAT;
        }
        
    }
}
