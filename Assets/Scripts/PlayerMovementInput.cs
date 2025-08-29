using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovementInput : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float move; // -1 (esquerda), 0 (parado), +1 (direita)

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Evento ligado no Player Input -> Move
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            move = ctx.ReadValue<float>(); // -1, 0, +1
        else if (ctx.canceled)
            move = 0f;
    }

    void FixedUpdate()
    {
        // movimento horizontal
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // flip do sprite (vira quando anda pra esquerda)
        if (Mathf.Abs(move) > 0.01f)
            sr.flipX = move < 0f;
    }
}
