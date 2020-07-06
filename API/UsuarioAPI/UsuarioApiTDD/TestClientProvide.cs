using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UsuarioAPI;

namespace UsuarioApiTDD
{
    public class TestClientProvide
    {
        public HttpClient Client { get; private set; }

        public TestClientProvide()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());

            Client = server.CreateClient();
        }
    }
}
