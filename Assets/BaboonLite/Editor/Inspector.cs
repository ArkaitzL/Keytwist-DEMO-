using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BaboOnLite {
    //Editor del  scriptableObject lenguaje
    #region lenguaje
    [CustomEditor(typeof(Lenguaje))]
    public class LenguajeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Lenguaje lang = (Lenguaje)target;

            GUILayout.Space(10);

            if (GUILayout.Button("Copiar")) lang.Copiar();
            if (GUILayout.Button("Pegar")) lang.Pegar();
            if (GUILayout.Button("Pegar como nuevo")) lang.PegarComoNuevo();
        }
    }
    #endregion


    //Editor del componete Controlador
    #region controlador
    [CustomEditor(typeof(ControladorBG))]
    public class ControladorBGEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("ControladorBG: Utiliza mecanicas varias de manera facil", EditorStyles.boldLabel);
            EditorGUILayout.Space(10);

            base.DrawDefaultInspector();
        }
    }
    #endregion

    //Editor del componete Save
    #region save
    [CustomEditor(typeof(Save))]
    public class SaveEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("Save: Guarda tus datos de manera facil y comoda", EditorStyles.boldLabel);
            EditorGUILayout.Space(10);

            base.DrawDefaultInspector();

            //A�ade datos extras en el inspector
            #region inspector
            EditorGUILayout.Space(10);

            Save save = (Save)target;

            serializedObject.Update();

            UIExtras.Separador();

            if (GUILayout.Button("Eliminar data"))
            {
                save.Eliminar();
            }


            EditorGUILayout.Space(10);
            save.mensajes = EditorGUILayout.Toggle("Mostrar mensajes: ", save.mensajes);
            EditorGUILayout.Space(10);

            serializedObject.ApplyModifiedProperties();
            #endregion
        }
    }
    #endregion

   
    //PLANTILLA
    [CustomEditor(typeof(DictionaryBG<>))]
    public class DictionaryBGEditor : Editor
    {
        public override void OnInspectorGUI()
        {
           
        }
    }

    public static class UIExtras 
    {
        public static void Separador(int altura = 1)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, altura);
            rect.height = altura;
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        }
    }
}
