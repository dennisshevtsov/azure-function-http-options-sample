// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the Apache License, Version 2.0.
// See License.txt in the project root for license information.

namespace AzureFunctionHttpOptionsSample.FunctionApp
{
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Azure.WebJobs.Extensions.Http;
  using Microsoft.Extensions.Options;

  public sealed class HttpPostConfigureOptions : IPostConfigureOptions<HttpOptions>
  {
    public void PostConfigure(string name, HttpOptions options)
    {
      var setResponse = options.SetResponse;

      options.SetResponse = (request, value) =>
      {
        if (value is ObjectResult result)
        {
          result.Formatters.Insert(0, new HelloWorldOutputFormatter());
        }

        setResponse(request, value);
      };
    }
  }
}
