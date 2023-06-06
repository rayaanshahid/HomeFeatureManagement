namespace HomeFeatureManagement.Repositories;

using Models;

/*public interface IUnitRepository
{
    List<Unit> GetAll();
    void Create(Unit model);
    //void Update(string propertyId, Unit model);
    //void Delete(string propertyId);
}*/

public class UnitRepository //: IUnitRepository
{
    private static List<Unit> units = new List<Unit>();

    public UnitRepository()
	{
	}

    public bool Exists(string propertyId)
    {
        return units.Any(unit => unit.PropertyId == propertyId);
    }

    public List<Unit> GetAll()
    {
        return units;
    }

    public void Create(Unit unitRequest)
    {
        units.Add(unitRequest);
    }

    public void Update(Unit unitRequest)
    {
        var itemToRemove = units.Single(unit => unit.PropertyId == unitRequest.PropertyId);
        var dict = units.ToDictionary(x => x.PropertyId);
        Unit found;
        if (dict.TryGetValue(unitRequest.PropertyId, out found)) found = unitRequest;
    }

    public void Delete(string propertyId)
    {
        var itemToRemove = units.Single(unit => unit.PropertyId == propertyId);
        units.Remove(itemToRemove);
    }

}


