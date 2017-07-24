namespace ITGGame.AI
{
    public enum BehaviourType 
    {
        None                = 0x00000,
        Seek                = 0x00002,
        Flee                = 0x00004,
        Arrive              = 0x00008,
        Wander              = 0x00010,
        Cohesion            = 0x00020,
        Separation          = 0x00040,
        Allignment          = 0x00080,
        ObstacleAvoidance   = 0x00100,
        FollowPath          = 0x00200,
        Pursuit             = 0x00400,
        Evade               = 0x00800,
        Interpose           = 0x01000,
        Hide                = 0x02000,
        Flock               = 0x04000,
        OffsetPursuit       = 0x08000,
    }               

    public enum Deceleration
    {
        Fast = 1,
        Normal = 2,
        Slow = 3
    }
    public enum EntityType
    {
        Default
    }
    public enum SumingMethod
    {
        WeightedAverage,
        Prioritized,
        Dithered
    }
}

