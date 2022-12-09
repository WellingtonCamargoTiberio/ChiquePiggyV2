using ChiquePiggy.Caching;
using ChiquePiggy.Domain;
using ChiquePiggy.Domain.Entities;
using ChiquePiggy.Domain.Models.Caixa.Response;
using ChiquePiggy.Helpers.Constantes;
using ChiquePiggy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Services
{
    public class CaixaService
    {    
        //DB CONTEX
        //VALIDAÇÂO DE ENTRADAS 
        //
        public bool ConsultarSaldoPontos(int id)
        {            
            return true;
        }

        public Usuario SelecionarDadosUsuario()
        {
            var cacheUsuario = CacheLocal.Get<Usuario>("Usuario1");
            if (cacheUsuario != null) return cacheUsuario;           

            //Banco de dados fazendo um select do usuario
            //Carregando o nome dele
            //Voltando o nome para a camada de apresentação(API=>Front/MVC/Blazor)
            var usuario = new Usuario();
            CacheLocal.Add(usuario, "Usuario1", DateTime.Now.AddMinutes(5));

            return usuario;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="pontuar"></param>
        public PontuacaoCaixaResponse PontuarConsumidor(PontuacaoCaixaRequest pontuacaoRequest)
        {
            PontuacaoCaixaResponse response = new PontuacaoCaixaResponse();
            if (!pontuacaoRequest.ValidarEntradasParametros()) return response;

            //SE FOR VALIDO
            //Inserir no banco de dados 
            //Fazer um retorno falando que deu certo ...
            response.Sucesso = true;
            return response;
        }
    }
}
