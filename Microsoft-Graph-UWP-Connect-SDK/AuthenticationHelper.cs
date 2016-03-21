//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
//See LICENSE in the project root for license information.

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.Storage;
using Microsoft.Graph.OAuth2;
using Microsoft.Graph;

namespace Microsoft_Graph_UWP_Connect_SDK
{
    internal static class AuthenticationHelper
    {
        // The Client ID is used by the application to uniquely identify itself to Microsoft Azure Active Directory (AD).
        static string clientId = App.Current.Resources["ida:ClientID"].ToString();

        static string returnUrl = App.Current.Resources["ida:ReturnUrl"].ToString();

        private static GraphServiceClient graphClient = null;

        // Get a Graph client.
        public static async Task<GraphServiceClient> GetAuthenticatedClientAsync()
        {
            if (graphClient == null)
            {
                var authenticationProvider = new OAuth2AuthenticationProvider(
                    new AppConfig
                    {
                        ClientId = clientId,
                        ReturnUrl = returnUrl,
                        Scopes = new string[]
                        {
                        "openid",
                        "offline_access",
                        "https://graph.microsoft.com/User.Read",
                        "https://graph.microsoft.com/Mail.Send",
                        },
                    });

                await authenticationProvider.AuthenticateAsync();

                graphClient = new GraphServiceClient(authenticationProvider);
            }

            return graphClient;
        }

        /// <summary>
        /// Signs the user out of the service.
        /// </summary>
        public static void SignOut()
        {
            //Dispose Graph client
            graphClient.Dispose();
            graphClient = null;

        }

    }
}
