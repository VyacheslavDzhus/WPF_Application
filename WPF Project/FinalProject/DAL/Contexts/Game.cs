namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        public int GameId { get; set; }

        [Required]
        [StringLength(100)]
        public string GameName { get; set; }

        public int? ManufacturerId { get; set; }

        public int? CategoryId { get; set; }

        
        public double Price { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        public double Popularity { get; set; }

        [StringLength(100)]
        public string ReleaseDate { get; set; }

        [Required]
        [StringLength(100)]
        public string ImagePath { get; set; }

        public virtual Category Category { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
