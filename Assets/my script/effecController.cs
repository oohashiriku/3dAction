using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffecController : MonoBehaviour
{
    [SerializeField] GameObject _comboEffect;
    [SerializeField] Transform _comboMuzzle1;
    [SerializeField] Transform _comboMuzzle2;
    [SerializeField] Transform _comboMuzzle3;

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
}
