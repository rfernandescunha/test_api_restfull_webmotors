using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebMotors.Application.Interfaces;
using WebMotors.Application.Services;
using WebMotors.Domain.Interfaces.IServices;
using WebMotors.Domain.Services;

namespace WebMotors.Infra.CrossCutting.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<Itb_AnuncioWebMotorsAppServices, tb_AnuncioWebMotorsAppServices>();

            serviceCollection.AddTransient<Itb_AnuncioWebMotorsServices, tb_AnuncioWebmotorsServices>();
        }
    }
}
