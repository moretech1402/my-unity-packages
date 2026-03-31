#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using System;

[InitializeOnLoad]
public static class CoreDependencyCheck
{
    private const string VContainerGitUrl =
        "https://github.com/hadashiA/VContainer.git?path=/VContainer/Assets/VContainer";

    private static AddRequest _addRequest;

    static CoreDependencyCheck()
    {
        EditorApplication.update += CheckDependency;
    }

    private static void CheckDependency()
    {
        EditorApplication.update -= CheckDependency;

        if (IsVContainerInstalled())
            return;

        Debug.LogWarning(
            "com.mc.core requires VContainer. Installing automatically..."
        );

        InstallVContainer();
    }

    private static bool IsVContainerInstalled()
    {
        return Type.GetType("VContainer.LifetimeScope, VContainer") != null;
    }

    private static void InstallVContainer()
    {
        _addRequest = Client.Add(VContainerGitUrl);

        EditorApplication.update += Progress;
    }

    private static void Progress()
    {
        if (_addRequest == null || !_addRequest.IsCompleted)
            return;

        EditorApplication.update -= Progress;

        if (_addRequest.Status == StatusCode.Success)
        {
            Debug.Log("VContainer installed successfully.");
        }
        else
        {
            Debug.LogError(
                "Failed to install VContainer automatically.\n" +
                "Please install manually:\n" +
                VContainerGitUrl
            );
        }
    }
}
#endif