using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int selectedCarIndex = 0;
    public int Level = 1;
    private void Awake()
    {
        

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
       
    }
    public void LevelSelect(int LevelIndex)
    {
        Level = LevelIndex;//for store current level
        SceneManager.LoadScene(LevelIndex);
        FindAnyObjectByType<AudioManger>().Playsound("click");

    }
}

