using CulinaryAnalytics.Core.Implementations;
using MediatR;

namespace caapp.www.Server.Commands
{
    public record GetLeftMenuOptionsCommand() : IRequest<StandardReply<List<LeftMenuOption>>>;

    public class GetLeftMenuOptionsCommandHandler : IRequestHandler<GetLeftMenuOptionsCommand, StandardReply<List<LeftMenuOption>>>
    {
        public Task<StandardReply<List<LeftMenuOption>>> Handle(GetLeftMenuOptionsCommand request, CancellationToken cancellationToken)
        {
            var sr = new StandardReply<List<LeftMenuOption>>
            {
                Response = new List<LeftMenuOption>
                {
                    new() { Sequence = 1, Route = "/dashboard", DisplayText = "Dashboard", DisplayInformation = "View user dashboard", Icon = "icons/layout.png" },
                    new() { Sequence = 2, Route = "/recipes", DisplayText = "Recipes", DisplayInformation = "View recipe list", Icon = "icons/report_key.png" },
                    new() { Sequence = 3, Route = "/inventory", DisplayText = "Inventory", DisplayInformation = "View inventory", Icon = "icons/building.png" },
                    new() { Sequence = 4, Route = "/sales", DisplayText = "Sales", DisplayInformation = "View sales data", Icon = "icons/chart_line.png" },
                    new() { Sequence = 5, Route = "/employees", DisplayText = "Employees", DisplayInformation = "View employees", Icon = "icons/group.png" },
                    new() { Sequence = 6, Route = "/admin", DisplayText = "Admin", DisplayInformation = "Admin page", Icon = "icons/server.png" },
                    new() { Sequence = 7, Route = "/picklist", DisplayText = "Edit Pick List", DisplayInformation = "Edit Pick List", Icon = "icons/text_columns.png" }
                }
            };
            return Task.FromResult(sr);
        }
    }

    public class LeftMenuOption
    {
        public int Sequence { get; set; }
        public string? Route { get; set; }
        public string? DisplayText { get; set; }
        public string? DisplayInformation { get; set; }
        public string? Icon { get; set; }
    }
}
