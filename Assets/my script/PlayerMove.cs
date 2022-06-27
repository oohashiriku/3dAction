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
        //メインカメラを基準に方向を決める
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;
        //速度がゼロでなければ
        if (dir != Vector3.zero)
        {
            //正面に速度を代入
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
        //入力
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        //方向ベクトルを取得
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
