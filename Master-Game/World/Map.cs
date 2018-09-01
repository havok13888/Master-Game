using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MasterGame.World
{
    public class Map
    {
        private BaseTile [,] CurrentMap;
        //private List<List<BaseTile>> MyCurrentMap;

        public void LoadMap()
        {
            MapData loadedMap = LoadJson();
            int Rows = loadedMap.rows;
            int Cols = loadedMap.cols;
            //Tiles currentTile = loadedMap.tiles[i];


            CurrentMap = new BaseTile[4,4]
            {
                { GetTile(loadedMap.tiles[0].Type), GetTile(loadedMap.tiles[1].Type), GetTile(loadedMap.tiles[2].Type), GetTile(loadedMap.tiles[3].Type) },
                { GetTile(loadedMap.tiles[4].Type), GetTile(loadedMap.tiles[5].Type), GetTile(loadedMap.tiles[6].Type), GetTile(loadedMap.tiles[7].Type) },
                { GetTile(loadedMap.tiles[8].Type), GetTile(loadedMap.tiles[9].Type), GetTile(loadedMap.tiles[10].Type), GetTile(loadedMap.tiles[11].Type) },
                { GetTile(loadedMap.tiles[12].Type), GetTile(loadedMap.tiles[13].Type), GetTile(loadedMap.tiles[14].Type), GetTile(loadedMap.tiles[15].Type) }
            };



           
        }

        public BaseTile TileAt(Point position)
        {
            //TODO: Need to do this checking in a smarter way
            if(position.X < 0 || position.Y < 0 ||
              position.X >= 4 || position.Y >= 4)
            {
                return null;
            }
            return CurrentMap[position.X, position.Y];
        }

        public void ResetTiles()
        {
            //This method should only run if the game restarts
            for(int y = 0; y < 4; y++)
            {
                for(int x = 0; x < 4; x++)
                {
                    CurrentMap[x, y].Occupied = false;
                }
            }
        }

        public MapData LoadJson()
        {
            string fileName = "Jay01.json";
            string filePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Assets\\Maps\\" + fileName;
            FileInfo f = new FileInfo(fileName);
            string fullName = f.Name;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string myJson = reader.ReadToEnd();
                MapData mapData = JsonConvert.DeserializeObject<MapData>(myJson);
                return mapData;
            }
        }

        public class MapData
        {
            //Name
            public string name { get; set; }
            //Version
            public string version { get; set; }
            //row
            public int rows { get; set; }
            //col
            public int cols { get; set; }
            //Tiles
            public Tiles [] tiles { get; set; }
            //Entities
            public Entities[] entities { get; set; }

            public int GetRows()
            {
                return rows;
            }
        }

        public class Tiles
        {
            [JsonProperty("type")]
            public int Type;

            [JsonProperty("x")]
            public int xCor;

            [JsonProperty("y")]
            public int yCor;
        }

        public class Entities
        {
            [JsonProperty("type")]
            public string Type;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("healthPoints")]
            public string HealthPoints;

            [JsonProperty("x")]
            public string xCor;

            [JsonProperty("y")]
            public string yCor;
        }

        private BaseTile GetTile(int typeNum)
        {

            if(TileType.Grass.GetHashCode() == typeNum)
            {
                return new GrassTile(1, 1);
            } 
            else if (TileType.Lava.GetHashCode() == typeNum)
            {
                return new LavaTile(1, 1);
            } 
            else if (TileType.Water.GetHashCode() == typeNum)
            {
                return new WaterTile(1, 1);
            }
            else
            {
                return null;
            }
        }
    }
}
