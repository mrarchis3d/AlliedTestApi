using Domain.Entities;

namespace Domain.Entities
{
    public class Image: BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public string UrlImage { get; set; }
    }
}
