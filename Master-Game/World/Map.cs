using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.IO;

namespace MasterGame.World
{
    public class Map
    {
        private const string MapsDir = "/Assets/Maps/";
        private List<BaseTile> CurrentMap = new List<BaseTile>();
        private int rows = -1;
        private int cols = -1;

        public void LoadMap()
        {
            //TODO; Build map selector
            BuildMap(LoadMapFromFile("Jay01.json"));
        }

        public BaseTile TileAt(Point position)
        {
            return GetTileAtLocation(position.X, position.Y);
        }

        public void ResetTiles()
        {
            //This method should only run if the game restarts
            foreach (BaseTile tile in CurrentMap)
            {
                tile.Occupied = false;
            }
        }

        public JsonMapData LoadMapFromFile(string fileName)
        {            
            if(fileName.Length == 0)
            {
                Console.WriteLine("No map file specified, aborting!");
                return null;
            }

            string filePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + 
                                MapsDir + fileName;

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Map file not found at ${filePath}");
                return null;
            }
            
            using (StreamReader reader = new StreamReader(filePath))
            {
                string jsonStringData = reader.ReadToEnd();

                if (jsonStringData.Equals(""))
                {
                    Console.WriteLine("Failed to load map data");
                    return null;
                }
                else
                {
                    return JsonConvert.DeserializeObject<JsonMapData>(jsonStringData);
                }                
            }
        }

        private void BuildMap(JsonMapData loadedMapData)
        {
            foreach(JsonTiles tile in loadedMapData.tiles)
            {
                BaseTile newTile = TileFactory.CreateTile((TileType)tile.type);
                if(newTile != null)
                {
                    newTile.X = tile.xCoord;
                    newTile.Y = tile.yCoord;
                    CurrentMap.Add(newTile);
                }
            }

            CurrentMap.Sort((leftTile, rightTile) => 
                            leftTile.X <= rightTile.X &&
                            leftTile.Y <= rightTile.Y ? 
                            1 : -1);

            rows = loadedMapData.rows;
            cols = loadedMapData.cols;
        }

        private BaseTile GetTileAtLocation(int xCor, int yCor)
        {
            BaseTile tile = CurrentMap.Find((BaseTile obj) => 
                                           obj.X == xCor && 
                                           obj.Y == yCor);  
            if(tile == null)
            {
                return TileFactory.CreateTile(TileType.Void);
            }
            return tile;
        }
    }
}
