using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D MyRb;
    private Vector2 MovementInput;
    public float MoveSpeed = 5f;

    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        MyRb.freezeRotation = true;
    }

    void Update()
    {
        MovementInput.x = Input.GetAxisRaw("Horizontal");
        MovementInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        MyRb.MovePosition(MyRb.position + MovementInput * MoveSpeed * Time.fixedDeltaTime);
    }
}
