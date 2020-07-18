using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rhino.Runtime.InProcess;

public class TitleSceneScript : MonoBehaviour
{


    void Update ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}