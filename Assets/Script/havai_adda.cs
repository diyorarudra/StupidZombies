using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class havai_adda : MonoBehaviour
{
    bool right_walk = false,left_walk = false;
    void Start()
    {
        right_walk= true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (right_walk)
        {
            transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);
        }
        if(left_walk)
        {
            transform.position = new Vector2(transform.position.x - 0.02f, transform.position.y);

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Right_tag")
        {
            right_walk= false;
            left_walk= true;
        }
        if (col.gameObject.tag == "Left_tag")
        {
          left_walk= false;
            right_walk= true;
        }
    }
    }
