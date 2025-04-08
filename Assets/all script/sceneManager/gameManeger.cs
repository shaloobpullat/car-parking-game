using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject pouseMenu;
    public GameObject pouseBT;
    public GameObject winPop;



    public void poused()
    {
        Time.timeScale = 0f;
        pouseMenu.SetActive(true);
        pouseBT.SetActive(false);
        FindAnyObjectByType<AudioManger>().Playsound("click");

    }

    public void Play()
    {
        Time.timeScale = 1f;
        pouseMenu.SetActive(false);
        pouseBT.SetActive(true);
        FindAnyObjectByType<AudioManger>().Playsound("click");

    }
    public void restart()
    {
        Time.timeScale = 1f;
        int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneIndex);
        FindAnyObjectByType<AudioManger>().Playsound("click");


    }
    public void NextLevel()
    {
        int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneIndex + 1);
        Time.timeScale = 1f;
        FindAnyObjectByType<AudioManger>().Playsound("click");



        winPop.SetActive(false);
        pouseBT.SetActive(true);
    }
    public void Home()
    {
        int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        FindAnyObjectByType<AudioManger>().Playsound("click");



        winPop.SetActive(false);
        pouseBT.SetActive(true);

    }
    public void exitt()
    {
        Application.Quit();
    }


}
