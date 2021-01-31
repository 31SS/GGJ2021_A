using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneMover : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    SoundManager sm;
    public void Start()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void ButtonClicked()
    {
        SceneManager.LoadScene(sceneName);
        sm.SEPlay("決定、ボタン押下32");
    }
 
}
