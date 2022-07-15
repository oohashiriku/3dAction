using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventController : MonoBehaviour
{
    [SerializeField] GameObject _comboEffect;
    [SerializeField] GameObject _rushEffect;
    [SerializeField] Transform _rushMuzzle;
    [SerializeField] Transform _comboMuzzle1;
    [SerializeField] Transform _comboMuzzle2;
    [SerializeField] Transform _comboMuzzle3;
    [SerializeField] float _attackSpeed;
    [SerializeField] GameObject _sword;
    [SerializeField] GameObject _swordEquip;
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void MoveAttack()
    {
        GameObject _instance = Instantiate(_rushEffect);
        _instance.transform.position = _rushMuzzle.transform.position;
        _instance.transform.rotation = _rushMuzzle.transform.rotation;
        _instance.transform.parent = transform;
        _rb.AddForce(transform.forward * _attackSpeed, ForceMode.Impulse);
    }
    void ComboEffect1()
    {
        GameObject _instance = Instantiate(_comboEffect);
        _instance.transform.position = _comboMuzzle1.transform.position;
        _instance.transform.rotation = _comboMuzzle1.transform.rotation;
        _instance.transform.parent = transform;
    }
    void ComboEffect2()
    {
        GameObject _instance = Instantiate(_comboEffect);
        _instance.transform.position = _comboMuzzle2.transform.position;
        _instance.transform.rotation = _comboMuzzle2.transform.rotation;
        _instance.transform.parent = transform;
    }
    void ComboEffect3()
    {
        GameObject _instance = Instantiate(_comboEffect);
        _instance.transform.position = _comboMuzzle3.transform.position;
        _instance.transform.rotation = _comboMuzzle3.transform.rotation;
        _instance.transform.parent = transform;
    }
    /// <summary> 抜刀のアニメーションイベント </summary>
    void EquipEvent()
    {
        _sword.SetActive(false);
        _swordEquip.SetActive(true);
    }
    /// <summary> 納刀のアニメーションイベント </summary>
    void UnequipEvent()
    {
        _sword.SetActive(true);
        _swordEquip.SetActive(false);
    }
}
