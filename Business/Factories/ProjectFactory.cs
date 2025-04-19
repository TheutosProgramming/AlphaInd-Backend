using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectFactory
{
    public static Project ToModel(ProjectEntity entity)
    {
        return entity == null
            ? null!
            : new Project
            {
                Id = entity.Id,
                ProjectImage = entity.ProjectImage,
                ProjectName = entity.ProjectName,
                ProjectDescription = entity.ProjectDescription,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Budget = entity.Budget,
                Client = ClientFactory.ToModel(entity.Client),
                Member = MemberFactory.ToModel(entity.Member),
                Status = StatusFactory.ToModel(entity.Status)
            };
    }

    public static ProjectEntity ToEntity(EditProjectFormData formData)
    {
        return formData == null
        ? null!
        : new ProjectEntity
        {
            Id = formData.Id,
            ProjectImage = formData.ProjectImage,
            ProjectName = formData.ProjectName,
            ProjectDescription = formData.ProjectDescription,
            StartDate = formData.StartDate,
            EndDate = formData.EndDate,
            Budget = formData.Budget,
            ClientId = formData.ClientId,
            MemberId = formData.MemberId,
            StatusId = formData.StatusId
        };
    }

    public static ProjectEntity ToEntity(AddProjectFormData formData)
    {
        return formData == null
        ? null!
        : new ProjectEntity
        {
            ProjectImage = formData.ProjectImage,
            ProjectName = formData.ProjectName,
            ProjectDescription = formData.ProjectImage,
            StartDate = formData.StartDate,
            EndDate = formData.EndDate,
            Budget = formData.Budget,
            ClientId = formData.ClientId,
            MemberId = formData.MemberId
        };
    }
}
