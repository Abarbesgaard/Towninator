
using TowninatorCLI.Model;

namespace TowninatorCLI.Utilities.Lists.Buildings
{
    public static class Buildings
    {
        public static List<Building> CultureBuildings()
        {
            return
            [
                new Building(1, null, null, BuildingType.Culture, SpecificBuilding.GreatHall, null,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Culture, SpecificBuilding.MeadHall, null,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Culture, SpecificBuilding.GreatHall, null,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Culture, SpecificBuilding.SkaldsHall, null,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Culture, SpecificBuilding.JarlsManor, null,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Culture, SpecificBuilding.BattlefieldMemorial, null,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Culture, SpecificBuilding.SagaHall, null,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),


            ];
        }

        public static List<Building> EducationBuildings()
        {
            return
            [
                new Building(1, null, null, BuildingType.Education, SpecificBuilding.SagaHall, 3,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Education, SpecificBuilding.GreatHall, 3,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Education, SpecificBuilding.AxethrowingArena, 3,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Education, SpecificBuilding.WoodworkersWorkshop, 3,
                    null, 1.0f, 1.2f, 4.0f, 1.0f,
                    0.8f, 2.5f, 1.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Education, SpecificBuilding.StoneMason, 3,
                    null, 1.0f, 1.2f, 1.0f, 0.2f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    3.5f, 4.4f, 3.0f, 1.4f,
                    0.7f)
            ];
        }

        public static List<Building> RecreationBuildings()
        {
            return
            [
                new Building(1, null, null, BuildingType.Recreation, SpecificBuilding.Alehouse, null,
                    null, 1.0f, 1.2f, 1.0f, 1.0f,
                    0.8f, 0.5f, 2.0f, 0.7f, 1.7f,
                    0.5f, 0.4f, 0.1f, 1.4f,
                    0.7f),
                new Building(1, null, null, BuildingType.Recreation, SpecificBuilding.HermitsHut, null,
                    null, 0.4f, 0.4f, 3.0f, 1.0f,
                    2.0f, 1.0f, 1.0f, 2.0f, 3.0f,
                    0.3f, 0.2f, 0.1f, 3.0f,
                    2.4f),
                new Building(1, null, null, BuildingType.Recreation, SpecificBuilding.MeadHall, null,
                    null, 1.4f, 1.4f, 1.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f, 1.0f,
                    1.3f, 1.2f, 1.1f, 1.0f,
                    1.4f),
            ];
        }

        public static List<Building> WorshipBuildings()
        {
            return
            [
                new Building(1, null, null, BuildingType.Worship, SpecificBuilding.Temple, null,
                    null, 1.4f, 1.4f, 1.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f, 1.0f,
                    1.3f, 1.2f, 1.1f, 1.0f,
                    1.4f),
                new Building(1, null, null, BuildingType.Worship, SpecificBuilding.Shrine, null,
                    null, 1.4f, 1.4f, 1.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f, 1.0f,
                    1.3f, 1.2f, 1.1f, 1.0f,
                    1.4f),
                new Building(1, null, null, BuildingType.Worship, SpecificBuilding.StaveChurch, null,
                    null, 1.4f, 1.4f, 1.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f, 1.0f,
                    1.3f, 1.2f, 1.1f, 1.0f,
                    1.4f),
                new Building(1, null, null, BuildingType.Worship, SpecificBuilding.SeafarersChapel, null,
                    null, 1.4f, 1.4f, 1.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f, 1.0f,
                    1.3f, 1.2f, 1.1f, 1.0f,
                    1.4f),
                new Building(1, null, null, BuildingType.Worship, SpecificBuilding.SeersHut, null,
                    null, 1.4f, 1.4f, 1.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f, 1.0f,
                    1.3f, 1.2f, 1.1f, 1.0f,
                    1.4f),
            ];
        }

        public static List<Building> HealthBuildings()
        {
            return
            [
                new Building(1, null, null, BuildingType.Health, SpecificBuilding.Brewery, null,
                    null, 1.4f, 1.4f, 1.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f, 1.0f,
                    1.3f, 1.2f, 1.1f, 1.0f,
                    1.4f),
                new Building(1, null, null, BuildingType.Health, SpecificBuilding.Tavern, null,
                    null, 1.4f, 1.4f, 1.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f, 1.0f,
                    1.3f, 1.2f, 1.1f, 1.0f,
                    1.4f),
                new Building(1, null, null, BuildingType.Health, SpecificBuilding.SagaHall, null,
                    null, 1.4f, 1.4f, 1.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f, 1.0f,
                    1.3f, 1.2f, 1.1f, 1.0f,
                    1.4f),
                new Building(1, null, null, BuildingType.Health, SpecificBuilding.MeadHall, null,
                    null, 1.4f, 1.4f, 1.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f, 1.0f,
                    1.3f, 1.2f, 1.1f, 1.0f,
                    1.4f),
            ];

        }

