using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary //Boundary classini kaydeder.Her yerden ulasilir.
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour
{
    Rigidbody physic;

    [SerializeField]
    float speed,tilt;

    [SerializeField]
    GameObject shotPrefab,shotSpawnPos;

    [SerializeField]
    float nextFire,fireRate;

    public Boundary boundary;

    public Joystick joystick;

    

    private void Start()
    {
        
        physic = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
       
    }

    private void FixedUpdate()
    {
        float moveHorizontal = joystick.Horizontal * speed * Time.deltaTime; // horizontal movement for joystick
        float moveVertical = joystick.Vertical * speed * Time.deltaTime; // vertical movement for joystick

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical); // 
        physic.velocity = movement*speed;


        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x,boundary.xMin,boundary.xMax),
            0,
            Mathf.Clamp(physic.position.z, boundary.zMin,boundary.zMax)
            );

        physic.position = position;

        //Rotation 
        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x*tilt); 
    }

    public void PlayerAttack()
    {
        if (Time.time > nextFire) 
        {
            
            nextFire = Time.time + fireRate;
            Instantiate(shotPrefab, shotSpawnPos.transform.position, shotSpawnPos.transform.rotation);
            PlaySfx.instance.PlaySfxEffect(1);
        }
    }

}
