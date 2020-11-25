using System;
using System.Collections.Generic;
using System.Linq;
using BlazorComponentLibServer.Context;
using Core.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorComponentLib.Component.TableComponent
{
    public partial class TableComponent<T> : ComponentBase where T : Entity
    {
        public PaginatedList<T> PaginatedEntities { get; set; }
        public int Index { get; set; }
        public int PageSize { get; set; } = 10;
        public int NumberOfPage { get; set; }

        [Parameter]
        public List<T> ListEntities { get; set; }

        [Parameter]
        public bool Paginated { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (ListEntities == null)
            {
                using var context = new BlazorContext();
                ListEntities = context.QueryCollection<T>().ToList();
            }

            if (Paginated == false)
            {
                PageSize = ListEntities.Count;
            }
            NumberOfPage = (int)Math.Ceiling(ListEntities.Count / (double)PageSize);
            Index = 1;
            PaginatedEntities = PaginatedList<T>.Create(ListEntities, Index, PageSize);
        }

        public void Pagination(int nb)
        {
            Index = nb;
            PaginatedEntities = PaginatedList<T>.Create(ListEntities, Index, PageSize);
            StateHasChanged();
        }
    }
}
