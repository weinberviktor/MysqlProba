using System.ComponentModel.DataAnnotations;

namespace MysqlProba.Model
{
    public class Diak
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Kötelező kitölteni")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string DiakNev { get; set; }
        [Required(ErrorMessage = "Kötelező kitölteni")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string TanarNev { get; set; }
        [StringLength(maximumLength: 4, MinimumLength = 1)]
        public string Osztaly { get; set; }
    }
}
