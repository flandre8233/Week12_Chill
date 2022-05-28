using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GroundData data;

    [SerializeField] Transform View;
    [SerializeField] Transform GroundView;
    public static Ground Spawn(Building ParentBuilding)
    {
        Transform SpawnedTrans = ResourcesSpawner.Spawn("Ground").transform;
        SpawnedTrans.parent = ParentBuilding.View;
        SpawnedTrans.localPosition = new Vector3();
        SpawnedTrans.localScale = new Vector3(1, 1, 1);
        Ground Ground = SpawnedTrans.GetComponent<Ground>();
        Ground.data = ParentBuilding.ground;
        return Ground;
    }

    private void Start()
    {
        if (data.directions.Length <= 0)
        {
            Destroy(GroundView.gameObject);
        }
        else
        {
            foreach (var item in data.directions)
            {
                SpawnRoadView(item);
            }
        }
    }

    void SpawnRoadView(Direction Dir)
    {

        Transform SpawnedTrans = ResourcesSpawner.Spawn("Road").transform;
        SpawnedTrans.parent = View;
        SpawnedTrans.localScale = new Vector3(.2f, 1.1f, .5f);
        SpawnedTrans.localPosition = Dir.RoadViewLocalV3();
        SpawnedTrans.localEulerAngles = Dir.RoadViewLocalEuler();
    }
}
