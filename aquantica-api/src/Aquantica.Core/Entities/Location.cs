namespace Aquantica.Core.Entities;

public class Location : BaseEntity
{
    public string? Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public virtual ICollection<WeatherForecast>? WeatherForecasts { get; set; }
}