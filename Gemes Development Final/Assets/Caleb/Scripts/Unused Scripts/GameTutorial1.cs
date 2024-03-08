using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;

public class GameTutorial1 : MonoBehaviour
{
    public Text instructionText; // Assign a UI Text element in the inspector
    public float pauseDuration = 2.0f; // Duration for each pause

    [SerializeField]
    private GameObject walkBackColliderGO;

    void Start()
    {
        StartCoroutine(InitialTutorialSequence());
    }

    IEnumerator InitialTutorialSequence()
    {
        // Pause and show 'D' instruction
        Time.timeScale = 0f;
        instructionText.text = "Press 'D' to move forward";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.D));
        Time.timeScale = 1f;
        yield return new WaitForSeconds(pauseDuration);

        // Hide instruction text
        instructionText.text = "";
    }

    public void StartWalkBackTutorial()
    {
        StartCoroutine(WalkBackTutorialSequence());
    }
    IEnumerator WalkBackTutorialSequence()
    {
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

        walkBackColliderGO.SetActive(false);

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

    public void StartGetGemTutorial()
    {
        StartCoroutine(GetGemTutorialSequence());
    }
    IEnumerator GetGemTutorialSequence()
    {
        // Pause and show climbing instructions
        instructionText.text = "Objects with color being stolen are not touchable, you have to get the orb with the corresponding color to restore the color in order to touch it.";
        Time.timeScale = 0f;
        yield return new WaitUntil(() => Input.anyKeyDown);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(pauseDuration);
        instructionText.text = "For now, the glassland ground has no color so you cannot stand on it. Get the green orb to restore its color in order to stand on it";
        Time.timeScale = 0f;
        yield return new WaitUntil(() => Input.anyKeyDown);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(pauseDuration);

        // Resume game and clear text
        Time.timeScale = 1f;
        instructionText.text = "";
        yield return new WaitForSeconds(pauseDuration);
    }

    public void EnterPortalGemTutorial()
    {
        StartCoroutine(EnterPortalTutorialSequence());
    }
    IEnumerator EnterPortalTutorialSequence()
    {
        // Pause and show climbing instructions
        Time.timeScale = 0f;
        instructionText.text = "Get into the portal to finish the level";
        yield return new WaitUntil(() => Input.anyKeyDown);

        // Resume game and clear text
        Time.timeScale = 1f;
        instructionText.text = "";
        yield return new WaitForSeconds(pauseDuration);
    }
}
