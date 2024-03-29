namespace Aquantica.Core.Entities;

public class SensorData : BaseEntity
{
    public double Humidity { get; set; }
    public double Temperature { get; set; }

    public int IrrigationSectionId { get; set; }
    public virtual IrrigationSection IrrigationSection { get; set; }

    public int BackgroundJobId { get; set; }
    public virtual BackgroundJob BackgroundJob { get; set; }
}