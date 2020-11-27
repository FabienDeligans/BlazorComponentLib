using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorComponentLib.Component.TableComponent
{
    public abstract partial class TableComponent<T> : ComponentBase
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

            if (typeof(T).BaseType != typeof(Entity))
            {
                Crud = false;
            }

            if (Paginated == false)
            {
                PageSize = ListEntities.Count;
            }
            NumberOfPage = (int)Math.Ceiling(ListEntities.Count / (double)PageSize);
            Index = 1;
            PaginatedEntities = PaginatedList<T>.Create(ListEntities, Index, PageSize);
            GenerateButton();
        }

        private void GoToPage(int nb)
        {
            Index = nb;
            if (Index <= 0)
            {
                Index = 1;
            }

            if (Index > NumberOfPage)
            {
                Index = NumberOfPage;
            }

            PaginatedEntities = PaginatedList<T>.Create(ListEntities, Index, PageSize);
            GenerateButton();
        }

        private List<int> ButtonList { get; set; }
        private int JumpDown { get; set; }
        private int JumpUp { get; set; }
        private void GenerateButton()
        {
            var min = (int)Math.Floor((decimal)(Index / 10)) * 10;
            if (min == 0)
            {
                min = 1;
            }
            var max = (int)Math.Ceiling((decimal)(Index / 10)) * 10 + 10;
            if (max > NumberOfPage)
            {
                max = NumberOfPage;
            }

            ButtonList = new List<int>();
            for (var i = min; i <= max; i++)
            {
                ButtonList.Add(i);
            }

            JumpDown = min - 10;
            if (JumpDown == 0)
            {
                JumpDown = 1;
            }
            JumpUp = max+1;
        }

        public void GotoInputSelect(ChangeEventArgs e)
        {
            var i = Convert.ToInt32(e.Value); 
            GoToPage(i);
        }

        protected override void OnParametersSet()
        {
            OnInitialized();
            base.OnParametersSet();
        }

        protected abstract void Create();
        protected abstract void Read(string id);
        protected abstract void Update(string id);
        protected abstract void Delete(string id);

    }
}
