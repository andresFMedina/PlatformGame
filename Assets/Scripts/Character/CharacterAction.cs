using UnityEngine;

public class CharacterAction : MonoBehaviour
{    
    public GameObject BulletPrefab;

    public void Shoot()
    {
        Vector3 direction = (transform.localScale.x == 1.0f) ? Vector3.right : Vector3.left;        

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().Direction = direction;
    }

}

