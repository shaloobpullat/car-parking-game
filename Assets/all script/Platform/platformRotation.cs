using UnityEngine;

public class platformRotation : MonoBehaviour
{
    public Vector3 speed = new Vector3(0, 3f, 0);

    //Platform rotaion
    public GameObject[] cars;
    public Transform spawnPosition;

    public int currentIndex = 0;
    GameObject currentCar;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        //Time.timeScale = 1;
        if (cars.Length > 0)
        {
            spwan(currentIndex);

        }
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(speed * Time.deltaTime);
        spawnPosition.position = currentCar.transform.position;
        currentCar.transform.Rotate(speed * Time.deltaTime);
    }

    public void spwan(int Index)
    {
        if (currentCar != null)
        {
            Destroy(currentCar);
        }
        currentCar = Instantiate(cars[Index], spawnPosition.position,spawnPosition.rotation);
        
    }
    public void Next()
    {
        currentIndex = (currentIndex + 1) % cars.Length; // loop next
        GameManager.Instance.selectedCarIndex = currentIndex;
        spwan(currentIndex);
        FindAnyObjectByType<AudioManger>().Playsound("click");


    }
    public void Prev()
    {
        currentIndex = (currentIndex - 1 +cars.Length) % cars.Length; // loop next
        GameManager.Instance.selectedCarIndex = currentIndex;
        spwan(currentIndex);
        FindAnyObjectByType<AudioManger>().Playsound("click");


    }
}

