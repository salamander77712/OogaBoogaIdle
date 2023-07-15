using Godot;
using System;

public class ResourceLabel : Label
{
    [Export]
    float resourceValue;

    [Export]
    string resourceName;
    public override void _Ready()
    {
        updateLabel(resourceValue);
    }

    public void updateLabel(float newResouceValue){
        resourceValue = newResouceValue;
        Text = resourceName + ": " + resourceValue;
    }

    private void OnResourceAmountChanged(float newResouceValue){
        updateLabel(newResouceValue);
    }
}
