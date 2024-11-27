using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.HelperModels
{
    public class EvaluationResult
    {
        public int ID { get; set; }
        public string CandidateName { get; set; }
        public string TestDate { get; set; }
        public int TotalPoints { get; set; }
        public int AwardedPoints { get; set; }
        public string Result { get; set; }
    }
}
