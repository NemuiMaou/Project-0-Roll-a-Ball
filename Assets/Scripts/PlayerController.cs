using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Allows us to change the speed of the player
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    // Rigidbody component of the player
    private Rigidbody rb;

    private int count;
    
    // Movement for X and Y axes.
    private float movementX;
    private float movementY;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gets us the rigidbody component that is attached to the player
        rb = GetComponent<Rigidbody>();    
        count = 0;
        
        SetCountText();
        winTextObject.SetActive(false);
    }
    
    // Called when movement is detected 
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
            
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    // Called every fixed frame-rate frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }

    // Called every time the player collides with a trigger
    void OnTriggerEnter(Collider other)
    {
        // deactivate gameObjects (PickUps) with the PickUp tag 
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}
