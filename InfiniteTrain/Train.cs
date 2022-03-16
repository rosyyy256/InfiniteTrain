using System;

namespace InfiniteTrain
{
    public class Train
    {
        public RailwayCarriage Carriage { get; private set; }

        public Train()
        {
            var startCarriage = new RailwayCarriage(GetRandomBool());
            var frontCarriage = new RailwayCarriage(GetRandomBool());
            var rearCarriage = new RailwayCarriage(GetRandomBool());
            startCarriage.SetFrontCarriage(frontCarriage);
            startCarriage.SetRearCarriage(rearCarriage);
            frontCarriage.SetFrontCarriage(rearCarriage);
            frontCarriage.SetRearCarriage(startCarriage);
            rearCarriage.SetFrontCarriage(startCarriage);
            rearCarriage.SetRearCarriage(frontCarriage);
            Carriage = startCarriage;
        }

        public Train(int carriagesCount) : this()
        {
            if (carriagesCount < 3) throw new ArgumentException("Carriages count must be more than 3");
            carriagesCount -= 3;

            for (var i = 0; i < carriagesCount; i++)
            {
                var currentCarriage = new RailwayCarriage(GetRandomBool());
                currentCarriage.SetFrontCarriage(Carriage.FrontCarriage);
                currentCarriage.SetRearCarriage(Carriage);
                Carriage.FrontCarriage.SetRearCarriage(currentCarriage);
                Carriage.SetFrontCarriage(currentCarriage);
            }
        }

        public int CountCarriages()
        {
            var currentCarriage = Carriage;
            if (!currentCarriage.IsLightsOn) currentCarriage.SwitchLights();

            while (true)
            {
                var result = 0;
                while (!currentCarriage.FrontCarriage.IsLightsOn)
                {
                    currentCarriage = currentCarriage.FrontCarriage;
                    result++;
                }
                currentCarriage.FrontCarriage.SwitchLights();
                for (var i = 0; i < result; i++)
                {
                    currentCarriage = currentCarriage.RearCarriage;
                }

                if (!currentCarriage.IsLightsOn) return result + 1;
            }
        }

        private static bool GetRandomBool()
        {
            var random = new Random();
            return random.Next(0, 9) < 5;
        }
    }
}