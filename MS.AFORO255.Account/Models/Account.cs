using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS.AFORO255.Account.Models;

public class Account
{
    public Account()
    {
    }

    public Account(int? accountId, decimal? totalAmount, int? customerId, Customer? customer)
    {
        AccountId = accountId;
        TotalAmount = totalAmount;
        CustomerId = customerId;
        Customer = customer;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int? AccountId { get; set; }
    public decimal? TotalAmount { get; set; }
    [ForeignKey("Customer")]
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
}

