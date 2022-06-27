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

        dir.y = rb.velocity.y;
        rb.velocity = dir.normalized * moveSpeed;
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
        dir = new Vector3(moveX, 0, moveZ);
        //�����x�N�g�����擾
    }
    void Jump()
    {
        bool jump = Input.GetButtonDown("Jump");
        if(jump)
        {
            Debug.Log("aaa");
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
