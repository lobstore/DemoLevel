using UnityEngine;
enum State
{
    ToGray,
    ToWhite
}
public class BackgroundElement : MonoBehaviour
{
    private SpriteRenderer backgrSpriteRenderer;
    float percentajeComplete = 0;
    public bool flag = false;
    float desiredDuration;
    float elapsedTime;
    private void Start()
    {
        backgrSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeColor(float desiredDuration)
    {
        percentajeComplete = 0;
        this.desiredDuration = desiredDuration;
        flag = true;
    }

    public void ColorRamp()
    {
        if (percentajeComplete >= 1)
        {
            percentajeComplete = 0;
            flag = false;
        }
        else
        {
            elapsedTime += Time.deltaTime;
            percentajeComplete = elapsedTime / desiredDuration;
            Debug.Log(percentajeComplete);
            backgrSpriteRenderer.color = Color.Lerp(new Color(0.2f,0.2f,0.2f,1), Color.gray, Mathf.PingPong(percentajeComplete, 1));

        }
        
    }

    private void Update()
    {
        ColorRamp();
    }
}
