
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    float high = 0;

    // Update is called once per frame
    void Update()
    {
        float temp = (player.GetComponent<Rigidbody>().velocity.magnitude)/10;
        if (temp > high)
        {
            high = temp;
        }
        scoreText.text = "Fastest Speed: " + high.ToString("0") + " m/s"
            + "\nCurrent Speed: " + temp.ToString("0") + " m/s";
    }
}
