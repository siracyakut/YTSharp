using YTSharp.Business.Abstract;
using YTSharp.Business.Concrete;

namespace YTSharp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddScoped<IVideoManager, VideoManager>();
            builder.Services.AddScoped<ISearchManager, SearchManager>();
            builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
            //builder.WebHost.ConfigureKestrel(options => options.ListenAnyIP(5000));

            var app = builder.Build();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors("corspolicy");
            app.Run();
        }
    }
}
