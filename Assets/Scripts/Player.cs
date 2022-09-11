using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // array of sprites to cycle between for animation
    private int spriteIndex; // keep track of which sprite used in sprites

    public AudioSource dickSound;

    private Vector3 direction; // creates vector with 3 components: Vector3(Single, Single, Single)
    public float gravity = -9.81f; // allows us to customize gravity on bird
    public float strength = 5f;

    // this is the first function called by Unity in the very first frame 
    private void Awake() 
    {   // SpriteRenderer is the type of component we want to get. (like Rigidbody). Search for that component on same object this script is running on
        spriteRenderer = GetComponent<SpriteRenderer>(); // This is the component in the editor under your sprite. 
    }

    // Start is called before the first frame update when this object is enabled
    void Start()
    {
        //Invoke is a way of calling another function, in this case repeatedly call function over and over again
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // repeat call every .15 seconds
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    // Update is called once per frame. Usually where you handle input
    private void Update()
    { // either press space bar or left click (0)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
            dickSound.Play();
        }
        // for mobile, touchCount is how many fingers are touching the screen
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0); // get the first touch

            if (touch.phase == TouchPhase.Began) // if just began to touch screen
            {
                direction = Vector3.up * strength;
            }
        }
        // gravity
        direction.y += gravity * Time.deltaTime; // gravity is m/s^2 so multiply by time
        transform.position += direction * Time.deltaTime; // this makes it framerate independent. Consistent changing position 

    }

    private void AnimateSprite() 
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle") {
            FindObjectOfType<GameManager>().GameOver(); // not a good way to do this. check other options
        } else if (other.gameObject.tag == "Scoring") {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
