using UnityEngine;

public class Tiro_Instanciado : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 1;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if(gameObject.transform.rotation.y < 0)
        {
            force *= -1;
        }

        
    }
    void Update()
    {
        rb.linearVelocity = new Vector2(force,0);
    }
}
