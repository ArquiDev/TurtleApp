using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using TurtleApp.Crossccutting.Core.Models.Board;
using TurtleApp.Microservices.ImportServices.Models;
using TurtleApp.Microservices.ImportServices.Responses.FileImport;

namespace TurtleApp.Microservices.ImportServices.Controllers
{
    public class FileImportController
    {
        private const string JSON = ".json";
        private const string XML = ".xml";
        private const int MAX_LENGHT_CORRECT_FILE_JSON = 12000000;
        private static readonly string[] FILE_SETTING_EXTENSIONS = { JSON, XML };
        private static readonly string[] NORTH_SYNONYM = { "N", "NORTH", "UP", "U" };
        private static readonly string[] EAST_SYNONYM = { "E", "EAST", "RIGHT", "R" };
        private static readonly string[] SOUTH_SYNONYM = { "S", "SOUTH", "DOWN", "D" };
        private static readonly string[] WEST_SYNONYM = { "W", "WEST", "LEFT", "L" };
        private static readonly string[] MOVE_SYNONYM = { "M", "MOVE", "ADVANCE", "GO" };
        private static readonly string[] ROTATE_SYNONYM = { "R", "ROTATE", "TURN"};
        public ImportBoardFileResult ImportSetting(string path)
        {
            Tableboard tableboard;
            var result = new ImportBoardFileResult();
            try
            {
                var file = new FileInfo(path);
                if (!file.Exists)
                {
                    result.ErrorType = ImportFileResultErrorType.FileNoExist;
                }
                else if (!string.IsNullOrEmpty(file.Extension) && !FILE_SETTING_EXTENSIONS.Contains(file.Extension.ToLower()))
                {
                    result.ErrorType = ImportFileResultErrorType.NotSupportedExtension;
                }
                else
                {
                    switch (file.Extension.ToLower())
                    {
                        case JSON:
                            if (file.Length < MAX_LENGHT_CORRECT_FILE_JSON && ImportSettingJson(File.ReadAllText(path), out tableboard))
                                result.Result = tableboard;
                            else
                                result.ErrorType = ImportFileResultErrorType.IncorrectJsonFormat;
                            break;
                        default:
                            if (file.Length < MAX_LENGHT_CORRECT_FILE_JSON && ImportSettingJson(File.ReadAllText(path), out tableboard))
                                result.Result = tableboard;
                            else
                                result.ErrorType = ImportFileResultErrorType.NotSupportedExtension;
                            break;
                    }
                }
            }
            catch
            {
                result.ErrorType = ImportFileResultErrorType.Unknown;
            }
            return result;
        }
        public ImportActionFileResult ImportActions(string path)
        {
            List<TurtleActionType> actions;
            var result = new ImportActionFileResult();
            try
            {
                var file = new FileInfo(path);
                if (!file.Exists)
                {
                    result.ErrorType = ImportFileResultErrorType.FileNoExist;
                }
                else
                {
                    switch (file.Extension.ToLower())
                    {
                        case JSON:
                            if (ImportActionsJson(File.ReadAllText(path), out actions))
                                result.Result = actions;
                            else
                                result.ErrorType = ImportFileResultErrorType.IncorrectJsonFormat;
                            break;
                        default:
                            if (ImportActionsJson(File.ReadAllText(path), out actions))
                                result.Result = actions;
                            else
                                result.ErrorType = ImportFileResultErrorType.NotSupportedExtension;
                            break;
                    }
                }
            }
            catch
            {
                result.ErrorType = ImportFileResultErrorType.Unknown;
            }
            return result;
        }
        private bool ImportSettingJson(string fileText,out Tableboard tableboard)
        {
            tableboard = null;
            TurtleDirectionType turtleDirection;
            TurtleTableboardFile fileBoard;
            try
            {
                fileBoard = JsonConvert.DeserializeObject<TurtleTableboardFile>(fileText);
                turtleDirection = MapTurtleDirectionType(fileBoard.TurtleDirection);
            }
            catch
            {
                return false;
            }
            tableboard = new Tableboard
            {
                Size = fileBoard.Size,
                Exit = fileBoard.Exit,
                Mines = fileBoard.Mines?
                    .Where(m => m.X >= 0 && 
                                m.Y >= 0 &&
                                m.X < fileBoard.Size.Width &&
                                m.Y < fileBoard.Size.Height &&
                                m != fileBoard.Exit &&
                                m != fileBoard.TurtlePosition)
                    .ToHashSet(),
                Turtle = new Turtle
                {
                    Position = fileBoard.TurtlePosition,
                    Direction = turtleDirection
                }
            };
            return true;
        }
        private bool ImportActionsJson(string fileText, out List<TurtleActionType> actions)
        {
            actions = null;
            string[] actionsText;
            try
            {
                actionsText = JsonConvert.DeserializeObject<string[]>(fileText);
            }
            catch
            {
                return false;
            }
            actions = actionsText.Select(a => MapAction(a)).ToList();
            return true;
        }
        private TurtleDirectionType MapTurtleDirectionType(string turtleDirection)
        {
            var result = TurtleDirectionType.North;
            if (!string.IsNullOrWhiteSpace(turtleDirection))
            {
                if (NORTH_SYNONYM.Contains(turtleDirection))
                    result = TurtleDirectionType.North;
                else if (EAST_SYNONYM.Contains(turtleDirection))
                    result = TurtleDirectionType.East;
                else if (SOUTH_SYNONYM.Contains(turtleDirection))
                    result = TurtleDirectionType.South;
                else if (WEST_SYNONYM.Contains(turtleDirection))
                    result = TurtleDirectionType.West;
                else
                    throw new Exception();
            }
            return result;
        }
        private TurtleActionType MapAction(string action)
        {
            var result = TurtleActionType.UNKNOWN;
            if (!string.IsNullOrWhiteSpace(action))
            {
                if (MOVE_SYNONYM.Contains(action))
                    result = TurtleActionType.Move;
                else if (ROTATE_SYNONYM.Contains(action))
                    result = TurtleActionType.Rotate;
            }
            return result;
        }

    }
}
