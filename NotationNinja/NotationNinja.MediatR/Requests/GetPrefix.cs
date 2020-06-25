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
    public class GetPrefix : IRequest<string>
    {
        public string Input { get; set; }

        internal class Handler : IRequestHandler<GetPrefix, string>
        {
            private readonly IMediator _mediator;

            public Handler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<string> Handle(GetPrefix request, CancellationToken cancellationToken)
            {
                var parser = await _mediator.Send(new GetParser { Input = request.Input });

                var ninja = new Services.NotationNinja(parser);

                return ninja.ToPrefix(request.Input);
            }
        }

        internal class Module : RequestModule<GetPrefix, string>
        {
            public override IExceptionsPipelineBuilder<GetPrefix, string> BuildPipeline(IPipelineBuilder<GetPrefix, string> builder)
            {
                return builder.AddHandler<Handler>();
            }
        }
    }
}
