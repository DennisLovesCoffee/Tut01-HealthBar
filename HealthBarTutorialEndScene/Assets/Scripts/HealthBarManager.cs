using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    #region Singleton

    public static HealthBarManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("We messed up bigtime!!");
            Destroy(this);
        }
    }

    #endregion


    [SerializeField]
    private GameObject healthBarPrefab;

    [SerializeField]
    private float healthBarDissapearTime, healthBarChangeSpeed;


    public void SpawnHealthBar(GameObject parentGo, Transform healthBarTransfrom)
    {
        GameObject healthBar = Instantiate(healthBarPrefab, healthBarTransfrom);
        healthBar.GetComponent<HealthBar>().SetUpHealthBar(parentGo, healthBarDissapearTime, healthBarChangeSpeed);
    }
    
}
