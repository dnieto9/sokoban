using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class Block : MonoBehaviour
{
    private Vector2 movement;
    public float speed;
   private Transform targetPosition ;

    public LayerMask UnwalkableLayer;

    public LayerMask MoveableLayer;
    private bool playerPushing;

     void Awake() {
        
        targetPosition = transform;
        targetPosition.position = transform.position;
        playerPushing = false;
        }
    

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("Collision in Block file");
            playerPushing = true;
            canMove();
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        // Stop moving when the player stops pushing
        if (other.gameObject.CompareTag("Player")) {
            playerPushing = false;
        }
    }

    private void canMove(){
        if(playerPushing && !Physics2D.OverlapCircle(this.transform.position + new UnityEngine.Vector3(movement.x, movement.y, 0f), .1f, UnwalkableLayer)){
            targetPosition.position = new UnityEngine.Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
        }

        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime); 
    }

     void OnMove(InputValue value){
        movement = value.Get<Vector2>();
        if (movement.x != 0 && movement.y != 0){
            movement = new Vector2(0,0);
        }
    }

    
}
