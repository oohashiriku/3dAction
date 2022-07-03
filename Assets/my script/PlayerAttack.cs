using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _swordEquip;
    Animator _anim;
    int _comboCount = 0;
    bool _test = false;
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
        if (Input.GetButtonDown("Fire3") && _swordEquip.activeSelf && !_test)
        {
            Debug.Log(_comboCount % 3 + 1);
            //attackモーションスタート
            StartCoroutine(AttackTest(_comboCount % 3 + 1));
            //コンボ数をカウント
            _comboCount++;
        }
    }

    /// <summary> i番目のattackモーションをtrueにする。 </summary>
    private IEnumerator AttackTest(int i)
    {
        _test = true;
        yield return new WaitForSeconds(0.1f);
        _anim.SetBool($"isAttack{i}", true);
        yield return new WaitForSeconds(0.2f);
        _anim.SetBool($"isAttack{i}", false);
        _test = false;
    }
}
