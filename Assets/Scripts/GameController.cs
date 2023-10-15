using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController controller;
    public GameObject[] winLose;

    // Start is called before the first frame update
    void Start()
    {
        controller = this;
    }

    public void WinLose(int _index)
    {
        winLose[_index].SetActive(true);
    }
}
