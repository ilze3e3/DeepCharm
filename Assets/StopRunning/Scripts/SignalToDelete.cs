using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalToDelete : MonoBehaviour
{
    public bool destroySignal = false;
    private void OnTriggerEnter2D(Collider2D collision) =>
        destroySignal = (collision.gameObject.tag == "EndOfLevel") ? true : false;
    public bool GetSignal() =>
       destroySignal;
}
