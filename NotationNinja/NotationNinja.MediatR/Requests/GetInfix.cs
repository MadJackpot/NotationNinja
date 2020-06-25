using MediatR;
using MediatR.Extensions.FluentBuilder;
using MediatR.Extensions.FluentBuilder.Builders;
using NotationNinja.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotationNinja.MediatR.Requests
{
    public class GetInfix : IRequest<string>
    {
        public string Input { get; set; }

        internal class Handler : IRequestHandler<GetInfix, string>
        {
            private readonly IMediator _mediator;

            public Handler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<string> Handle(GetInfix request, CancellationToken cancellationToken)
            {
                var parser = await _mediator.Send(new GetParser { Input = request.Input });

                var ninja = new Services.NotationNinja(parser);

                return ninja.ToInfix(request.Input);
            }
        }

        internal class Module : RequestModule<GetInfix, string>
        {
            public override IExceptionsPipelineBuilder<GetInfix, string> BuildPipeline(IPipelineBuilder<GetInfix, string> builder)
            {
                return builder.AddHandler<Handler>();
            }
        }
    }
}
