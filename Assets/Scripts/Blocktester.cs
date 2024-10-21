using System.Security.Cryptography;
using UnityEngine;

public class Blocktester : MonoBehaviour
{
    public LayerMask UnwalkableLayer;
    public LayerMask MoveableLayer;
    public LayerMask TargetLayer;
   // private bool onTarget = false;
    private int onTarget = 3; //1 means on target now, 2 means left target, 3 means do nothing with targets

    

    //check if another block is in front else do not move
    
    // Method to attempt to move the block in a given direction
    public bool TryMoveBlock(Vector2 movement)
    {
        Vector3 currentPos = transform.position;
        Vector3 newPos = currentPos + new Vector3(movement.x, movement.y, 0f);

        // Check if the space ahead is clear for the block to move into
        if (!Physics2D.OverlapCircle(newPos, .1f, UnwalkableLayer) && !Physics2D.OverlapCircle(newPos, .1f,MoveableLayer))
        {
            transform.position = newPos;
            return true;  // Block moved successfully
        }

        return false;  // Block can't move
    }

         public int isOnTarget(){
          bool currentlyOnTarget = Physics2D.OverlapCircle(transform.position, .1f, TargetLayer);


         if (currentlyOnTarget && onTarget != 1)
            {
        // Block just landed on the target
             onTarget = 1;
             }
            else if (!currentlyOnTarget && onTarget == 1)
            {
        // Block just left the target
            onTarget = 2;
             }
            else
        {
        // No change
            onTarget = 3;
         }

            return onTarget;

         }
    /*
public bool isOnTarget(){
        
        if((onTarget==false) && ( Physics2D.OverlapCircle(transform.position, .1f, TargetLayer)==true)){
         //changed transform to currentloc
            onTarget = true;
            return true;
        }else if((Physics2D.OverlapCircle(transform.position, .1f, TargetLayer)== false )&& (onTarget == true)){
            onTarget = false;
            return false;
        }else if((onTarget == false) && (Physics2D.OverlapCircle(transform.position, .1f, TargetLayer)== false )   ) {
            onTarget = false;
            return false;
        }else{
            onTarget = true;
            return true;
        }

    }
   */


}
