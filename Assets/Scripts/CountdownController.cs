using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountDownController : MonoBehaviour
{
    public int countdownTime = 3; // Number of seconds for the countdown
    public TextMeshProUGUI countdownDisplay; // Reference to the UI Text component
    public GameObject gameplayObjects; // Parent GameObject for gameplay elements

    private void Start()
    {
        if (gameplayObjects != null)
        {
            gameplayObjects.SetActive(false); // Disable gameplay elements initially
        }
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString(); // Update countdown text
            yield return new WaitForSeconds(1f); // Wait for 1 second
            countdownTime--; // Decrease the countdown
        }

        countdownDisplay.text = "GO!"; // Display "GO!"
        yield return new WaitForSeconds(1f); // Wait for another second

        countdownDisplay.gameObject.SetActive(false); // Hide countdown display

        if (gameplayObjects != null)
        {
            gameplayObjects.SetActive(true); // Enable gameplay elements
        }

        
    }
}
