const screen = document.getElementById("screen");
let string = screen.value;


var num1 = "", num2 = "";
let op = "";

document.querySelectorAll("button").forEach(button => button.addEventListener("click", () => {
    if (button.className == "number") {
        if (op != "") num2 += button.innerText;
        else num1 += button.innerText;
    }
    else if (button.id == "V-") {
        if (op != "") num2 = num2.slice(0, -1);
        else {
            if (num1.length > 0) num1 = num1.slice(0, -1);
            else num1 = "";
        }
    }
    else if (button.id == ".") {
        if (op == "" && parseInt(num1) == parseFloat(num1)) num1 += button.innerText;
        if (op != "" && parseInt(num2) == parseFloat(num2)) num2 += button.innerText;
    }
    else if (button.className == "op") {
        if (op != "") {
            op = button.innerText;
            Calculate();
        } else op = button.innerText;
    } else if (button.id == "=") {
        Calculate();   
        num2 = "";
        op = "";
    }  else if (button.id == "C") {
        num1 = "";
        op = "";
        num2 = "";
    }      
    //Display
    if (num2 != "") {
        screen.innerHTML = `<span style="color:grey">${num1} ${op}</span> <span>${num2}</span>`;
    } else if (op != "") {
        screen.innerHTML = `<span style="color:grey">${num1} ${op}</span>`;
    } else if (num1 != "") {
        screen.innerHTML = `<span>${num1}</span>`;
    } else {
        screen.innerHTML = `<span>${num1}</span>`;
    }
}))


function Calculate() {
    if (!num2) return;
    if (op == "+") num1 = (parseFloat(num1) + parseFloat(num2)).toString();
    if (op == "-") num1 = (parseFloat(num1) - parseFloat(num2)).toString();
    if (op == "*") num1 = (parseFloat(num1) * parseFloat(num2)).toString();
    if (op == "/") num1 = (parseFloat(num1) / parseFloat(num2)).toString();
    num2 = "";
}



/*                <button id="7">7</button>
                <button id="8">8</button>
                <button id="8">9</button>
                <button id="/">/</button>
                <button id="C">C</button>
                <button id="4">4</button>
                <button id="5">5</button>
                <button id="6">6</button>
                <button id="*">*</button>
                <button id="V-">&lt;-</button>
                <button id="1">1</button>
                <button id="2">2</button>
                <button id="3">3</button>
                <button id="-">-</button>
                <button id="=">=</button>
                <button id="0">0</button>
                <button id=".">.</button>
                <button id="+">+</button>*/

