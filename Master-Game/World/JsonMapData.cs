namespace MasterGame.World
{
    public class JsonTiles
    {
        public int type;
        public int xCoord;
        public int yCoord;
    }

    public class JsonEntities
    {
        public string type;
        public string name;
        public string healthPoints;
        public string xCoord;
        public string yCoord;
    }

    public class JsonMapData
    {
        public string name { get; set; }
        public string version { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }
        public JsonTiles[] tiles { get; set; }
        public JsonEntities[] entities { get; set; }
    }
}
