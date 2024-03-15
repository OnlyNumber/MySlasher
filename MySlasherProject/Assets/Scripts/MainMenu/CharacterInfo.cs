using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character")]
public class CharacterInfo : ScriptableObject
{
    public List<Skill> SkillIcons;

    public Sprite CharacterIcon;

    public GameObject CharacteModel;

    public StarterAssets.ThirdPersonController personController;


}
