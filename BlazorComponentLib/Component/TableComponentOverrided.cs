using BlazorComponentLib.Component.TableComponent;
using Microsoft.AspNetCore.Components;

namespace BlazorComponentLib.Component
{
    // ReSharper disable once ClassNeverInstantiated.Global
    // ReSharper disable once IdentifierTypo
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
