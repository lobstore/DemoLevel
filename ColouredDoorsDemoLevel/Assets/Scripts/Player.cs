using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer irisSpriteRenderer;
    private Animator animatorController;
    public Colours.Colour colour;
    private PlayerController controller;
   new private ParticleSystem particleSystem;
    private Rigidbody2D rb;
    private void Start()
    {
        controller = GetComponent<PlayerController>();
        animatorController = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        colour = Colours.Colour.Neutral;
        StartCoroutine(nameof(RandomAnimation));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Door"))
        {
            DoorType type = collision.gameObject.GetComponent<DoorType>();
            if (type.colour == colour)
            {
                StartCoroutine(Death());
            }
            else
            {
                colour = type.colour;
                switch (colour)
                {
                    case Colours.Colour.Neutral:
                        irisSpriteRenderer.color = new Color(1, 1, 1, 1);
                        break;
                    case Colours.Colour.Red:
                        irisSpriteRenderer.color = new Color(255/255f, 94/255f, 109 / 255f, 1);
                        break;
                    case Colours.Colour.Green:
                        irisSpriteRenderer.color = new Color(0, 255 / 255f, 130 / 255f, 1);
                        break;
                    default:
                        break;
                }
            }
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            DoorType type = collision.gameObject.GetComponent<DoorType>();
            if (type.colour == colour)
            {
                StartCoroutine(Death());
            }
            else
            {
                StartCoroutine(Win());
            }
        }
    }
    IEnumerator Death()
    {
        Destroy(controller);
        animatorController.SetTrigger("Death");
        particleSystem.Play();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        EventHandler.onFail.Invoke();
    }
    IEnumerator Win()
    {
        Destroy(controller);
        yield return new WaitForSeconds(1);
        EventHandler.onWin.Invoke();
    }
    IEnumerator RandomAnimation()
    {
        while (true)
        {
            int randomstate = Random.Range(0, 2);
            switch (randomstate)
            {
                case 0:
                    animatorController.SetTrigger("CloseEye");
                    break;
                case 1:
                    animatorController.SetTrigger("LookAround");
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(4);
        }
        
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
