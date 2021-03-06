using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpPower;
    [SerializeField] GameObject _sword;
    [SerializeField] GameObject _swordEquip;
    [SerializeField] PlayerAttack _playerAttack;
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
        //メインカメラを基準に方向を決める。
        _dir = Camera.main.transform.TransformDirection(_dir);
        _dir.y = 0;
        //速度がゼロでなければ
        if (_dir != Vector3.zero)
        {
            _anim.SetFloat("speed", _moveSpeed, 0.1f, Time.deltaTime);
            if(!_canRoll)
            {
                //正面に速度を代入
                transform.forward = _dir;
            }
        }
        else
        {
            _dir.y = 0;
            _anim.SetFloat("speed",0f);
        }
        if(_anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            _rb.velocity = _dir.normalized * _moveSpeed + new Vector3(0f, _rb.velocity.y, 0f);//y座標はそのまま
        }
    }

    void Update()
    {
        Move();//playerの移動
        Jump();//playerのジャンプ
        Equip();//playerの抜刀
        Roll();//playerのローリング
    }
    void Move()
    {
        if(_playerAttack._canAttack)
        {
            _dir = new Vector3(0, 0, 0);
        }
        else
        {
            //入力
            float _moveX = Input.GetAxisRaw("Horizontal");
            float _moveZ = Input.GetAxisRaw("Vertical");
            //方向ベクトルを取得
            _dir = new Vector3(_moveX, 0, _moveZ);
        }
    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);//ジャンプの計算
        }
    }
    void Equip()
    {
        //psコントローラーの□ボタンを押したとき。かつ、インターバルが終わったとき。
        if(Input.GetButtonDown("Fire2") && !_canEquip)
        {
            //納刀、抜刀のモーションがスタート
            StartCoroutine(EquipInterval(_equipCount % 2 + 1));//納刀と抜刀のモーションを交互にする。
            _equipCount++;
        }
    }
    /// <summary> 抜刀納刀のインターバル </summary>
    private IEnumerator EquipInterval(int i)
    {
        _canEquip = true;
        _anim.SetTrigger($"isEquip{i}");
        yield return new WaitForSeconds(1.5f);//1.5秒待つ
        _canEquip = false;
    }
    void Roll()
    {
        //psコントローラーの×ボタンを押したとき。かつインターバルが終わったとき。
        if(Input.GetButtonDown("roll") && !_canRoll)
        {
            _playerAttack._canAttack = true;
            _canRoll = true;
            _anim.SetTrigger("isRoll");

            //ローリングのアニメーションスタート
            StartCoroutine(RollInterval());
        }
        if(_canRoll)
        {
            _rb.velocity = transform.forward * _moveSpeed;
        }
    }
    /// <summary> ローリングのインターバル </summary>
    private IEnumerator RollInterval()
    {
        yield return new WaitForSeconds(1.2f);
        _canRoll = false;
    }
    /// <summary> 納刀抜刀のアニメーションイベント </summary>
    void EquipEvent()
    {
        if(_sword.activeSelf)
        {
            _sword.SetActive(false);
            _swordEquip.SetActive(true);
        }
        else
        {
            _sword.SetActive(true);
            _swordEquip.SetActive(false);
        }
    }
}
