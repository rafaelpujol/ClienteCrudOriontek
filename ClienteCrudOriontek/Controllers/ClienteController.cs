using ClienteCrudOriontek.Context;
using ClienteCrudOriontek.Models;
using ClienteCrudOriontek.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClienteCrudOriontek.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _clienteService.GetClientes();
                if(clientes == null)
                {
                    return NotFound();
                }
                return Ok(clientes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var cliente = await _clienteService.GetCliente(id);
                if(cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int clienteid = await _clienteService.AddCliente(cliente);
                    if(clienteid > 0)
                    {
                        return Ok(cliente);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // PUT api/<ClienteController>
        [HttpPut()]
        public async Task<IActionResult> Put(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _clienteService.UpdatCliente(cliente);
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            int result = 0;
            if(id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _clienteService.DeleteCliente(id);
                if(result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
