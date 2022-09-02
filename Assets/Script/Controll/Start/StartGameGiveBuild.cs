using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameGiveBuild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BuildingSpawner.instance.Spawn(new Vector2Int(0, 0), Direction.GetAllDirections() );
        Destroy(this);
    }

}
