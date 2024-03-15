using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelecter : MonoBehaviour
{
    [SerializeField]
    private SelectButton _selectButton;

    [SerializeField]
    private SkillDescriptionItem descriptionItem;

    private List<SelectButton> _selectButtons = new List<SelectButton>();

    [SerializeField]
    private List<CharacterInfo> _characterInfos;

    private List<GameObject> _charactersModels = new List<GameObject>();

    private List<SkillDescriptionItem> _skillDescriptionItems = new List<SkillDescriptionItem>();

    [SerializeField]
    private Transform _gridSkills;

    [SerializeField]
    private Transform _gridCharactres;

    [SerializeField]
    private Transform _characterPos;

    //private int _currentCharacter = -1;

    private PlayerDataC _player;

    private void Start()
    {

        DataControl.Instance.OnDataLoaded += Initialize;

    }

    private void Initialize(PlayerDataC player)
    {
        _player = player;
        
        for (int i = 0; i < _characterInfos.Count; i++)
        {
            int index = i;

            SelectButton transfer = Instantiate(_selectButton, _gridCharactres);
            transfer.Icon.sprite = _characterInfos[i].CharacterIcon;
            transfer.SelectingButton.onClick.AddListener(() => ShowCharacter(index));

            _selectButtons.Add(transfer);

            _charactersModels.Add(Instantiate(_characterInfos[i].CharacteModel, _characterPos));

            _charactersModels[i].SetActive(false);
        }

        ShowCharacter(0);
    }

    private void ShowCharacter(int index)
    {
        //Debug.Log("Show character");
       
        /*if(index == _player.CurrentCharacter)
        {
            return;
        }*/


        _charactersModels[_player.CurrentCharacter].SetActive(false);

        _player.CurrentCharacter = index;
        //Debug.Log(_player.CurrentCharacter);

        _charactersModels[_player.CurrentCharacter].SetActive(true);

        foreach (var item in _skillDescriptionItems)
        {
            Destroy(item.gameObject);
        }

        _skillDescriptionItems.Clear();


        for (int i = 0; i < _characterInfos[index].SkillIcons.Count; i++)
        {
            _skillDescriptionItems.Add(Instantiate(descriptionItem, _gridSkills));

            _skillDescriptionItems[i].SkillIcon.sprite = _characterInfos[index].SkillIcons[i].IconSkill;
            _skillDescriptionItems[i].SkillDescription.text = _characterInfos[index].SkillIcons[i].SkillDescription;
        }


    }

}
