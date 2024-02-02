using AutoMapper.Internal;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuyumcuAPI.Applicaion.Interfaces;
using IMapper = AutoMapper.IMapper;
using static System.Net.Mime.MediaTypeNames;

namespace KuyumcuAPI.Mapper.AutoMapper
{
    public class Mapper : Applicaion.Interfaces.AutoMapper.IMapper
    {
        public static List<TypePair> typePairs = new();
        private IMapper MapperContainer;
        public TDestionation Map<TDestionation, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestionation, TSource>(5, ignore);
            return MapperContainer.Map<TSource, TDestionation>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(sources);
        }

        public TDestionation Map<TDestionation>(object source, string? ignore = null)
        {
            Config<TDestionation, object>(5, ignore);
            return MapperContainer.Map<TDestionation>(source);
        }

        public IList<TDestionation> Map<TDestionation>(IList<object> source, string? ignore = null)
        {
            Config<TDestionation, IList<object>>(5, ignore);
            return MapperContainer.Map<IList<TDestionation>>(source);
        }

        protected void Config<TDestination, TraceSource>(int depth = 5, string? ignore = null)
        {
            var typepair = new TypePair(typeof(TraceSource), typeof(TDestination));
            if (typePairs.Any(a => a.DestinationType == typepair.DestinationType && a.SourceType == typepair.SourceType && ignore is null))
                return;

            typePairs.Add(typepair);
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();


                }
            });

            MapperContainer = config.CreateMapper();
        }
    }
}
