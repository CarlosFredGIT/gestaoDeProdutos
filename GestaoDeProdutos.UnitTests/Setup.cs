using GestaoDeProdutos.Domain.Interfaces.Repositories;
using GestaoDeProdutos.Domain.Interfaces.Services;
using GestaoDeProdutos.Domain.Services;
using GestaoDeProdutos.Infra.Data.Contexts;
using GestaoDeProdutos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.UnitTests
{
    public class Setup : Xunit.Di.Setup
    {
        protected override void Configure()
        {
            ConfigureAppConfiguration((hostingContext, config) => 
            {
                #region Ativar a Injeção de dependência no XUnit

                bool reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);
                if (hostingContext.HostingEnvironment.IsDevelopment())
                    config.AddUserSecrets<Setup>(true, reloadOnChange);

                #endregion
            });

            ConfigureServices((context, services) =>
            {
                #region Localizar o appsettings.json

                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);

                #endregion

                #region Captura a connectionstring

                var root = configurationBuilder.Build();
                var connectionString = root.GetSection("ConnectionStrings").GetSection("GestaoDeProduto").Value;

                #endregion

                #region Fazendo as injeção de dependência

                //Injetando a connection string na classe SqlServerContext
                services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));

                //Injetando a repository na interface 
                services.AddTransient<IProdutoRepository, ProdutoRepository>();
                services.AddTransient<IFornecedorRepository, FornecedorRepository>();

                //Injetando a domain service na interface 
                services.AddTransient<IProdutoDomainService, ProdutoDomainService>();

                #endregion
            });    
        }
    }
}
