using PetsAPI.Models;

namespace PetsAPI.DataAccess;

public class PetData : IPetData
{
    private readonly ISqlDataAccess _sql;

    public PetData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public Task<List<PetModel>> GetAllAssigned(int assignedTo)
    {
        return _sql.LoadData<PetModel, dynamic>(
            "dbo.spPets_GetAllAssigned", new { AssignedTo = assignedTo });
    }

    public async Task<PetModel?> GetOneAssigned(int assignedTo, int petId)
    {
        return (await _sql.LoadData<PetModel, dynamic>(
            "dbo.spPets_GetOneAssigned", new
            {
                AssignedTo = assignedTo,
                petId = petId
            })).FirstOrDefault();
    }
    public async Task<PetModel?> Create(int assignedTo, string task)
    {
        var res = await _sql.LoadData<PetModel, dynamic>(
            "dbo.spPets_Create", new
            {
                AssignedTo = assignedTo,
                Task = task
            });

        return res.FirstOrDefault();
    }
    public Task UpdateTask(int assignedTo, int petId, string task)
    {
        return _sql.SaveData<dynamic>(
            "dbo.spPets_UpdateTask",
            new
            {
                AssignedTo = assignedTo,
                petId = petId,
                Task = task
            });
    }

    public Task AdoptPet(int assignedTo, int petId)
    {
        return _sql.SaveData<dynamic>(
            "dbo.spPets_AdoptPet",
            new
            {
                AssignedTo = assignedTo,
                petId = petId
            });
    }
    public Task Delete(int assignedTo, int petId)
    {
        return _sql.SaveData<dynamic>(
            "dbo.spPets_Delete",
            new
            {
                AssignedTo = assignedTo,
                petId = petId
            });
    }
}
