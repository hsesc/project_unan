using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatBall : MonoBehaviour
{
    public Transform target;
    public Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("FPSController").transform;
        targetPosition = new Vector3(target.position.x, 90, target.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(target.position.x, 90, target.position.z);
        transform.LookAt(targetPosition);
    }
}
