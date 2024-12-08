//Animation
public enum AnimationName
{
    idleDown,
    idleUp,
    idleLeft,
    idleRight,
    walkDown,
    walkUp,
    walkLeft,
    walkRight,
    runDown,
    runUp,
    runLeft,
    runRight,
    useToolDown,
    useToolUp,
    useToolLeft,
    useToolRight,
    swingToolDown,
    swingToolUp,
    swingToolLeft,
    swingToolRight,
    liftToolDown,
    liftToolUp,
    liftToolLeft,
    liftToolRight,
    holdToolDown,
    holdToolUp,
    holdToolLeft,
    holdToolRight,
    pickDown,
    pickUp,
    pickLeft,
    pickRight,
    count
}

public enum CharacterPartAnimator
{
    body,
    arms,
    hair,
    tool,
    hat,
    count
}

public enum PartVariantColor
{
    none,
    count
}

public enum PartVariantType
{
    none,
    carry,
    axe,
    hoe,
    pickaxe,
    scythe,
    wateringCan,
    count
}

//Game Time
public enum Season
{
    Spring,
    Summer,
    Autumun,
    Winter,
    none,
    count
}


//Tool Effect
public enum ToolEffect
{ 
    none,
    watering
}

public enum Direction
{
    left,
    right,
    up,
    down,
    none
}

public enum ItemType
{
    Seed,
    Commodity,
    Watering_Tool,
    Hoeing_Tool,
    Chopping_Tool,
    Breaking_Tool,
    Reaping_Tool,
    Collecting_Tool,
    Reapable_Scenary,
    Furniture,
    none,
    count
}

public enum InventoryLocation
{
    player,
    chest,
    count
}
