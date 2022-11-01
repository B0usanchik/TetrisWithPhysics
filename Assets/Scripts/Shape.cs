using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    Coroutine moveCoroutine;

    private bool CanLeft = true, CanRight = true, isMoving = true;

    public int speedIndex = 1;

    float time = 0f;
    void Start()
    {
        moveCoroutine = StartCoroutine(MoveDown());
    }


    void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }

    void Move()
    {
        float xMove = 0, yMove = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && CanLeft)
            xMove = -0.5f;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && CanRight)
            xMove = 0.5f;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            speedIndex = 4;
            if (time >= 1f / speedIndex)
                RestartCoroutine();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            speedIndex = 1;
        }

        transform.Translate(xMove, yMove, 0, Space.World);
    }

    private void LateUpdate()
    {
        if (isMoving)
        {
            RotateShape();
        }
    }

    IEnumerator MoveDown()
    {
        while (true)
        {
            time = 0f;
            transform.Translate(0, -0.5f, 0, Space.World);
            yield return new WaitForSeconds(1f / speedIndex);
        }
    }

    void RestartCoroutine()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
    }
    void RotateShape()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -90);
    }

    internal void BorderColided(string tag)
    {
        switch (tag)
        {
            case "LeftBorder":
                CanLeft = false;
                break;
            case "RightBorder":
                CanRight = false;
                break;
            case "BottomBorder":
                StopMovement();
                break;
            default:
                CanRight = true;
                CanLeft = true;
                break;
        }
    }

    void StopMovement()
    {
        if (!isMoving) return;
        isMoving = false;

        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        
        GameController gm = FindObjectOfType<GameController>();
        gm.SpawnNextShape();
    }
}
