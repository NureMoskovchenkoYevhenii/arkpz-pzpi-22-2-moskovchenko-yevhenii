public class SensorDataService
{
    private readonly ISensorDataRepository _sensorDataRepository;

    public SensorDataService(ISensorDataRepository sensorDataRepository)
    {
        _sensorDataRepository = sensorDataRepository;
    }

    public void AddSensorData(SensorData sensorData)
    {
        _sensorDataRepository.Add(sensorData);
    }

    public IEnumerable<SensorData> GetAllSensorData()
    {
        return _sensorDataRepository.GetAll();
    }

    public SensorData GetSensorDataById(int id)
    {
        return _sensorDataRepository.GetById(id);
    }

    public void UpdateSensorData(int id, SensorData updatedSensorData)
    {
        var sensorData = _sensorDataRepository.GetById(id);
        if (sensorData != null)
        {
            sensorData.Timestamp = updatedSensorData.Timestamp;
            sensorData.Temperature = updatedSensorData.Temperature;
            sensorData.Humidity = updatedSensorData.Humidity;
            _sensorDataRepository.Update(sensorData);
        }
    }

    public void DeleteSensorData(int id)
    {
        _sensorDataRepository.Delete(id);
    }
}
