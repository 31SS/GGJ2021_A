using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneMover : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    public void ButtonClicked()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("aaa");
    }
 
}
