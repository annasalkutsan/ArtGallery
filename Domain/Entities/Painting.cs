namespace Domain.Entities
{
    public class Painting : BaseEntity
    {
        public Painting() { }

        public Painting(string title, string? description, decimal price, string imagePath, Author author, Order order)
        {
            Title = title;
            Description = description;
            Price = price;
            ImagePath = imagePath;
            Author = author;
            AuthorId = author.Id;
            Order = order;
            OrderId = order.Id;

            //var validator = new PaintingValidator();
            //validator.ValidateAndThrow(this);
        }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public Author Author { get; set; }
        public Guid AuthorId { get; set; }

        public Order Order { get; set; }
        public Guid OrderId { get; set; }

        public Painting Update(string? title, string? description, decimal? price)
        {
            if (title is not null)
            {
                Title = title;
            }

            if (description is not null)
            {
                Description = description;
            }

            if (price.HasValue)
            {
                Price = price.Value;
            }

            //var validator = new PaintingValidator();
            //validator.ValidateAndThrow(this);

            return this;
        }
    }
}