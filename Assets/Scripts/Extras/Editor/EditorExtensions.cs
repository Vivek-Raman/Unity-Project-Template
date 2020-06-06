using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using System.Linq;
using Object = System.Object;

public class EditorExtensions : Editor
{

    #region Lock Inspector
    // credit: https://forum.unity.com/threads/shortcut-key-for-lock-inspector.95815/

    private static EditorWindow _mouseOverWindow;
 
    [MenuItem("Extensions/Select Inspector under cursor #&q")]
    private static void SelectLockableInspector()
    {
        if (EditorWindow.mouseOverWindow.GetType().Name == "InspectorWindow")
        {
            _mouseOverWindow = EditorWindow.mouseOverWindow;
            Type type = Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.InspectorWindow");
            Object[] findObjectsOfTypeAll = Resources.FindObjectsOfTypeAll(type);
            int indexOf = findObjectsOfTypeAll.ToList().IndexOf(_mouseOverWindow);
            EditorPrefs.SetInt("LockableInspectorIndex", indexOf);
        }
    }
 
    [MenuItem("Extensions/Toggle Inspector Lock &q")]
    private static void ToggleInspectorLock()
    {
        if (_mouseOverWindow == null)
        {
            if (!EditorPrefs.HasKey("LockableInspectorIndex"))
                EditorPrefs.SetInt("LockableInspectorIndex", 0);
            int i = EditorPrefs.GetInt("LockableInspectorIndex");
 
            Type type = Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.InspectorWindow");
            Object[] findObjectsOfTypeAll = Resources.FindObjectsOfTypeAll(type);
            _mouseOverWindow = (EditorWindow)findObjectsOfTypeAll[i];
        }
 
        if (_mouseOverWindow != null && _mouseOverWindow.GetType().Name == "InspectorWindow")
        {
            Type type = Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.InspectorWindow");
            PropertyInfo propertyInfo = type.GetProperty("isLocked");
            bool value = (bool)propertyInfo.GetValue(_mouseOverWindow, null);
            propertyInfo.SetValue(_mouseOverWindow, !value, null);
            _mouseOverWindow.Repaint();
        }
    }
    
    #endregion

    #region Clear Console
    // credit: https://answers.unity.com/questions/707636/clear-console-window.html
    
    [MenuItem ("Extensions/Clear Console #&c")]
    private static void Clear ()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries,UnityEditor.dll");
        var clearMethod = logEntries.GetMethod(
            "Clear", 
            System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null,null);
    }
    
    #endregion

    #region Snap to Ground
    // credit: https://unity3d.college/2017/09/26/using-unity-editor-extensions-to-snap-to-ground-when-placing-gameobjects/
    
    [MenuItem("Extensions/Snap To Ground &g")]
    public static void Ground()
    {
        foreach(var transform in Selection.transforms)
        {
            var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 10f);
            foreach(var hit in hits)
            {
                if (hit.collider.gameObject == transform.gameObject)
                    continue;

                transform.position = hit.point;
                break;
            }
        }
    }
    
    #endregion
    
    #region Template
    // credit: 
    

    #endregion
    
}