        public static List<Building> ProductionBuildings()
        {
            return
            [
                new Building(5, null, null, BuildingType.Production, SpecificBuilding.Smithy, null, null, 1.2f, 1.3f,
                    1.0f,
                    1.0f, 1.1f, 1.0f, 1.0f, 1.0f, 1.0f, 1.2f, 1.1f, 1.1f, 1.0f, 1.3f),
                new Building(6, null, null, BuildingType.Production, SpecificBuilding.Tannery, null, null, 1.2f, 1.3f,
                    1.0f, 1.0f, 1.1f, 1.0f, 1.0f, 1.0f, 1.0f, 1.2f, 1.1f, 1.1f, 1.0f, 1.3f),
                new Building(7, null, null, BuildingType.Production, SpecificBuilding.WoodworkersWorkshop, null, null,
                    1.2f, 1.3f, 1.0f, 1.0f, 1.1f, 1.0f, 1.0f, 1.0f, 1.0f, 1.2f, 1.1f, 1.1f, 1.0f, 1.3f),
                new Building(8, null, null, BuildingType.Production, SpecificBuilding.Shipwright, null, null, 1.2f,
                    1.3f,
                    1.0f, 1.0f, 1.1f, 1.0f, 1.0f, 1.0f, 1.0f, 1.2f, 1.1f, 1.1f, 1.0f, 1.3f),
                new Building(9, null, null, BuildingType.Production, SpecificBuilding.StoneMason, null, null, 1.2f,
                    1.3f,
                    1.0f, 1.0f, 1.1f, 1.0f, 1.0f, 1.0f, 1.0f, 1.2f, 1.1f, 1.1f, 1.0f, 1.3f),
                new Building(10, null, null, BuildingType.Production, SpecificBuilding.Farmstead, null, null, 1.2f,
                    1.3f,
                    1.0f, 1.0f, 1.1f, 1.0f, 1.0f, 1.0f, 1.0f, 1.2f, 1.1f, 1.1f, 1.0f, 1.3f)
            ];
        }

        public static List<Building> OrderBuildings()
        {
            return
            [
                new Building(11, null, null, BuildingType.Order, SpecificBuilding.Longhouse, null, null, 1.3f, 1.2f,
                    1.0f,
                    1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(12, null, null, BuildingType.Order, SpecificBuilding.TradingPost, null, null, 1.3f, 1.2f,
                    1.0f,
                    1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(13, null, null, BuildingType.Order, SpecificBuilding.FishermansHut, null, null, 1.3f, 1.2f,
                    1.0f,
                    1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(14, null, null, BuildingType.Order, SpecificBuilding.HuntersLodge, null, null, 1.3f, 1.2f,
                    1.0f,
                    1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(15, null, null, BuildingType.Order, SpecificBuilding.GreatHall, null, null, 1.3f, 1.2f,
                    1.0f,
                    1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(16, null, null, BuildingType.Order, SpecificBuilding.AxethrowingArena, null, null, 1.3f,
                    1.2f,
                    1.0f, 1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(17, null, null, BuildingType.Order, SpecificBuilding.JarlsManor, null, null, 1.3f, 1.2f,
                    1.0f,
                    1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(18, null, null, BuildingType.Order, SpecificBuilding.Wharf, null, null, 1.3f, 1.2f, 1.0f,
                    1.0f,
                    1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(19, null, null, BuildingType.Order, SpecificBuilding.WarriorsBarracks, null, null, 1.3f,
                    1.2f,
                    1.0f, 1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(20, null, null, BuildingType.Order, SpecificBuilding.Meadery, null, null, 1.3f, 1.2f, 1.0f,
                    1.0f,
                    1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(21, null, null, BuildingType.Order, SpecificBuilding.VikingBurialGround, null, null, 1.3f,
                    1.2f,
                    1.0f, 1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f),
                new Building(22, null, null, BuildingType.Order, SpecificBuilding.SeafarersChapel, null, null, 1.3f,
                    1.2f,
                    1.0f, 1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.1f, 1.1f, 1.0f, 1.2f)
            ];
        }

        public static List<Building> MilitaryBuildings()
        {
            return
            [
                new Building(23, null, null, BuildingType.Military, SpecificBuilding.Smithy, null, null, 1.5f, 1.4f,
                    1.0f, 1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.2f, 1.3f, 1.0f, 1.4f),

                new Building(24, null, null, BuildingType.Military, SpecificBuilding.Watchtower, null, null, 1.5f, 1.4f,
                    1.0f,
                    1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.2f, 1.3f, 1.0f, 1.4f),

                new Building(25, null, null, BuildingType.Military, SpecificBuilding.Lookout, null, null, 1.5f, 1.4f,
                    1.0f, 1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.2f, 1.3f, 1.0f, 1.4f),

                new Building(26, null, null, BuildingType.Military, SpecificBuilding.LongshipDock, null, null, 1.5f,
                    1.4f,
                    1.0f,
                    1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.2f, 1.3f, 1.0f, 1.4f),

                new Building(27, null, null, BuildingType.Military, SpecificBuilding.BattlefieldMemorial, null, null,
                    1.5f,
                    1.4f,
                    1.0f, 1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.2f, 1.3f, 1.0f, 1.4f)

            ];
        }

        public static List<Building> TradeBuildings()
        {
            return
            [
                new Building(23, null, null, BuildingType.Trade, SpecificBuilding.TradingPost, null, null, 1.5f, 1.4f,
                    1.0f, 1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.2f, 1.3f, 1.0f, 1.4f),
            ];
        }

        public static List<Building> WealthBuildings()
        {
            return
            [
                new Building(23, null, null, BuildingType.Wealth, SpecificBuilding.Shrine, null, null, 1.5f, 1.4f,
                    1.0f, 1.0f, 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.3f, 1.2f, 1.3f, 1.0f, 1.4f),
            ];
        }


    }
}
        