using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class TileMapClicked : MonoBehaviour
{
    

    void Update()
    {
        // Check if the player left-clicks
        if (Input.GetMouseButtonDown(0))  // 0 is the left mouse button
        {
            // Convert the mouse position to world point
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

            // Raycast at the mouse position to detect collisions
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            // If we hit something
            if (hit.collider != null)
            {
                // Check if it's part of the tilemap
                if (hit.collider.GetComponent<TilemapCollider2D>() != null)
                {
                    // Load the new scene
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }

}
