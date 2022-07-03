using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _swordEquip;
    Animator _anim;
    int _comboCount = 0;
    bool _canCombo = false;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        AttackCombo();
    }
    void AttackCombo()
    {
        //psコントローラの〇ボタンを押したとき。かつ、剣を構えてるときに以下を実行する。
        if (Input.GetButtonDown("Fire3") && _swordEquip.activeSelf && !_canCombo)
        {                                                           //～～～～～～
                                                                    //インターバルが終わったとき。
            //attackモーションスタート                              
            StartCoroutine(AttackTest(_comboCount % 3 + 1));//コンボ数の上限を3にする。
            //コンボ数をカウント
            _comboCount++;
        }
    }
    /// <summary> i番目のattackモーションをtrueにする。かつ、インターバルがスタートする。</summary>
    private IEnumerator AttackTest(int i)
    {
        _canCombo = true;
        yield return new WaitForSeconds(0.1f);//0.1秒待つ
        _anim.SetBool($"isAttack{i}", true);
        yield return new WaitForSeconds(0.2f);//0.2秒待つ
        _anim.SetBool($"isAttack{i}", false);
        _canCombo = false;
    }
}
