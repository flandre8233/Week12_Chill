using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMapPosition : SingletonMonoBehavior<MouseMapPosition>
{
    [SerializeField] GameObject TestObject;

    private void Update()
    {
        Vector2Int MapPos = GetMouseMapPos();
        Vector3 TargetPos = new Vector3(MapPos.x * 5, 0, MapPos.y * 5);
        TestObject.transform.position = TargetPos;
    }


    public Vector2Int GetMouseMapPos()
    {
        Vector3 WorldPos = GetMouseWorldPosOnPlane();
        int X = Mathf.RoundToInt(WorldPos.x / 5);
        int Y = Mathf.RoundToInt(WorldPos.z / 5);
        return new Vector2Int(X, Y);
    }

    Vector3 GetMouseWorldPosOnPlane()
    {
        Plane WorldGround = new Plane(Vector3.up, 0f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distanceToPlane = 0;
        if (WorldGround.Raycast(ray, out distanceToPlane))
        {
            return ray.GetPoint(distanceToPlane);
        }
        return new Vector3();
    }
}
