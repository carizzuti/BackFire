using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPortal : MoveableObject
{
    [SerializeField] private DoorPortal exitPoint;
    [SerializeField] private Player player;
    [SerializeField] private float bottomWallY, topWallY, leftWallX, rightWallX;

    private Vector2 exitDirection;
    private Vector2 exitLocation;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindExitDirectionAndLocation();
            StartCoroutine(Teleportation());
        }
    }

    IEnumerator Teleportation()
    {
        player.StopMoving();
        yield return new WaitForSeconds(0.5f);

        player.gameObject.SetActive(false);
        player.SetPlayerDirection(-exitDirection);
        player.transform.position = exitLocation;
        player.SetShotDirection(-exitDirection);
        player.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        player.ExitDoor(exitDirection);
    }

    public void FindExitDirectionAndLocation()
    {
        if (exitPoint.transform.position.x == rightWallX)
        {
            exitDirection = Vector2.left;
            exitLocation = new Vector2(exitPoint.transform.position.x - 1, exitPoint.transform.position.y);
        }
        else if (exitPoint.transform.position.x == leftWallX)
        {
            exitDirection = Vector2.right;
            exitLocation = new Vector2(exitPoint.transform.position.x + 1, exitPoint.transform.position.y);
        }
        else if (exitPoint.transform.position.y == bottomWallY)
        {
            exitDirection = Vector2.up;
            exitLocation = new Vector2(exitPoint.transform.position.x, exitPoint.transform.position.y + 1);
        }
        else if (exitPoint.transform.position.y == topWallY)
        {
            exitDirection = Vector2.down;
            exitLocation = new Vector2(exitPoint.transform.position.x, exitPoint.transform.position.y - 1);
        }
        else
        {
            Debug.Log("Default");
            Debug.Log("X: " + exitPoint.transform.position.x + " Y: " + exitPoint.transform.position.y);
        }
    }
}
