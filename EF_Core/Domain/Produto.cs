﻿using EF_Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Domain
{
    public class Produto
    {
        public Produto(Guid id, string codigoBarras, string descricao, decimal valor, TipoProduto tipoProduto, bool ativo)
        {
            Id = id;
            CodigoBarras = codigoBarras;
            Descricao = descricao;
            Valor = valor;
            TipoProduto = tipoProduto;
            Ativo = ativo;
        }

        public Guid Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
    }
}
