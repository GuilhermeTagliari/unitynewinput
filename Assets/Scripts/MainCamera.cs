using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector2 offset = new Vector2(0f, 5.5f); 
    public float smoothTime = 0.15f;

    private float fixedY;     
    private float vx, vy;     

    void Start()
    {
        fixedY = transform.position.y; 
    }

    void LateUpdate()
    {
        if (!target) return;

        var pos = transform.position;

        // segue apenas no X, suavizado
        float desiredX = target.position.x + offset.x;
        pos.x = Mathf.SmoothDamp(pos.x, desiredX, ref vx, smoothTime);

        // Y travado (não segue o personagem verticalmente)
        pos.y = fixedY + offset.y; // ajuste offset.y para subir/descer o enquadramento

        // mantém Z (ex.: -10)
        pos.z = transform.position.z;

        transform.position = pos;
    }
}