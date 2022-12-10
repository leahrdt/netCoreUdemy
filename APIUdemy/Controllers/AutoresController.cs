using System;
using APIUdemy.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace APIUdemy.Controllers
{
	[ApiController]
	[Route("api/autores")]
	public class AutoresController : ControllerBase
	{
		//Tipo de Request
		[HttpGet]
		// public ActionResult, devuelve una Lista, de Autor, y la funcion se llama Get.
		public ActionResult<List<Autor>> Get()
        {
			return new List<Autor>()
			{
				new Autor(){ Id = 1, Nombre = "Felipe"},
				new Autor(){ Id = 2, Nombre = "Claudio"},

			};
        }
	}
}

