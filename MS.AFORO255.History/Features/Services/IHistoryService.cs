using MS.AFORO255.History.Features.DTOs;
using MS.AFORO255.History.Features.Models;

namespace MS.AFORO255.History.Features.Services;

public interface IHistoryService
{
    Task<IEnumerable<HistoryResponse>> GetById(int accountId);

    Task<bool> Add(HistoryModel historyModel);
}

