using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Discovery : SingletonMonoBehavior<Discovery>
{
    public Dictionary<Type, int> GameBuildingsDict = new Dictionary<Type, int>();
    List<Type> BuildTypeList = new List<Type>();
    [SerializeField] DiscoveryBar barView;
    private void Start()
    {
        BuildTypeList.Add(typeof(House));
        BuildTypeList.Add(typeof(Mine));
        BuildTypeList.Add(typeof(CityHall));
        BuildTypeList.Add(typeof(Farm));
        BuildTypeList.Add(typeof(HouseLV2));
        BuildTypeList.Add(typeof(HouseLV3));
        BuildTypeList.Add(typeof(Forest));
        BuildTypeList.Add(typeof(ForestLv2));
        BuildTypeList.Add(typeof(ForestLv3));
        BuildTypeList.Add(typeof(ForestMax));
        BuildTypeList.Add(typeof(Sports));
        BuildTypeList.Add(typeof(Sawmill));
    }

    public bool IsForestMaxExist()
    {
        return GameBuildingsDict.ContainsKey(typeof(ForestMax)) && (GameBuildingsDict[typeof(ForestMax)] > 0);
    }
    public bool IsCityHallExist(){
        return GameBuildingsDict.ContainsKey(typeof(CityHall)) && (GameBuildingsDict[typeof(CityHall)] > 0);
    }

    public void RecordToDict(Build build)
    {
        print(build.GetType().Name);
        Type TargetType = build.GetType();
        if (!GameBuildingsDict.ContainsKey(TargetType))
        {
            GameBuildingsDict.Add(TargetType, 0);
        }
        GameBuildingsDict[TargetType]++;
        GameBuildingsDict[TargetType] = Mathf.Clamp(GameBuildingsDict[TargetType], 0, int.MaxValue);
        OnRecordInDict();
    }

    public void RemoveToDict(Build build)
    {
        Type TargetType = build.GetType();
        print(TargetType.Name);
        print(GameBuildingsDict.ContainsKey(TargetType));

        if (build == null || !GameBuildingsDict.ContainsKey(TargetType))
        {
            return;
        }
        GameBuildingsDict[TargetType]--;
        GameBuildingsDict[TargetType] = Mathf.Clamp(GameBuildingsDict[TargetType], 0, int.MaxValue);
        OnRecordInDict();
    }

    void OnRecordInDict()
    {
        barView.UpdateBar();


    }

    public float GetDiscoveryRate()
    {
        return (float)GameBuildingsDict.Count / (float)BuildTypeList.Count;
    }

}
