namespace Application.DTO.Painting.Pag
{
    /// <summary>
    ///     new
    /// </summary>
    public class PaintingListItems
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
    }
}
