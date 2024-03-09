﻿using curriculumManager.src.domain.Enum;

namespace curriculumManager.src.domain.dtos.education
{
    public class EducationInsert
    {
        public int CustomerId { get; set; }
        public string NameSchool { get; set; }
        public Graduation Graduation { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Course { get; set; }
    }
}
