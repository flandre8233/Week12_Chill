using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Building : MonoBehaviour
{
    public BuildData build;
    public GroundData ground;

    public Transform View;

    void Start()
    {
        SpawnView();
    }

    void SpawnView()
    {
        Ground.Spawn(this);
    }

    public Vector2Int GetVector2Int()
    {
        int X = Mathf.RoundToInt(transform.position.x / 5);
        int Y = Mathf.RoundToInt(transform.position.z / 5);
        return new Vector2Int(X, Y);
    }

    private void OnEnable()
    {
        if (IsSpawnInGame())
        {
            Map.instance.OnAddBuildData(GetVector2Int(), this);
            GetComponent<Development>().enabled = true;
        }
    }

    bool IsSpawnInGame()
    {
        return transform.position.y <= 0;
    }
}

[System.Serializable]
public class BuildData
{
    [SerializeField] Build build = new EmptyVoid();

    public BuildData(Build _build)
    {
        build = _build;
    }

    public GameObject SpawnView(Building parentbuild)
    {
        return build.Spawn(parentbuild.transform);
    }

    public Build GetCurrentBuild()
    {
        if (build == null)
        {
            build = new EmptyVoid();
        }
        return build;
    }
}


[System.Serializable]
public class GroundData
{
    public Direction[] directions;

    public GroundData(Direction[] _directions)
    {
        directions = _directions;
    }
    public Direction[] GetWallDirections()
    {
        List<Direction> Output = Direction.GetAllDirections().ToList();
        for (int i = 0; i < directions.Length; i++)
        {
            for (int o = 0; o < Output.Count; o++)
            {
                if (Output[o].GetType() == directions[i].GetType())
                {
                    Output.RemoveAt(o);
                    continue;
                }
            }
        }
        return Output.ToArray();
    }
}