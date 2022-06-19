using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    Rigidbody physic;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject enemyDieVfx;

    private void Start()
    {
        physic = GetComponent<Rigidbody>();

        physic.velocity = transform.forward*speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GameController.instance.score++;
            GameController.instance.UpdateScoreTxt();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy2")
        {
            GameController.instance.score += 10;
            GameController.instance.UpdateScoreTxt();
            Instantiate(enemyDieVfx, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }

}
