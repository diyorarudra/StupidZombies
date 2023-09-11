using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope_script : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseDrag()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mouseposs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mouseposs.x,mouseposs.y) ;
        
    }
}
