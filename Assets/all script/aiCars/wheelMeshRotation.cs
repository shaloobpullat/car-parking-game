using UnityEngine;

public class wheelMeshRotation : MonoBehaviour
{
    //for Ai car
   
    public WheelCollider WheelCollider;

    public Vector3 position;
    public Quaternion rotation;

    
    void Update()
    {
        WheelCollider.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;
    }
}
