namespace WebApplication1
{
    public class Program
    {
        public static System.Collections.Generic.List<WebApplication1.Models.User> userList = new List<Models.User>();
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //Add sample starting data
            var newUser = new Models.User();
            newUser.Id = 10;
            newUser.FirstName = "Jean-Luc";
            newUser.LastName = "Picard";
            newUser.FavoriteCartoon = "Snoopy";
            userList.Add(newUser);

            app.Run();
        }
    }
}