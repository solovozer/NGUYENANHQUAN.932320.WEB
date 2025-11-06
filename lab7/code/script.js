function DrawShape(shape) {
    var size = parseInt(document.getElementById("1").value);
    for (let i = size; i > 0; i--) {
        let temp;
        if (shape == 'square') {
            temp = MakeSquare();
        }
        if (shape == 'circle') {
            temp = MakeCircle();
        }
        if (shape == 'triangle') {
            temp = MakeTriangle();
        }
        temp.style.opacity = "0.7";
        document.body.append(temp);
    }
}

