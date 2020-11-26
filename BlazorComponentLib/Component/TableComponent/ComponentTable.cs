using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorComponentLib.Component.TableComponent
{
    public class ComponentTable<T> : ComponentBase where T : Entity
    {
        [Parameter]
        public List<T> RowListEntity { get; set; }
        public int RowsCount { get; set; }
        public List<PropertyInfo> ColProperties { get; set; }
        public int ColCount { get; set; }

        protected override void OnInitialized()
        {
            RowsCount = RowListEntity.Count;

            var data = RowListEntity.First();
            ColProperties = data.GetType().GetProperties().Where(v => v.GetValue(data) != null).ToList();
            ColCount = ColProperties.Count;

            base.OnInitialized();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var seq = 0;

            builder.OpenElement(++seq, "table");
            builder.AddAttribute(++seq, "class", "table table-responsive table-hover");

            builder.OpenElement(++seq, "thead");

            foreach (var propertyInfo in ColProperties)
            {
                builder.OpenElement(++seq, "th");
                builder.AddContent(++seq, $"{propertyInfo.Name}");
                builder.CloseElement();
            }
            builder.CloseElement();

            builder.OpenElement(++seq, "tbody");

            var i = 0;
            foreach (var entity in RowListEntity)
            {
                builder.OpenElement(++seq, "tr");
                
                foreach (var value in ColProperties.Select(propertyInfo => $"{propertyInfo.GetValue(entity)}"))
                {
                    builder.OpenElement(++seq, "td");
                    builder.AddContent(++seq, value);
                    builder.CloseElement();
                }
                builder.CloseElement();
            }
            builder.CloseElement();

            builder.CloseElement();

            base.BuildRenderTree(builder);

        }
    }
}
