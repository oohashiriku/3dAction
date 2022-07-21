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

        yield return new WaitForSeconds(0.1f);//0.1秒待つ
        _canAttack = true;
        _anim.SetBool($"isAttack{i}", true);
        yield return new WaitForSeconds(0.2f);//0.2秒待つ
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
        Debug.Log("突き攻撃");
        GameObject _instance = Instantiate(_rushEffect);
        _instance.transform.position = _rushMuzzle.transform.position;
        _instance.transform.rotation = _rushMuzzle.transform.rotation;
        _instance.transform.parent = transform;
        _rb.AddForce(transform.forward * _attackSpeed, ForceMode.Impulse);
    }
    void ComboEffect1()
    {
        Debug.Log($"コンボ攻撃{_comboMuzzleCount}");
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
