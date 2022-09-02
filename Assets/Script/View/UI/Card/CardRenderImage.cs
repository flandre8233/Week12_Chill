using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardRenderImage : MonoBehaviour
{
    [SerializeField] Card ParentCard;
    [SerializeField] RawImage RawImage;
    void Start()
    {
        RawImage.texture = Resources.Load<Texture>("Render-" + ParentCard.CardIndex);
    }
}
