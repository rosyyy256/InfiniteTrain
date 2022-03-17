namespace InfiniteTrain
{
    public class RailwayCarriage
    {
        public int Number;
        public RailwayCarriage FrontCarriage { get; private set; }
        public RailwayCarriage RearCarriage { get; private set; }
        public bool IsLightsOn { get; private set; }

        public RailwayCarriage(bool isLightsOn)
        {
            IsLightsOn = isLightsOn;
        }

        public void SwitchLights() => IsLightsOn = !IsLightsOn;

        public void SetFrontCarriage(RailwayCarriage carriage) => FrontCarriage = carriage;

        public void SetRearCarriage(RailwayCarriage carriage) => RearCarriage = carriage;
    }
}