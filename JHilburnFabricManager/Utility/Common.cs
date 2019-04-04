using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using RestSharp;

namespace JHilburnFabricManager.Utility
{
    public static class Common
    {
        public static string CallRestService(Method method, string resource, object body)
        {
            var baseurl = @"http://localhost:3000/api/";
            var client = new RestClient();
            client.BaseUrl = new Uri(baseurl);

            var request = new RestRequest();
            request.Resource = resource;

            //if (parameters != null)
            //{
            //    foreach (var parameter in parameters)
            //        request.AddParameter(parameter.Key, parameter.Value, ParameterType.UrlSegment);
            //}
            request.Method = method;
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("x-api-auth", "F1467AA76C4776F69D165BD598812");
            if (body != null)
            {
                request.AddJsonBody(body);
            }

            return client.Execute(request).Content;
        }

        //get list of all fabrics or one fabric by passing Id------------------------------------
        public static string Get(string resource)
        {
            return CallRestService(Method.GET, resource, null);
        }

        //add,create a new fabric-------------------------------------------------------------------
        public static string Post(string resource, object body)
        {
            return CallRestService(Method.POST, resource, body);
        }

        //update,edit selected fabric records------------------------------------------------------------
        public static string Put(string resource, object body)
        {
            return CallRestService(Method.PUT, resource, body);
        }

        //delete the selected fabric---------------------------------------------------------
        public static string Delete(string resource)
        {
            return CallRestService(Method.DELETE, resource, null);
        }

        //update or edit a particular fields of a fabric record--------------------------------
        public static string Patch(string resource, object body)
        {
            return CallRestService(Method.PATCH, resource, body);
        }
    }
}