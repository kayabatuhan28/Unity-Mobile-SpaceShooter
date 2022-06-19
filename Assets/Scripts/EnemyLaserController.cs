using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserController : MonoBehaviour
{
    Rigidbody rb;

    public float speed;

    [SerializeField]
    GameObject playerDieVFX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        rb.velocity = transform.forward * speed ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameController.instance.gameover = true;
            Destroy(this.gameObject);
            Instantiate(playerDieVFX, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);

        }
    }

}
