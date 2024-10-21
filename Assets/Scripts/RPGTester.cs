using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RPGTester : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 movement;
    public Transform targetPosition;
    public LayerMask UnwalkableLayer;
    public LayerMask MoveableLayer;
    public string nextScene;
    public string currentScene;
    public int targets_left ;//= 2; // Number of targets left to be completed
   // public Animator animator; 
    private void Awake()
    {
        // Initialize the player's position
        targetPosition.position = transform.position;
    }

    void Update()
    {
       

        //if press r then restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            restart(); // Call the restart function
        }
        // Move the player towards the target position
        if (Vector3.Distance(transform.position, targetPosition.position) < .01f)
        {
            Vector3 newPosition = targetPosition.position + new Vector3(movement.x, movement.y, 0f);

            // Check if the next position is walkable (not blocked by unwalkable layers)
            if (!Physics2D.OverlapCircle(newPosition, .01f, UnwalkableLayer))
            {
                // Check if there's a moveable block in the direction
                Collider2D blockCollider = Physics2D.OverlapCircle(newPosition, .1f, MoveableLayer);
                if (blockCollider != null)
                {
                    // Get the Blocktester component from the block and try to move it
                    Blocktester blockMovement = blockCollider.GetComponent<Blocktester>();
                    if (blockMovement != null && blockMovement.TryMoveBlock(movement))
                    {
                        // Block moved successfully, now move the player
                        targetPosition.position = newPosition;

                        // Check if the block has landed on a target
                        StartCoroutine(CheckBlockOnTarget(blockMovement));
                    }
                }
                else
                {
                    // No block in the way, move the player
                    targetPosition.position = newPosition;
                }
            }



        }

        // Smooth movement to the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
    


    }

    // Coroutine to check if the block has landed on a target after the movement is complete
    private IEnumerator CheckBlockOnTarget(Blocktester blockMovement)
    {
        yield return new WaitForEndOfFrame(); // Wait until the end of the frame to ensure the block has moved
        int targetState = blockMovement.isOnTarget();
        if (targetState == 1) //true
        {
            Debug.Log("Block is on the target!");

            // Decrease the number of targets left
            targets_left--;
            Debug.Log(targets_left);


            // Check if all targets are covered
            if (targets_left == 0)
            {
                Debug.Log("All targets covered! Moving to the next level.");
                loadNextScene(); // Load the next scene
            }
       
        } else if(targetState == 2){
            targets_left ++;
            Debug.Log("block left target");
            Debug.Log(targets_left);
        } else if(targetState== 3){
            Debug.Log("Do nothing");
            Debug.Log(targets_left);


        }
    }

    // Input handler for player movement
    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();

        // Ensure the player moves only in one direction (horizontal or vertical)
        if (movement.x != 0 && movement.y != 0)
        {
            movement = new Vector2(0, 0);
        }
    }

    // Load the next scene (level 2 in this case)
    private void loadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    void restart(){
        SceneManager.LoadScene(currentScene);
    }

    
    
}
