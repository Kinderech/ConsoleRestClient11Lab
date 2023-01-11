using System.Net.Http.Headers;
using System.Text;

namespace ConsoleRestClient;

public class RegionClient
{

    private HttpClient client = new HttpClient();
    private string _url = "http://localhost:5264/NorthWind/";
    
    public RegionClient(string url)
    {
        _url = url;
        client.BaseAddress = new Uri(_url);
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

    }
    
    private const string getAllRegionsPath = "NorthWindRegions";
    private const string getRegionPath = "getNorthWindRegion?regionId=";
    private const string addRegionPath = "addNorthWindRegion";
    private const string updateRegionPath = "upadteNorthWindRegion";
    private const string deleteRegionPath = "deleteNorthWindRegion?regionId=";
    
    

    public List<Region> getAllRegions()
    {
        HttpResponseMessage response = client.GetAsync(getAllRegionsPath).Result;
        if (response.IsSuccessStatusCode)
        {
            // Parse the response body.
            var dataObjects = response.Content.ReadAsAsync<IEnumerable<Region>>().Result;
            return dataObjects.ToList();
        }
        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

        return new List<Region>();

    }
    
    public Region getRegion(int regionId)
    {
        HttpResponseMessage response = client.GetAsync(getRegionPath+regionId).Result;
        if (response.IsSuccessStatusCode)
        {
            // Parse the response body.
            var dataObjects = response.Content.ReadAsAsync<Region>().Result;
            return dataObjects;
        }
        
        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        return null;
    }
    
    public bool addRegion(Region region)
    {
        HttpResponseMessage response = client.PostAsJsonAsync(addRegionPath, region).Result;
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        return false;
    }
    
    public bool updateRegion(Region region)
    {
        HttpResponseMessage response = client.PutAsJsonAsync(updateRegionPath, region).Result;
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        return false;
    }
    public bool deleteRegion(int regionId)
    {
        HttpResponseMessage response = client.DeleteAsync(deleteRegionPath+regionId).Result;
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        return false;
    }

}