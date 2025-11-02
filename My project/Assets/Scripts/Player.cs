using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // array of sprites
    private int spriteIndex;
    private Vector3 direction;

    public float gravity = -9.81f;

    public float strength = 5f;

    private GameManager gm;

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Awake() // awake function is ran when initialized and only once
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // gets the component from attached object
        gm = FindFirstObjectByType<GameManager>(); // cache once
        if (gm == null) Debug.LogError("GameManager not found in scene");
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // invokes the function repeatedly after a delay
    }

    private void Update()
    {
        // space and m1
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        //gravity

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime; // framerate independent 


    }

    private void AnimateSprite()
    {
        spriteIndex++; // increment index
        if (spriteIndex >= sprites.Length) // if index exceeds length
        {
            spriteIndex = 0; // reset index
        }
        spriteRenderer.sprite = sprites[spriteIndex]; // set sprite to current index
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            gm.GameOver();
        } else if (other.gameObject.CompareTag("Scoring")) {
            gm.IncreaseScore();
        }
    }
}
