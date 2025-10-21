function DrawShape(shape) {
    var size = parseInt(document.getElementById("1").value);
    for (let i = size; i > 0; i--) {
        if (shape == 'square') {
        document.body.appendChild(MakeSquare());
        }
        if (shape == 'circle') {
            document.body.appendChild(MakeCircle());
        }
        if (shape == 'triangle') {
            document.body.appendChild(MakeTriangle());
        }
    }
}