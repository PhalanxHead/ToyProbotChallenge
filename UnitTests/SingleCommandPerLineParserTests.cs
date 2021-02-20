using NUnit.Framework;
using ToyRobotChallenge;
using static ToyRobotChallenge.Domain.Domain;

namespace UnitTests
{
    public class SingleCommandPerLineParserTests
    {
        [Test]
        public void ParseCommand_StdcaseMode_FailsOnUnknownCommand()
        {
            string testCmd = "TEST_COMMAND";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParseCommand_CaseInsensitiveMode_FailsOnUnknownCommand()
        {
            string testCmd = "TEST_COMMAND";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParseMoveCommand_StdcaseMode_ReturnsMoveCommandType()
        {
            string testCmd = "MOVE";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<MoveCommand>(command, $"Returned command type was not a MoveCommand");
        }

        [Test]
        public void ParseMoveCommand_StdcaseMode_FailsOnInvalidCase_AllLowercase()
        {
            string testCmd = "move";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParseMoveCommand_StdcaseMode_FailsOnInvalidCase_RandomCase()
        {
            string testCmd = "mOVe";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParseMoveCommand_CaseInsensitiveMode_ReturnsMoveCommandType()
        {
            string testCmd = "MOVE";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<MoveCommand>(command, $"Returned command type was not a MoveCommand");
        }

        [Test]
        public void ParseMoveCommand_CaseInsensitiveMode_ReturnsMoveCommandType_AllLowercase()
        {
            string testCmd = "move";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<MoveCommand>(command, $"Returned command type was not a MoveCommand");
        }

        [Test]
        public void ParseMoveCommand_CaseInsensitiveMode_ReturnsMoveCommandType_RandomCase()
        {
            string testCmd = "mOVe";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<MoveCommand>(command, $"Returned command type was not a MoveCommand");
        }

        [Test]
        public void ParseLeftCommand_StdcaseMode_ReturnsLeftCommandType()
        {
            string testCmd = "LEFT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<LeftCommand>(command, $"Returned command type was not a LeftCommand");
        }

        [Test]
        public void ParseLeftCommand_StdcaseMode_FailsOnInvalidCase_AllLowercase()
        {
            string testCmd = "left";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParseLeftCommand_StdcaseMode_FailsOnInvalidCase_RandomCase()
        {
            string testCmd = "lEfT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParseLeftCommand_CaseInsensitiveMode_ReturnsLeftCommandType()
        {
            string testCmd = "LEFT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<LeftCommand>(command, $"Returned command type was not a LeftCommand");
        }

        [Test]
        public void ParseLeftCommand_CaseInsensitiveMode_ReturnsLeftCommandType_AllLowercase()
        {
            string testCmd = "left";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<LeftCommand>(command, $"Returned command type was not a LeftCommand");
        }

        [Test]
        public void ParseLeftCommand_CaseInsensitiveMode_ReturnsLeftCommandType_RandomCase()
        {
            string testCmd = "lEFT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<LeftCommand>(command, $"Returned command type was not a LeftCommand");
        }

        [Test]
        public void ParseRightCommand_StdcaseMode_ReturnsRightCommandType()
        {
            string testCmd = "RIGHT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<RightCommand>(command, $"Returned command type was not a RightCommand");
        }

        [Test]
        public void ParseRightCommand_StdcaseMode_FailsOnInvalidCase_AllLowercase()
        {
            string testCmd = "right";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParseRightCommand_StdcaseMode_FailsOnInvalidCase_RandomCase()
        {
            string testCmd = "rIGht";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParseRightCommand_CaseInsensitiveMode_ReturnsRightCommandType()
        {
            string testCmd = "RIGHT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<RightCommand>(command, $"Returned command type was not a RightCommand");
        }

        [Test]
        public void ParseRightCommand_CaseInsensitiveMode_ReturnsRightCommandType_AllLowercase()
        {
            string testCmd = "right";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<RightCommand>(command, $"Returned command type was not a RightCommand");
        }

        [Test]
        public void ParseRightCommand_CaseInsensitiveMode_ReturnsRightCommandType_RandomCase()
        {
            string testCmd = "rIgHT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<RightCommand>(command, $"Returned command type was not a RightCommand");
        }

        [Test]
        public void ParseReportCommand_StdcaseMode_ReturnsReportCommandType()
        {
            string testCmd = "REPORT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<ReportCommand>(command, $"Returned command type was not a ReportCommand");
        }

        [Test]
        public void ParseReportCommand_StdcaseMode_FailsOnInvalidCase_AllLowercase()
        {
            string testCmd = "report";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParseReportCommand_StdcaseMode_FailsOnInvalidCase_RandomCase()
        {
            string testCmd = "rePOrT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParseReportCommand_CaseInsensitiveMode_ReturnsReportCommandType()
        {
            string testCmd = "REPORT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<ReportCommand>(command, $"Returned command type was not a ReportCommand");
        }

        [Test]
        public void ParseReportCommand_CaseInsensitiveMode_ReturnsReportCommandType_AllLowercase()
        {
            string testCmd = "report";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<ReportCommand>(command, $"Returned command type was not a ReportCommand");
        }

        [Test]
        public void ParseReportCommand_CaseInsensitiveMode_ReturnsReportCommandType_RandomCase()
        {
            string testCmd = "rEpOrT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<ReportCommand>(command, $"Returned command type was not a ReportCommand");
        }

        [Test]
        public void ParsePrintCommand_StdcaseMode_ReturnsPrintCommandType()
        {
            string testPhrase = "a TestPhrase";
            string testCmd = $"PRINT \"{testPhrase}\"";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PrintCommand>(command, $"Returned command type was not a PrintCommand");
            var printCommand = command as PrintCommand?;
            Assert.AreEqual(testPhrase, printCommand.GetValueOrDefault().OutputString, "Output string was not given by the struct.");
        }

        [Test]
        public void ParsePrintCommand_StdcaseMode_FailsOnInvalidCase_AllLowercase()
        {
            string testPhrase = "a TestPhrase";
            string testCmd = $"print \"{testPhrase}\"";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePrintCommand_StdcaseMode_FailsOnInvalidCase_RandomCase()
        {
            string testPhrase = "a TestPhrase";
            string testCmd = $"pRiNt \"{testPhrase}\"";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should have been ignored!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePrintCommand_CaseInsensitiveMode_ReturnsPrintCommandType()
        {
            string testPhrase = "August 22 is a Day!";
            string testCmd = $"PRINT \"{testPhrase}\"";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PrintCommand>(command, $"Returned command type was not a PrintCommand");
            var printCommand = command as PrintCommand?;
            Assert.AreEqual(testPhrase, printCommand.GetValueOrDefault().OutputString, "Output string was not given by the struct.");
        }

        [Test]
        public void ParsePrintCommand_CaseInsensitiveMode_ReturnsPrintCommandType_AllLowercase()
        {
            string testPhrase = "Toy Robot Challenge could go on forever!";
            string testCmd = $"print \"{testPhrase}\"";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PrintCommand>(command, $"Returned command type was not a PrintCommand");
            var printCommand = command as PrintCommand?;
            Assert.AreEqual(testPhrase, printCommand.GetValueOrDefault().OutputString, "Output string was not given by the struct.");
        }

        [Test]
        public void ParsePrintCommand_CaseInsensitiveMode_ReturnsPrintCommandType_RandomCase()
        {
            string testPhrase = "a newer TestPhrase";
            string testCmd = $"pRiNT \"{testPhrase}\"";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PrintCommand>(command, $"Returned command type was not a PrintCommand");
            var printCommand = command as PrintCommand?;
            Assert.AreEqual(testPhrase, printCommand.GetValueOrDefault().OutputString, "Output string was not given by the struct.");
        }

        [Test]
        public void ParsePrintCommand_StdcaseMode_ReturnsPrintCommandType_IgnoresStringsOutsideOfQuotes()
        {
            string testPhrase = "a TestPhrase";
            string testCmd = $"PRINT \"{testPhrase}\" Random Gunk on the End";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PrintCommand>(command, $"Returned command type was not a PrintCommand");
            var printCommand = command as PrintCommand?;
            Assert.AreEqual(testPhrase, printCommand.GetValueOrDefault().OutputString, "Output string was not given by the struct.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_ReturnsPlaceCommandType_NoSpacesBetweenArgs()
        {
            int argX = 2;
            int argY = 3;
            Direction startingDirection = Direction.EAST;

            string testCmd = $"PLACE {argX},{argY},{startingDirection}";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PlaceCommand>(command, $"Returned command type was not a PlaceCommand");
            var placeCommand = command as PlaceCommand?;
            Assert.AreEqual(argX, placeCommand.GetValueOrDefault().X, "X Values aren't equal!");
            Assert.AreEqual(argY, placeCommand.GetValueOrDefault().Y, "Y Values aren't equal!");
            Assert.AreEqual(startingDirection, placeCommand.GetValueOrDefault().FacingDirection, "Facing Directions aren't equal!");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_ReturnsPlaceCommandType_SpacesBetweenArgs()
        {
            int argX = 1;
            int argY = 1;
            Direction startingDirection = Direction.EAST;

            string testCmd = $"PLACE {argX}, {argY}, {startingDirection}";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PlaceCommand>(command, $"Returned command type was not a PlaceCommand");
            var placeCommand = command as PlaceCommand?;
            Assert.AreEqual(argX, placeCommand.GetValueOrDefault().X, "X Values aren't equal!");
            Assert.AreEqual(argY, placeCommand.GetValueOrDefault().Y, "Y Values aren't equal!");
            Assert.AreEqual(startingDirection, placeCommand.GetValueOrDefault().FacingDirection, "Facing Directions aren't equal!");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnLowercaseCommand_AllLowerCase()
        {
            int argX = 1;
            int argY = 1;
            Direction startingDirection = Direction.EAST;

            string testCmd = $"place {argX}, {argY}, {startingDirection}";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnLowercaseCommand_RandomCase()
        {
            int argX = 1;
            int argY = 1;
            Direction startingDirection = Direction.EAST;

            string testCmd = $"pLaCe {argX}, {argY}, {startingDirection}";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnLowercaseArgument_AllLowerCase()
        {
            int argX = 1;
            int argY = 1;
            Direction startingDirection = Direction.EAST;

            string testCmd = $"PLACE {argX}, {argY}, {startingDirection.ToString().ToLower()}";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnLowercaseArgument_RandomCase()
        {
            int argX = 1;
            int argY = 1;

            string testCmd = $"PLACE {argX}, {argY}, eAsT";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnMissingYArgument()
        {
            int argX = 6;

            string testCmd = $"PLACE {argX}, EAST";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnEmptyDirectionArgument()
        {
            int argX = 6;
            int argY = 9;

            string testCmd = $"PLACE {argX}, {argY} ,";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnGarbageDirectionArgument()
        {
            int argX = 6;
            int argY = 9;

            string testCmd = $"PLACE {argX}, {argY} , Blargh";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnMisorderedArguments()
        {
            int argX = 6;
            int argY = 9;

            string testCmd = $"PLACE {argX} , Blargh, {argY}";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_CaseInvariantMode_ReturnsPlaceCommandType_AllLowerCaseCommand()
        {
            int argX = 6;
            int argY = 2;
            Direction startingDirection = Direction.WEST;

            string testCmd = $"place {argX}, {argY}, {startingDirection}";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PlaceCommand>(command, $"Returned command type was not a PlaceCommand");
            var placeCommand = command as PlaceCommand?;
            Assert.AreEqual(argX, placeCommand.GetValueOrDefault().X, "X Values aren't equal!");
            Assert.AreEqual(argY, placeCommand.GetValueOrDefault().Y, "Y Values aren't equal!");
            Assert.AreEqual(startingDirection, placeCommand.GetValueOrDefault().FacingDirection, "Facing Directions aren't equal!");
        }

        [Test]
        public void ParsePlaceCommand_CaseInvariantMode_ReturnsPlaceCommandType_RandomCommandCase()
        {
            int argX = 9;
            int argY = 15;
            Direction startingDirection = Direction.NORTH;

            string testCmd = $"pLAce {argX}, {argY}, {startingDirection}";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PlaceCommand>(command, $"Returned command type was not a PlaceCommand");
            var placeCommand = command as PlaceCommand?;
            Assert.AreEqual(argX, placeCommand.GetValueOrDefault().X, "X Values aren't equal!");
            Assert.AreEqual(argY, placeCommand.GetValueOrDefault().Y, "Y Values aren't equal!");
            Assert.AreEqual(startingDirection, placeCommand.GetValueOrDefault().FacingDirection, "Facing Directions aren't equal!");
        }

        [Test]
        public void ParsePlaceCommand_CaseInvariantMode_ReturnsPlaceCommandType_AllLowerCaseArgument()
        {
            int argX = 200;
            int argY = -30;
            Direction startingDirection = Direction.WEST;

            string testCmd = $"PLACE {argX}, {argY}, {startingDirection.ToString().ToLower()}";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PlaceCommand>(command, $"Returned command type was not a PlaceCommand");
            var placeCommand = command as PlaceCommand?;
            Assert.AreEqual(argX, placeCommand.GetValueOrDefault().X, "X Values aren't equal!");
            Assert.AreEqual(argY, placeCommand.GetValueOrDefault().Y, "Y Values aren't equal!");
            Assert.AreEqual(startingDirection, placeCommand.GetValueOrDefault().FacingDirection, "Facing Directions aren't equal!");
        }

        [Test]
        public void ParsePlaceCommand_CaseInvariantMode_ReturnsPlaceCommandType_RandomArgumentCase()
        {
            int argX = 420;
            int argY = 96;
            Direction startingDirection = Direction.NORTH;

            string testCmd = $"PLACE {argX}, {argY}, nORth";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: false);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PlaceCommand>(command, $"Returned command type was not a PlaceCommand");
            var placeCommand = command as PlaceCommand?;
            Assert.AreEqual(argX, placeCommand.GetValueOrDefault().X, "X Values aren't equal!");
            Assert.AreEqual(argY, placeCommand.GetValueOrDefault().Y, "Y Values aren't equal!");
            Assert.AreEqual(startingDirection, placeCommand.GetValueOrDefault().FacingDirection, "Facing Directions aren't equal!");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnNonIntegerPositionArgs()
        {
            int argX = 6;

            string testCmd = $"PLACE {argX}, 9.9, EAST";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_ReturnsPlaceCommandType_IgnoresAfterArguments()
        {
            int argX = 1;
            int argY = 1;
            Direction startingDirection = Direction.EAST;

            string testCmd = $"PLACE {argX},{argY},{startingDirection} GarbageEndingData";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PlaceCommand>(command, $"Returned command type was not a PlaceCommand");
            var placeCommand = command as PlaceCommand?;
            Assert.AreEqual(argX, placeCommand.GetValueOrDefault().X, "X Values aren't equal!");
            Assert.AreEqual(argY, placeCommand.GetValueOrDefault().Y, "Y Values aren't equal!");
            Assert.AreEqual(startingDirection, placeCommand.GetValueOrDefault().FacingDirection, "Facing Directions aren't equal!");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_ReturnsPlaceCommandType_IgnoresMultipleAfterArguments()
        {
            int argX = 1;
            int argY = 1;
            Direction startingDirection = Direction.EAST;

            string testCmd = $"PLACE {argX},{argY},{startingDirection} Garbage,Ending Data";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PlaceCommand>(command, $"Returned command type was not a PlaceCommand");
            var placeCommand = command as PlaceCommand?;
            Assert.AreEqual(argX, placeCommand.GetValueOrDefault().X, "X Values aren't equal!");
            Assert.AreEqual(argY, placeCommand.GetValueOrDefault().Y, "Y Values aren't equal!");
            Assert.AreEqual(startingDirection, placeCommand.GetValueOrDefault().FacingDirection, "Facing Directions aren't equal!");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_ReturnsPlaceCommandType_IgnoresMultipleAfterArguments_WithSpaces()
        {
            int argX = 1;
            int argY = 1;
            Direction startingDirection = Direction.EAST;

            string testCmd = $"PLACE {argX}, {argY}, {startingDirection} Garbage,Ending Data";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.True(cmdParsedSuccess, $"Command \"{testCmd}\" could not be parsed.");
            Assert.IsInstanceOf<PlaceCommand>(command, $"Returned command type was not a PlaceCommand");
            var placeCommand = command as PlaceCommand?;
            Assert.AreEqual(argX, placeCommand.GetValueOrDefault().X, "X Values aren't equal!");
            Assert.AreEqual(argY, placeCommand.GetValueOrDefault().Y, "Y Values aren't equal!");
            Assert.AreEqual(startingDirection, placeCommand.GetValueOrDefault().FacingDirection, "Facing Directions aren't equal!");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnMissingArgument_AddedEndingData_NoSpaces()
        {
            int argX = 1;
            int argY = 1;

            string testCmd = $"PLACE {argX},{argY},Garbage, Ending Data";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnSpaceAsArgumentDelimiter()
        {
            int argX = 1;
            int argY = 1;

            string testCmd = $"PLACE {argX} {argY} EAST";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }

        [Test]
        public void ParsePlaceCommand_StdcaseMode_FailsOnMissingArgument_AddedEndingData_Spaces()
        {
            int argX = 1;
            int argY = 1;

            string testCmd = $"PLACE {argX}, {argY}, Garbage, Ending Data";
            var cmdParser = new SingleCommandPerLineParser(isUsingCaseSensitivity: true);

            var cmdParsedSuccess = cmdParser.TryParseCommand(testCmd, out IBaseCommand command);

            Assert.False(cmdParsedSuccess, $"Command \"{testCmd}\" was parsed when it should not have been!");
            Assert.Null(command, "Returned Command type was not null when parsing failed.");
        }
    }
}