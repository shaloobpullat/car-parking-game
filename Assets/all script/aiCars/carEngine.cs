using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics.Geometry;

public class carEngine : MonoBehaviour
{

    //for AI car
    public Transform path;
    private List<Transform> node;
    public float maxSteerAngle = 45f;

    private  int currentNode = 0;

    public WheelCollider FL;
    public WheelCollider FR;
    public float motorPower=100f;
    public float curretSpeed;
    public float maxSpeed = 130f;
    public Vector3 centerOfMass;

    [Header("sensors")]
    public float sensorLength = 1f;
    public float sensorAngle = 30f;

    public Transform FrontsensorPositionC;
    public Transform FrontsensorPositionL;
    public Transform FrontsensorPositionR;
    public Transform sideSensorPositionR;

    private bool avoiding = false;
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;

        Transform[] pathTrans = path.GetComponentsInChildren<Transform>();
        node = new List<Transform>();
        for(int i = 0; i < pathTrans.Length; i++)
        {
            if (pathTrans[i] !=path.transform)
            {
                node.Add(pathTrans[i]);
            }
        }

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplySteer();
        Drive();
        NodeDistance();
        sensors();
        
    }

    public void sensors()
    {
        RaycastHit hit;
        float avoidMultiplier=0;
        avoiding = false;
        
       
        

        //Left sensor
        if (Physics.Raycast(FrontsensorPositionL.position, transform.forward, out hit, sensorLength))
        {
            if (!hit.collider.CompareTag("ground"))
            {
                Debug.DrawLine(FrontsensorPositionL.position, hit.point);
                avoiding = true;
                avoidMultiplier += 1f;

            }
        }
        //Left angle sensor
        else if (Physics.Raycast(FrontsensorPositionL.position, Quaternion.AngleAxis(-sensorAngle, FrontsensorPositionL.up) * transform.forward, out hit, sensorLength))
        {
            if (!hit.collider.CompareTag("ground"))
            {
                Debug.DrawLine(FrontsensorPositionL.position, hit.point);
                avoiding = true;
                avoidMultiplier += 0.5f;

            }
        }

        //Right sensor
        if (Physics.Raycast(FrontsensorPositionR.position, transform.forward, out hit, sensorLength))
        {
            if (!hit.collider.CompareTag("ground"))
            {
                Debug.DrawLine(FrontsensorPositionR.position, hit.point);
                avoiding = true;
                avoidMultiplier -= 1f;

            }

        }//Right angle sensor
        else if (Physics.Raycast(FrontsensorPositionR.position, Quaternion.AngleAxis(sensorAngle, FrontsensorPositionR.up) * transform.forward, out hit, sensorLength))
        {
            if (!hit.collider.CompareTag("ground"))
            {
                Debug.DrawLine(FrontsensorPositionR.position, hit.point);
                avoiding = true;
                avoidMultiplier -= 0.5f;

            }

        }
        //Right angle sensor
        else if (Physics.Raycast(sideSensorPositionR.position, Quaternion.AngleAxis(20, sideSensorPositionR.up) * transform.forward, out hit, 1f))
        {
            if (!hit.collider.CompareTag("ground"))
            {
                Debug.DrawLine(sideSensorPositionR.position, hit.point);
                avoiding = true;
                avoidMultiplier -= 0.5f;

            }

        }
        //center sensor
        if (avoidMultiplier == 0)
        {
            if (Physics.Raycast(FrontsensorPositionC.position, transform.forward, out hit, sensorLength))
            {
                if (!hit.collider.CompareTag("ground"))
                {
                    Debug.DrawLine(FrontsensorPositionC.position, hit.point);
                    avoiding = true;
                    if (hit.normal.x < 0)
                    {
                        avoidMultiplier = -1f;
                    }
                    else
                    {
                        avoidMultiplier = 1f;
                    }

                }
            }
        }
        if (avoiding)
        {
            FL.steerAngle = maxSteerAngle * avoidMultiplier;
            FR.steerAngle = maxSteerAngle * avoidMultiplier;

        }

    }
    public void ApplySteer()
    {
        if (avoiding) { return; } 
        
            Vector3 relativeVector = transform.InverseTransformPoint(node[currentNode].position);
            float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
            FL.steerAngle = newSteer;
            FR.steerAngle = newSteer;
        


    }
    public void Drive()
    {
        curretSpeed = 2 * Mathf.PI * FL.radius * FL.rpm * 60 / 1000;
        if (curretSpeed > maxSpeed)
        {
            FL.motorTorque = 0;
            FR.motorTorque = 0;
        }
        else
        {
            FL.motorTorque = motorPower;
            FR.motorTorque = motorPower;
        }
    }
    public void NodeDistance()
    {
        float distance = Vector3.Distance(transform.position, node[currentNode].position);
        if (distance <2f)
        {
            if (currentNode==node.Count-1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }
}
