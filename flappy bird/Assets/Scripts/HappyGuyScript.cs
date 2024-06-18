using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyGuyScript : MonoBehaviour
{
    public Rigidbody2D MyRigidBody;
    public float FlapStrength;
    public LogicScript Logic;
    public bool birdIsAlive = true;
    public float MaxY = 17;
    public float MinY = -17;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            MyRigidBody.velocity = Vector2.up * FlapStrength;
        }

        if (transform.position.y > MaxY || transform.position.y < MinY)
        {
            transform.position = new Vector2(transform.position.x, 0);
            Logic.gameOver();
            birdIsAlive = false;
        }
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        Logic.gameOver();
        birdIsAlive = false;
    }   
}
