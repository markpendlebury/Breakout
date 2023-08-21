using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private readonly float moveSpeed = 10;
    
    
    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }


    private void Awake()
    {
    }


    private void Update()
    {
    }

    private void FixedUpdate()
    {
        // Get Horizontal Input
        float mousePos = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * mousePos * moveSpeed;
        GetComponent<Rigidbody2D>().rotation = 0;
        
    }

}
