using Microsoft.AspNetCore.Mvc.Formatters;
// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the Apache License, Version 2.0.
// See License.txt in the project root for license information.

namespace AzureFunctionHttpOptionsSample.FunctionApp
{
  using System.Net.Mime;
  using System.Text;
  using System.Threading.Tasks;

  using Microsoft.Net.Http.Headers;

  public sealed class HelloWorldOutputFormatter : TextOutputFormatter
  {
    public HelloWorldOutputFormatter()
    {
      SupportedEncodings.Add(Encoding.UTF8);
      SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(MediaTypeNames.Application.Json).CopyAsReadOnly());
    }

    public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
      => await context.HttpContext.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("{ \"message\": \"Hello World!\" }"));
  }
}
