using MediatR;
using MediatR.Extensions.FluentBuilder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NotationNinja.MediatR
{
    public class MediatRModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddMediatR();
            services.AddRequestModules(typeof(MediatRModule).Assembly);
        }
    }
}
