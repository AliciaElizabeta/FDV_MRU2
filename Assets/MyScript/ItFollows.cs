using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ItFollows : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objetive;

    public float speedMovement;
    public float speedRotation;
    void Start()
    {
        speedMovement = Time.deltaTime * 1.0f;
        speedRotation = Time.deltaTime * 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = objetive.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speedRotation);

        if (Vector3.Distance(objetive.transform.position, this.transform.position) > 1.5f)
        {
            this.transform.Translate(Vector3.forward.normalized * speedMovement);
        }
    }
}
