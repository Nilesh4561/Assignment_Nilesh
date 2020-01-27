# Assignment_Nilesh
Snake2d Game

This game is boundry limited game where in game a snake pop up to eat the food.
I have used sprite to create a outer boundry layer and sprite mask for inner layer which masks the area in which i can play.
Then created a snake body which is a 2d cube and food also with 2d cube.

codes which is handling overall funtionality are GameHandler, SpawnFood and GameManager.

GameHandler:
this script handles the overall movement of the snake with respective to the keyboard and all spawing the snake body inside an empty
gameobject.
it is somewhat responsible for destroying the food just after snake eats it.

SpawnFood:
this script is used to instantiate the foodprefab randomly inside the boundry and also instantiate randomly the different type
of food.

GameManager:
it is responsible for the UI if the game is over.

Then I have Score handling scripts which controls the score. And also display the highest score to beat.
Score script, ScoreWindows Script, HighScore Script, streak Script.

Then there is also a script which handles the UI buttons funtionality.
GameOver Script.
