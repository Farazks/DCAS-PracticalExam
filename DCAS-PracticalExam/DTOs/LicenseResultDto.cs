using System;

namespace DCAS_PracticalExam.DTOs
{
    public class LicenseResultDto
    {
        public string RequestNumber { get; set; }
        public string TestResult { get; set; } // "Pass" or "Fail"
    }
}
