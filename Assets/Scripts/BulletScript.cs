using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletSpeed;

    private Rigidbody2D RigidbodyBullet;
    public Vector2 Direction { private get; set; }
    void Start()
    {
        RigidbodyBullet = GetComponent<Rigidbody2D>();
    }    

    private void FixedUpdate()
    {
        Debug.Log(Direction.ToString());
        RigidbodyBullet.velocity = Direction * BulletSpeed;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            var characterStatistics = collision.gameObject.GetComponent<Character>();
            characterStatistics.Health--;            

            Destroy(gameObject);
        }
    }


}
