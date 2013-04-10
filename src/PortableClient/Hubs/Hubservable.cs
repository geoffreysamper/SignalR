// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.SignalR.Client.Infrastructure;
using Microsoft.AspNet.SignalR.Infrastructure;
using System.Collections.Generic;

namespace Microsoft.AspNet.SignalR.Client.Hubs
{
    /// <summary>
    /// <see cref="T:System.IObservable{object[]}"/> implementation of a hub event.
    /// </summary>
    public class Hubservable
    {
        private readonly string _eventName;
        private readonly IHubProxy _proxy;

        public Hubservable(IHubProxy proxy, string eventName)
        {
            _proxy = proxy;
            _eventName = eventName;
        }
    }
}
