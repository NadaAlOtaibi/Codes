
let canvas = document.querySelector("#canvas");
let context = canvas.getContext("2d");
let tileCount = 20
let tileSize = canvas.width / tileCount - 2;
let headX = 15;
let headY = 15;
let dx = 0;
let dy = 0;
let appleX = 10;
let appley= 10;
var grid = 16;
let score =0;
class SnakePart{
    constructor(x,y){
        this.x = x;
        this.y =y;
    
    }
}
let tailLength = 2 ;
let snakePart = [];

function drawGame(){
    clearScreen()
    changePosition();
    drawSnake();
    setTimeout(drawGame,1000/8)
    drawApple();
    HitApple();
    printScore();
    


}
  
 function printScore(){
    context.fillStyle = "white";
    context.font = "24px Helvetica";
    context.textAlign = "left";
    context.textBaseline = "top";
    context.fillText("Score: " + score, tileCount,tileCount);
}
 function HitApple(){
    if (headX === appleX && headY === appley) {
        appleX=Math.floor(Math.random() * tileCount);
        appley= Math.floor(Math.random() * tileCount);
        tailLength++;
        score ++;
                     
    }
 }

function drawApple(){
    context.fillStyle='red';
    context.fillRect(appleX* tileCount,appley* tileCount,tileSize,tileSize);

}
function clearScreen() {
    context.fillStyle='black';
    context.fillRect(0,0,canvas.width, canvas.height); 
}
function drawSnake(){
    context.fillStyle = 'green'
    for(let i=0 ; i < snakePart.length;i++)  {// cmd d select
        const parts = snakePart[i];
        context.fillRect(parts.x * tileCount, parts.y* tileCount , tileSize,tileSize);
    }
    snakePart.push(new SnakePart(headX,headY));
    if(snakePart.length > tailLength){
        snakePart.shift();
    }
    context.fillStyle='orange';
    context.fillRect(headX * tileCount, headY* tileCount, tileSize, tileSize);
}
function changePosition(){
    headX = headX + dx;
    headY = headY + dy;
}
document.addEventListener("keydown", keyDown);
function keyDown(event){
    if(event.keyCode == 37){ // left
        if(dx == 1)
            return
        dx = -1;
        dy = 0;
    } else if ( event.keyCode == 38 ) { // up
        if(dy == 1)
            return
        dx = 0;
        dy = -1;
    }
    else if ( event.keyCode == 39 ) { // right
        if(dx == -1)
            return
        dx = 1;
        dy = 0;
    }
    else if ( event.keyCode == 40 ) { // down
        if(dy == -1)
            return
        dx = 0
        dy = 1
    }
}
drawGame()
