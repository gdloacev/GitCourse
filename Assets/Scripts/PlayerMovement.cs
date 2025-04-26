using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed of the player movement
    [SerializeField] private float speedPowerFactor = 1.5f; // Speed of the player when running
    [SerializeField] private bool speedPowerUp = false; // Flag to check if speed power-up is active

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movement; // Store the movement input


    private void Awake() => rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component when the script is loaded

    private void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        var moveY = Input.GetAxisRaw("Vertical"); // Get vertical input (W/S or Up/Down arrow keys)

        movement = new Vector2(moveX, moveY).normalized; // Create a normalized vector for movement
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * (speedPowerUp ? speedPowerFactor : 1) ) * Time.fixedDeltaTime); // Move the player using Rigidbody2D
    }
}
