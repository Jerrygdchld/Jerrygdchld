using CulinaryAnalytics.Core;
using MediatR;

namespace caapp.www.Server.Commands
{
    public record GetLeftMenuOptionsCommand() : IRequest<IStandardReply<List<LeftMenuOption>>>;

    public class GetLeftMenuOptionsCommandHandler : IRequestHandler<GetLeftMenuOptionsCommand, IStandardReply<List<LeftMenuOption>>>
    {
        public Task<IStandardReply<List<LeftMenuOption>>> Handle(GetLeftMenuOptionsCommand request, CancellationToken cancellationToken)
        {
            var sr = IStandardReply<List<LeftMenuOption>>.CreateStandardReply(true);
            sr.Response = new List<LeftMenuOption>
                {
                    new() { Sequence = 1, Route = "dashboard", DisplayText = "Dashboard", DisplayInformation = "View user dashboard", Icon = "dash.png" },
                    new() { Sequence = 2, Route = "recipes", DisplayText = "Recipes", DisplayInformation = "View recipe list", Icon = "chef-hat.png" },
                    new() { Sequence = 3, Route = "inventory", DisplayText = "Inventory", DisplayInformation = "View inventory", Icon = "box.png" },
                    new() { Sequence = 4, Route = "sales", DisplayText = "Sales", DisplayInformation = "View sales data", Icon = "sale.png" },
                    new() { Sequence = 5, Route = "dailyproduction", DisplayText = "Daily Production", DisplayInformation = "View daily production", Icon = "Oven-Mitts.png" },
                    new() { Sequence = 6, Route = "ordermanagement", DisplayText = "Order Management", DisplayInformation = "View order management", Icon = "orders.png" },
                    new() { Sequence = 7, Route = "expenses", DisplayText = "Expenses", DisplayInformation = "View expenses", Icon = "Wallet-Money.png" }
                    //new() { Sequence = 5, Route = "/employees", DisplayText = "Employees", DisplayInformation = "View employees", Icon = "icons/group.png" },
                    //new() { Sequence = 6, Route = "/admin", DisplayText = "Admin", DisplayInformation = "Admin page", Icon = "icons/server.png" },
                    //new() { Sequence = 7, Route = "/picklist", DisplayText = "Edit Pick List", DisplayInformation = "Edit Pick List", Icon = "icons/text_columns.png" }
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
