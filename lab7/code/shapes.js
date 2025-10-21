const baseMult = 300;
const spawnSize = 80;

function MakeSquare() {
    const size  = Math.max(Math.floor(Math.random()*baseMult), 60);
    const square = document.createElement("div");
    const style = square.style;
    style.width = size + "px";
    style.height = size + "px";
    style.backgroundColor = "red";
    style.position = "fixed";
    style.border = "1px solid black";
    style.marginLeft = Math.floor(Math.random()*spawnSize) + "vw";
    style.marginTop = Math.floor(Math.random()*spawnSize) + "vh";
    square.addEventListener("click", () => {
        if (style.backgroundColor != "yellow") style.backgroundColor = "yellow";
        else square.remove();
        }
    );
    return square;
}

function MakeCircle() {
    const size  = Math.max(Math.floor(Math.random()*baseMult), 60);
    const circle = document.createElement("div");
    const style = circle.style;
    style.width = size + "px";
    style.height = size + "px";
    style.borderRadius = size/2 + "px";
    style.backgroundColor = "green";
    style.position = "fixed";
    style.border = "1px solid black";
    style.marginLeft = Math.floor(Math.random()*spawnSize) + "vw";
    style.marginTop = Math.floor(Math.random()*spawnSize) + "vh";
    circle.addEventListener("click", () => {
        if (style.backgroundColor != "yellow") style.backgroundColor = "yellow";
        else circle.remove();
        }
    );
    return circle;
}

function MakeTriangle() {
    const size  = Math.max(Math.floor(Math.random()*baseMult), 60);
    const triangle = document.createElement("div");
    const style = triangle.style;
    style.width = size*2 + "px";
    style.height = size + "px";
    style.clipPath = "polygon(50% 0%, 0% 100%, 100% 100%)";
    style.backgroundColor = "blue";
    style.position = "fixed";
    style.marginLeft = Math.floor(Math.random()*spawnSize) + "vw";
    style.marginTop = Math.floor(Math.random()*spawnSize) + "vh";
    triangle.addEventListener("click", () => {
        if (style.backgroundColor!= "yellow") style.backgroundColor = "yellow";
        else triangle.remove();
        }
    );
    return triangle;
}