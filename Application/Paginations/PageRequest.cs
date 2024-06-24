namespace Application.Paginations
{
    /// <summary>
    ///     Параметры страницы для запроса с пагинацией
    /// </summary>
    public class PageRequest
    {
        /// <summary>
        ///     Номер страницы
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        ///     Размер страницы (количество элементов на странице)
        /// </summary>
        public int PageSize { get; set; }
    }
}
