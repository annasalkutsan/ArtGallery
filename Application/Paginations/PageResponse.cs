namespace Application.Paginations
{
    /// <summary>
    ///     Данные для пагинации страницы
    /// </summary>
    public class PageResponse
    {
        /// <summary>
        ///     Номер текущей страницы
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        ///     Общее количество страниц
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        ///     Общее количество элементов
        /// </summary>
        public int TotalItems { get; set; }
    }
}
