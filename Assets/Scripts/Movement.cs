using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    Rigidbody2D rb;

    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = 0;
        speed = 8;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }
    void FixedUpdate(){
        rb.linearVelocity = new Vector2(horizontal * speed,rb.linearVelocity.y);
    }
}
