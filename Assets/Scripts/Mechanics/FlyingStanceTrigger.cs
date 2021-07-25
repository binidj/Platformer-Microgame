using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyingStanceTrigger : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) 
        {
            onTriggerEnter.Invoke();
        } 
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) 
        {
            onTriggerExit.Invoke();
        } 
    }
}
