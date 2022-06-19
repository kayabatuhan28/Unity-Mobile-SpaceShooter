using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;

    public string sahneAdi;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boundary")
        {
            return;
        }
        if(other.gameObject.tag == "Enemy2" || other.gameObject.tag == "Enemy")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag == "Player")
        {
            
            GameController.instance.gameover = true;
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (GameController.instance.score >= 0)
            {
                GameController.instance.score--;
                GameController.instance.UpdateScoreTxt();
                
                
            }
            else
            {
                GameController.instance.score = 0;              
                GameController.instance.UpdateScoreTxt();
                
            }
            
        }
        
    }

   

}
