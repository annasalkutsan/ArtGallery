namespace Domain.Entities
{
    public class Image : BaseEntity
    {
        public Image() { }

        public Image(string path, Painting? painting)
        {
            Path = path;
        }

        public string Path { get; set; }
    }
}