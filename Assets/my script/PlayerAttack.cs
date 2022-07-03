using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _swordEquip;
    Animator _anim;
    int _comboCount = 0;
    bool _test = false;
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
        //ps�R���g���[���́Z�{�^�����������Ƃ��B���A�����\���Ă�Ƃ��Ɉȉ������s����B
        if (Input.GetButtonDown("Fire3") && _swordEquip.activeSelf && !_test)
        {
            Debug.Log(_comboCount % 3 + 1);
            //attack���[�V�����X�^�[�g
            StartCoroutine(AttackTest(_comboCount % 3 + 1));
            //�R���{�����J�E���g
            _comboCount++;
        }
    }

    /// <summary> i�Ԗڂ�attack���[�V������true�ɂ���B </summary>
    private IEnumerator AttackTest(int i)
    {
        _test = true;
        yield return new WaitForSeconds(0.1f);
        _anim.SetBool($"isAttack{i}", true);
        yield return new WaitForSeconds(0.2f);
        _anim.SetBool($"isAttack{i}", false);
        _test = false;
    }
}
