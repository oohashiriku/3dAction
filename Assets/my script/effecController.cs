using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effecController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Effect());
    }
    IEnumerator Effect()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
