using Entitas;
    
public partial class GameFeature : Feature
{
    public GameFeature(Contexts contexts) 
    {
        // initialize Systems
        Add(new TickInitializeSystem(contexts.game));
        Add(new TickUpdateSystem(contexts.game));
        Add(new PlayerInitSystem(contexts.game));

        //Simulation Systems
        Add(new PlayerMovementSystem(contexts.game));
        // render Systems
        Add(new PlayerRenderInitSystem(contexts.game));
        Add(new PlayerPositionApplySystem(contexts.game));

        // Cleanup System
        Add(new EntityDisposeSystem(contexts.game));
    }
}