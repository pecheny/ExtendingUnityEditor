using System;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildAndRunCurrentScene {
    [MenuItem("Build tools/Build and run current scene &x")]
    static void  BuildAndRunScene() {
        var scene = EditorSceneManager.GetActiveScene();
        Build(scene);
        Run(GetBuildName(scene));
    }

    static void Build(Scene scene) {
        var buildName = GetBuildName(scene);
        PlayerSettings.productName = buildName;
        PlayerSettings.runInBackground = true;
        string binPath = ComposeBuildPath(buildName);
        if (Directory.Exists(binPath)) {
            Directory.CreateDirectory(binPath);
        }
        string[] levels = new string[] {scene.path};
        BuildPipeline.BuildPlayer(levels, ComposeExecPath(buildName), BuildTarget.StandaloneWindows, BuildOptions.None);
    }

    static void Run(string buildName) {
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo.FileName = ComposeExecPath(buildName);
        proc.Start();
    }

    static string ComposeBuildPath(string buildName) {
        return Application.dataPath + "/../Builds/" + DateTime.Now.ToString("dd.MM.yy") + "/" + buildName + "/";
    }

    static string ComposeExecPath(string buildName) {
        string execPath = ComposeBuildPath(buildName) + buildName + ".exe";
        execPath = execPath.Replace("/", "\\");
        return execPath;
    }
    static string GetBuildName(Scene scene) {
        return scene.name;
    }
}
