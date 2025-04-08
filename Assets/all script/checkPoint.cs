using UnityEngine;

public class checkPoint : MonoBehaviour
{
    public GameObject[] checkPoints;
    int nextPoint = 0;
    void Start()
    {
        checkPoints[nextPoint].SetActive(true);  
    }

   public void NextcheckPoint()
    {
        nextPoint++;
        if (checkPoints.Length > nextPoint)
        {
            checkPoints[nextPoint].SetActive(true);
        }
    }
    
}
