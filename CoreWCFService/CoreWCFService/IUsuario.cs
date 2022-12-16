using CoreWCF;
using CoreWCFService.Core.Entities;
using CoreWCFService.Core.DTOs;
using CoreWCFService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.Serialization;

namespace CoreWCFService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class UsuarioService : IUsuarioRepository
    {
        private readonly IUsuarioRepository _context;
        public UsuarioService(IUsuarioRepository UsuarioRepository)
        {
            _context = UsuarioRepository;
            
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            var list = await _context.GetUsuariosAsync();
            return list;
                
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.GetUsuarioByIdAsync(id);
        }

        public async Task AddUsuario(Usuario usuario)
        {
            
             await _context.AddUsuarioAsync(usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            await _context.UpdateUsuarioAsync(usuario);
        }

        public async Task DeleteUsuario(int id)
        {
            await _context.DeleteUsuarioAsync(id);
        }

        public Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddUsuarioAsync(Usuario Usuario)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUsuarioAsync(Usuario Usuario)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUsuarioAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Usuario>> IUsuarioRepository.GetUsuariosAsync()
        {
            var list =  _context.GetUsuariosAsync();
            return list;
        }

        public string GetData(int value)
        {
            return _context.GetData(value);
        }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
