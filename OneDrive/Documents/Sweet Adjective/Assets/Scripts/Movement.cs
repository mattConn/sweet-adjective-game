using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get verical and horizontal axis
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 position = transform.position;
        //horizontal movements
        position.x = position.x + 0.3f * horizontal;
        //vertical movements
        position.y = position.y + 0.3f * vertical;

        transform.position = position;
    }
}
