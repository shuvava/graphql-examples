using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StarWars.Models
{
    public abstract class StarWarsCharacter
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public string[] Friends { get; set; }
        public int[] AppearsIn { get; set; }
    }
}
