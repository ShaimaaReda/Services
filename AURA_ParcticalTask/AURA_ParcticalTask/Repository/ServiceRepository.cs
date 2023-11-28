using AURA_ParcticalTask.models;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace AURA_ParcticalTask.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        public readonly ApplicationDbContext context;

        public ServiceRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<ServiceModel> AddOperation(ServiceModel serviceModel)
        {
            var operation = new ServiceModel()
            {
                Name = serviceModel.Name,
                Activated = true
            };
            context.service.Add(operation);
            await context.SaveChangesAsync();
            return operation;
        }
        public async Task<bool> SoftDeleteOperation(int id)
        {
            var operation= await context.service.FindAsync(id);
            if (operation != null)
            {
                operation.Activated = false;
                context.service.Update(operation);
                await context.SaveChangesAsync();
                return true;
            }
            else
                return false;   
        }
        public async Task<List<ServiceModel>>GetAll()
        {
            var operations = await context.service.Select(Op => new ServiceModel
            {
                Id=Op.Id,
                Name=Op.Name,
                Activated = Op.Activated
            }).ToListAsync();
            return operations;
        }


    }
}
