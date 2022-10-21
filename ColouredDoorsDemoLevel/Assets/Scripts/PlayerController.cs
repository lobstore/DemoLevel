using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public Joystick joystick;
    float Horizontal { get; set; }
    float Vertical { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = joystick.Horizontal;
        Vertical = joystick.Vertical;
    }

    void FixedUpdate()
    {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + 3.0f * Horizontal * Time.deltaTime;
            position.y = position.y + 3.0f * Vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);
    }
}
