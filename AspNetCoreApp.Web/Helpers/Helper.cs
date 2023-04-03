using AspNetCoreApp.Web.Models;

namespace AspNetCoreApp.Web.Helpers
{
    public class Helper : IHelper
    {
        private readonly AppDbContext _context;

        public Helper(AppDbContext context)
        {
            _context = context;
        }

        public string Upper(string text)
        {
            return text.ToUpper();
        }
    }
}
