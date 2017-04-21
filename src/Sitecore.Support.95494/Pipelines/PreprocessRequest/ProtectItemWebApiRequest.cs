using Sitecore.Pipelines.PreprocessRequest;
using System;
using System.Reflection;

namespace Sitecore.Support.Pipelines.PreprocessRequest
{
  public class ProtectItemWebApiRequest : PreprocessRequestProcessor
  {
    // Methods
    public override void Process(PreprocessRequestArgs args)
    {
      if (args.Context.Request.Url.LocalPath.StartsWith("/-/item/v1/", StringComparison.OrdinalIgnoreCase))
      {
        try
        {
          args.Context.Request.GetType().GetMethod("get_Form", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).Invoke(args.Context.Request, new object[0]);
        }
        catch (Exception)
        {
        }
      }
    }
  }
}