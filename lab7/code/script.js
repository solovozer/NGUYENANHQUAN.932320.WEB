function DrawShape(shape) {
    var size = parseInt(document.getElementById("1").value);
    for (let i = size; i > 0; i--) {
        if (shape == 'square') {
        document.body.appendChild(MakeSquare(i));
        }
        if (shape == 'circle') {
            document.body.appendChild(MakeCircle(i));
        }
        if (shape == 'triangle') {
            document.body.appendChild(MakeTriangle(i));
        }
    }
}