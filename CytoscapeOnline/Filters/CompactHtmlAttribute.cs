using System.Web.Mvc;

namespace CytoscapeOnline
{
    public class CompactHtmlAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                var response = filterContext.HttpContext.Response;

                if (response.Filter != null)
                {
                    response.Filter = new ReduceHtmlStream(response.Filter, response.ContentEncoding);
                }
            }
            else
            {
            }
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }
    }
}
