using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _swordEquip;
    Animator _anim;
    int _attackCount = 0;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        AttackCombo();
    }
    void AttackCombo()
    {
        bool combo = Input.GetButtonDown("Fire3");
        if (combo && _swordEquip.activeSelf && _attackCount <= 0)
        {
            _attackCount++;
            _anim.SetTrigger("isAttack");
        }
        else if(combo && _anim.GetCurrentAnimatorStateInfo(0).IsName("combo1") && _attackCount <= 1)
        {
            _attackCount++;
            _anim.SetTrigger("isAttack2");
        }
        else if (combo && _anim.GetCurrentAnimatorStateInfo(0).IsName("combo2") && _attackCount <= 2)
        {
            _attackCount++;
            _anim.SetTrigger("isAttack3");
        }
    }
}
