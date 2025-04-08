using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Parkingzzone : MonoBehaviour
{
    

    public Renderer zone;
    public Animator anim;
    Color newColor = new Color(0f, 0.69f, 0.27f, 0.27f);
    public GameObject winPop;

    bool isFPivotInside = false;
    bool isBPivotInside = false;
    public Coroutine winCoroutine;

    public GameObject[] cars;
    
    public Vector3 carpossition;
    public  Vector3 carrotationEular;
    platformRotation IndexOfPlatformCar;
    public CinemachineFreeLook freeLook;
    GameObject currentCar;
    int index;
   

    private void Awake()
    {
        
         index = GameManager.Instance.selectedCarIndex;
        

            Quaternion carRotation = Quaternion.Euler(carrotationEular);
        currentCar=Instantiate(cars[index], carpossition, carRotation);
    }
    void Start()
    {
        zone = GetComponent<Renderer>();
        freeLook.Follow = currentCar.transform;
        freeLook.LookAt = currentCar.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFPivotInside && isBPivotInside)
        {
            zone.material.color = newColor;
            anim.SetBool("CarIn", isBPivotInside);

           
            if (winCoroutine == null)
            {
                winCoroutine = StartCoroutine(winPopHold());
            }
        }
        else
        {
            
            if (winCoroutine != null)
            {
                StopCoroutine(winCoroutine);
                winCoroutine = null;
            }

            zone.material.color = new Color(0.7830188f, 0.03716894f, 0, 0.2705882f);
            anim.SetBool("CarIn", isBPivotInside);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FrontPivot"))
        {
            isFPivotInside = true;  
        }

        if (other.CompareTag("BackPivot"))
        {
            isBPivotInside = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FrontPivot"))
        {
            isFPivotInside = false;
        }

        if (other.CompareTag("BackPivot"))
        {
            isBPivotInside = false;
        }

    }
   

    IEnumerator winPopHold()
    {
        yield return new WaitForSeconds(2f);
        winPop.SetActive(true);
        Time.timeScale = 0f;
        FindAnyObjectByType<gameManeger>().pouseBT.SetActive(false);
        FindAnyObjectByType<AudioManger>().Playsound("Handbrake");


    }

}
