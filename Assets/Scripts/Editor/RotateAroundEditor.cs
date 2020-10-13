using UnityEngine;
using UnityEditor;
using System.Reflection.Emit;

[CustomEditor(typeof(RotateAround))]
public class RotateAroundEditor : Editor
{
    bool isCounterClockwise = false;

    private Color matColor = Color.white;

    bool showPosition = true;
    string status = "Select a GameObject";

    Vector2 scrollPos;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        RotateAround rotateAround = (RotateAround)target;

        GUILayout.Label("Determines direction of the rotation");

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Counter Clockwise"))
        {
            rotateAround.GoCounterClockwise();
        }

        if (GUILayout.Button("Clockwise"))
        {
            rotateAround.GoClockwise();
        }

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.Label("Determines the speed at which the object rotates the object");
        rotateAround.rotateSpeed = EditorGUILayout.Slider("Rotation Speed", rotateAround.rotateSpeed, 0f, 500f);

        GUILayout.Space(10);

        GUILayout.Label("Determines the color of the object. Make sure to click Change!");
        GUILayout.BeginHorizontal();
        matColor = EditorGUILayout.ColorField("New Color", matColor);
        if(GUILayout.Button("Change"))
        {
            rotateAround.SetColor(matColor);
        }

        GUILayout.EndHorizontal();

        if(rotateAround.target == null)
        {
            EditorGUILayout.HelpBox("Missing a target to rotate around", MessageType.Warning);
        }

        showPosition = EditorGUILayout.Foldout(showPosition, status);
        if (showPosition)
            GUILayout.Label("This option invites chaos. It works...sometimes?");
            if (Selection.activeTransform)
            {
                rotateAround.RotateVector =
                    EditorGUILayout.Vector3Field("Axis", rotateAround.RotateVector);
                status = "Advanced";
            }
        if (!Selection.activeTransform)
        {
            status = "Select a GameObject";
            showPosition = false;
        }
    }
}
