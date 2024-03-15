using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthEnemyUI : MonoBehaviour
{
    public RectTransform rectTransform;
    private Transform _target;
    public Image HealthBarImage;
    public TMP_Text HealthText;
    [SerializeField]
    private HealthHandler _healthHandler;
    


    private void Start()
    {
        _target = Camera.main.transform;

        _healthHandler.OnHealthChange += Change;
        Change(_healthHandler.MaxHealth);
    }

    private void Update()
    {
        rectTransform.LookAt(_target);
        rectTransform.Rotate(new Vector3(0, 180, 0));

    }

    /*public void Initialize(HealthHandler healthHandler)
    {
        _healthHandler = healthHandler;
        _healthHandler.OnHealthChange += Change;
    }*/

    public void Change(int currentHealth)
    {
        HealthBarImage.fillAmount = (float)currentHealth / (float)_healthHandler.MaxHealth;
        HealthText.text = currentHealth + " / " + _healthHandler.MaxHealth;
    }

}
