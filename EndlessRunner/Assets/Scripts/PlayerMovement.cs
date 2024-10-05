using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float yIncrement;
    [SerializeField] private float speed;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;

    [Header("Stat")]
    public int health;

    private Vector2 targetPos;
    private bool isMoving = false;

    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        if ((Vector2)transform.position != targetPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            }
        }
    }
}
