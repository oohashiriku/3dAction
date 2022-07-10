using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpPower;
    [SerializeField] GameObject _sword;
    [SerializeField] GameObject _swordEquip;
    Vector3 _dir = new Vector3(0, 0, 0);
    Rigidbody _rb;
    Animator _anim;
    int _equipCount = 0;
    bool _canEquip = false;
    bool _canRoll = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //���C���J��������ɕ��������߂�B
        _dir = Camera.main.transform.TransformDirection(_dir);
        _dir.y = 0;
        //���x���[���łȂ����
        if (_dir != Vector3.zero)
        {
            _anim.SetFloat("speed", 1f);
            //���ʂɑ��x����
            transform.forward = _dir;
        }
        else
        {
            _anim.SetFloat("speed", 0f);
        } 

        if(_anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            _rb.velocity = _dir.normalized * _moveSpeed + new Vector3(0f, _rb.velocity.y, 0f);//y���W�͂��̂܂�
        }
    }
    void Update()
    {
        Move();//player�̈ړ�
        Jump();//player�̃W�����v
        Equip();//player�̔���
        Roll();
    }
    void Move()
    {
        //����
        float _moveX = Input.GetAxisRaw("Horizontal");
        float _moveZ = Input.GetAxisRaw("Vertical");
        //�����x�N�g�����擾
        _dir = new Vector3(_moveX, 0, _moveZ);

    }
    void Jump()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);//�W�����v�̌v�Z
        }
    }
    void Equip()
    {
        //ps�R���g���[���[�́��{�^�����������Ƃ��B���A�C���^�[�o�����I������Ƃ��B
        if(Input.GetButtonDown("Fire2") && !_canEquip)
        {
            //�[���A�����̃��[�V�������X�^�[�g
            StartCoroutine(EquipInterval(_equipCount % 2 + 1));//�[���Ɣ����̃��[�V���������݂ɂ���B
            _equipCount++;
        }
    }
    /// <summary> �C���^�[�o�� </summary>
    private IEnumerator EquipInterval(int i)
    {
        _canEquip = true;
        _anim.SetTrigger($"isEquip{i}");
        yield return new WaitForSeconds(1.5f);//1.5�b�҂�
        _canEquip = false;
    }
    void Roll()
    {
        if(Input.GetButtonDown("roll") && !_canRoll)
        {
            StartCoroutine(RollInterval());
        }
    }
    private IEnumerator RollInterval()
    {
        _canRoll = true;
        _anim.SetTrigger("isRoll");
        yield return new WaitForSeconds(1.2f);
        _canRoll = false;
    }
    /// <summary> �����̃A�j���[�V�����C�x���g </summary>
    void EquipEvent()
    {
        _sword.SetActive(false);
        _swordEquip.SetActive(true);
    }
    /// <summary> �[���̃A�j���[�V�����C�x���g </summary>
    void UnequipEvent()
    {       
        _sword.SetActive(true);
        _swordEquip.SetActive(false);
    }
}
