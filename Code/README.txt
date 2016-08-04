Directory Structure

The solution is split in 5 parts

1. Guida - Back End
2. Guida.Droid - Andorid Front End
3. Guida.iOS - iOS Front End
4. Guida.WinPhone- Windows Front End (not implemented)
5. UnitTests - Unit tests of the system

1. Guida
Controller.cs (A.K.A. Doctor Service) must be called to have access to the back end.
Database.cs contain tables of the entities of the system.
Data.cs contain all the information that is going to be added to the database.
RuleEngine.cs contain the inference engine of the system.
Session.cs contain current state of the program. Example: Current user logged in or current selected patient
SQLite.cs is a file that contain all required information for Database.cs create tables of the entities.

2. Guida.Droid
Resources/Drawable-hdpi contain all the images used by the Android device
Resources/layout contain all the pages of the App
MainActivity.cs is the main file

3. Guida.iOS
Resources contain a list of images files used by the iOS device
Main.storyboard contain all the pages used by the iOS device
Main.cs is the Main file

4. Guida.Winphone
Not implemented

5.UnitTests
Contain the list of use case test
