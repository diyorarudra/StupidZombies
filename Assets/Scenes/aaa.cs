using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    public GameObject round;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)

    {

        print("col");
        if (col.gameObject.tag == "Bullet_tag")
        {
            round.SetActive(true);  
            print("zombi kill this radiation");
        }
    }

    
}
