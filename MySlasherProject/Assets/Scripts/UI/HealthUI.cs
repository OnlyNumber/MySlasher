using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public Image CharacterIconImage;
    public Image HealthBarImage;
    public TMP_Text HealthText;
    [SerializeField]
    private HealthHandler _healthHandler;

    private void Start()
    {
        _healthHandler = FindObjectOfType<HealthHandler>();
        _healthHandler.OnHealthChange += Change;
    }

    public void Initialize(HealthHandler healthHandler)
    {
        _healthHandler = healthHandler;
        _healthHandler.OnHealthChange += Change;
    }

    public void Change(int currentHealth)
    {
        HealthBarImage.fillAmount = currentHealth / _healthHandler.MaxHealth;
        HealthText.text = currentHealth + " / " + _healthHandler.MaxHealth;
    }

}
