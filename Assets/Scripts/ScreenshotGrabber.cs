#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ScreenshotGrabber {
    [MenuItem("Screenshot/1")]
    public static void Grab1() {
        ScreenCapture.CaptureScreenshot("D:/Даниил/Unity_projects/Test_task_Inty/Test_Task_Inty/README_Additional_materials/1.png", 1);
    }
    [MenuItem("Screenshot/2")]
    public static void Grab2() {
        ScreenCapture.CaptureScreenshot("D:/Даниил/Unity_projects/Test_task_Inty/Test_Task_Inty/README_Additional_materials/2.png", 1);
    }
    [MenuItem("Screenshot/3")]
    public static void Grab3() {
        ScreenCapture.CaptureScreenshot("D:/Даниил/Unity_projects/Test_task_Inty/Test_Task_Inty/README_Additional_materials/3.png", 1);
    }
    [MenuItem("Screenshot/4")]
    public static void Grab4() {
        ScreenCapture.CaptureScreenshot("D:/Даниил/Unity_projects/Test_task_Inty/Test_Task_Inty/README_Additional_materials/4.png", 1);
    }
    [MenuItem("Screenshot/5")]
    public static void Grab9() {
        ScreenCapture.CaptureScreenshot("D:/Даниил/Unity_projects/Test_task_Inty/Test_Task_Inty/README_Additional_materials/5.png", 1);
    }
}
#endif