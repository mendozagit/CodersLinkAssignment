using CodersLinkAssignment.Aplication.Parameters;

namespace CodersLinkAssignment.Aplication.Features.Customers.Queries
{
    public class GetAllCustomerParameters : RequestParameter
    {
        public string LastName { get; set; }
        public string SortingDirection { get; set; }
    }
}
