﻿using Challenge.Nubimetrics.Infrastructure.Extensions;
using Challenge.Nubimetrics.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Infrastructure.Services
{
    public abstract class ServiceBase<TOptions> where TOptions : HttpOptionsBase, new()
    {
        protected readonly ILogger<ServiceBase<TOptions>> logger;
        private readonly IHttpClientFactory clientFactory;
        protected TOptions Options { get; }

        protected ServiceBase(ILogger<ServiceBase<TOptions>> logger, IHttpClientFactory clientFactory, IOptions<TOptions> options)
        {
            this.logger = logger;
            this.clientFactory = clientFactory;
            Options = options.Value;
        }

        public async Task<TResponse> Get<TResponse>(string url, AuthenticationHeaderValue authentication = null)
        {
            using (HttpClient client = clientFactory.CreateClient(Options.HttpClientName))
            {
                client.DefaultRequestHeaders.Authorization = authentication;

                logger.LogInformation("GET: {baseAddress}{url}", client.BaseAddress, url);

                using (HttpResponseMessage responseMessage = await client.GetAsync(url))
                {
                    var response = await responseMessage.GetContentWithStatusCodeValidated();

                    logger.LogInformation("GET {statusCode}: {baseAddress}{url}", responseMessage.StatusCode, client.BaseAddress, url);
                    logger.LogDebug("Response: {response}", response);

                    return JsonConvert.DeserializeObject<TResponse>(response);
                }
            }
        }

        public async Task<TResponse> Get<TResponse>(string url, AuthenticationHeaderValue authentication = null, params KeyValuePair<string, string>[] args)
        {
            using (HttpClient client = clientFactory.CreateClient(Options.HttpClientName))
            {
                client.DefaultRequestHeaders.Authorization = authentication;

                for (int i = 0; i < args.Length; i++)
                {
                    url = $"{url}{(i == 0 ? "?" : "&")}{args[i].Key}={args[i].Value}";
                }

                logger.LogInformation("GET: {baseAddress}{url}", client.BaseAddress, url);

                using (HttpResponseMessage responseMessage = await client.GetAsync(url))
                {
                    var response = await responseMessage.GetContentWithStatusCodeValidated();

                    logger.LogInformation("GET {statusCode}: {baseAddress}{url}", responseMessage.StatusCode, client.BaseAddress, url);
                    logger.LogDebug("Response: {response}", response);

                    return JsonConvert.DeserializeObject<TResponse>(response);
                }
            }
        }
    }
}