using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTutorial : MonoBehaviour
{
    public Text instructionText; // Assign a UI Text element in the inspector
    public float pauseDuration = 2.0f; // Duration for each pause

    void Start()
    {
        StartCoroutine(TutorialSequence());
    }

    IEnumerator TutorialSequence()
    {
        // Pause and show 'D' instruction
        Time.timeScale = 0f;
        instructionText.text = "Press 'D' to move forward";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.D));
        Time.timeScale = 1f;
        yield return new WaitForSeconds(pauseDuration);

        // Pause and show 'A' instruction
        Time.timeScale = 0f;
        instructionText.text = "Press 'A' to move backward";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A));
        Time.timeScale = 1f;
        yield return new WaitForSeconds(pauseDuration);

        // Pause and show 'Space Bar' instruction
        Time.timeScale = 0f;
        instructionText.text = "Press 'SPACE' to jump";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        Time.timeScale = 1f;


        // Hide instruction text
        instructionText.text = "";
    }
}
