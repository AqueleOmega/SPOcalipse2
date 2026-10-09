using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Andar : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public GameObject bala_prefab;
    Vector2 movimento;
    public float velocidade = 1;
    public float force_pulo = 1000;
    float rotation = 0;
    bool arma = false;
    int pulo = 0;
    public SpriteRenderer sr;
    public void OnMove(InputAction.CallbackContext context)
    {
        movimento = context.ReadValue<Vector2>();

    }
    public void OnJump()
    {
        if (pulo > 0)
        {
            pulo -= 1;
            rb.AddForce(transform.up * force_pulo);
        }
    }
    public void OnShot()
    {
        if (arma == true)
        {
            Instantiate(bala_prefab, transform.position, Quaternion.Euler(0, rotation, 0));
        }
    }
    public void OnGun()
    {
        if (arma == false)
        {
            arma = true;
            sr.enabled = true;
        }
        else
        {
            arma = false;
            sr.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        rb.linearVelocityX = movimento.x * velocidade;
        if (rb.linearVelocityY == 0)
        {
            pulo = 2;
        }
        else
        {
        }

        if (movimento.x == 1)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            rotation = 0;

        }
        else if (movimento.x == -1)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
            rotation = -180;
        }
    }


}
