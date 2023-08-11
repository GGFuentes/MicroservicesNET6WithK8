using Carter;
using MS.AFORO255.History.Features.DTOs;
using MS.AFORO255.History.Features.Services;

namespace MS.AFORO255.History.Features;

public class HistoryModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/history/{accountId}", GetAccount)
           .Produces<HistoryResponse>()
           .Produces(StatusCodes.Status404NotFound);
    }

    private static async Task<IResult> GetAccount(int accountId, IHistoryService service)
    {
        var movements = await service.GetById(accountId);
        if (movements is null)  return Results.NotFound();
        return Results.Ok(movements);
    }
}

