using Microsoft.AspNetCore.Http;

namespace GenericComputationPlatform.Extensions;

public static class HttpRequestExtensions
{
    public static bool IsAjax(this HttpRequest request)
    {
        return request.Headers["X-Requested-With"] == "XMLHttpRequest";
    }

    public static bool IsAjaxRequest(this HttpContext context)
    {
        return context.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
    }


    public static void SetIntegrityView(this HttpContext context, string view)
    {
        context.Response.Cookies.Append("IntegrityView", view); // non Essential Cookie, requires user cookie consent
    }

    public static string GetIntegrityView(this HttpContext context)
    {
        return context.Request.Cookies["IntegrityView"] ?? "";
    }


    public static bool UseCardOutputDisplay(this HttpContext context)
    {
        return bool.TryParse(context.Request.Cookies["UseCardOutputDisplay"], out bool val) && val;
    }

    public static void SetUseCardOutputDisplay(this HttpContext context, bool use)
    {
        context.Response.Cookies.Append("UseCardOutputDisplay", use.ToString()); // non Essential Cookie, requires user cookie consent
    }


    public static bool UseGeneSymbolForTargetDisplay(this HttpContext context)
    {
        return bool.TryParse(context.Request.Cookies["UseGeneSymbolForTargetDisplay"], out bool val) && val;
    }

    public static void SetUseGeneSymbolForTargetDisplay(this HttpContext context, bool use)
    {
        context.Response.Cookies.Append("UseGeneSymbolForTargetDisplay", use.ToString()); // non Essential Cookie, requires user cookie consent
    }
}
