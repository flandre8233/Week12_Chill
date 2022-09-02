using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClear : MonoBehaviour
{
    [SerializeField]
    float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ClearUp", delayTime);
    }

    void ClearUp()
    {
        Destroy(GetComponent<Animator>());
    }
}
