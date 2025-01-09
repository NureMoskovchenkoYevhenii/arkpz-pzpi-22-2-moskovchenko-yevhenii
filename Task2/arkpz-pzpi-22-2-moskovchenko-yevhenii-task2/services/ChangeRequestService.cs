public class ChangeRequestService
{
    private readonly IChangeRequestRepository _changeRequestRepository;

    public ChangeRequestService(IChangeRequestRepository changeRequestRepository)
    {
        _changeRequestRepository = changeRequestRepository;
    }

    public void AddChangeRequest(ChangeRequest changeRequest)
    {
        _changeRequestRepository.Add(changeRequest);
    }

    public IEnumerable<ChangeRequest> GetAllChangeRequests()
    {
        return _changeRequestRepository.GetAll();
    }

    public ChangeRequest GetChangeRequestById(int changeRequestId)
    {
        return _changeRequestRepository.GetById(changeRequestId);
    }

    public void UpdateChangeRequest(int changeRequestId, ChangeRequest updatedChangeRequest)
    {
        var changeRequest = _changeRequestRepository.GetById(changeRequestId);
        if (changeRequest != null)
        {
            changeRequest.RequestDate = updatedChangeRequest.RequestDate;
            changeRequest.Status = updatedChangeRequest.Status;
            changeRequest.DayTypeId = updatedChangeRequest.DayTypeId;
            _changeRequestRepository.Update(changeRequest);
        }
    }

    public void DeleteChangeRequest(int changeRequestId)
    {
        _changeRequestRepository.Delete(changeRequestId);
    }
}
