using System.ComponentModel.DataAnnotations;

namespace McMovieFTI.DataContext.Data
{
    public class Categorys
    {
        public int Id { get; set; }

        public string  Title { get; set; }

        public decimal Imdb { get; set; }

        public decimal  Price { get; set; }

        public string Category { get; set; }


    }
}
