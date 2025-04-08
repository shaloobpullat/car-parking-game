using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public sound[] sounds;
    void Start()
    {
        foreach(sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;

        }
        Playsound("carIdle");
        Playsound("bgm");

    }
    public void Playsound(string Name)
    {
        foreach(sound s in sounds)
        {
            if (s.name == Name)
            {
                s.source.Play();
            }

        }
    }

   
}
