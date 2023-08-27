using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using Mono.Cecil;
using UnityEngine.UI;
using UnityEditor.PackageManager.UI;

public class PopupWindow : VisualElement
{
    [UnityEngine.Scripting.Preserve]
    public new class UxmlFactory : UxmlFactory<PopupWindow, UxmlTraits> { }
    VisualElement content = new VisualElement();
    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription m_string =
            new UxmlStringAttributeDescription { name = "title", defaultValue = "default_value" };
        
        public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
        {
            get { yield break; }
        }

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var ate = ve as PopupWindow;
            ate.title.Clear();
            ate.stringAttr = m_string.GetValueFromBag(bag, cc);
            
            ate.title.text = ate.stringAttr;
        }
    }


    public string stringAttr { get; set; }

    private const string popupWindow = "popup-window";
    private const string popupContain = "popup-contain";
    private const string popupContent = "popup-content";
    private const string popupTitle = "popup-title";

    public VisualElement window;
    
    Label title;


    public PopupWindow() {
        AddToClassList(popupWindow);

        content = new VisualElement();
        content.AddToClassList(popupContent);
        hierarchy.Add(content);

        title = new Label();
        
        title.AddToClassList(popupTitle);
        content.Add(title);


    }
    
}
