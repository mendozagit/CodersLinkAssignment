namespace CodersLinkAssignment.Aplication.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(T data, int pageSize, int pageNumber)
        {
            Data = data;
            PageSize = pageSize;
            PageNumber = pageNumber;
            Message = null;
            Success = true;
            Errors = null;
        }
    }
}
