
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Health;
    public float Speed;
    public float JumpForce;

    protected Animator animator;    

    public bool IsAlive()
    {
        return Health > 0;
    }
    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
