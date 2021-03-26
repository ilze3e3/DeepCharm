using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalToSpawn : MonoBehaviour
{
    public bool spawnSignal;
    private void OnTriggerEnter2D(Collider2D collision) =>
        spawnSignal = (collision.gameObject.tag == "EndOfLevel") ?
            true : false;
    public bool GetSignal() =>
        spawnSignal;
}
