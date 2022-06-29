using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpPower;
    Rigidbody _rb;
    Animator _anim;
    Vector3 _dir = new Vector3(0, 0, 0);
    int _equipCount = 0; 
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //���C���J��������ɕ��������߂�
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
        _rb.velocity = _dir.normalized * _moveSpeed + new Vector3(0f, _rb.velocity.y, 0f);
    }
    void Update()
    {
        Move();
        Jump();
        Equip();

    }
    void Move()
    {
        //����
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        //�����x�N�g�����擾
        _dir = new Vector3(moveX, 0, moveZ);

    }
    void Jump()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }
    void Equip()
    {
        if(Input.GetButtonDown("Fire2") && _equipCount <= 0)
        {
            Debug.Log("ss");
            _equipCount++;
            _anim.SetTrigger("isEquip");
        }
    }
}
