using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesHighliting : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float changeTime = 0;
    float elapsedTime;
    float percentageComplete ;
    void Start()
    {
        elapsedTime = changeTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        
    }
    private void FixedUpdate()
    {
        percentageComplete = elapsedTime;
            spriteRenderer.color = Color.Lerp(new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1), new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.7f), Mathf.PingPong(percentageComplete,1));
        
    }
}
