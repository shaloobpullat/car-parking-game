using UnityEngine;

public class UISliding : MonoBehaviour
{
    public RectTransform UIPanal;
    public RectTransform LevelBT;
    public GameObject Nextbt, Prevbt;
    public Animator camera;

    Vector2 onscreen;
    Vector2 offScreen;
    Vector2 levelBTonscreen;
    Vector2 levleBToffScreen;


    void Start()
    {
        onscreen = UIPanal.anchoredPosition;
        offScreen = new Vector2(-Screen.width, onscreen.y);

        UIPanal.anchoredPosition = offScreen;

        levelBTonscreen = LevelBT.anchoredPosition;
        levleBToffScreen = new Vector2(levelBTonscreen.x, -Screen.height);

        LevelBT.anchoredPosition = levelBTonscreen;
        
    }

    // Update is called once per frame
    public void UIslidein()
    {
        LeanTween.move(UIPanal,onscreen,0.3f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.move(LevelBT, levleBToffScreen, 0.8f).setEase(LeanTweenType.easeOutQuad);
        Nextbt.SetActive(false);
        Prevbt.SetActive(false);

        camera.SetBool("IsLevelPress", true);
        FindAnyObjectByType<AudioManger>().Playsound("click");



    }
    public void Slideout()
    {
        LeanTween.move(UIPanal, offScreen, 0.7f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.move(LevelBT, levelBTonscreen, 0.3f).setEase(LeanTweenType.easeOutQuad);
        Nextbt.SetActive(true);
        Prevbt.SetActive(true);

        camera.SetBool("IsLevelPress", false);
        FindAnyObjectByType<AudioManger>().Playsound("click");

    }
}
