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
        //psコントローラの〇ボタンを押したとき。かつ、剣を構えてるときに以下を実行する。
        if (Input.GetButtonDown("Fire3") && _swordEquip.activeSelf && !_canCombo)
        {
            //attackモーションスタート
            StartCoroutine(IsAttack(_comboCount % 3 + 1));//コンボ数の上限を3にする。
            //コンボ数をカウント
            _comboCount++;
        }
    }
    /// <summary> i番目のattackモーションをtrueにする。かつ、インターバルがスタートする。</summary>
    private IEnumerator IsAttack(int i)
    {
        _canCombo = true;
        yield return new WaitForSeconds(0.1f);//0.1秒待つ
        _anim.SetBool($"isAttack{i}", true);
        yield return new WaitForSeconds(0.2f);//0.2秒待つ
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
