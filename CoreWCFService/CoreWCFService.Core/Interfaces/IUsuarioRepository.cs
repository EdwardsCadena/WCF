using CoreWCFService.Core.Entities;
using Microsoft.SqlServer.Management.Smo.Broker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CoreWCFService.Core.Interfaces
{
    [ServiceContract]
    public interface IUsuarioRepository
    {
        [OperationContract]
        Task<List<Usuario>> GetUsuariosAsync();

        [OperationContract]
        Task<Usuario> GetUsuarioByIdAsync(int id);

        [OperationContract]
        Task AddUsuarioAsync(Usuario Usuario);

        [OperationContract]
        Task UpdateUsuarioAsync(Usuario Usuario);

        [OperationContract]
        Task DeleteUsuarioAsync(int id);

        [OperationContract]
        string GetData(int value);
    }
}



