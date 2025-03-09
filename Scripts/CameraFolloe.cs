using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolloe : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 4, -10); 
    public float smoothSpeed = 0.125f; 
    public float followSpeed = 2.0f;

    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + 3.5f, -10f);  
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed*Time.deltaTime);
    }


}
