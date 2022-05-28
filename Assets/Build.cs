using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Build
{
    public abstract GameObject Spawn(Transform ParentTrans);
    protected GameObject Spawn(string SpawnName, Transform ParentTrans)
    {
        Transform trans = ResourcesSpawner.Spawn(SpawnName).transform;
        trans.parent = ParentTrans;
        trans.localPosition = new Vector3(0, 0, 0);
        trans.localEulerAngles = new Vector3(0, 0, 0);
        OnAddIntoGame();
        return trans.gameObject;
    }

    protected abstract void OnAddIntoGame();

}

[System.Serializable]
public class EmptyVoid : Build
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return null;
    }

    public static bool CanSpawn(Building TargetBuilding)
    {
        return false;
    }

    protected override void OnAddIntoGame()
    {
    }
}

[System.Serializable]
public class House : Build
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("House", ParentTrans);
    }

    public static bool CanSpawn(Building TargetBuilding)
    {
        if (Random.Range(0, 100) <= 50)
        {
            return false;
        }

        if (TargetBuilding.ground.directions.Length == 1)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}
[System.Serializable]
public class Sports : House
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("Sports", ParentTrans);
    }

    public new static bool CanSpawn(Building TargetBuilding)
    {
        if (Random.Range(0, 100) <= 80)
        {
            return false;
        }

        Building[] NearBuilding = Map.instance.GetNearBuildings(TargetBuilding.GetVector2Int());
        Building[] NearHouse = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(House), x.build.GetCurrentBuild().GetType())).ToArray();
        Building[] NearRoad = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(EmptyVoid), x.build.GetCurrentBuild().GetType())).ToArray();
        if (NearHouse.Length == 3 && NearRoad.Length == 1)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}

[System.Serializable]
public class Mine : House
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("Mine", ParentTrans);
    }

    public new static bool CanSpawn(Building TargetBuilding)
    {
        if (Random.Range(0, 100) <= 95)
        {
            return false;
        }

        Building[] NearBuilding = Map.instance.GetNearBuildings(TargetBuilding.GetVector2Int());
        Building[] NearForest = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(Forest), x.build.GetCurrentBuild().GetType())).ToArray();
        Building[] NearRoad = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(EmptyVoid), x.build.GetCurrentBuild().GetType())).ToArray();
        if (NearForest.Length == 1 && NearRoad.Length >= 2)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}

[System.Serializable]
public class Sawmill : House
{

    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("Sawmill", ParentTrans);
    }

    public new static bool CanSpawn(Building TargetBuilding)
    {
        if (Random.Range(0, 100) <= 80)
        {
            return false;
        }
        Building[] NearBuilding = Map.instance.GetNearBuildings(TargetBuilding.GetVector2Int());
        Building[] NearForest = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(ForestLv2), x.build.GetCurrentBuild().GetType())).ToArray();
        Building[] NearRoad = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(EmptyVoid), x.build.GetCurrentBuild().GetType())).ToArray();
        if (NearForest.Length == 3 && NearRoad.Length == 1)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}

[System.Serializable]
public class CityHall : House
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("CityHall", ParentTrans);
    }

    public new static bool CanSpawn(Building TargetBuilding)
    {
        if (Random.Range(0, 100) <= 98)
        {
            return false;
        }
        Building[] NearBuilding = Map.instance.GetNearBuildings(TargetBuilding.GetVector2Int());
        Building[] NearHouse = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(House), x.build.GetCurrentBuild().GetType())).ToArray();
        if (NearHouse.Length == 4)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}

[System.Serializable]
public class Farm : Build
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("Farm", ParentTrans);
    }

    public static bool CanSpawn(Building TargetBuilding)
    {
        if (Random.Range(0, 100) <= 50)
        {
            return false;
        }
        Building[] NearBuilding = Map.instance.GetNearBuildings(TargetBuilding.GetVector2Int());
        Building[] NearFarm = NearBuilding.Where(x => x != null && x.build != null && x.ground.directions.Length == 4).ToArray();
        if (NearFarm.Length == 4)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}

[System.Serializable]
public class HouseLV2 : House
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("HouseLV2", ParentTrans);
    }

    public new static bool CanSpawn(Building TargetBuilding)
    {
        if (Random.Range(0, 100) <= 75)
        {
            return false;
        }
        Building[] NearBuilding = Map.instance.GetNearBuildings(TargetBuilding.GetVector2Int());
        Building[] Near = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(House), x.build.GetCurrentBuild().GetType())).ToArray();
        if (Near.Length == 2)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}

[System.Serializable]
public class HouseLV3 : HouseLV2
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("HouseLV3", ParentTrans);
    }

    public new static bool CanSpawn(Building TargetBuilding)
    {
          if (Random.Range(0, 100) <= 95)
        {
            return false;
        }
        Building[] NearBuilding = Map.instance.GetNearBuildings(TargetBuilding.GetVector2Int());
        Building[] Near = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(HouseLV2), x.build.GetCurrentBuild().GetType())).ToArray();
        if (Near.Length == 2)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}

[System.Serializable]
public class Forest : Build
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("Forest", ParentTrans);
    }

    public static bool CanSpawn(Building TargetBuilding)
    {
         if (Random.Range(0, 100) <= 30)
        {
            return false;
        }
        if (TargetBuilding.ground.directions.Length == 0)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}
[System.Serializable]
public class ForestLv2 : Forest
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("Forest-Lv2", ParentTrans);
    }

    public new static bool CanSpawn(Building TargetBuilding)
    {
         if (Random.Range(0, 100) <= 50)
        {
            return false;
        }
        Building[] NearBuilding = Map.instance.GetNearBuildings(TargetBuilding.GetVector2Int());
        NearBuilding = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(Forest), x.build.GetCurrentBuild().GetType())).ToArray();
        if (NearBuilding.Length == 2)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}

[System.Serializable]
public class ForestLv3 : ForestLv2
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("Forest-Lv3", ParentTrans);
    }

    public new static bool CanSpawn(Building TargetBuilding)
    {
         if (Random.Range(0, 100) <= 70)
        {
            return false;
        }
        Building[] NearBuilding = Map.instance.GetNearBuildings(TargetBuilding.GetVector2Int());
        NearBuilding = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(ForestLv2), x.build.GetCurrentBuild().GetType())).ToArray();
        if (NearBuilding.Length == 3)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}


[System.Serializable]
public class ForestMax : ForestLv3
{
    public override GameObject Spawn(Transform ParentTrans)
    {
        return Spawn("Forest-LVMAX", ParentTrans);
    }

    public new static bool CanSpawn(Building TargetBuilding)
    {
        if (Random.Range(0, 100) <= 85)
        {
            return false;
        }
        Building[] NearBuilding = Map.instance.GetNearBuildings(TargetBuilding.GetVector2Int());
        NearBuilding = NearBuilding.Where(x => x != null && x.build != null && TypeChecker.IsSameOrSubclass(typeof(ForestLv3), x.build.GetCurrentBuild().GetType())).ToArray();
        if (NearBuilding.Length == 4)
        {
            return true;
        }
        return false;
    }
    protected override void OnAddIntoGame()
    {
    }
}