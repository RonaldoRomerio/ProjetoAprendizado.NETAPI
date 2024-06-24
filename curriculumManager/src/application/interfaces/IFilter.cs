using curriculumManager.src.domain.Enum;

namespace curriculumManager.src.application.interfaces
{
    public interface IFilter
    {
        public string NameProperty { get; set; }
        public FilterOperator FilterOperator { get; set; }
        public object Value { get;}
    }
}
