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
    [Table("Accounts")]
    
        public class Account
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Account"/> class.
            /// Account constructor.
            /// </summary>
            

            /// <summary>
            /// Gets or sets id of the account.
            /// </summary>
            [Key]
            [Required]

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets name of the account.
            /// </summary>
            
            
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether inactive flag of the account.
            /// </summary>
            public bool IsInactive { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether closed flag of the account.
            /// </summary>
            public bool IsClosed { get; set; }

            /// <summary>
            /// Gets or sets type of the account.
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// Gets the persons assigned to the account.
            /// </summary>

            /// <summary>
            /// The personaccounts to the account.
            /// </summary>
            [NotMapped]
            [JsonIgnore]


        public virtual Person Person { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; }

            /// <summary>
            /// ToString methos for the Account.
            /// </summary>
            /// <returns>TransactionList.</returns>
            public override string ToString()
            {
                return this.Id + " " + this.Name;
            }
        
    }
}
