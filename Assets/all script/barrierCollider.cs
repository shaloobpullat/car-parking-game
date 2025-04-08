using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class barrierCollider : MonoBehaviour
{
    public Animator Barrier;
    public TextMeshProUGUI money;
    private int cash;
    public GameObject noFundPanel;
    bool carOnceTouch = false;
    public GameObject LocationToCash;
    public GameObject arrow;



    void Start()
    {
        Barrier.SetBool("carEnter", false);
        cash = 0;
    }

    private void Update()
    {
        cash = int.Parse(money.text);

        if (Input.GetKey(KeyCode.E) && carOnceTouch)
        {
            LocationToCash.SetActive(true);

            noFundPanel.SetActive(false);
            carOnceTouch = false;
            arrow.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("car")&& cash>=5)
        {
            Barrier.SetBool("carEnter", true);
            cash = cash - 5;
            money.text = cash.ToString();
            FindAnyObjectByType<AudioManger>().Playsound("coin");


        }
        if (other.CompareTag("car")&&cash==0)
        {
            noFundPanel.SetActive(true);
            carOnceTouch = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("car"))
        {
            Invoke("BarrierDelay", 2f);
        }
    }
    private void BarrierDelay()
    {
        Barrier.SetBool("carEnter", false);
        
    }
}
