using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image healthBarSlider;

    private float dissaperTime, timeSinceLastChange;
    private float changeTime;

    private Health healthScript;
    private Transform mainCamTrasform;

    public void SetUpHealthBar(GameObject parentGo, float _dissaperTime, float _changeSpeed)
    {
        dissaperTime = _dissaperTime;
        changeTime = _changeSpeed;
        mainCamTrasform = Camera.main.transform;

        healthScript = parentGo.GetComponent<Health>();
        healthScript.OnHealthChanged += OnHealthChanged;

        timeSinceLastChange = 0f;

        float sliderStartPct = healthScript.CurrentHealth / (float)healthScript.MaxHealth;
        healthBarSlider.fillAmount = sliderStartPct;
    }

    private void LateUpdate()
    {
        if(timeSinceLastChange > dissaperTime)
        {
            DestoyHealthBar();
        }

        timeSinceLastChange += Time.deltaTime;
        transform.LookAt(2 * mainCamTrasform.position - transform.position);
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        if(currentHealth <= 0)
        {
            DestoyHealthBar();
        }

        timeSinceLastChange = 0f;
        float healthPct = currentHealth / (float)maxHealth;
        StartCoroutine(HealthSliderChange(healthPct));
    }


    private IEnumerator HealthSliderChange(float endFillPct)
    {
        float timeElapsed = 0f;
        float startFillPct = healthBarSlider.fillAmount;
        while(timeElapsed < changeTime)
        {
            healthBarSlider.fillAmount = Mathf.Lerp(startFillPct, endFillPct, timeElapsed / changeTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void DestoyHealthBar()
    {
        healthScript.OnHealthChanged -= OnHealthChanged;
        Destroy(gameObject, changeTime);
    }
}
