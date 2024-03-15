using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPlayerUI : MonoBehaviour
{
    public Image CharacterIconImage;
    public Material HealthBarImage;
    public TMP_Text HealthText;
    [SerializeField]
    private HealthHandler _healthHandler;

    public void Initialize(HealthHandler healthHandler)
    {
        _healthHandler = healthHandler;
        _healthHandler.OnHealthChange += Change;
        Change(_healthHandler.MaxHealth);
    }

    public void Change(int currentHealth)
    {
        HealthBarImage.SetFloat(StaticFields.FILL_AMOUNT_MATERIAL, (float)currentHealth / (float)_healthHandler.MaxHealth);
        //Debug.Log("Health percent:" +currentHealth / _healthHandler.MaxHealth);
        HealthText.text = currentHealth + " / " + _healthHandler.MaxHealth;
    }

}
