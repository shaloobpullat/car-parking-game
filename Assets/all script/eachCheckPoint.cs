using UnityEngine;

public class eachCheckPoint : MonoBehaviour
{

     public checkPoint checkpointss;
    

    private void Start()
    {
        checkpointss = GetComponentInParent<checkPoint>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {


            checkpointss.NextcheckPoint();
            gameObject.SetActive(false);
            FindAnyObjectByType<AudioManger>().Playsound("ch");
            FindAnyObjectByType<barrierCollider>().arrow.SetActive(true);
           
        }
    }
}
