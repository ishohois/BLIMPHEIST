using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthUpdater : MonoBehaviour
{
    public GameObject[] plasters;

    private void OnEnable()
    {
        HealthSystem.updateHealth += DecreaseHealth;
        HealthSystem.updateHealth += IncreaseHealth;
    }

    private void OnDisable()
    {
        HealthSystem.updateHealth += DecreaseHealth;
        HealthSystem.updateHealth += IncreaseHealth;
    }

    private void DecreaseHealth(HealthSystem health)
    {
        for (int i = health.GetHealthPoints(); i < plasters.Length; i++)
        {
            plasters[i].SetActive(false);
        }
    }

    private void IncreaseHealth(HealthSystem health)
    {
        for (int i = 0; i < health.GetHealthPoints(); i++)
        {
            plasters[i].SetActive(true);
        }
    }

}
