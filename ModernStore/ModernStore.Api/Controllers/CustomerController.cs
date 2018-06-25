using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Infra.Transactions;

namespace ModernStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUow _uow;
        private readonly CustomerHandler _handler;

        public CustomerController(IUow uow, CustomerHandler handler)
        {
            _uow = uow;
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/customers")]
        public IActionResult Post([FromBody]RegisterCustomerCommad command)
        {
            var result = _handler.Handle(command);

            if (_handler.Valid)
            {
                _uow.Commit();

                return Ok(result);
            }
            else
            {
                return BadRequest("error");
            }
        }
    }
}
