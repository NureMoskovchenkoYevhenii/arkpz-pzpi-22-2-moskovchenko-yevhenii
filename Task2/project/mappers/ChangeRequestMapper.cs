using System.ComponentModel.DataAnnotations;

public class ChangeRequestMapper
{
    public ChangeRequestDto MapToDto(ChangeRequest changeRequest)
    {
        return new ChangeRequestDto
        {
            ChangeRequestId = changeRequest.ChangeRequestId,
            RequestDate = changeRequest.RequestDate,
//Status = changeRequest.Status,
            DayTypeId = changeRequest.DayTypeId,
            StartDate = changeRequest.StartDate, // Дата початку
            EndDate = changeRequest.EndDate,     // Дата кінця
            Description = changeRequest.Description // Короткий опис
        };
    }

    public ChangeRequest MapToEntity(ChangeRequestDto changeRequestDto)
    {
        return new ChangeRequest
        {
            ChangeRequestId = changeRequestDto.ChangeRequestId,
            RequestDate = changeRequestDto.RequestDate,
        //    Status = changeRequestDto.Status,
            DayTypeId = changeRequestDto.DayTypeId,
            StartDate = changeRequestDto.StartDate, // Дата початку
            EndDate = changeRequestDto.EndDate,     // Дата кінця
            Description = changeRequestDto.Description // Короткий опис
        };
    }
}

public class ChangeRequestDto
{
    public int ChangeRequestId { get; set; }

 
    public DateTime RequestDate { get; set; } // Дата запиту

   // public string Status { get; set; }
    public int DayTypeId { get; set; }

    public DateTime StartDate { get; set; } // Дата початку

    public DateTime EndDate { get; set; }   // Дата кінця

    public string Description { get; set; } // Короткий опис
}
