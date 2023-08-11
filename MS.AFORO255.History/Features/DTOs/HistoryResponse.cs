namespace MS.AFORO255.History.Features.DTOs;
public class HistoryResponse
{
    public int? IdTransaction { get; set; }
    public decimal? Amount { get; set; }
    public string? Type { get; set; }
    public string? CreationDate { get; set; }
    public int? AccountId { get; set; }
}

