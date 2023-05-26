﻿using Application.Abstractions;
using Application.Produtos.Commands;
using Domain.Models;
using MediatR;

namespace Application.Produtos.CommandHandlers
{
    internal class AdicionarProdutoHandler : IRequestHandler<AdicionarProduto>
    {
        private readonly IProdutoRepository _repositorio;
        private readonly IGalvanicaRepository _repositorioGalvanica;

        public AdicionarProdutoHandler(IProdutoRepository repositorio, IGalvanicaRepository repositorioGalvanica)
        {
            _repositorio = repositorio;
            _repositorioGalvanica = repositorioGalvanica;
        }

        public async Task<Unit> Handle(AdicionarProduto request, CancellationToken cancellationToken)
        {
            var galvanica = await _repositorioGalvanica.ObterGalvanica(request.IdGalvanica, cancellationToken) ?? throw new Exception("Galvanica não encontrado.");
            var produto = request.ObterProduto();

            foreach (var estoque in request.Estoque)
            {
                produto.AdicionarEstoque(estoque.Medida, estoque.Quantidade);
            }

            produto.CalcularPreco(galvanica);

            await _repositorio.Adicionar(produto, cancellationToken);
            return Unit.Value;
        }
    }
}
