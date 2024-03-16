using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.SceneManagement;
using Zenject;

public class PauseControl : MonoBehaviour
{
    [SerializeField]
    private ActivePanel _pausePanel;

    [SerializeField]
    private ActivePanel _diePanel;

    [SerializeField]
    private TimeControl _timeControl;
    
    private StarterAssetsInputs _input;

    private HealthHandler _healthHandler;


    public void Initialize(StarterAssetsInputs input)
    {
        _input = input;

        _healthHandler = _input.GetComponent<HealthHandler>();

        _healthHandler.OnHealthChange += CheckDeath;
    }

    [Inject] public void Initialize(ThirdPersonController player)
    {
        _input = player.GetComponent<StarterAssetsInputs>();

        _healthHandler = _input.GetComponent<HealthHandler>();

        _healthHandler.OnHealthChange += CheckDeath;
    }


    private void Update()
    {
        if (_input == null)
        {
            return;
        }
        
        if(_input.escape && !_diePanel.IsShowed())
        {
            ShowPanel();
        }

        _input.escape = false;


    }

    public void CheckDeath(int health)
    {
        Debug.Log("CheckDeath:  " + health);

        if(health <=0 )
        {
            _diePanel.SetActivity(true);
            _timeControl.SetTime(0);
        }
    }


    public void ShowPanel()
    {
        _pausePanel.SetActivity(true);
        _timeControl.SetTime(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(StaticFields.GAME_SCENE);
    }

    public void MainMenuGame()
    {
        SceneManager.LoadScene(StaticFields.MAIN_SCENE);

    }


}
