using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : CharacterAction
{
    private float LastShot;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > LastShot + 0.25f && player.IsAlive())
        {
            Shoot();
            LastShot = Time.time;
        }
    }   

}
