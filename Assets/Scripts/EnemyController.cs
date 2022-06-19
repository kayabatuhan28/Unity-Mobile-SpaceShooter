using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{

    [SerializeField]
    GameObject laserPrefab;

    [SerializeField]
    Transform spawnTransform;

    public float enemySpeed;

    bool moveLeft;

    public float nextFire,fireRate;

    private void Start()
    {
        Instantiate(laserPrefab, spawnTransform.position, spawnTransform.rotation);
    }

    private void Update()
    {
        if(transform.position.x <= 3 && !moveLeft)
        {
            transform.position += new Vector3(0.1f, 0, 0) * enemySpeed * Time.deltaTime;

            if(transform.position.x >= 3)
            {
                moveLeft = true;
            }
        }
        
        if(moveLeft == true)
        {
            transform.position += new Vector3(0.1f, 0, 0) * -enemySpeed * Time.deltaTime;
            if(transform.position.x <= -3)
            {
                moveLeft = false;
            }
        }

        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(laserPrefab, spawnTransform.position, spawnTransform.rotation);
            PlaySfx.instance.PlaySfxEffect(0);
        }


       
        
    }

}
