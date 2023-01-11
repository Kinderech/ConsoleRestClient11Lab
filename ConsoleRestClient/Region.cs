namespace ConsoleRestClient;

public class Region
{
    public Region()
    {
    }

    public Region(int regionId, string regionDescription)
    {
        RegionID = regionId;
        RegionDescription = regionDescription;
    }

    public int RegionID { get; set; }
    public string RegionDescription { get; set; }
}