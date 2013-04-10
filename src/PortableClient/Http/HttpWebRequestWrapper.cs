// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
//#if (NET4 || NET45)
//using System.Security.Cryptography.X509Certificates;
//#endif

namespace Microsoft.AspNet.SignalR.Client.Http
{
    public class HttpWebRequestWrapper : IRequest
    {
        private readonly HttpWebRequest _request;

        private IDictionary<string, Action<HttpWebRequest, string>> _restrictedHeadersSet = new Dictionary<string, Action<HttpWebRequest, string>>() {
                                                                        { HttpRequestHeader.Accept.ToString(), (request, value) => { request.Accept = value; } },                                                                       
                                                                        { HttpRequestHeader.ContentType.ToString(), (request, value) => { request.ContentType = value; } }
                                                                    };

        public HttpWebRequestWrapper(HttpWebRequest request)
        {
            _request = request;
        }

        public string UserAgent
        {
            get
            {
                // return _request.UserAgent;
                return null;
            }
            set
            {
                // _request.UserAgent = value;
            }
        }

        public ICredentials Credentials
        {
            get
            {
                return _request.Credentials;
            }
            set
            {
                _request.Credentials = value;
            }
        }

        public CookieContainer CookieContainer
        {
            get
            {
                return _request.CookieContainer;
            }
            set
            {
                _request.CookieContainer = value;
            }
        }

        public string Accept
        {
            get
            {
                return _request.Accept;
            }
            set
            {
                _request.Accept = value;
            }
        }

        public void Abort()
        {
            _request.Abort();
        }

        public void SetRequestHeaders(IDictionary<string, string> headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }

            foreach (KeyValuePair<string, string> headerEntry in headers)
            {
                if (!_restrictedHeadersSet.Keys.Contains(headerEntry.Key))
                {
//#if (!WINDOWS_PHONE && !SILVERLIGHT)
//                    _request.Headers.Add(headerEntry.Key, headerEntry.Value);
//#endif
                }
                else
                {
                    Action<HttpWebRequest, string> setHeaderAction;

                    if (_restrictedHeadersSet.TryGetValue(headerEntry.Key, out setHeaderAction))
                    {
                        setHeaderAction.Invoke(_request, headerEntry.Value);
                    }
                }
            }
        }

//#if (NET4 || NET45)
//        public void AddClientCerts(X509CertificateCollection certificates)
//        {
//            if (certificates == null)
//            {
//                throw new ArgumentNullException("certificates");
//            }

//            _request.ClientCertificates = certificates;
//        }
//#endif
    }
}
