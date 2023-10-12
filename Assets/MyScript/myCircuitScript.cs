using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class myCircuitScript : MonoBehaviour
{
    public GameObject circuit;
    private ArrayList myList = new ArrayList(); 
    private Transform actualTarget;
    private float speedMovement;
    private int counter;
    private bool reached = true;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in circuit.transform)
        {
            Debug.Log(child.tag);
            if(child.tag == "waypoint")
                myList.Add(child);

        }
        speedMovement = Time.deltaTime * 1.0f;
        counter = 0;
        Debug.Log(myList.Count);
        Debug.Log(myList);
    }

    // Update is called once per frame
    void Update()
    {
        if (reached == false)
        {
            if (Vector3.Distance(actualTarget.position, this.transform.position) > 0.5f)
            {
                this.transform.LookAt(actualTarget.position);
                this.transform.Translate(Vector3.forward.normalized * speedMovement);
            }
            else { 
                counter++;
                reached = true;
            }

        }
        else
        {
            if (counter > myList.Count-1) counter = 0;
            actualTarget = (Transform)myList[counter];
            reached = false;
        }
    }
}
