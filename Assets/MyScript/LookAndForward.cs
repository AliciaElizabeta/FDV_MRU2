using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAndForward : MonoBehaviour
{
    public Transform target;

    private float speedMovement;
    private float speedRotation;

    // Start is called before the first frame update
    void Start()
    {
        speedMovement = Time.deltaTime * 1.0f;
        speedRotation = Time.deltaTime * 40f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, this.transform.position) > 1.5f )
        {
            this.transform.LookAt(target.position);
            this.transform.Translate(Vector3.forward.normalized * speedMovement);
        }
    }
}
