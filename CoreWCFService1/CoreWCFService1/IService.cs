using ClassLibrary1;
using CoreWCF;
using System;
using System.Runtime.Serialization;

namespace CoreWCFService1
{
    public class Service : IService
    {
        private readonly ClassLibrary1.IService _context;
        public Service(ClassLibrary1.IService Interface1)
        {
            _context = Interface1;

        }
        public string GetData(int value)
        {
            return _context.GetData(value);
        }

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
