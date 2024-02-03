using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Interfaces.AutoMapper
{
    public interface IMapper
    {
        TDestionation Map<TDestionation, TSource>(TSource source, string? ignore = null);

        IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null);

        TDestionation Map<TDestionation>(object source, string? ignore = null);

        IList<TDestionation> Map<TDestionation>(IList<object> source, string? ignore = null);
    }
}
