using UnityEngine;

public class GAMEOVER : MonoBehaviour
{
    public GameObject UIGameOver;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            FindAnyObjectByType<AudioManger>().Playsound("hit");

            UIGameOver.SetActive(true);
            Invoke("stop", 1f);

        }


    }
    public void stop()
    {
        Time.timeScale = 0f;
    }
}
