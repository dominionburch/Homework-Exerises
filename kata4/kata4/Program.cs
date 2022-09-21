namespace kata4
{
    public class Program
    {
        public static System.Collections.Generic.List<Models.User> userList = new List<Models.User>();
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

            //Adding two sample record
            var newRecordA = new Models.User();
            newRecordA.Id = 10;
            newRecordA.Firstname = "Super";
            newRecordA.Lastname = "Man";
            newRecordA.FavoriteCartoon = "Snoopy";
            userList.Add(newRecordA);

            var newRecordB = new Models.User();
            newRecordB.Id = 11;
            newRecordB.Firstname = "Wonder";
            newRecordB.Lastname = "Woman";
            newRecordB.FavoriteCartoon = "TellyTubbies";
            userList.Add(newRecordB);

            app.Run();
        }
    }
}