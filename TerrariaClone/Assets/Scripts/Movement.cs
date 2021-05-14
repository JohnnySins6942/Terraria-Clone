using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
	  public float speed;
    public float jump;
    public GameObject rayOrigin;
    public float rayCheckDistance;
    Rigidbody2D rb;
 
    void Start () {
        rb = GetComponent <Rigidbody2D> ();
    }
 
    void Update () {
        float x = Input.GetAxis ("Horizontal");
        if (Input.GetAxis ("Jump") > 0) {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin.transform.position, Vector2.down, rayCheckDistance);
            if (hit.collider != null) {
                rb.AddForce (Vector2.up * jump, ForceMode2D.Impulse);
            }
        }
        rb.velocity = new Vector3 (x * speed, rb.velocity.y, 0);
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}