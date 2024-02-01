using Fiap.Api.AspNet.Repository.Context;
using Fiap.Api.AspNet.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

[Route("api/[controller]")]
[ApiController]
public class WantedController : ControllerBase
{

    private readonly WantedRepository wantedRepository;

    public WantedController(DataBaseContext context)
    {
        wantedRepository = new WantedRepository(context);
    }
[HttpGet]
    public ActionResult<List<WantedModel>> get()
    {
        try
        {
            var lista = wantedRepository.SaveApiDataToDatabaseAsync();

            if (lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound("O usuário não apresenta nenhum tipo de restrição");
            }

        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{nome}")]
    public ActionResult<WantedModel> Get([FromRoute] string nome)
    {
        try
        {
            var wantedModel = wantedRepository.ConsultarPorParteNome(nome);

            if (wantedModel != null)
            {
                return Ok(wantedModel);
            }
            else
            {
                return NotFound("O usuário não apresenta nenhum tipo de restrição");
            }

        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


}