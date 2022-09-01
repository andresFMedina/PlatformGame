using System.Threading;
using UnityEngine;

public class Player : Character
{
    public bool isHurt;
    private float hurtedIn = 0f;

    private CapsuleCollider2D playerCollider;    

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        animator.SetInteger("health", Health);
        animator.SetBool("hurt", isHurt);        

        if (hurtedIn != 0f && hurtedIn > 0.05f)
        {
            isHurt = false;
            hurtedIn = 0f;
        }        
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        isHurt = collision.gameObject.CompareTag("Bullet");
        Debug.Log(isHurt);
        hurtedIn = Time.time;
    }

    protected override void Death()
    {
        animator.enabled = false;
        gameObject.tag = "Death";
    }
}
