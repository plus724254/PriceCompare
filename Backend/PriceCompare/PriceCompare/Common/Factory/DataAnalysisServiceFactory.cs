using PriceCompare.Constants.Enums;
using PriceCompare.Helpers;
using PriceCompare.Services.WebSiteDataAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PriceCompare.Common.Factory
{
    public static class DataAnalysisServiceFactory
    {
        private static readonly List<Type> _types;
        static DataAnalysisServiceFactory()
        {
            _types = TypeHelper.GetImplementTypesFromInterface(typeof(IDataAnalysisService));
        }
        public static IDataAnalysisService CreateInstance(DataAnalysisTypes dataAnalysisType, WebSiteNames webSiteName)
        {
            switch (dataAnalysisType)
            {
                case DataAnalysisTypes.Exclusive:
                    var type = _types.First(x => x.Name.StartsWith(webSiteName.ToString()));
                    return TypeHelper.CreateInstanceByType<IDataAnalysisService>(type);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
