using CulinaryAnalytics.Core.Implementations;
using MediatR;

namespace caapp.www.Server.Commands
{
    public record GetListTypesCommand() : IRequest<StandardReply<List<string>>>;

    public class GetListTypesCommandHandler : IRequestHandler<GetListTypesCommand, StandardReply<List<string>>>
    {
        public Task<StandardReply<List<string>>> Handle(GetListTypesCommand request, CancellationToken cancellationToken)
        {
            var sr = new StandardReply<List<string>>
            {
                Response = new List<string>
                {
                    "Corporate Entity Type",
                    "Location Type",
                    "Person Type",
                    "Per Type",
                    "Unit Type"
                }
            };
            return Task.FromResult(sr);
        }
    }
}
