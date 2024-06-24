using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;

namespace curriculumManager.src.domain.models
{
    public class Filter<TValue> : IFilter
    {
        public string NameProperty { get; set; }
        public FilterOperator FilterOperator { get; set; }
        public TValue Value{ get; set; }
        object IFilter.Value => Value;

        public Filter(string nameproperty, FilterOperator filterOperator, TValue value)
        {
            NameProperty = nameproperty;
            FilterOperator = filterOperator;
            Value = value;
        }
    }
}