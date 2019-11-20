using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject following;
    float speed= 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        following = GameObject.Find("hero");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = following.transform.position;
        newPosition.z = -8f;
        newPosition.y += 1f;
        transform.position =  Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
    }
}
