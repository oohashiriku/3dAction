using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _swordEquip;
    Animator _anim;
    int _comboCount = 0;
    bool _canCombo = false;
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
        if (Input.GetButtonDown("Fire3") && _swordEquip.activeSelf && !_canCombo)
        {                                                           //�`�`�`�`�`�`
                                                                    //�C���^�[�o�����I������Ƃ��B
            //attack���[�V�����X�^�[�g                              
            StartCoroutine(AttackTest(_comboCount % 3 + 1));//�R���{���̏����3�ɂ���B
            //�R���{�����J�E���g
            _comboCount++;
        }
    }
    /// <summary> i�Ԗڂ�attack���[�V������true�ɂ���B���A�C���^�[�o�����X�^�[�g����B</summary>
    private IEnumerator AttackTest(int i)
    {
        _canCombo = true;
        yield return new WaitForSeconds(0.1f);//0.1�b�҂�
        _anim.SetBool($"isAttack{i}", true);
        yield return new WaitForSeconds(0.2f);//0.2�b�҂�
        _anim.SetBool($"isAttack{i}", false);
        _canCombo = false;
    }
}
