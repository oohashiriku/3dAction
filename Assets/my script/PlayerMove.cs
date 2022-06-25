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
        //メインカメラを基準に方向を決める
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;
        //速度がゼロでなければ
        if (rb.velocity != Vector3.zero)
        {
            //正面に速度を代入
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
        //入力
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        //方向ベクトルを取得
        dir = new Vector3(moveX, 0, moveZ);
    }
}
