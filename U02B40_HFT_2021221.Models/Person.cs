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
    [Table("Persons")]
    public class Person
    {
       

        /// <summary>
        /// Gets or sets id of the peron.
        /// </summary>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets person id.
        /// </summary>
        /// 
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets date of Birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets name of mother.
        /// </summary>
        public string MotherName { get; set; }

        /// <summary>
        /// Gets or sets address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets accountid.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets the corresponding Accounts.
        /// </summary>
        ///
        [NotMapped]
        [JsonIgnore]
       public virtual Account Account { get; set; }

        /// <summary>
        /// To String method.
        /// </summary>
        /// <returns>PersonAccount.</returns>
        public override string ToString()
        {
            return this.Id + " " + this.Name;
        }
    }
}
