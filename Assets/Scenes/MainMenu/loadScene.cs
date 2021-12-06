using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //LoadScene is called once to load a new Scene

    public void LoadScene (string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
