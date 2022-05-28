using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Development : MonoBehaviour
{
    [SerializeField]
    float TryDevelopTime;
    Build TargetBuild = new EmptyVoid();
    [SerializeField] Building Building;
    Transform SpawnView;

    private void OnEnable()
    {
        Building.build = new BuildData(TargetBuild);
        InvokeRepeating("Develop", TryDevelopTime, TryDevelopTime);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    public void Develop()
    {
        

        Build NewTargetBuild = null;

        if (!TypeChecker.IsSameOrSubclass(typeof(House), TargetBuild.GetType()) && House.CanSpawn(Building))
        {
            NewTargetBuild = new House();
        }

        if (TypeChecker.IsSameOrSubclass(typeof(House), TargetBuild.GetType()))
        {
            if (!TypeChecker.IsSameOrSubclass(typeof(Sports), TargetBuild.GetType()) && Sports.CanSpawn(Building))
            {
                NewTargetBuild = new Sports();
            }
            if (!TypeChecker.IsSameOrSubclass(typeof(Mine), TargetBuild.GetType()) && Mine.CanSpawn(Building))
            {
                NewTargetBuild = new Mine();
            }
            if (!TypeChecker.IsSameOrSubclass(typeof(Sawmill), TargetBuild.GetType()) && Sawmill.CanSpawn(Building))
            {
                NewTargetBuild = new Sawmill();
            }
            if (!TypeChecker.IsSameOrSubclass(typeof(HouseLV2), TargetBuild.GetType()) && HouseLV2.CanSpawn(Building))
            {
                NewTargetBuild = new HouseLV2();
            }
            if (!TypeChecker.IsSameOrSubclass(typeof(HouseLV3), TargetBuild.GetType()) && HouseLV3.CanSpawn(Building))
            {
                NewTargetBuild = new HouseLV3();
            }

        }

        if (!TypeChecker.IsSameOrSubclass(typeof(CityHall), TargetBuild.GetType()) && CityHall.CanSpawn(Building))
        {
            NewTargetBuild = new CityHall();
        }

        if (!TypeChecker.IsSameOrSubclass(typeof(Farm), TargetBuild.GetType()) && Farm.CanSpawn(Building))
        {
            NewTargetBuild = new Farm();
        }


        if (!TypeChecker.IsSameOrSubclass(typeof(Forest), TargetBuild.GetType()) && Forest.CanSpawn(Building))
        {
            NewTargetBuild = new Forest();
        }

        if (TypeChecker.IsSameOrSubclass(typeof(Forest), TargetBuild.GetType()))
        {
            if (!TypeChecker.IsSameOrSubclass(typeof(ForestLv2), TargetBuild.GetType()) && ForestLv2.CanSpawn(Building))
            {
                NewTargetBuild = new ForestLv2();
            }
            if (!TypeChecker.IsSameOrSubclass(typeof(ForestLv3), TargetBuild.GetType()) && ForestLv3.CanSpawn(Building))
            {
                NewTargetBuild = new ForestLv3();
            }
            if (!TypeChecker.IsSameOrSubclass(typeof(ForestMax), TargetBuild.GetType()) && ForestMax.CanSpawn(Building))
            {
                NewTargetBuild = new ForestMax();
            }
        }



        if (NewTargetBuild != null)
        {
            if (SpawnView)
            {
                print("Remove");
                Destroy(SpawnView.gameObject);
            }
            Discovery.instance.RemoveToDict(TargetBuild);
            TargetBuild = NewTargetBuild;
            Discovery.instance.RecordToDict(NewTargetBuild);
            Building.build = new BuildData(TargetBuild);
            SpawnView = Building.build.SpawnView(Building).transform;
        ResourcesSpawner.Spawn("LevelUp",3f);
        }
    }

}
