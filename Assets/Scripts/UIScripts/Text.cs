using System;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace UIScripts
{
    public class Text : CustomUIComponent
    {
        public TextSO textData;
        public Style style;

        public TextMeshProUGUI textMeshProUGUI;

        protected override void Setup()
        {
            textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        }

        protected override void Configure()
        {
            textMeshProUGUI.color = textData.theme.GetTextColor(style);
            textMeshProUGUI.font = textData.font;
            textMeshProUGUI.fontSize = textData.size;
        }

        void OnValidate()
        {
            Init();
        }

        public void OnClickInitButton()
        {
            Init();
        }
    }

    [CustomEditor(typeof(Text))]
    public class TextEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Text text = (Text)target;

            if (GUILayout.Button("Run Init 2"))
            {
                text.OnClickInitButton();
            }
        }
    }
}