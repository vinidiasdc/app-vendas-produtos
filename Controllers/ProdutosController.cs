using AppVendas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppVendas.Controllers;

public class ProdutosController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string apiEndPoint = "/api/produto/";

    public ProdutosController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index() {
        try {
            HttpClient httpClient = _httpClientFactory.CreateClient("ApiProdutos");

            List<ProdutoModel>? produtos = await httpClient.GetFromJsonAsync<List<ProdutoModel>>(apiEndPoint);

            return View(produtos);

        }
        catch(Exception erro) {
            throw new ApplicationException($"Não foi possível encontrar a api {erro.Message}");
        }
    }
}
