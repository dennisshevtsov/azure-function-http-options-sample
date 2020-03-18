// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the Apache License, Version 2.0.
// See License.txt in the project root for license information.

[assembly: Microsoft.Azure.WebJobs.Hosting.WebJobsStartup(typeof(AzureFunctionHttpOptionsSample.FunctionApp.Startup))]

namespace AzureFunctionHttpOptionsSample.FunctionApp
{
  using Microsoft.Azure.WebJobs;
  using Microsoft.Azure.WebJobs.Extensions.Http;
  using Microsoft.Azure.WebJobs.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.DependencyInjection.Extensions;
  using Microsoft.Extensions.Options;

  public sealed class Startup : IWebJobsStartup
  {
    public void Configure(IWebJobsBuilder builder) =>
      builder.Services.TryAddEnumerable(
        ServiceDescriptor.Singleton<IPostConfigureOptions<HttpOptions>,
                                    HttpPostConfigureOptions>());
  }
}
