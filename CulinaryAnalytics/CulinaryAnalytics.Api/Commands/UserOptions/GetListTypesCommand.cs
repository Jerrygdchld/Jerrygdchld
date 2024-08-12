using CulinaryAnalytics.Core;
using MediatR;

namespace caapp.www.Server.Commands
{
    public record GetListTypesCommand() : IRequest<IStandardReply<List<string>>>;

    public class GetListTypesCommandHandler : IRequestHandler<GetListTypesCommand, IStandardReply<List<string>>>
    {
        public Task<IStandardReply<List<string>>> Handle(GetListTypesCommand request, CancellationToken cancellationToken)
        {
            var sr = IStandardReply<List<string>>.CreateStandardReply(true);
            sr.Response = new List<string>
                {
                    "Corporate Entity Type",
                    "Location Type",
                    "Person Type",
                    "Per Type",
                    "Unit Type"
                };
            return Task.FromResult(sr);
        }
    }
}
