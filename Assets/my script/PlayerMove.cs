using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;
    Rigidbody rb;
    Vector3 dir = new Vector3(0, 0, 0);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //���C���J��������ɕ��������߂�
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;
        //���x���[���łȂ����
        if (dir != Vector3.zero)
        {
            //���ʂɑ��x����
            transform.forward = dir;
        }
            rb.velocity = dir.normalized * moveSpeed + new Vector3(0f, rb.velocity.y, 0f);
    }
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        //����
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        //�����x�N�g�����擾
        dir = new Vector3(moveX, 0, moveZ);
        
    }
    void Jump()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("aaa");
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
