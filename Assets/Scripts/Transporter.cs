using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    public Transform leftEntry;
    public Transform rightEntry;

    public Transform player;
    public Transform target;
    private float detectionRadius = 0.1f;
    
    private void Update() {
        trytoTransport(player);
        detectBlock();
        //trytoTransport(box);
        //Blocktester block = block.GetComponent<Blocktester>();
     //   checkBlockTransport(block.getTransform());


    }    
    public void trytoTransport(Transform player)
{
    float overlapDistance = 0.1f;

    // Function to snap the position to the nearest grid center (0.5, 0.5)
    Vector3 SnapToGrid(Vector3 originalPosition)
    {
        // Round to the nearest integer and add 0.5 to center on the grid
        float snappedX = Mathf.Floor(originalPosition.x) + 0.5f;
        float snappedY = Mathf.Floor(originalPosition.y) + 0.5f;
        return new Vector3(snappedX, snappedY, originalPosition.z); // z remains unchanged for 2D
    }

    // Check which one is the entry point
    if (Vector3.Distance(player.position, leftEntry.position) < overlapDistance)
    {
        Debug.Log("It is on the left entry.");
        
        // Transport player to the right entry + offset, then snap to grid
        Vector3 newPosition = rightEntry.position + new Vector3(-1f, 0f, 0f);
        player.position = SnapToGrid(newPosition);
        target.position = SnapToGrid(newPosition);

    }
    else if (Vector3.Distance(player.position, rightEntry.position) < overlapDistance)
    {
        Debug.Log("It is on the right entry.");
        
        // Transport player to the left entry + offset, then snap to grid
        Vector3 newPosition = leftEntry.position + new Vector3(-1f, 0f, 0f);
        player.position = SnapToGrid(newPosition);
        target.position = SnapToGrid(newPosition);
    }
    else
    {
       // Debug.Log("Not found");
    }
}



    /*public void trytoTransport(Transform player){
        float overlapDistance = 0.1f;


        //check which one is the entry point
        if (Vector3.Distance(player.position, leftEntry.position) < overlapDistance)
        {
            Debug.Log("It is on the left entry.");
            player.position = rightEntry.position + new Vector3(-1f, 0f, 0f);
            target.position = rightEntry.position + new Vector3(-1f, 0f, 0f);

        }else if(Vector3.Distance(player.position, rightEntry.position) < overlapDistance){
            Debug.Log("It is on the right entry.");
            player.position = leftEntry.position + new Vector3(-1f, 0f, 0f);
            target.position = leftEntry.position + new Vector3(-1f, 0f, 0f);
        }else{
            Debug.Log("Not found");
        }

        
        

    }*/

    private void detectBlock(){
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

        foreach(GameObject block in blocks)
        {
            if(Vector3.Distance(block.transform.position, leftEntry.position) < detectionRadius)
            {
                Debug.Log("Over left entry");
                block.transform.position = rightEntry.position + new Vector3(-1f *2, 0f, 0f);

            } else if (Vector3.Distance(block.transform.position, rightEntry.position) < detectionRadius)
            {
                Debug.Log("Right entry point");
                block.transform.position = leftEntry.position + new Vector3(-1f *2, 0f, 0f);

            }
        }
    }
/*
    private void checkBlockTransport(Blocktester block){
        float overlapDistance = 0.1f;


        //check which one is the entry point
        if (Vector3.Distance(block.transform.position, leftEntry.position) < overlapDistance)
        {
            Debug.Log("It is on the left entry.");
            block.transform.position = rightEntry.position + new Vector3(-1f, 0f, 0f);

        }else if(Vector3.Distance(block.position, rightEntry.position) < overlapDistance){
            Debug.Log("It is on the right entry.");
            block.transform.position = leftEntry.position + new Vector3(-1f, 0f, 0f);
        }else{
            Debug.Log("Not found in block transport");
        }
    }*/





}
