namespace curriculumManager.src.domain.dtos.genericDTOS
{
    public class ListReturn <TList> where TList : class
    {
        public List<TList> list { get; set; }
        public bool hasNextPage {  get; set; }
    }
}
