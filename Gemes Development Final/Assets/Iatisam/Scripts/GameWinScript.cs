using UnityEngine;

public class GameWinScript : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.winSound);
    }
}
