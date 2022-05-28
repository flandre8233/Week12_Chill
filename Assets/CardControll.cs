using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControll : SingletonMonoBehavior<CardControll>
{
    [SerializeField]
    List<Card> CurrentCards = new List<Card>();

    public int MaxCardCount
    {
        get
        {
            return 3 + (Discovery.instance.IsForestMaxExist() ? 1 : 0) + (Discovery.instance.IsCityHallExist() ? 1 : 0);
        }
    }

    [SerializeField] Transform CanvasTrans;

    public void OnAddCard(Card card)
    {
        CurrentCards.Add(card);
    }
    public void OnRemoveCard(Card card)
    {
        CurrentCards.Remove(card);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GiveToPlayerCard();
        }
    }

    public void GiveToPlayerCard()
    {
        if (CurrentCards.Count < MaxCardCount)
        {
            GetOneCard();
        }
    }

    void GetOneCard()
    {
        ResourcesSpawner.Spawn("SpawnCard" , 3f);
        RectTransform CardRect = ResourcesSpawner.Spawn("Card").GetComponent<RectTransform>();
        CardRect.SetParent(CanvasTrans);
        CardRect.anchoredPosition = new Vector2(Random.Range(-Screen.width / 2 + (Screen.width * 0.1f), Screen.width / 2 - (Screen.width * 0.1f)), 0);
        CardRect.localScale = new Vector3(1, 1, 1);
    }
}
