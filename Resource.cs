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
    public delegate void ProducedEventHandler(float newResourceValue);

    public void produce(){
        resourceAmount += productionPerWorker * numberOfWorkers;
        //EmitSignal("Produced", resourceAmount);
    }
    
    private void _on_TickTimer_timeout(){
        produce();
        GD.Print("produced");
    }
}
