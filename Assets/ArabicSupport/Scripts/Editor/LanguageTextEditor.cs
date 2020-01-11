using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEditor.UI
{
    [CustomEditor(typeof(LanguageText), true)]
    [CanEditMultipleObjects]
    public class LanguageTextEditor : GraphicEditor
    {
        SerializedProperty m_Text;
        SerializedProperty m_FontData;
        SerializedProperty m_languageId;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_Text = serializedObject.FindProperty("m_Text");
            m_FontData = serializedObject.FindProperty("m_FontData");
        }

        public override void OnInspectorGUI()
        {
            var lan = target as LanguageText;
            serializedObject.Update();

            if (EditorGUILayout.Toggle("根据文本自动阿语排版", lan.AutoArabicByText) != lan.AutoArabicByText)
            {
                lan.AutoArabicByText = !lan.AutoArabicByText;
                lan.text = lan.BaseText;
                EditorUtility.SetDirty(target);
            }

            EditorGUILayout.PropertyField(m_Text);

            EditorGUILayout.PropertyField(m_FontData);

            AppearanceControlsGUI();
            RaycastControlsGUI();
            serializedObject.ApplyModifiedProperties();

            lan.UpdateLanguage();
        }
    }
}