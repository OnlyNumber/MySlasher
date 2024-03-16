using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using StarterAssets;

public class PlayerUI : MonoBehaviour
{
    public Image CharacterIconImage;
    public Material HealthBarImage;
    public TMP_Text HealthText;

    public List<Image> IconsColdown;

    [SerializeField]
    private HealthHandler _healthHandler;

    public void Initialize(HealthHandler healthHandler)
    {
        _healthHandler = healthHandler;
        _healthHandler.OnHealthChange += Change;
        Change(_healthHandler.MaxHealth);
    }

    
    public void Initialize(ThirdPersonController player)
    {
        Debug.Log("First injection player ui");

        _healthHandler = player.GetComponent<HealthHandler>();

        _healthHandler.OnHealthChange += Change;
        Change(_healthHandler.MaxHealth);

        //SpawnWave();

    }


    public void Change(int currentHealth)
    {
        HealthBarImage.SetFloat(StaticFields.FILL_AMOUNT_MATERIAL, (float)currentHealth / (float)_healthHandler.MaxHealth);
        HealthText.text = currentHealth + " / " + _healthHandler.MaxHealth;
    }

}
