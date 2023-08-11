using System.ComponentModel.DataAnnotations.Schema;

namespace MS.AFORO255.Withdrawal.Models;

[Table("transaction")]
public class TransactionModel
{
    public TransactionModel(decimal amount, int accountId, string? type = "withdrawal")
    {
        Amount = amount;
        Type = type;
        CreationDate = DateTime.Now.ToShortDateString();
        AccountId = accountId;
    }

    [Column("id")]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("amount")]
    public decimal Amount { get; set; }
    [Column("type")]
    public string? Type { get; set; }
    [Column("creationdate")]
    public string? CreationDate { get; set; }
    [Column("accountid")]
    public int AccountId { get; set; }

}

