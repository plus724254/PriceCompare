using PriceCompare.Constants.Enums;
using PriceCompare.Services.WebSiteDataAnalysis;

namespace PriceCompare.Common.Factory
{
    public interface IDataAnalysisServiceFactory
    {
        IDataAnalysisService CreateInstance(DataAnalysisTypes dataAnalysisType, WebSiteNames webSiteName);
    }
}