using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using RestSharp;
using System.Net;
using RestSharp.Authenticators;
using CustomerVue.Models;

namespace CustomerVue.Code
{
    public class CustomerApi : ICustomerApi
    {
        public string ApiUrl { get; private set; }
        public string ApiSecret { get; private set; }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            RestClient client = GetNewRestClient();
            RestRequest request = new RestRequest($"customer/{customerId}");

            var response = await client.ExecuteGetTaskAsync<Customer>(request);

            ValidateResponse(response, HttpStatusCode.OK);

            return response.Data;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            RestClient client = GetNewRestClient();
            RestRequest request = new RestRequest($"customers");

            var response = await client.ExecuteGetTaskAsync<List<Customer>>(request);

            ValidateResponse(response, HttpStatusCode.OK);

            return response.Data;
        }


        private void ValidateResponse(IRestResponse response, params HttpStatusCode[] acceptableHttpStatusCodes)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception($"API request did not complete. ResponseStatus={response.ResponseStatus}, ContentType={response.ContentType}, Content={response.Content}", response.ErrorException);
            }

            if (!acceptableHttpStatusCodes.Contains(response.StatusCode))
            {
                throw new Exception(
                    String.Format("API returned an unexpected HttpStatusCode. ActualStatusCode={0}, ExpectedStatusCode(s)={1}.",
                        response.StatusCode,
                        String.Join(",", acceptableHttpStatusCodes)),
                    response.ErrorException);
            }
        }

        private RestClient GetNewRestClient()
        {
            return new RestClient(this.ApiUrl)
            {
                Authenticator = new HttpBasicAuthenticator("", this.ApiSecret)
            };
        }
    }
}