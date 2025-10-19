function MakeSquare(size) {
    const square = document.createElement("div");
    const style = square.style;
    style.width = 40 * Math.pow(1.5, size) + "px";
    style.height = 40 * Math.pow(1.5, size) + "px";
    style.backgroundColor = "red";
    style.position = "fixed";
    style.border = "1px solid black";
    style.marginLeft = Math.floor(Math.random()*80) + "vw";
    style.marginTop = Math.floor(Math.random()*80) + "vh";
    square.addEventListener("click", () => {
        if (style.backgroundColor != "yellow") style.backgroundColor = "yellow";
        else square.remove();
        }
    );
    return square;
}

function MakeCircle(size) {
    const circle = document.createElement("div");
    const style = circle.style;
    style.width = 40 * size + "px";
    style.height = 40 * size + "px";
    style.backgroundColor = "green";
    style.position = "fixed";
    style.border = "1px solid black";
    style.borderRadius = 20 * size + "px";
    style.marginLeft = Math.floor(Math.random()*80) + "vw";
    style.marginTop = Math.floor(Math.random()*80) + "vh";
    circle.addEventListener("click", () => {
        if (style.backgroundColor != "yellow") style.backgroundColor = "yellow";
        else circle.remove();
        }
    );
    return circle;
}

function MakeTriangle(size) {
    const triangle = document.createElement("div");
    const style = triangle.style;
    style.width = "0";
    style.height = "0";
    style.position = "fixed";
    style.borderLeft = "40px solid transparent";
    style.borderRight = "40px solid transparent";
    style.borderBottom = "40px solid blue";
    style.marginLeft = Math.floor(Math.random()*80) + "vw";
    style.marginTop = Math.floor(Math.random()*80) + "vh";
    triangle.addEventListener("click", () => {
        if (style.borderBottom != "40px solid yellow") style.borderBottom = "40px solid yellow";
        else triangle.remove();
        }
    );
    return triangle;
}