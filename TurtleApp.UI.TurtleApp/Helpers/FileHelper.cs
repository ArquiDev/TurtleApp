using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurtleApp.Crossccutting.Core.Exceptions;
using TurtleApp.Crossccutting.Core.Models.Board;
using TurtleApp.Microservices.BoardServices.Controllers;
using TurtleApp.Microservices.BoardServices.Responses.BoardValidation;
using TurtleApp.Microservices.ImportServices.Controllers;
using TurtleApp.Microservices.ImportServices.Responses.FileImport;

namespace TurtleApp.UI.TurtleApp.Helpers
{
    static class FileHelper
    {
        public const string SETTING_FILE_TYPE = "setting";
        public const string ACTIONS_FILE_TYPE = "actions";
        public static Tableboard ImportSetting(string path)
        {
            var serviceImport = new FileImportController();
            var fileResult = serviceImport.ImportSetting(path);
            if (fileResult.Success)
            {
                var serviceValidation = new BoardValidationController();
                var validationResult = serviceValidation.ValidateBoard(fileResult.Result);
                if (validationResult.Success)
                {
                    return fileResult.Result;
                }
                else
                {
                    var boardRageText = $" ({validationResult.MinWidth},{validationResult.MaxWidth})";
                    var maxX = Math.Max(0, Math.Min(validationResult.MaxWidth, fileResult.Result.Size.Width - 1));
                    var maxY = Math.Max(0, Math.Min(validationResult.MaxWidth, fileResult.Result.Size.Height - 1));
                    var maxPointBoardText = $"({maxX},{maxY})";
                    var listMessage = validationResult.Result
                        .Select(r => GetErrorBoardMessages(r, boardRageText, maxPointBoardText))
                        .ToList();
                    throw new ListMessageException(listMessage);
                }
            }
            else
            {
                throw new MessageException(GetErrorFileMessages(fileResult.ErrorType, SETTING_FILE_TYPE));
            }
        }
        public static List<TurtleActionType> ImportActions(string path)
        {
            var serviceImport = new FileImportController();
            var fileResult = serviceImport.ImportActions(path);
            if (fileResult.Success)
            {
                    return fileResult.Result;
            }
            else
            {
                throw new MessageException(GetErrorFileMessages(fileResult.ErrorType, ACTIONS_FILE_TYPE));
            }
        }
        private static string GetErrorFileMessages(ImportFileResultErrorType errorType, string fileType) 
            => errorType switch
            {
                ImportFileResultErrorType.FileNoExist => $"The {fileType} file don't exist.",
                ImportFileResultErrorType.NotSupportedExtension => $"The extension of the {fileType} file is not supported.",
                ImportFileResultErrorType.IncorrectJsonFormat => $"The {fileType} file have incorrect format.",
                _ => "Unexpected error."
            };
        private static string GetErrorBoardMessages(BoardValidationErrorType errorType, string boardRageText, string maxPointBoardText)
            => errorType switch
            {
                BoardValidationErrorType.WrongWidth => $"The width of the board is out of the rage{boardRageText}.",
                BoardValidationErrorType.WrongHeight => $"The height of the board is out of the rage{boardRageText}.",
                BoardValidationErrorType.WrongExit => $"The exit is out of the board from (0,0) to {maxPointBoardText}.",
                BoardValidationErrorType.WrongTurtlePosition => $"The turtle position is out of the board from (0,0) to {maxPointBoardText}.",
                _ => "Unknown."
            };
    }
}
