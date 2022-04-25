using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericLayer
{
    public class PagedList<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public List<T> Entities { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList() { }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            Entities = new List<T>();
            Entities.AddRange(items);
        }

        public static async Task<PagedList<T>> ToPagedList(IQueryable<T> source, SortingData sortingData, CancellationToken token)
        {
            var count = source.Count();

            if (sortingData.OrderBy != null)
            {
                var orderParams = sortingData.OrderBy.Trim().Split(',');
                var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var orderQueryBuilder = new StringBuilder();

                foreach (var param in orderParams)
                {
                    if (string.IsNullOrWhiteSpace(param))
                        continue;

                    var propertyFromQueryName = param.Split(" ")[0];
                    var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                    if (objectProperty == null)
                        continue;

                    var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                    orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
                }

                var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

                source = source.OrderBy(orderQuery);
            }

            Console.WriteLine(sortingData.PageNumber);

            var items = await source.Skip((sortingData.PageNumber - 1) * sortingData.PageSize).Take(sortingData.PageSize).ToDynamicListAsync<T>();

            return new PagedList<T>(items, count, sortingData.PageNumber, sortingData.PageSize);
        }
    }
}
