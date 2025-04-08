using UnityEngine;


[System.Serializable]
public class sound
{
    public string name;
    public AudioClip clip;

    public float volume;
    public bool loop;

    public AudioSource source;
}
