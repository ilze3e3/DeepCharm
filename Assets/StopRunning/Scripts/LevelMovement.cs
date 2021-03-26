using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    public GameObject levelHead;
    public GameObject levelTail;
    public bool signalToSpawn;
    public bool signalToDestroy;
    public float moveSpeed = 5;
    public Vector3 userDirection = Vector3.left;
    Transform position;
    private bool oncesp = true;
    private bool oncedl = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        signalToSpawn = levelHead.GetComponent<SignalToSpawn>().GetSignal(); // Gets signal to spawn the next level
        signalToDestroy = levelTail.GetComponent<SignalToDelete>().GetSignal(); // Gets signal to destroy this level
        oncesp = (signalToSpawn && oncesp) ? false : true;
        oncedl = (signalToDestroy && oncedl) ? false : true;
        transform.Translate(userDirection * moveSpeed * Time.deltaTime);  // Move Level      
    }

    public bool GetSignalToSpawn() => signalToSpawn;
    public bool GetSignalToDestroy() => signalToDestroy;
    public void SetMoveSpeed(float ms) => moveSpeed = ms;
}
