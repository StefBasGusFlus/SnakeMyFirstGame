using UnityEngine;
using UnityEngine.SceneManagement;

public class LooserScript : MonoBehaviour
{
    public void LoserReturn()
    {
        SceneManager.LoadScene(1);
    }
}
