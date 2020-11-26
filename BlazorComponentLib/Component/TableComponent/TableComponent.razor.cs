using System;
using System.Collections.Generic;
using System.Linq;
using BlazorComponentLibServer.Context;
using Core.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorComponentLib.Component.TableComponent
{
    public abstract partial class TableComponent<T> : ComponentBase where T : Entity
    {
        private PaginatedList<T> PaginatedEntities { get; set; }
        private int Index { get; set; }
        protected virtual int PageSize { get; set; } = 10;
        private int NumberOfPage { get; set; }

        [Parameter]
        public List<T> ListEntities { get; set; }

        [Parameter]
        public bool Paginated { get; set; }
        
        [Parameter]
        public RenderFragment RenderFragment { get; set; }

        [Parameter]
        public bool Crud { get; set; }

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

        private void Pagination(int nb)
        {
            Index = nb;
            PaginatedEntities = PaginatedList<T>.Create(ListEntities, Index, PageSize);
        }

        protected override void OnParametersSet()
        {
            OnInitialized();
            base.OnParametersSet();
        }

        protected abstract void Read(string id);
        protected abstract void Update(string id);
        protected abstract void Delete(string id);

    }
}
