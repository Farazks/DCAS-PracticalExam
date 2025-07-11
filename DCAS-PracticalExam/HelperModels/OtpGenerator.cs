using System;

namespace DCAS_PracticalExam.Helper_Model
{
    public static class OtpGenerator
    {  
      public static string GenerateOTP()
      {
                // Generate a random 6-digit OTP
                Random random = new Random();
                int otp = random.Next(100000, 999999);
                return otp.ToString();
      }
        
    }
}
