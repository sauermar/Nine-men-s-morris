# Nine men's morris
 Finishing project for summer programing class at Charle's University.
 <br>
 <p align="center">
 <img src="https://github.com/sauermar/Nine-men-s-morris/blob/master/screens/logo.png" style="hight:auto; width:50%; display:block; margin-left:auto; margin-right:auto;">
 </p>
 
Mill is an implementation of the board game *"Nine Men's Morris"*. Nine Men's Morris, being probably 2000-3000 years old, appears to be one of the oldest board games, much older than chess.

This implementation offers the **classic game**, where the board consists of a grid with *twenty-four points*. Each player has *nine pieces*, or "men", coloured **black** and **white**.
<p align="center">
 <img src="https://github.com/sauermar/Nine-men-s-morris/blob/master/screens/blackwon.png" hight="auto" width="500px">
</p>

#### Rules
Players try to form **mills**, three of their own men lined horizontally or vertically, allowing a player to remove an opponent's man from the game. A player wins by reducing the opponent to two pieces.

**The game proceeds in three phases according to rules:**
1.	Placing men on vacant points
2.	Moving men to adjacent points
3.	Moving men to any vacant point when the player has been reduced to three men
<p align="center">
 <img src="https://github.com/sauermar/Nine-men-s-morris/blob/master/screens/settings.png" hight="auto" width="500px">
</p>

Furthermore, player can choose whether he wants to play with another player or take turns with artificial intelligence. The AI's can be also tested by letting them play against each other.

Project is written as a *windows form application in C#* with **Minimax** and **Alpha-beta pruning** algorithms with simple heuristics as AI players.
