using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace MasterGame.World
{
    public class Map
    {
        private const string MapsDir = "/Assets/Maps/";
        private static string MainFilePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private List<BaseTile> CurrentMap = new List<BaseTile>();
        private int rows = -1;
        private int cols = -1;

        public void LoadMap()
        {
            //TODO; Build map selector
            SelectAndBuildMap();
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

            string filePath = MainFilePath + MapsDir + fileName;

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

        public void SelectAndBuildMap()
        {
            string userSelectedMap = SelectMap();

            BuildMap(LoadMapFromFile(userSelectedMap));
        }

        public void BuildMapTransition(String mapName)
        {
            CurrentMap.Clear();
            BuildMap(LoadMapFromFile(mapName));
        }

        private string SelectMap()
        {
            string selectedMap = "";
            Console.Clear();
            Console.WriteLine("Let's go!");
            Console.WriteLine("");
            Console.WriteLine("Select a map number!");
            string[] mapFiles = Directory.GetFiles(MainFilePath + MapsDir, "*.json").Select(Path.GetFileName).ToArray();
            int numberOfMaps = mapFiles.Length;
            for (int i = 0; i < numberOfMaps; i++)
            {
                Console.WriteLine(i + " - " + mapFiles[i]);
            }

            int userInputMap = -1;
            while (userInputMap < 0 | userInputMap >= numberOfMaps)
            {
                string userInput = Console.ReadKey(true).KeyChar.ToString();
                bool isNumber = int.TryParse(userInput, out userInputMap);
                if (isNumber & (userInputMap >= 0 & userInputMap < numberOfMaps))
                {
                    selectedMap = mapFiles[userInputMap];
                    Console.WriteLine("");
                    Console.WriteLine("You picked " + userInputMap.ToString());
                    Console.WriteLine(selectedMap + " loaded!");
                    Console.WriteLine("");
                    Console.WriteLine("Loading...");
                    Thread.Sleep(4000);
                    Console.Clear();
                }
                else
                {
                    userInputMap = -1;
                    Console.WriteLine("");
                    Console.WriteLine("Hmm... I do not understand your input. That is not an option. Please try again!");
                }
            }
            return selectedMap;
        }

        public int[] GetMapDim()
        {
            if(rows != -1 & cols != -1)
            {
                return new int[] { rows, cols };
            } else
            {
                Console.WriteLine("The rows or cols was not set when map was loaded. Exiting!");
                return null;
            }
        }
    }
}
