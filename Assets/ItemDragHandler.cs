using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Card ParentCard;

    public void OnBeginDrag(PointerEventData eventData)
    {
        ResourcesSpawner.Spawn("CardFilp", 3f);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        transform.position += new Vector3(100, -150, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResourcesSpawner.Spawn("Deal", 3f);

        Vector2Int MapPos = MouseMapPosition.instance.GetMouseMapPos();
        ParentCard.OnPlayerDrop(MapPos);
        transform.localPosition = new Vector3();
        ParentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-Screen.width / 2 + (Screen.width * 0.1f), Screen.width / 2 - (Screen.width * 0.1f)), 0);
    }
}
