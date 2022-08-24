using System.Net;
using Newtonsoft.Json;
using RestSharp;

public class CPService
{
    public static readonly string cpUrl = "https://cpapi.sambapos.com";

    public IServiceResponse<LoginResponse> CPLogin(string username, string password)
    {
        var result = new ServiceResponse<LoginResponse>();
        try
        {
            var client = new RestClient(cpUrl + "/auth/login/api");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("text/plain", "" +
            "{\n\t\"email\":\"" + username + "\"," +
            "\n\t\"password\":\"" + password + "\"}", ParameterType.RequestBody);
            var response = client.ExecuteAsync(request).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("An error occurred while logging in CP");
            var res = JsonConvert.DeserializeObject<LoginResponse>(response.Content);
            result.Success = true;
            result.Entity = res;
            result.Count = 1;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
        }
        return result;
    }


    public IServiceResponse<LicenseResult> CPLicense(string email, string licenseKey)
    {
        var result = new ServiceResponse<LicenseResult>();
        try

        {
            var client = new RestClient(cpUrl + "/customer-licenses/?format=json&license_email=" + email + "&license_key=" + licenseKey + "");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Content-Type", "application/json");
            var response = client.ExecuteAsync(request).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("An error occurred while get license in CP");
            var res = JsonConvert.DeserializeObject<LicenseResponse>(response.Content);
            result.Success = true;
            result.List = res.results;
            result.Count = res.count;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
        }
        return result;
    }





}