using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    [SerializeField]
    private List<Spell> _spells;

    ITargetFindAble targetFindAble;

    IAttackAble attackAble;

    private void Start()
    {
        targetFindAble = GetComponent<ITargetFindAble>();
        attackAble = GetComponent<IAttackAble>();
    }

    public void CastSpell(int index)
    {
        Vector3 transferPos = targetFindAble.GetTargetPosition();
        transferPos += new Vector3(0, 0.2f, 0);

        Spell spell = Instantiate(_spells[index], transferPos, Quaternion.identity);
        spell.Initialize(attackAble.GetDamage());



    }

}
