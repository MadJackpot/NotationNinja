using MediatR;
using MediatR.Extensions.FluentBuilder;
using MediatR.Extensions.FluentBuilder.Builders;
using NotationNinja.Services.NotationParsers;
using NotationNinja.Services.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotationNinja.MediatR.Requests
{
    public class GetParser : IRequest<INotationParser>
    {
        public string Input { get; set; }

        internal class Handler : IRequestHandler<GetParser, INotationParser>
        {
            public Task<INotationParser> Handle(GetParser request, CancellationToken cancellationToken)
            {
                if (request.Input[0].IsSymbol())
                {
                    return Task.FromResult<INotationParser>(new PrefixNotationParser());
                }
                else if (request.Input.Last().IsSymbol())
                {
                    return Task.FromResult<INotationParser>(new PostfixNotationParser());
                }

                return Task.FromResult<INotationParser>(new InfixNotationParser());
            }
        }

        internal class Module : RequestModule<GetParser, INotationParser>
        {
            public override IExceptionsPipelineBuilder<GetParser, INotationParser> BuildPipeline(IPipelineBuilder<GetParser, INotationParser> builder)
            {
                return builder.AddHandler<Handler>();
            }
        }
    }
}
