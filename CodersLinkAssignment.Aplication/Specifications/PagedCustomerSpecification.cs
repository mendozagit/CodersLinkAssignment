using Ardalis.Specification;
using CodersLinkAssignment.Domain.Entities;

namespace CodersLinkAssignment.Aplication.Specifications
{
    public sealed class PagedCustomerSpecification : Specification<Customer>
    {
        public PagedCustomerSpecification(int pageSize,
            int pageNumber,
            string lastName,
            string sortingDirection)
        {
            Query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!string.IsNullOrEmpty(lastName))
                Query.Search(x => x.LastName, lastName);


            sortingDirection ??= string.Empty;

            switch (sortingDirection.ToUpper())
            {
                case "A":
                    //A - flag for Ascending
                    Query.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
                    break;
                case "D":
                    //D - flag for Descending
                    Query.OrderByDescending(x => x.LastName).ThenBy(x => x.FirstName);
                    break;
                default:
                    //Any other flag
                    Query.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
                    break;
            }
        }
    }
}
