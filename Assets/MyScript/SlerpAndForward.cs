using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpAndForward : MonoBehaviour
{


    public Transform target;

    private float speedMovement;
    private float speedRotation;

    // Start is called before the first frame update
    void Start()
    {
        speedMovement = Time.deltaTime * 1.0f;
        speedRotation = Time.deltaTime * 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speedRotation);

        if (Vector3.Distance(target.position, this.transform.position) > 1.5f)
        {
            this.transform.Translate(Vector3.forward.normalized * speedMovement);
        }
    }
}
