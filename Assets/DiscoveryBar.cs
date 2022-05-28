using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoveryBar : MonoBehaviour
{
    [SerializeField] float WantedRate = 0;
    float currentRate = 0;
    [SerializeField] Healthbar healthbar;

    public void UpdateBar()
    {
        WantedRate = Discovery.instance.GetDiscoveryRate();
    }

    private void Update() {
        currentRate = Mathf.Lerp(currentRate , WantedRate , Time.deltaTime * 3);
        healthbar.SetHealth(currentRate * 100);
    }
}
