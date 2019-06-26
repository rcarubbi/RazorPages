using System.ComponentModel.DataAnnotations;

namespace RazorPagesDemo1.Core
{
    public class Restaurant 
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(225)]
        public string Location { get; set; }


        public CousineType Cousine { get; set; }

       
    }
}
