using System.Collections.Generic;
using System.Linq;
using BlazorComponentLib.Component.TableComponent;
using BlazorComponentLibServer.Context;
using BlazorComponentLibServer.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorComponentLib.Component
{
    public class TableComponentOverrided<T> : TableComponent<T>
    {
        [Inject]
        private NavigationManager Navigation { get; set; }

        protected override void Create()
        {

        }

        protected override void Read(string id)
        {
            Navigation.NavigateTo($"/readPageTest/{id}");
        }

        protected override void Update(string id)
        {

        }

        protected override void Delete(string id)
        {

        }

        protected override int PageSize { get; set; } = 5;
    }
}
