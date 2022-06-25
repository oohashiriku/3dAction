using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float moveX;
    float moveZ;
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
        if (rb.velocity != Vector3.zero)
        {
            //���ʂɑ��x����
            transform.forward = rb.velocity;
        }
        rb.velocity = dir.normalized * moveSpeed;
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        //����
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        //�����x�N�g�����擾
        dir = new Vector3(moveX, 0, moveZ);
    }
}
