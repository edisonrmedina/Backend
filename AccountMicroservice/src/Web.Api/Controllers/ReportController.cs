using Application.Reporte;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Web.API.Controllers;

[Route("v1/Reporte")]
public class ReportesController : ApiController
{
    private readonly ISender _mediator;

    public ReportesController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<IActionResult> GenerarEstadoCuentaReporteAsync(
        [FromQuery] DateTime fechaInicio,
        [FromQuery] DateTime fechaFin,
        [FromQuery] Guid clienteId)
    {
        try
        {
            var customerResult = await _mediator.Send(
                new CreateCommandReport(fechaInicio,fechaFin,clienteId)
                );

            return customerResult.Match(
                customer => Ok(customer),
                errors => Problem(errors)
            );
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al generar el informe: {ex.Message}");
        }
    }
}
