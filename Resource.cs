using Godot;
using System;

public class Resource : Node
{
    [Export]
    string resourceName;

    [Export]

    float productionPerWorker;

    [Export]
    int numberOfWorkers;

    float resourceAmount;

    [Signal]
    public delegate void ResourceAmountChangedEventHandler(float newResourceValue);

    public void produce(){
        resourceAmount += productionPerWorker * numberOfWorkers;
        EmitSignal("ResourceAmountChangedEventHandler", resourceAmount);
    }
    
    private void _on_TickTimer_timeout(){
        produce();
    }
}
