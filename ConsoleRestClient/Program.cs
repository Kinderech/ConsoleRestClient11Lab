// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using ConsoleRestClient;

public class App
{
    private const string URL = "http://localhost:5264/NorthWind/";

    static void Main(string[] args)
    {
        var client = new RegionClient(URL);
        var result = client.getAllRegions();
        Console.WriteLine("READING ALL REGIONS");
        foreach (var region in result)
        {
            Console.WriteLine($"Recieving list of regions {region.RegionDescription}");   
        }
        
        Console.WriteLine("READING ONE REGION BY ID");
        Console.WriteLine($"Region description for region with id 1: {client.getRegion(1).RegionDescription}");
        
        Console.WriteLine("CREATING NEW REGION");
        var newRegion = new Region(5, "newRegion");
        client.addRegion(newRegion);
        
        Console.WriteLine("CHECKING: CREATION");
        Console.WriteLine($"Region description for region with id 5: {client.getRegion(5).RegionDescription}");
        
        Console.WriteLine("UPDATING NEW REGION");
        newRegion.RegionDescription = "updatedRegionDescription";
        client.updateRegion(newRegion);
        
        Console.WriteLine("CHECKING: UPDATE");
        Console.WriteLine($"Region description for region with id 5: {client.getRegion(5).RegionDescription}");
        
        Console.WriteLine("DELETING NEW REGION");
        client.deleteRegion(5);
        
        Console.WriteLine("READING ALL REGIONS: should be the same amount");
        result = client.getAllRegions();
        foreach (var region in result)
        {
            Console.WriteLine($"Recieving list of regions {region.RegionDescription}");   
        }
    }
}