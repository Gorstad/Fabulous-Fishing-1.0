using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
[SerializeField] int SceneIndex = 0;
[SerializeField] float InvokeLoad = 20f;
   void Start()
    {
     Invoke("Loadscene",InvokeLoad);
    }
    private void Loadscene()
    {
     SceneManager.LoadScene(SceneIndex);
    }
}
