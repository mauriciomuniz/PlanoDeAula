using System.Globalization;

namespace PlanoDeAula.API.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("en");

            //var fisrtitem = requestedCulture.Split(",")[0];
            //var cultureInfo = new CultureInfo(fisrtitem);

            if(string.IsNullOrWhiteSpace(requestedCulture) == false &&
                supportedLanguages.Any(c=>c.Name.Equals(requestedCulture)))
            {
                cultureInfo = new CultureInfo(requestedCulture); 
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
