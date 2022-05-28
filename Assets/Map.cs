using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : SingletonMonoBehavior<Map>
{
    public Dictionary<Vector2Int, Building> MapDict = new Dictionary<Vector2Int, Building>();
    public void OnAddBuildData(Vector2Int v2, Building build)
    {
        print("OnAddBuildData : " + v2);
        MapDict.Add(v2, build);
    }
    public void OnRemoveBuildData(Vector2Int v2)
    {
        print("OnRemoveBuildData : " + v2);
        MapDict.Remove(v2);
    }

    public Building[] GetNearBuildings(Vector2Int v2)
    {
        List<Building> output = new List<Building>();
        Vector2Int[] NearV2 = GetNearV2(v2);
        foreach (var item in NearV2)
        {
            Building ItemBuilding = null;
            Map.instance.MapDict.TryGetValue(item, out ItemBuilding);
            output.Add(ItemBuilding);
        }
        return output.ToArray();
    }
    Vector2Int[] GetNearV2(Vector2Int v2)
    {
        Vector2Int[] output = new Vector2Int[4];
        output[0] = v2 + new North().ToLocalV2();
        output[1] = v2 + new South().ToLocalV2();
        output[2] = v2 + new West().ToLocalV2();
        output[3] = v2 + new East().ToLocalV2();
        return output;
    }

}
