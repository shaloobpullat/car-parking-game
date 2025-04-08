using TMPro;
using UnityEngine;

public class speedMeter : MonoBehaviour
{
    public Rigidbody car;
    public float speed;
    public TextMeshProUGUI speedLabel;
    
    void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = car.linearVelocity.magnitude * 3.6f;

        speedLabel.text = ((int)speed) + "  km/h";
    }
}
