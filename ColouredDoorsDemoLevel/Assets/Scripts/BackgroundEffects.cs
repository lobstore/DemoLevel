using System.Collections;
using UnityEngine;

public class BackgroundEffects : MonoBehaviour
{
    private BackgroundElement[] backgroundElements;

    [Range(0, 100)]
    public float desiredDuration = 1;
    void Start()
    {
        backgroundElements = GetComponentsInChildren<BackgroundElement>();
        StartCoroutine(TurnSprite());
    }
    IEnumerator TurnSprite()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int randomitem = Random.Range(0, backgroundElements.Length);
            backgroundElements[randomitem].ChangeColor(desiredDuration);
            
        }
    }
    // Update is called once per frame
}
