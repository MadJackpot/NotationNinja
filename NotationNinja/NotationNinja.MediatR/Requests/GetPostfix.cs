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
    public class GetPostfix : IRequest<string>
    {
        public string Input { get; set; }

        internal class Handler : IRequestHandler<GetPostfix, string>
        {
            private readonly IMediator _mediator;

            public Handler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<string> Handle(GetPostfix request, CancellationToken cancellationToken)
            {
                var parser = await _mediator.Send(new GetParser { Input = request.Input });

                var ninja = new Services.NotationNinja(parser);

                return ninja.ToPostfix(request.Input);
            }
        }

        internal class Module : RequestModule<GetPostfix, string>
        {
            public override IExceptionsPipelineBuilder<GetPostfix, string> BuildPipeline(IPipelineBuilder<GetPostfix, string> builder)
            {
                return builder.AddHandler<Handler>();
            }
        }
    }
}
