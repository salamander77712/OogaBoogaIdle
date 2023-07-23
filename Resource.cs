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
    [Signal]
    public delegate void ResourceTakenEventHandler(float amountTaken, string whoTook);
    public void produce(){
        resourceAmount += productionPerWorker * numberOfWorkers;
        EmitSignal("ResourceAmountChangedEventHandler", resourceAmount);
    }
    
    private void _on_TickTimer_timeout(){
        produce();
    }
     public void requestResource(float amountRequested, string whoRequested){
        if(amountRequested <= resourceAmount){
            resourceAmount -= amountRequested;
            EmitSignal("ResourceTakenEventHandler", amountRequested, whoRequested);
        }
        else{
             EmitSignal("ResourceTakenEventHandler", resourceAmount, whoRequested);
             resourceAmount = 0;
        }
        EmitSignal("ResourceAmountChangedEventHandler", resourceAmount);
    }
}
