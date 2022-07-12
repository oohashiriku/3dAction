using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _swordEquip;
    [SerializeField] Transform _muzzle;
    [SerializeField] GameObject _effect;
   [SerializeField] float _attackSpeed;
   
    ParticleSystem _ps;
    Animator _anim;
    Rigidbody _rb;
    int _comboCount = 0;
    bool _canCombo = false;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _ps = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        AttackCombo();
        AttackRush();
    }
    void AttackCombo()
    {
        //ps�R���g���[���́Z�{�^�����������Ƃ��B���A�����\���Ă�Ƃ��Ɉȉ������s����B
        if (Input.GetButtonDown("Fire3") && _swordEquip.activeSelf && !_canCombo)
        {
            //attack���[�V�����X�^�[�g
            StartCoroutine(IsAttack(_comboCount % 3 + 1));//�R���{���̏����3�ɂ���B
            //�R���{�����J�E���g
            _comboCount++;
        }
    }
    /// <summary> i�Ԗڂ�attack���[�V������true�ɂ���B���A�C���^�[�o�����X�^�[�g����B</summary>
    private IEnumerator IsAttack(int i)
    {
        _canCombo = true;
        yield return new WaitForSeconds(0.1f);//0.1�b�҂�
        _anim.SetBool($"isAttack{i}", true);
        yield return new WaitForSeconds(0.2f);//0.2�b�҂�
        _anim.SetBool($"isAttack{i}", false);
        _canCombo = false;
    }
    void AttackRush()
    {
        if(Input.GetButtonDown("rush"))
        {
            _anim.SetTrigger("isTuki");
        }
    }
    void MoveAttack()
    {
        GameObject _instance = Instantiate(_effect, this.transform.position, Quaternion.identity);
        _instance.transform.position = _muzzle.transform.position;

        _rb.AddForce(transform.forward * _attackSpeed, ForceMode.Impulse);
    }
}
