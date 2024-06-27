namespace Application.Paginations
{
    public static class PaginationExtensions
    {
        /// <summary>
        /// Получить постраничку
        /// </summary>
        /// <typeparam name="T">Таблица в БД (Entity)</typeparam>
        /// <typeparam name="TResponse">Выходная модель (Результат)</typeparam>
        /// <typeparam name="TItem">Элементы содержащийся в выходной модели</typeparam>
        /// <param name="query">Запрос в БД(IQueryable)</param>
        /// <param name="request">Запрос постранички (IPaginationRequest)</param>
        /// <param name="selector">Способ заполнения элемента</param>
        /// <returns></returns>
        public static TResponse GetPaginationResponse<T, TResponse, TItem>(this IQueryable<T> query, IPaginationRequest request, Func<T, TItem> selector)
            where T : class
            where TResponse : IPaginationResponse<TItem>, new()
            where TItem : class
        {
            var totalCount = query.Count();

            var items = query.Skip((request.Page!.PageNumber - 1) * request.Page.PageSize)
                             .Take(request.Page.PageSize)
                             .Select(selector)
                             .ToList();

            var totalPages = (int)Math.Ceiling(totalCount / (double)request.Page.PageSize);

            return new TResponse
            {
                Items = items,
                Page = new PageResponse
                {
                    TotalPages = totalPages,
                    CurrentPage = request.Page.PageNumber,
                    TotalItems = totalCount
                }
            }; ;
        }
    }
}
