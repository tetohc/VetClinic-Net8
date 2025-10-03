using Proyecto1_JerryHurtado.Managers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Managers.Interfaces.Location;
using Proyecto1_JerryHurtado.Managers.Location;
using Proyecto1_JerryHurtado.Models.ViewModels;
using Proyecto1_JerryHurtado.Models.ViewModels.Location;

namespace Proyecto1_JerryHurtado
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Registro de dependencias

            // Inyección de dependencias para los crud
            builder.Services.AddSingleton<IManager<EmployeeVM>, EmployeeManager>();
            builder.Services.AddSingleton<IManager<PetVM>, PetManager>();
            builder.Services.AddSingleton<IManager<CustomerVM>, CustomerManager>();
            builder.Services.AddSingleton<IManager<ProcedureVM>, ProcedureManager>();

            // Solo lectura
            builder.Services.AddSingleton<IReadOnlyManager<ProcedureTypeVM>, ProcedureTypeManager>();
            builder.Services.AddSingleton<IReadOnlyManager<ProvinceVM>, ProvinceManager>();
            builder.Services.AddSingleton<IRelationalManager<CantonVM>, CantonManager>();
            builder.Services.AddSingleton<IRelationalManager<DistrictVM>, DistrictManager>();

            #endregion Registro de dependencias

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

            app.Run();
        }
    }
}