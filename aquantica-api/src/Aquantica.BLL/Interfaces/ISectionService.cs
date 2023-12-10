using Aquantica.Contracts.Requests;
using Aquantica.Contracts.Responses;
using Aquantica.Core.DTOs;
using Aquantica.Core.Entities;
using Aquantica.Core.ServiceResult;

namespace Aquantica.BLL.Interfaces;

public interface ISectionService
{
    Task<List<SectionResponse>> GetAllSectionsAsync();

    GetIrrigationSectionDTO GetSectionById(int sectionId);

    Task<SectionResponse> GetSectionByIdAsync(int id);

    ServiceResult<IrrigationSection> GetRootSection();

    Task<bool> CreateSectionAsync(CreateSectionRequest request);

    Task<bool> UpdateSectionAsync(UpdateSectionRequest request);

    Task<bool> DeleteSectionAsync(int id);

    Task<List<IrrigationHistoryResponse>> GetIrrigationHistoryAsync(GetIrrigationHistoryRequest request);

    bool CreateIrrigationEvent(IrrigationEventDTO request);

    bool UpdateIrrigationEvent(IrrigationEventDTO request);

    IrrigationEventDTO GetLastIrrigationEventBySectionId(int sectionId);

    IrrigationEventDTO GetIrrigationEventById(int id);
}