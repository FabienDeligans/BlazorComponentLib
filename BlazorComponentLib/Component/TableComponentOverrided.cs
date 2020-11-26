using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorComponentLib.Component.TableComponent;
using BlazorComponentLibServer.Models;
using Core.Models;

namespace BlazorComponentLib.Component
{
    public class TableComponentOverrided<T> : TableComponent<T> where T : Entity
    {
        protected override void Read(string id)
        {

        }

        protected override void Update(string id)
        {

        }

        protected override void Delete(string id)
        {

        }

        protected override int PageSize { get; set; } = 10;
    }
}
