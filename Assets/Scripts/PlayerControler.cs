using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    static PlayerControler instance;
    Rigidbody playerRB;
    public float playerSpeed = 10.0f;
    bool isPlayerDead;

    CurrentDirection currentDirection;
    MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isPlayerDead = false;
        playerRB = GetComponent<Rigidbody>();
        currentDirection = CurrentDirection.right;
        menuManager = FindObjectOfType<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerDead && menuManager.TimerActiveCheck())
        {
            RayCastDetector();
            if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
            {
                ChangeDirection();
                PlayerStop();
            }
        }
    }

    private void RayCastDetector()
    {
        RaycastHit hit;

        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit))
        {
            MoveWithVel();
            SpeedAccelerator();
        }
        else
        {
            PlayerStop();
            isPlayerDead= true;
            this.gameObject.SetActive(false);
            playerSpeed = 1f;
        }
    }

    public static PlayerControler GetInstance()
    {
        return instance;
    }
    public bool DeadCheck()
    {
        return isPlayerDead;
    }

    enum CurrentDirection
    {
        left, right
    }

    void ChangeDirection()
    {
        if (currentDirection == CurrentDirection.left)
        {
            currentDirection = CurrentDirection.right;
        }
        else if (currentDirection == CurrentDirection.right)
        {
            currentDirection = CurrentDirection.left;
        }
    }

    void PlayerMove()
    {
        if (currentDirection == CurrentDirection.left)
        {
            playerRB.AddForce(Vector3.forward.normalized * playerSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if (currentDirection == CurrentDirection.right)
        {
            playerRB.AddForce(Vector3.right.normalized * playerSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void MoveWithVel()
    {
        if (currentDirection == CurrentDirection.left)
        {
            playerRB.velocity = Vector3.forward * playerSpeed;
        }
        if (currentDirection == CurrentDirection.right)
        {
            playerRB.velocity = Vector3.right * playerSpeed;
        }

    }

    void PlayerStop()
    {
        playerRB.velocity = Vector3.zero;
    }

    void SpeedAccelerator()
    {
        playerSpeed += 0.1f * Time.deltaTime;
    }
}
