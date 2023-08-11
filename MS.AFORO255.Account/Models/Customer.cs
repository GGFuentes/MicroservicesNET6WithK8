using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS.AFORO255.Account.Models;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int? CustomerId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }

}

