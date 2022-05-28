using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public abstract class Direction
{
    public abstract Vector2Int ToLocalV2();
    public abstract Direction Reverse();
    public abstract Vector3 RoadViewLocalV3();
    public abstract Vector3 RoadViewLocalEuler();

    public static Direction[] GetAllDirections()
    {
        return new Direction[] { new North(), new South(), new West(), new East() };
    }

    public static Direction[] RoadToWalls(Direction[] Road)
    {
        List<Direction> Output = Direction.GetAllDirections().ToList();
        for (int i = 0; i < Road.Length; i++)
        {
            for (int o = 0; o < Output.Count; o++)
            {
                if (Output[o].GetType() == Road[i].GetType())
                {
                    Output.RemoveAt(o);
                    continue;
                }
            }
        }
        return Output.ToArray();
    }
}

public class North : Direction
{
    public override Vector2Int ToLocalV2()
    {
        return new Vector2Int(0, 1);
    }

    public override Direction Reverse()
    {
        return new South();
    }

    public override Vector3 RoadViewLocalV3()
    {
        return new Vector3(0, 0, .25f);
    }
    public override Vector3 RoadViewLocalEuler()
    {
        return new Vector3();
    }
}

public class South : Direction
{
    public override Vector2Int ToLocalV2()
    {
        return new Vector2Int(0, -1);
    }
    public override Direction Reverse()
    {
        return new North();
    }
    public override Vector3 RoadViewLocalV3()
    {
        return new Vector3(0, 0, -.25f);
    }
    public override Vector3 RoadViewLocalEuler()
    {
        return new Vector3();
    }
}

public class West : Direction
{
    public override Vector2Int ToLocalV2()
    {
        return new Vector2Int(-1, 0);
    }
    public override Direction Reverse()
    {
        return new East();
    }
    public override Vector3 RoadViewLocalV3()
    {
        return new Vector3(-.25f, 0, 0);
    }
    public override Vector3 RoadViewLocalEuler()
    {
        return new Vector3(0, 90, 0);
    }
}

public class East : Direction
{
    public override Vector2Int ToLocalV2()
    {
        return new Vector2Int(1, 0);
    }
    public override Direction Reverse()
    {
        return new West();
    }
    public override Vector3 RoadViewLocalV3()
    {
        return new Vector3(.25f, 0, 0);
    }
    public override Vector3 RoadViewLocalEuler()
    {
        return new Vector3(0, 90, 0);
    }
}
