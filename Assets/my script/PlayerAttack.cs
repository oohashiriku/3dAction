using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _comboEffect;
    [SerializeField] GameObject _rushEffect;
    [SerializeField] Transform _rushMuzzle;
    [SerializeField] Transform[] _comboMuzzle;
    [SerializeField] float _attackSpeed;
    [SerializeField] GameObject _swordEquip;
    Animator _anim;
    int _comboCount = 0;
    int _comboMuzzleCount = 0;
    bool _canCombo = false;
    bool _canRush = false;
    public bool _canAttack = false;
    Rigidbody _rb;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
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

        yield return new WaitForSeconds(0.1f);//0.1�b�҂�
        _canAttack = true;
        _anim.SetBool($"isAttack{i}", true);
        yield return new WaitForSeconds(0.2f);//0.2�b�҂�
        _anim.SetBool($"isAttack{i}", false);
        _canCombo = false;
    }
    void AttackRush()
    {
        if(Input.GetButtonDown("rush") && _swordEquip.activeSelf && !_canRush)
        {
            _canAttack = true;
            _anim.SetTrigger("isTuki");
            StartCoroutine(RushInterval());
        }
    }
    private IEnumerator RushInterval()
    {
        _canRush = true;
        yield return new WaitForSeconds(1f);
        _canRush = false;
    }
    void MoveAttack()
    {
        Debug.Log("�˂��U��");
        GameObject _instance = Instantiate(_rushEffect);
        _instance.transform.position = _rushMuzzle.transform.position;
        _instance.transform.rotation = _rushMuzzle.transform.rotation;
        _instance.transform.parent = transform;
        _rb.AddForce(transform.forward * _attackSpeed, ForceMode.Impulse);
    }
    void ComboEffect1()
    {
        Debug.Log($"�R���{�U��{_comboMuzzleCount}");
        GameObject _instance = Instantiate(_comboEffect);
        _instance.transform.position = _comboMuzzle[_comboMuzzleCount].transform.position;
        _instance.transform.rotation = _comboMuzzle[_comboMuzzleCount].transform.rotation;
        _instance.transform.parent = transform;
        _comboMuzzleCount++;
 
    }
    void CanComboMove()
    {
        _comboMuzzleCount = 0;
        _canAttack = false;
    }
}
