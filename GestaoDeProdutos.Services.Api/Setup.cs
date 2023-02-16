using GestaoDeFornecedors.Domain.Services;
using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.Services;
using GestaoDeProdutos.Domain.Interfaces.Repositories;
using GestaoDeProdutos.Domain.Interfaces.Services;
using GestaoDeProdutos.Domain.Services;
using GestaoDeProdutos.Infra.Data.Contexts;
using GestaoDeProdutos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProdutos.Services.Api
{
    public static class Setup
    {
        public static void AddRegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IProdutoApplicationService, ProdutoApplicationService>();
            builder.Services.AddTransient<IFornecedorApplicationService, FornecedorApplicationService>();

            builder.Services.AddTransient<IProdutoDomainService, ProdutoDomainService>();
            builder.Services.AddTransient<IFornecedorDomainService, FornecedorDomainService>();

            builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();
        }

        public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("GestaoDeProduto");
            builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddAutoMapperServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
