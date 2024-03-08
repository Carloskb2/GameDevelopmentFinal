using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTutorial : MonoBehaviour
{
    public Text instructionText; // Assign a UI Text element in the inspector
    public float pauseDuration = 2.0f; // Duration for each pause

    void Start()
    {
        StartCoroutine(InitialTutorialSequence());
    }

    IEnumerator InitialTutorialSequence()
    {
        // Pause and show 'D' instruction
        yield return new WaitForSeconds(1.2f);
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

    public void StartClimbingTutorial()
    {
        StartCoroutine(ClimbingTutorialSequence());
    }

    IEnumerator ClimbingTutorialSequence()
    {
        // Pause and show climbing instructions
        Time.timeScale = 0f;
        instructionText.text = "Press 'W' to climb up, 'S' to climb down";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S));

        // Resume game and clear text
        Time.timeScale = 1f;
        instructionText.text = "";
        yield return new WaitForSeconds(pauseDuration);
    }
}
