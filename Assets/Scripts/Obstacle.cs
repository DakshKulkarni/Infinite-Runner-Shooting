using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    bool hasCollided=false;
   private void Start()
    {
        playerMovement=GameObject.FindObjectOfType<PlayerMovement>();
        transform.position=new Vector3(transform.position.x,0f,transform.position.z);
    }
    private void OnCollisionEnter(Collision collision) {
         if(!hasCollided && collision.gameObject.CompareTag("Player"))
         {
            playerMovement.Die();
            hasCollided=true;
         }
    }
    void Update()
    {
        
    }
}
