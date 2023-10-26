using System.ComponentModel;

namespace SinusBotAPI;

public enum ErrorCode
{
    [Description("An unknown error occured")]
    UnknownError = -1000,
    
    [Description("Received unexpected data from the server")]
    UnexpectedDataReceived = -1100,
    
    [Description("No SinusBot instance was found under this url")]
    BotNotFound = -2000,
    
    [Description("The server had an error")]
    ServerError = -3000,
    
    [Description("You have no permission for this action")]
    NoPermission = -4000,
    
    [Description("You need to be logged in for this action")]
    NotAuthenticated = -4100,
    
    [Description("You need to be logged in for this action")]
    WrongUserNameOrPassword = -4200,
    
    [Description("The received data is wrong")]
    BadRequest = -4300,
    
    [Description("The performed action was not successful")]
    ActionNotSuccessful = -4400
}