using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Card : MonoBehaviour
{
    [SerializeField]
    public int CardIndex;
    Direction[] directions;
    GameObject CardContextView;
    private void Start()
    {
        CardControll.instance.OnAddCard(this);
        CardIndex = CardIndexControll.GetCardIndex();
        InitDirections();
        CardContextView = BuildingSpawner.instance.Spawn(CardIndex, directions).gameObject;
    }

    void InitDirections()
    {
        directions = new Direction[] { new North(), new South(), new West(), new East() };
        directions = Shuffle(directions);
        int TakingLength = Random.Range(0, directions.Length + 1);
        directions = directions.Take(TakingLength).ToArray();
    }

    T[] Shuffle<T>(T[] Array)
    {
        var sorted = Array.OrderBy(a => System.Guid.NewGuid()).ToList();
        return sorted.ToArray();
    }

    public void OnPlayerDrop(Vector2Int MapPos)
    {
        if (BuildingSpawner.instance.IsPosCanBeSpawn(MapPos, directions))
        {
            BuildingSpawner.instance.Spawn(MapPos, directions);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        CardControll.instance.OnRemoveCard(this);
        Destroy(CardContextView);
        CardIndexControll.AddIndex(CardIndex);
    }
}
