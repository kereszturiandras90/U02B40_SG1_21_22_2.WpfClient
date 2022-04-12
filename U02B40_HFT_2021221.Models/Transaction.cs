using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the trasaction.
        /// </summary>
         [MaxLength(6)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the time of sending the transaction.
        /// </summary>
        public DateTime TransferTime { get; set; }

        /// <summary>
        /// Gets or sets transaction amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets currency of transacrótion.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets id of the account.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the correponding Account.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual Account Account { get; set; }

        /// <summary>
        /// To String method for transaction.
        /// </summary>
        /// <returns>Accounts.</returns>
        public override string ToString()
        {
            return "Azonosító: " + this.Id + this.AccountId + " penzosszeg: " + this.Amount + " valuta: " + this.Currency + " dátum: " + this.TransferTime;
        }
    }
}
