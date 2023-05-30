using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using System.Text.Json.Serialization;

public class EnableQueryWithCountAttribute : EnableQueryAttribute
{
  public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
  {
    base.OnActionExecuted(actionExecutedContext);

    if (actionExecutedContext.HttpContext.Request.Query.ContainsKey("$count"))
    {
      if (actionExecutedContext.Result is ObjectResult obj && obj.Value is IQueryable qry)
      {
        if (actionExecutedContext.HttpContext.Request.Query.Keys.Count == 1)
        {
          obj.Value = actionExecutedContext.HttpContext.Request.ODataFeature().TotalCount;
        }
        else
        {
          obj.Value = new ODataResponse()
          {
            Count = actionExecutedContext.HttpContext.Request.ODataFeature().TotalCount,
            Value = qry
          };
        }
      }
    }
  }

  public class ODataResponse
  {
    [JsonPropertyName("@odata.count")]
    public long? Count { get; set; }

    [JsonPropertyName("value")]
    public IQueryable? Value { get; set; }
  }
}