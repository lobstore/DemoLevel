using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isDead;
    public Colours.Colour colour;
    private void Start()
    {
        colour = Colours.Colour.Neutral;
        isDead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Door"))
        {
            DoorType type = collision.gameObject.GetComponent<DoorType>();
            if (type.colour == colour)
            {
                isDead = true;
                Destroy(gameObject);
                EventHandler.onFail.Invoke();
            }
            else
            {
                colour = type.colour;
            }
        }
        else if(collision.gameObject.CompareTag("Finish"))
        {
            DoorType type = collision.gameObject.GetComponent<DoorType>();
            if (type.colour == colour)
            {
                isDead = true;
                Destroy(gameObject);
                EventHandler.onFail.Invoke();
            }
            else
            {
                EventHandler.onWin.Invoke();
            }
        }
    }
  
}
