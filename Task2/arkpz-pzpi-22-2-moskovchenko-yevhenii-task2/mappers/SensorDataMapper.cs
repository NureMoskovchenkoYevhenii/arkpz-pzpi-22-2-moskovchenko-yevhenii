public class SensorDataMapper
{
    public SensorDataDto MapToDto(SensorData sensorData)
    {
        return new SensorDataDto
        {
            Id = sensorData.Id,
            Timestamp = sensorData.Timestamp,
            Temperature = sensorData.Temperature,
            Humidity = sensorData.Humidity
        };
    }

    public SensorData MapToEntity(SensorDataDto sensorDataDto)
    {
        return new SensorData
        {
            Id = sensorDataDto.Id,
            Timestamp = sensorDataDto.Timestamp,
            Temperature = sensorDataDto.Temperature,
            Humidity = sensorDataDto.Humidity
        };
    }
}

public class SensorDataDto
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal Temperature { get; set; }
    public decimal Humidity { get; set; }
}
