using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class SliderIntElement : VisualElement
{
    [UnityEngine.Scripting.Preserve]
    public new class UxmlFactory : UxmlFactory<SliderIntElement>{};
    private const string SliderIntElementContain = "slider-int-element-contain";
    private const string SliderIntElementLeftBar = "slider-int-element-leftbar";
    private const string SliderIntElementRightBar = "slider-int-element-rightbar";
    private const string Slider = "slider-int-element-slider";
    private const string SliderIntBoderDrag = "border-drag";

    VisualElement leftBar;
    VisualElement rightBar;
    Label text;
    VisualElement slider;
    VisualElement dragBorder;
    SliderInt sliderInt;
    ProgressBar progressBar;
    public SliderIntElement () {
        AddToClassList(SliderIntElementContain);

        leftBar = new VisualElement ();
        leftBar.AddToClassList(SliderIntElementLeftBar);
        hierarchy.Add(leftBar);

        rightBar = new VisualElement ();
        rightBar.AddToClassList(SliderIntElementRightBar);
        hierarchy.Add(rightBar);

        text = new Label ();
        text.text = "volume";
        leftBar.Add(text);

        slider = new VisualElement ();
        slider.name = "slider";
        slider.AddToClassList(Slider);
        rightBar.Add(slider);

        dragBorder = new VisualElement ();
        dragBorder.name = "dragboder";
        dragBorder.AddToClassList(SliderIntBoderDrag);
        
        sliderInt = new SliderInt();
        sliderInt.value = 2;
        sliderInt.lowValue = 0;
        sliderInt.highValue = 10;
        
        progressBar= new ProgressBar ();
        progressBar.value = sliderInt.value;
        progressBar.lowValue = 0;
        progressBar.highValue = sliderInt.highValue;

        slider.Add(dragBorder);
        slider.Add (progressBar);
        slider.Add(sliderInt);

        AddAction();
    }

    public void AddAction() {
        sliderInt.RegisterCallback<ChangeEvent<int>, SliderInt>(Change, sliderInt);
    }

    public void Change(ChangeEvent<int> e, SliderInt sliderInt) {
        Debug.Log("asd");
        // Debug.Log(progressBar.value);
        Debug.Log(sliderInt.value);
        progressBar.value = sliderInt.value;

    }

    
}
