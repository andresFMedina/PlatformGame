using UnityEngine;

public class EnemyAction : CharacterAction
{
    private float LastShot;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > LastShot + 1.0f && enemy.IsAlive())
        {
            Shoot();
            LastShot = Time.time;
        }
    }
}
