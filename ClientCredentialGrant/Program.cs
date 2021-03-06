﻿using System;
using System.Net.Http;

using Constants;

using DotNetOpenAuth.OAuth2;

namespace ClientCredentialGrant
{
    internal class Program
    {
        private static WebServerClient _webServerClient;
        private static string _accessToken;

        private static void Main(string[] args)
        {
            InitializeWebServerClient();

            Console.WriteLine("Requesting Token...");
            RequestToken();

            Console.WriteLine("Access Token: {0}", _accessToken);

            Console.WriteLine("Access Protected Resource");
            AccessProtectedResource();
            Console.ReadLine();
        }

        private static void InitializeWebServerClient()
        {
            var authorizationServerUri = new Uri(Paths.AuthorizationServerBaseAddress);
            var authorizationServer = new AuthorizationServerDescription
            {
                AuthorizationEndpoint = new Uri(authorizationServerUri, Paths.AuthorizePath),
                TokenEndpoint = new Uri(authorizationServerUri, Paths.TokenPath)
            };
            _webServerClient = new WebServerClient(authorizationServer, "3", "4");
        }

        private static void RequestToken()
        {
            var state = _webServerClient.GetClientAccessToken(new[] { "bio", "notes" });
            _accessToken = state.AccessToken;
        }

        private static void AccessProtectedResource()
        {
            var resourceServerUri = new Uri(Paths.ResourceServerBaseAddress);
            var client = new HttpClient(_webServerClient.CreateAuthorizingHandler(_accessToken));
            var body = client.GetStringAsync(new Uri(resourceServerUri, Paths.MePath)).Result;
            Console.WriteLine(body);
        }
    }
}