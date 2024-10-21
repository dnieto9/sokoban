/*
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class RPGController : MonoBehaviour
{
    public float speed;
    private Vector2 movement;

    public Tilemap map;
    public Transform targetPosition;
    public LayerMask UnwalkableLayer;
    public LayerMask MoveableLayer;
    public LayerMask TargetLayer;
    private int ct_targets_collisions = 0;

    private void Awake()
    {
        targetPosition.position = transform.position; // Initialize target position
    }

    void Update()
    {   
        if(Vector3.Distance(transform.position, targetPosition.position) < .01f &&
           !Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f,UnwalkableLayer)){
                if(Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f,MoveableLayer)) {
                    if(!Physics2D.OverlapCircle(targetPosition.position + new Vector3(2*movement.x, 2*movement.y, 0f), .1f,UnwalkableLayer)){
                        targetPosition.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y+ movement.y, 0f);
                    }
                }else{
                    targetPosition.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y+ movement.y, 0f);
                }
        }      
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("entering collision");
        if(other.gameObject.CompareTag("Coin")){
            Debug.Log("comparing tag coin 1");
            other.gameObject.transform.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y+ movement.y, 0f);
            if(checkTargets(other)){
                Debug.Log("Adding 1 in coin1");
                ct_targets_collisions+=1;
            }
        }
        if(other.gameObject.CompareTag("Coin2")){
            Debug.Log("comparing tag coin 2");

            other.gameObject.transform.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y+ movement.y, 0f);
            if(checkTargets(other)){
                Debug.Log("Adding 1 in coin2");

                ct_targets_collisions+=1;
            }

        }
        if(ct_targets_collisions == 2){
            Debug.Log("The player has moved objects over both targets");
        }
        

    }
    void OnMove(InputValue value){
        movement = value.Get<Vector2>();
    }

    
    private bool checkTargets(Collision2D other){
        Debug.Log("checking targets functions");
        return Physics2D.OverlapCircle(other.gameObject.transform.position, .1f, TargetLayer);

    }
    //check if there is a overlap from compare tag coin and target layer


}



*/