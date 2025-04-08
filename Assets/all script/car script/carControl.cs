



using System.Runtime.InteropServices;
using UnityEngine;


public class carControl : MonoBehaviour
{

    
    [SerializeField] WheelCollider FLW;
    [SerializeField] WheelCollider FRW;
    [SerializeField] WheelCollider BLW;
    [SerializeField] WheelCollider BRW;

    public Rigidbody rb;
    public float accelaration = 1000f;
    public float BreakForce = 1500f;
    public float steerAngle = 70f;
    public float enginBreak;

    public float currentacc = 0f;
    public float currentBreak = 0f;
    public float currentAngle = 0f;


    [SerializeField] Transform FLWheel;
    [SerializeField] Transform FRWheel;
    [SerializeField] Transform BLWheel;
    [SerializeField] Transform BRWheel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Drive();
        Break();
        turn();

        RealWheelMove(BLW, BLWheel);
        RealWheelMove(BRW, BRWheel);
        RealWheelMove(FLW, FLWheel);
        RealWheelMove(FRW, FRWheel);

    }

    public void Drive()
    {

        

        float Vertical = Input.GetAxis("Vertical");

        currentacc = Vertical * accelaration;


        FRW.motorTorque = currentacc;
        FLW.motorTorque = currentacc;

        if (Vertical == 0)
        {
            
            currentBreak = enginBreak;

        }
        else
        {
            currentBreak = 0f;
          


        }
        //FRW.brakeTorque = currentBreak;
        //FLW.brakeTorque = currentBreak;
        BRW.brakeTorque = currentBreak;
        BLW.brakeTorque = currentBreak;
    }
    public void Break()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreak = BreakForce;

        }

        FRW.brakeTorque = currentBreak;
        FLW.brakeTorque = currentBreak;
        BRW.brakeTorque = currentBreak;
        BLW.brakeTorque = currentBreak;
    }
    public void turn()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        currentAngle = Horizontal * steerAngle;

        FLW.steerAngle = currentAngle;
        FRW.steerAngle = currentAngle;
    }

    public void RealWheelMove(WheelCollider coli, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;

        coli.GetWorldPose(out position, out rotation);
        trans.rotation = rotation;
        trans.position = position;

    }
    
}
