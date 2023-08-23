using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using Mono.Cecil;

public class PopupWindow : VisualElement
{
    [UnityEngine.Scripting.Preserve]
    public new class UxmlFactory : UxmlFactory<PopupWindow> {};

    private const string styleResource = "PopupWindowStyle";
    private const string ussPopupWindow = "popup_window";
    private const string ussPopupContain = "popup_contain";
    private const string ussSlider = "slider";


    public PopupWindow() {
        // styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
        AddToClassList(ussPopupContain);

        VisualElement window = new();
        window.AddToClassList(ussPopupWindow);
        hierarchy.Add(window);

        Button back = new();
        back.name = "BACK";
        back.text = "BACK";
        window.Add(back);

        SliderInt sliderInt= new SliderInt();
        sliderInt.AddToClassList(ussSlider);
        sliderInt.name = "volime";
        window.Add(sliderInt);


        Scroller scroller = new Scroller();
        scroller.name = "scroll";
        window.Add(scroller);

        

    }
}
