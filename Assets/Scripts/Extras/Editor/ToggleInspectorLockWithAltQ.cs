using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using System.Linq;
using Object = System.Object;

// credit: https://forum.unity.com/threads/shortcut-key-for-lock-inspector.95815/
public class ToggleInspectorLockWithAltQ: Editor
{
    private static EditorWindow _mouseOverWindow;
 
    [MenuItem("Extensions/Select Inspector under cursor #&q")]
    static void SelectLockableInspector()
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
    static void ToggleInspectorLock()
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

}
