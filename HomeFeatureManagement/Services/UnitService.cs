namespace HomeFeatureManagement.Services;

using Models;
using Repositories;

public interface IUnitService
{
    List<Unit> GetAll();
    void Create(Unit model);
    void Update(Unit model);
    void Delete(string propertyId);
}

public class UnitService : IUnitService
{
    UnitRepository _unitRepositories = new UnitRepository();

    public UnitService()
    {
        
    }

    public List<Unit> GetAll()
    {
        return _unitRepositories.GetAll();
    }

    public void Create(Unit model)
    {
        // validate
        if (_unitRepositories.Exists(model.PropertyId))
            throw new Exception("Unit with the property Id '" + model.PropertyId + "' already exists");

        Validate(model);
        _unitRepositories.Create(model);
    }

    public void Update(Unit model)
    {
        // validate
        if (!_unitRepositories.Exists(model.PropertyId))
            throw new Exception("Unit with the property Id '" + model.PropertyId + "' does not exist");

        Validate(model);
        _unitRepositories.Update(model);
    }

    public void Delete(string propertyId)
    {
        // validate
        if (!_unitRepositories.Exists(propertyId))
            throw new Exception("Unit with the property Id '" + propertyId + "' does not exist");

        _unitRepositories.Delete(propertyId);
    }

    public void Validate(Unit model)
    { 
        if (model.Floors < 0)
            throw new Exception("Floors '" + model.Floors + "' less than 0");

        //validating features enums
        foreach (string feature in model.Features)
        {
            if (!Enum.IsDefined(typeof(FeatureEnumeration), feature))
                throw new Exception("Feature '" + feature + "' does not comply with allowed features");
        }
    }

}


