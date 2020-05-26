using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelRoute.Application.Interfaces;
using TravelRoute.Entities;

namespace TravelRoute.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private ITravelApplication _travelApplication;

        public RouteController(ITravelApplication travelApplication)
        {
            _travelApplication = travelApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string route)
        {

            try
            {
                var bestRoute = _travelApplication.GetBestRoute(route);

                if (bestRoute == null)
                    return NotFound("Rota não encontrada");

                return Ok(new { bestRoute.Route, bestRoute.Value });
            }
            catch (Exception ex)
            {
                var erro = string.Format("Erro ao consultar rota", ex.Message);
                return BadRequest(erro);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Route route)
        {

            try
            {
                _travelApplication.SetRoute(route);
               
                return Ok();
            }
            catch (Exception ex)
            {
                var erro = string.Format("Erro inserir rota", ex.Message);
                return BadRequest(erro);
            }
        }
    }
}