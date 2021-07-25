using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public bool active = false;
    private SpriteRenderer spriteRenderer;
    private GameObject spawnPoint;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPoint = GameObject.Find("SpawnPoint");
    }

    void OnTriggerEnter2D(Collider2D other){
        if (active) 
        {
            return;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) 
        {
            spawnPoint.transform.position = this.transform.position;
            spriteRenderer.color = new Color(255,255,255,255);
        } 
    }
}
