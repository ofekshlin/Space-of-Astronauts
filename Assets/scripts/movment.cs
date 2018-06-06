using UnityEngine;

[System.Serializable]
public class Boundery
{
    public float xMin, xMax, yMin, yMax;
}

public class movment : MonoBehaviour
{

    public float speed = 0f; //the input from the player for the speed 
    public float accelarate = 2f; //the amount of speed to add to the player input
    public Boundery boundery;
    
    public float maxVelocity = 5f;

    public float rotate = 0f;
    private float amountRotate = 50f;

    Rigidbody2D spaceShip;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    public void  Start()
    {
        //fetch the rigidbody component 
        spaceShip = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //set the speed of the ship
        speed = Input.GetAxis("Vertical");

        //set the rotation of the ship
        rotate = 0 - Input.GetAxis("Horizontal") * amountRotate;

        //shooting
        if (Input.GetButton("Jump") && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            GameObject clone =  Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
        }
    }

    void FixedUpdate()
    {
        //moving the ship by adding force
        Vector2 force = transform.up * speed;
        spaceShip.AddForce(force);

        //rotating
        spaceShip.angularVelocity = rotate;

        ClampVelocity(); // set that the velocity doesn't be more then the max velocity

        //sting the border of the map for the ship
        spaceShip.position = new Vector2
        (
            Mathf.Clamp(spaceShip.position.x, boundery.xMin, boundery.xMax),
            Mathf.Clamp(spaceShip.position.y, boundery.yMin, boundery.yMax)
        );
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(spaceShip.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(spaceShip.velocity.y, -maxVelocity, maxVelocity);

        spaceShip.velocity = new Vector2(x, y);
    }
}
