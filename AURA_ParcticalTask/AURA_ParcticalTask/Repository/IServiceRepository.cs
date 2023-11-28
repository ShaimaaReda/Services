using AURA_ParcticalTask.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AURA_ParcticalTask.Repository
{
    public interface IServiceRepository
    {
        Task<ServiceModel> AddOperation(ServiceModel serviceModel);
        Task<bool> SoftDeleteOperation(int id);
        Task<List<ServiceModel>> GetAll();

    }
}