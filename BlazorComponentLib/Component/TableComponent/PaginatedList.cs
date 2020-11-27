using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorComponentLib.Component.TableComponent
{
    public class PaginatedList<T> : List<T>
    {
        private int PageIndex { get; set; }
        private int TotalPages { get; set; }

        private PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public static PaginatedList<T> Create(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
