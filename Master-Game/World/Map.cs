﻿using Newtonsoft.Json;
using System.Drawing;
using System.IO;

namespace MasterGame.World
{
    public class Map
    {
        private BaseTile [,] CurrentMap;

        public void LoadMap()
        {
            MapData loadedMap = LoadJson();
            int rows = loadedMap.rows;
            int cols = loadedMap.cols;
            CurrentMap = new BaseTile[4,4]
            {
                { TileFactory.CreateTile((TileType) loadedMap.tiles[0].type), TileFactory.CreateTile((TileType) loadedMap.tiles[1].type), TileFactory.CreateTile((TileType) loadedMap.tiles[2].type), TileFactory.CreateTile((TileType) loadedMap.tiles[3].type) },
                { TileFactory.CreateTile((TileType) loadedMap.tiles[4].type), TileFactory.CreateTile((TileType) loadedMap.tiles[5].type), TileFactory.CreateTile((TileType) loadedMap.tiles[6].type), TileFactory.CreateTile((TileType) loadedMap.tiles[7].type) },
                { TileFactory.CreateTile((TileType) loadedMap.tiles[8].type), TileFactory.CreateTile((TileType) loadedMap.tiles[9].type), TileFactory.CreateTile((TileType) loadedMap.tiles[10].type), TileFactory.CreateTile((TileType) loadedMap.tiles[11].type) },
                { TileFactory.CreateTile((TileType) loadedMap.tiles[12].type), TileFactory.CreateTile((TileType) loadedMap.tiles[13].type), TileFactory.CreateTile((TileType) loadedMap.tiles[14].type), TileFactory.CreateTile((TileType) loadedMap.tiles[15].type) }
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
            return CurrentMap[position.Y, position.X]; //X - Horizontal , Y- vertical
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
            string filePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "/Assets/Maps/" + fileName;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string jsonStringData = reader.ReadToEnd();

                if (!jsonStringData.Equals(""))
                {
                    return JsonConvert.DeserializeObject<MapData>(jsonStringData);
                }
                else
                {
                    return null; //String data value cannot be empty.
                }                
            }
        }

        public class MapData
        {
            public string name { get; set; }
            public string version { get; set; }
            public int rows { get; set; }
            public int cols { get; set; }
            public Tiles [] tiles { get; set; }
            public Entities[] entities { get; set; }
        }

        public class Tiles
        {
            public int type;
            public int xCoord;
            public int yCoord;
        }

        public class Entities
        {
            public string type;
            public string name;
            public string healthPoints;
            public string xCoord;
            public string yCoord;
        }
    }
}
