using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using DCAS_PracticalExam.Context;
using DCAS_PracticalExam.HelperModels;
using SelectPdf;

namespace DCAS_PracticalExam.Repository
{
    public interface ICommonServices<T> where T : class
    {
        Task<List<T>> GetAllDataAsync();
        Task<int> AddDataAsync(T data);
        Task<T> GetCardByUniqueNumberAsync(Expression<Func<T, bool>> predicate);
        string GenerateFullUniqueNumber(string uniqueNo);
        Task<string> SendEmailWithAttachement(string email, string url, string subject, string body, string attachmentName);
        Task<int> EditDataAsync(T data);
    }//ICommonServices End

    public class CommonServices<T> : ICommonServices<T> where T : class
    {
        private readonly PracticalExamContext _Db;
        private readonly DbSet<T> _entities;
        private readonly MailSender emailSender;
        private readonly IConfiguration _config;
        private readonly string baseUrl;

        public async Task<List<T>> GetAllDataAsync()
        {
            var data = await _entities.ToListAsync();
            return data;
        }
        public CommonServices(PracticalExamContext db, IOptions<SmtpConfig> smtpConfigModel, IConfiguration config)
        {
            _Db = db;
            _config = config;
            _entities = _Db.Set<T>();
            emailSender = new MailSender(smtpConfigModel);
            baseUrl = _config.GetValue<string>("BaseUrl");
        }

        public async Task<int> AddDataAsync(T data)
        {
            await _entities.AddAsync(data);
            var result = await _Db.SaveChangesAsync();
            if (result > 0) return result;
            else return 0;
        }

        public async Task<T> GetCardByUniqueNumberAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var data = await _entities.FirstOrDefaultAsync(predicate);
                if (data == null)
                {
                    return null;
                }
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GenerateFullUniqueNumber(string uniqueNo)
        {
            string result = $"DCAS/{DateTime.Now.ToString("yy")}/{uniqueNo}";
            return result;
        }

        public async Task<string> SendEmailWithAttachement(string email, string url, string subject, string body, string attachmentName)
        {
            var viewAsPdf = new HtmlToPdf();
            PdfDocument doc = viewAsPdf.ConvertUrl(baseUrl + url);

            var ms = new MemoryStream();
            doc.Save(ms);
            var pdfBytes = ms.ToArray();

            EmailOptions ops = new EmailOptions();
            ops.toEmail = email;
            ops.attachment = pdfBytes;
            ops.subject = subject;
            ops.body = body;
            ops.licenceNo = attachmentName;
            string message = await emailSender.SendEmailPublic(ops);
            return message;
        }

        public async Task<int> EditDataAsync(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("entity");
            }
            var result = await _Db.SaveChangesAsync();
            return result;
        }
    }

}
