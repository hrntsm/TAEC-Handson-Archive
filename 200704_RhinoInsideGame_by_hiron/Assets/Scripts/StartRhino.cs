using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Rhino.Runtime.InProcess;
using UnityEngine;

public class StartRhino : MonoBehaviour
{
    CancellationTokenSource _cts;
    void Awake()
    {
        var token = this.GetCancellationTokenOnDestroy();
        _cts = new CancellationTokenSource();
        string RhinoSystemDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Rhino WIP", "System");
        var PATH = Environment.GetEnvironmentVariable("PATH");
        Environment.SetEnvironmentVariable("PATH", PATH + ";" + RhinoSystemDir);
        // var t = new RhinoCore(new string[] {"/scheme=Unity", "/nosplash"}, WindowStyle.Minimized);
        Task.Run(() =>
                // GC.SuppressFinalize(new RhinoCore(new string[] {"/scheme=Unity", "/nosplash"}, WindowStyle.Minimized)),
                new RhinoCore(new string[] {"/scheme=Unity", "/nosplash"}, WindowStyle.Minimized),
            token
        );
    }

    void OnApplicationQuit()
    {
        Destroy(gameObject);
    }
}
