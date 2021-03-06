﻿//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------


namespace CosmosCTL
{
    using System.Threading;
    using System.Threading.Tasks;
    using App.Metrics;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Extensions.Logging;

    internal interface ICTLScenario
    {
        public Task InitializeAsync(
            CTLConfig config,
            CosmosClient cosmosClient,
            ILogger logger);

        public Task RunAsync(
            CTLConfig config,
            CosmosClient cosmosClient,
            ILogger logger,
            IMetrics metrics,
            CancellationToken cancellationToken);
    }
}
