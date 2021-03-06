﻿// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

namespace Microsoft.Azure.Cosmos.Tracing.TraceData
{
    using System;
    using Microsoft.Azure.Cosmos.Diagnostics;

    internal sealed class CosmosDiagnosticsTraceDatum : TraceDatum
    {
        public CosmosDiagnosticsInternal CosmosDiagnostics { get; }

        public CosmosDiagnosticsTraceDatum(CosmosDiagnosticsInternal cosmosDiagnostics)
        {
            this.CosmosDiagnostics = cosmosDiagnostics ?? throw new ArgumentNullException(nameof(cosmosDiagnostics));
        }

        internal override void Accept(ITraceDatumVisitor traceDatumVisitor)
        {
            traceDatumVisitor.Visit(this);
        }
    }
}
