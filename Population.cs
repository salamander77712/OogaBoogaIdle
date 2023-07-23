using Godot;
using System;

public class Population : Node
{
    [Export]
    float fertilityRate;

    [Export]
    float foodPerPerson;

    [Export]
    float population;

    int availableWorkers;
    int assignedWorkers;

    [Export]
    float availableFood;

    [Signal]
    public delegate void TakeFoodEventHandler(float amountTaken, string whoTook);
    [Signal]
    public delegate void PopulationChangedEventHandler(float newPopulation);
    [Signal]
    public delegate void AvailableWorkersChangedEventHandler(int newAvailableWorkers);
    [Signal]
    public delegate void AssignedWorkersChangedEventHandler(int newAssignedWorkers);
    [Signal]
    public delegate void WorkersAssignedEventHandler(int workersAssigned, string whoAssigned, bool success);


    public void breedAndDie(){
        float foodNeeded = population * foodPerPerson;
        EmitSignal("TakeFoodEventHandler", foodNeeded, "Population");
        availableFood -= foodNeeded;
        if(availableFood >= 0){
            population *= fertilityRate;
        }
        else{
            population += availableFood / foodPerPerson;
            availableFood = 0;
        }
        EmitSignal("PopulationChangedEventHandler", population);
        //what happens when assigned workers starve?
    }

    public void getFood(float amount, string name){
        if(name == "population"){
            availableFood += amount;
        }
    }

    public void assignWorkers(int numberOfWorkers, string whoAssignedWorkers){
        if(numberOfWorkers > 0){
            
        }
    }
}
