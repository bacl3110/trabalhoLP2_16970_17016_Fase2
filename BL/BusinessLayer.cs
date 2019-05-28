﻿/*
*  -------------------------------------------------
* <copyright file=" BusinessLayer " company="IPCA"/>
* <date> 5/27/2019 10:56:28 AM </date>
* <author> bruno </author>
* <email> a16970@alunos.ipca.pt </email>
* <desc>
*   
* </desc>
* -------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DL;

namespace BL
{
    /// <summary>
    /// Classe que controla o acesso aos dados
    /// </summary>
    public class BusinessLayer
    {
        private DataLayer data;

        #region Construtores
        /// <summary>
        /// Construtor de BusinessLayer
        /// </summary>
        public BusinessLayer()
        {
            data = new DataLayer();
        }
        #endregion

        #region Metodos
        
        /// <summary>
        /// Metodo que fornece o nome da marca
        /// </summary>
        /// <returns></returns>
        public string NomeMarca()
        {
            return data.NomeMarca();
        }

        #region Contadores
        /// <summary>
        /// Conta o numero total de Concessionarios da marca
        /// </summary>
        /// <returns></returns>
        public int NConcessionarios()
        {
            return data.NConcessionarios();
        }

        /// <summary>
        /// Conta o numero total de Carros em stock da marca
        /// </summary>
        /// <returns></returns>
        public int NCarros()
        {
            return data.NCarros();
        }

        /// <summary>
        /// Conta o numero de carros de um determinado cliente
        /// </summary>
        /// <param name="nif">NIF do cliente</param>
        /// <returns></returns>
        public int NCarros(double nif)
        {
            return data.NCarros(nif);
        }

        /// <summary>
        /// Conta o numero total de Comerciais da marca
        /// </summary>
        /// <returns></returns>
        public int NComerciais()
        {
            return data.NComerciais();
        }

        /// <summary>
        /// Conta o numero total de Clientes da marca
        /// </summary>
        /// <returns></returns>
        public int NClientes()
        {
            return data.NClientes();
        }
        #endregion

        #region Metodos Concessionarios
        /// <summary>
        /// Metodo que fornece uma lista com os concessionarios
        /// </summary>
        /// <returns></returns>
        public List<Concessionario> Concessionarios()
        {
            return data.Concessionarios();
        }

        /// <summary>
        /// Metodo para adicionar um novo concessionario
        /// </summary>
        public void AddConcessionario()
        {
            int id;
            if (data.Concessionarios().Count != 0) id = data.Concessionarios().Max<Concessionario>(var => var.Id) + 1; else id = 1;
            data.AddConcessionario(id);
        }

        /// <summary>
        /// Metodo para remover um concessionario
        /// </summary>
        /// <param name="id"></param>
        public void DeleteConcessionario(int id)
        {
            data.DeleteConcessionario(id);
        }
        #endregion


        /// <summary>
        /// Metodo que exporta os dados para um ficheiro
        /// </summary>
        public void Export()
        {
            data.Export();
        }

        #endregion
    }
}