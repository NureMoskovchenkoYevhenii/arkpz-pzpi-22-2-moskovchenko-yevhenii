public interface ISensorDataRepository
{
    void Add(SensorData sensorData);
    IEnumerable<SensorData> GetAll();
    SensorData GetById(int id);
    void Update(SensorData sensorData);
    void Delete(int id);
}

public class SensorDataRepository : ISensorDataRepository
{
    private readonly ApplicationDbContext _context;

    public SensorDataRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(SensorData sensorData)
    {
        _context.SensorData.Add(sensorData);
        _context.SaveChanges();
    }

    public IEnumerable<SensorData> GetAll()
    {
        return _context.SensorData.ToList();
    }

    public SensorData GetById(int id)
    {
        return _context.SensorData.Find(id);
    }

    public void Update(SensorData sensorData)
    {
        _context.SensorData.Update(sensorData);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var sensorData = _context.SensorData.Find(id);
        if (sensorData != null)
        {
            _context.SensorData.Remove(sensorData);
            _context.SaveChanges();
        }
    }
}
