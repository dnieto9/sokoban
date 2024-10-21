using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class RPGController : MonoBehaviour
{
    public float speed;
    private Vector2 movement;

    public Tilemap targetTilemap; // Reference to the Tilemap for the targets
    public Transform targetPosition;
    public LayerMask UnwalkableLayer;
    public LayerMask MoveableLayer;
  //  private int ct_targets_collisions = 0;
    public bool level_complete = false;

    private void Awake()
    {
        targetPosition.position = transform.position; // Initialize target position
    }

    void Update()
    {   
        if(Vector3.Distance(transform.position, targetPosition.position) < .01f &&
           !Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f, UnwalkableLayer)){
                if(Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f, MoveableLayer)) {
                    if(!Physics2D.OverlapCircle(targetPosition.position + new Vector3(2*movement.x, 2*movement.y, 0f), .1f, UnwalkableLayer)){
                        targetPosition.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
                    }
                }else{
                    targetPosition.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
                }
        }      
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
    }
/*
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("entering collision");
        if(other.gameObject.CompareTag("Coin")){
            other.gameObject.transform.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y+ movement.y, 0f);
            if(CheckIfOnTarget(other)){
                ct_targets_collisions += 1;
            }
        }
        if(other.gameObject.CompareTag("Coin2")){
            other.gameObject.transform.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y+ movement.y, 0f);
            if(CheckIfOnTarget(other)){
                ct_targets_collisions += 1;
            }
        }

        if(ct_targets_collisions == 2){
            Debug.Log("The player has moved objects over both targets");
            level_complete = true;
            loadNextScene();
        }
    }
*/
   

    void OnMove(InputValue value){
        movement = value.Get<Vector2>();
        if (movement.x != 0 && movement.y != 0){
            movement = new Vector2(0,0);
        }
    }
/*
    private bool CheckIfOnTarget(Collision2D other){
        // Get the object's position in world space
        Vector3 objectWorldPos = other.gameObject.transform.position;

        // Convert the world position to the tilemap grid position
        Vector3Int tilePosition = targetTilemap.WorldToCell(objectWorldPos);

        // Check if there is a tile at the object's position in the target tilemap
        if(targetTilemap.HasTile(tilePosition)){
            Debug.Log("Coin is on the target tile!");
            return true;
        } else {
            Debug.Log("Coin is NOT on the target tile.");
            return false;
        }
    }*/
     private void loadNextScene()
    {
        SceneManager.LoadScene("Level2"); // Replace "NextScene" with the actual scene name or index
    }

}
