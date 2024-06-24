namespace Application.Paginations
{
    public interface IPaginationResponse<TType>
    {
        public ICollection<TType> Items { get; set; }
        public PageResponse? Page { get; set; }
    }
}
