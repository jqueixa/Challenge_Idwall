using Fiap.Api.AspNet.Repository.Context;
using Fiap.Api.AspNet.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;

[Route("api/[controller]")]
[ApiController]
public class InterpolController : ControllerBase
{

    private readonly InterpolRepository interpolRepository;

    public InterpolController(DataBaseContext context)
    {
        interpolRepository = new InterpolRepository(context);
    }

    [HttpGet]
    public ActionResult<List<InterpolModel>> Get()
    {
        try
        {
            var lista = interpolRepository.Listar();

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
    public ActionResult<InterpolModel> Get([FromRoute] string nome)
    {
        try
        {
            var interpolModel = interpolRepository.ConsultarPorParteNome(nome);

            if (interpolModel != null)
            {
                return Ok(interpolModel);
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

