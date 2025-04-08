using UnityEngine;

public class cashCollition : MonoBehaviour
{
    public GameObject returnPath;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            returnPath.SetActive(true);
            Destroy(gameObject);
            FindAnyObjectByType<barrierCollider>().money.text=10.ToString();
            FindAnyObjectByType<AudioManger>().Playsound("coin");

        }
    }
}
