#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[InitializeOnLoad]
public static class CoreDependencyCheck
{
    // ReSharper disable once CollectionNeverUpdated.Local
    private static readonly List<PackageDependency> Dependencies = new()
    {
        // Añade aquí las dependencias cuando las necesites:
        // new PackageDependency(
        //     "VContainer",
        //     "VContainer.LifetimeScope, VContainer",
        //     "https://github.com/hadashiA/VContainer.git?path=/VContainer/Assets/VContainer"
        // ),
    };

    private static readonly Queue<PackageDependency> PendingInstalls = new();
    private static AddRequest _addRequest;

    static CoreDependencyCheck()
    {
        EditorApplication.update += CheckDependencies;
    }

    private static void CheckDependencies()
    {
        EditorApplication.update -= CheckDependencies;

        foreach (var dependency in Dependencies.Where(dependency => !dependency.IsInstalled()))
        {
            PendingInstalls.Enqueue(dependency);
        }

        if (PendingInstalls.Count > 0)
            InstallNext();
    }

    private static void InstallNext()
    {
        if (PendingInstalls.Count == 0) return;

        var dependency = PendingInstalls.Dequeue();
        Debug.LogWarning($"com.mc.core requires {dependency.Name}. Installing automatically...");
        _addRequest = Client.Add(dependency.GitUrl);
        EditorApplication.update += Progress;
    }

    private static void Progress()
    {
        if (_addRequest is not { IsCompleted: true }) return;

        EditorApplication.update -= Progress;

        if (_addRequest.Status == StatusCode.Success)
            Debug.Log($"Package installed successfully.");
        else
            Debug.LogError($"Failed to install package automatically.\nURL: {_addRequest.Error?.message}");

        InstallNext();
    }

    private readonly struct PackageDependency
    {
        public readonly string Name;
        private readonly string _typeCheck;
        public readonly string GitUrl;

        // ReSharper disable once UnusedMember.Local
        public PackageDependency(string name, string typeCheck, string gitUrl)
        {
            Name = name;
            _typeCheck = typeCheck;
            GitUrl = gitUrl;
        }

        public bool IsInstalled() => System.Type.GetType(_typeCheck) != null;
    }
}
#endif