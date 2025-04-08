using System.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public GameObject cam;
    public GameObject pressW;
    bool isWPressed = true;
    void Start()
    {
        Time.timeScale = 1f;
        Invoke("camera", 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W)&&isWPressed||Input.GetKey(KeyCode.S) && isWPressed)
        {
            pressW.SetActive(false);
            Time.timeScale = 1f;
            isWPressed = false;

        }
    }
    public async void camera()
    {
        cam.SetActive (true);
        await Task.Delay(2000);
        Time.timeScale = 0f;
        pressW.SetActive(true);
        isWPressed = true;

    }
}
