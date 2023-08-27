using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class SliderIntElement : VisualElement
{
    [UnityEngine.Scripting.Preserve]
    public new class UxmlFactory : UxmlFactory<SliderIntElement, UxmlTraits>{};


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
            var ate = ve as SliderIntElement;
            ate.title.Clear();
            ate.stringAttr = m_string.GetValueFromBag(bag, cc);
            
            ate.title.text = ate.stringAttr;
        }
    }

    public string stringAttr { get; set; }

    private const string SliderIntElementContain = "slider-int-element-contain";
    private const string SliderIntElementLeftBar = "slider-int-element-leftbar";
    private const string SliderIntElementRightBar = "slider-int-element-rightbar";
    private const string Slider = "slider-int-element-slider";
    private const string SliderIntBoderDrag = "border-drag";
    private const string SliderIntTitle = "slider-int-element-title";

    VisualElement leftBar;
    VisualElement rightBar;
    Label title;
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

        //title

        title = new Label ();
        title.AddToClassList(SliderIntTitle);
        title.text = "volume";
        leftBar.Add(title);

        //sliderInt

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
        progressBar.value = sliderInt.value;

    }

    
}
