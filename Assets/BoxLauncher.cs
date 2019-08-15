using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody boxRigidBody = GetComponent<Rigidbody>();
        boxRigidBody.AddForce(new Vector3(2, 2, 2 ), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
