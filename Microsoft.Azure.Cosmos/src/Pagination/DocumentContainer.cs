﻿// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

namespace Microsoft.Azure.Cosmos.Pagination
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.ChangeFeed.Pagination;
    using Microsoft.Azure.Cosmos.CosmosElements;
    using Microsoft.Azure.Cosmos.Json;
    using Microsoft.Azure.Cosmos.Query.Core;
    using Microsoft.Azure.Cosmos.Query.Core.Monads;
    using Microsoft.Azure.Cosmos.Query.Core.Pipeline;
    using Microsoft.Azure.Cosmos.ReadFeed.Pagination;
    using Microsoft.Azure.Cosmos.Tracing;
    using Microsoft.Azure.Documents;

    /// <summary>
    /// Composes a <see cref="IMonadicDocumentContainer"/> and creates an <see cref="IDocumentContainer"/>.
    /// </summary>
    internal sealed class DocumentContainer : IDocumentContainer
    {
        private readonly IMonadicDocumentContainer monadicDocumentContainer;

        public DocumentContainer(IMonadicDocumentContainer monadicDocumentContainer)
        {
            this.monadicDocumentContainer = monadicDocumentContainer ?? throw new ArgumentNullException(nameof(monadicDocumentContainer));
        }

        public Task<TryCatch<List<FeedRangeEpk>>> MonadicGetChildRangeAsync(
            FeedRangeInternal feedRange,
            ITrace trace,
            CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicGetChildRangeAsync(
                feedRange,
                trace,
                cancellationToken);

        public Task<List<FeedRangeEpk>> GetChildRangeAsync(
            FeedRangeInternal feedRange,
            ITrace trace,
            CancellationToken cancellationToken) => TryCatch<List<FeedRangeInternal>>.UnsafeGetResultAsync(
                this.MonadicGetChildRangeAsync(
                    feedRange,
                    trace,
                    cancellationToken),
                cancellationToken);

        public Task<TryCatch<List<FeedRangeEpk>>> MonadicGetFeedRangesAsync(
            ITrace trace,
            CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicGetFeedRangesAsync(
                trace,
                cancellationToken);

        public Task<List<FeedRangeEpk>> GetFeedRangesAsync(
            ITrace trace,
            CancellationToken cancellationToken) => TryCatch<List<FeedRangeEpk>>.UnsafeGetResultAsync(
                this.MonadicGetFeedRangesAsync(
                    trace,
                    cancellationToken),
                cancellationToken);

        public Task RefreshProviderAsync(ITrace trace, CancellationToken cancellationToken) => TryCatch.UnsafeWaitAsync(
            this.MonadicRefreshProviderAsync(trace, cancellationToken),
            cancellationToken);

        public Task<TryCatch> MonadicRefreshProviderAsync(ITrace trace, CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicRefreshProviderAsync(
            trace,
            cancellationToken);

        public Task<TryCatch<Record>> MonadicCreateItemAsync(
            CosmosObject payload,
            CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicCreateItemAsync(
                payload,
                cancellationToken);

        public Task<Record> CreateItemAsync(
            CosmosObject payload,
            CancellationToken cancellationToken) => TryCatch<Record>.UnsafeGetResultAsync(
                this.MonadicCreateItemAsync(
                    payload,
                    cancellationToken),
                cancellationToken);

        public Task<TryCatch<Record>> MonadicReadItemAsync(
            CosmosElement partitionKey,
            string identifer,
            CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicReadItemAsync(
                partitionKey,
                identifer,
                cancellationToken);

        public Task<Record> ReadItemAsync(
            CosmosElement partitionKey,
            string identifier,
            CancellationToken cancellationToken) => TryCatch<Record>.UnsafeGetResultAsync(
                this.MonadicReadItemAsync(
                    partitionKey,
                    identifier,
                    cancellationToken),
                cancellationToken);

        public Task<TryCatch<ReadFeedPage>> MonadicReadFeedAsync(
            ReadFeedState readFeedState,
            FeedRangeInternal feedRange,
            QueryRequestOptions queryRequestOptions,
            int pageSize,
            ITrace trace,
            CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicReadFeedAsync(
                readFeedState,
                feedRange,
                queryRequestOptions,
                pageSize,
                trace,
                cancellationToken);

        public Task<ReadFeedPage> ReadFeedAsync(
            ReadFeedState readFeedState,
            FeedRangeInternal feedRange,
            QueryRequestOptions queryRequestOptions,
            int pageSize,
            ITrace trace,
            CancellationToken cancellationToken) => TryCatch<ReadFeedPage>.UnsafeGetResultAsync(
                this.MonadicReadFeedAsync(
                    readFeedState,
                    feedRange,
                    queryRequestOptions,
                    pageSize,
                    trace,
                    cancellationToken),
                cancellationToken);

        public Task<TryCatch<QueryPage>> MonadicQueryAsync(
            SqlQuerySpec sqlQuerySpec,
            string continuationToken,
            FeedRangeInternal feedRange,
            int pageSize,
            ITrace trace,
            CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicQueryAsync(
                sqlQuerySpec,
                continuationToken,
                feedRange,
                pageSize,
                trace,
                cancellationToken);

        public Task<QueryPage> QueryAsync(
            SqlQuerySpec sqlQuerySpec,
            string continuationToken,
            FeedRangeInternal feedRange,
            int pageSize,
            ITrace trace,
            CancellationToken cancellationToken) => TryCatch<QueryPage>.UnsafeGetResultAsync(
                this.MonadicQueryAsync(
                    sqlQuerySpec,
                    continuationToken,
                    feedRange,
                    pageSize,
                    trace,
                    cancellationToken),
                cancellationToken);

        public Task<TryCatch> MonadicSplitAsync(
            FeedRangeInternal feedRange,
            CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicSplitAsync(
                feedRange,
                cancellationToken);

        public Task SplitAsync(
            FeedRangeInternal feedRange,
            CancellationToken cancellationToken) => TryCatch.UnsafeWaitAsync(
                this.MonadicSplitAsync(
                    feedRange,
                    cancellationToken),
                cancellationToken);

        public Task<TryCatch> MonadicMergeAsync(
            FeedRangeInternal feedRange1,
            FeedRangeInternal feedRange2,
            CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicMergeAsync(
                feedRange1,
                feedRange2,
                cancellationToken);

        public Task MergeAsync(
            FeedRangeInternal feedRange1,
            FeedRangeInternal feedRange2,
            CancellationToken cancellationToken) => TryCatch.UnsafeWaitAsync(
                this.MonadicMergeAsync(
                    feedRange1,
                    feedRange2,
                    cancellationToken),
                cancellationToken);

        public Task<ChangeFeedPage> ChangeFeedAsync(
            ChangeFeedState state,
            FeedRangeInternal feedRange,
            int pageSize,
            ChangeFeedMode changeFeedMode,
            JsonSerializationFormat? jsonSerializationFormat,
            ITrace trace,
            CancellationToken cancellationToken) => TryCatch<ChangeFeedPage>.UnsafeGetResultAsync(
                this.MonadicChangeFeedAsync(
                    state,
                    feedRange,
                    pageSize,
                    changeFeedMode,
                    jsonSerializationFormat,
                    trace,
                    cancellationToken), 
                cancellationToken);

        public Task<TryCatch<ChangeFeedPage>> MonadicChangeFeedAsync(
            ChangeFeedState state,
            FeedRangeInternal feedRange,
            int pageSize,
            ChangeFeedMode changeFeedMode,
            JsonSerializationFormat? jsonSerializationFormat,
            ITrace trace,
            CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicChangeFeedAsync(
                state,
                feedRange,
                pageSize,
                changeFeedMode,
                jsonSerializationFormat,
                trace,
                cancellationToken);

        public Task<string> GetResourceIdentifierAsync(
            ITrace trace,
            CancellationToken cancellationToken) => TryCatch<string>.UnsafeGetResultAsync(
                this.MonadicGetResourceIdentifierAsync(trace, cancellationToken),
                cancellationToken);

        public Task<TryCatch<string>> MonadicGetResourceIdentifierAsync(
            ITrace trace, 
            CancellationToken cancellationToken) => this.monadicDocumentContainer.MonadicGetResourceIdentifierAsync(trace, cancellationToken);
    }
}
