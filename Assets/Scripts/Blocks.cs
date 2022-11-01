using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    Shape parent;
    public bool isMoving = true;

    private void Start()
    {
        parent = GetComponentInParent<Shape>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftBorder") || collision.CompareTag("RightBorder"))
        {
            //Debug.Log(collision.tag);
            parent.BorderColided(collision.tag);
        }
        else if (collision.CompareTag("BottomBorder"))
        {
            if (parent != null)
                parent.BorderColided(collision.tag);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftBorder") || collision.CompareTag("RightBorder"))
        {
            parent.BorderColided("Null");
        }
    }
}
