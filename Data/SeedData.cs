using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace App_Lanches.Data
{
    public static class SeedData
    {
        // cria o perfil que sera atribuido ao usuario
        public static async Task CreateRoles(IServiceProvider serviceProvider,
           IConfiguration Configuration)
        {
            //incluir perfis customizados
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>(); // instância que permite gerenciar os perfis
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>(); // instância que permite gerenciar o usuario 

            //define os perfis em um array de strings
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;

            //percorre o array de strings 
            //verifica se o perfil já existe
            foreach (var roleName in roleNames)
            {
                // cria perfis e os inclui no banco de dados
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // cria um super usuário que pode manter a aplicação web
            var poweruser = new IdentityUser
            {
                //obtem o nome e o email do arquivo de configuração
                UserName = Configuration.GetSection("UserSettings")["UserName"], // appsenttings
                Email = Configuration.GetSection("UserSettings")["UserEmail"]
            };

            //obtem a senha do arquivo de configuração
            string userPassword = Configuration.GetSection("UserSettings")["UserPassword"];

            //verifica se existe um usuário com o email informado
            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);

            if (user == null)
            {
                //cria o super usuário com os dados informados
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // atribui o usuário ao perfil Admin
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}
