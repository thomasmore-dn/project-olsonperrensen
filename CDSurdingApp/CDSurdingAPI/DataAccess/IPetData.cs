using PetsAPI.Models;

namespace PetsAPI.DataAccess;

public interface IPetData
{
    Task AdoptPet(int assignedTo, int petId);
    Task<PetModel?> Create(int assignedTo, string task);
    Task Delete(int assignedTo, int petId);
    Task<List<PetModel>> GetAllAssigned(int assignedTo);
    Task<PetModel?> GetOneAssigned(int assignedTo, int petId);
    Task UpdateTask(int assignedTo, int petId, string task);
}