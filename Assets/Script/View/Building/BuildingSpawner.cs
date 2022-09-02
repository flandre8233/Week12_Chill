using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : SingletonMonoBehavior<BuildingSpawner>
{
    public Building Spawn(int CardIndex, Direction[] RoadDir)
    {
        GameObject SpawnedObject = ResourcesSpawner.Spawn("Building", new Vector3(1000 * CardIndex, 1000, 1000 * CardIndex));
        SpawnedObject.GetComponent<Building>().ground = new GroundData(RoadDir);
        return SpawnedObject.GetComponent<Building>();
    }
    public Building Spawn(Vector2Int Pos, Direction[] RoadDir)
    {
        GameObject SpawnedObject = ResourcesSpawner.Spawn("Building", new Vector3(Pos.x * 5, 0, Pos.y * 5));
        SpawnedObject.GetComponent<Building>().ground = new GroundData(RoadDir);
        return SpawnedObject.GetComponent<Building>();
    }

    public bool IsPosCanBeSpawn(Vector2Int v2, Direction[] RoadDir)
    {
        if (Map.instance.MapDict.ContainsKey(v2))
        {
            print("Already Have this spawn");
            return false;
        }
        if (IsWallRoadCollision(v2, RoadDir) || IsRoadWallCollision(v2, Direction.RoadToWalls(RoadDir) ))
        {
            return false;
        }
        if (IsCanPair(v2, RoadDir) || IsCanPairbyWall(v2, Direction.RoadToWalls(RoadDir)) || Map.instance.MapDict.Count <= 0)
        {
            return true;
        }
        print("Can't be Pair");
        return false;
    }

    bool IsWallRoadCollision(Vector2Int v2, Direction[] RoadDir)
    {
        foreach (var CurrentItem in RoadDir)
        {
            Building TargetBuild = null;
            if (Map.instance.MapDict.TryGetValue(v2 + CurrentItem.ToLocalV2(), out TargetBuild))
            {
                foreach (var TargetItem in TargetBuild.ground.GetWallDirections())
                {
                    if (CurrentItem.GetType() == TargetItem.Reverse().GetType())
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
 bool IsRoadWallCollision(Vector2Int v2, Direction[] WallDir)
    {
        foreach (var CurrentItem in WallDir)
        {
            Building TargetBuild = null;
            if (Map.instance.MapDict.TryGetValue(v2 + CurrentItem.ToLocalV2(), out TargetBuild))
            {
                foreach (var TargetItem in TargetBuild.ground.directions)
                {
                    if (CurrentItem.GetType() == TargetItem.Reverse().GetType())
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    bool IsCanPair(Vector2Int v2, Direction[] RoadDir)
    {
        foreach (var CurrentItem in RoadDir)
        {
            Building TargetBuild = null;
            if (Map.instance.MapDict.TryGetValue(v2 + CurrentItem.ToLocalV2(), out TargetBuild))
            {
                foreach (var TargetItem in TargetBuild.ground.directions)
                {
                    if (CurrentItem.GetType() == TargetItem.Reverse().GetType())
                    {
                        return true;
                    }
                }

            }
        }
        return false;
    }


    bool IsCanPairbyWall(Vector2Int v2, Direction[] WallDir)
    {
        foreach (var CurrentItem in WallDir)
        {
            Building TargetBuild = null;
            if (Map.instance.MapDict.TryGetValue(v2 + CurrentItem.ToLocalV2(), out TargetBuild))
            {
                foreach (var TargetItem in TargetBuild.ground.GetWallDirections())
                {
                    if (CurrentItem.GetType() == TargetItem.Reverse().GetType())
                    {
                        return true;
                    }
                }

            }
        }
        return false;
    }

}
