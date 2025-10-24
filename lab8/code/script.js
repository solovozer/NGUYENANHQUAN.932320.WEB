let entries = {
  1: "first",
  2: "second",
  3: "third",
  4: "fourth",
  5: "fifth",
  6: "sixth",
  7: "seventh",
  8: "eighth",
  9: "ninth",
  10: "tenth",
  11: "eleventh",
  12: "twelfth",
  13: "thirteenth",
  14: "fourteenth",
  15: "fifteenth",
  16: "sixteenth",
  17: "seventeenth",
  18: "eighteenth",
  19: "nineteenth",
  20: "twentieth",
  21: "twenty-first",
  22: "twenty-second",
  23: "twenty-third",
  24: "twenty-fourth",
  25: "twenty-fifth",
  26: "twenty-sixth",
  27: "twenty-seventh",
  28: "twenty-eighth",
  29: "twenty-ninth",
  30: "thirtieth",
  31: "thirty-first",
  32: "thirty-second",
  33: "thirty-third",
  34: "thirty-fourth",
  35: "thirty-fifth",
  36: "thirty-sixth",
  37: "thirty-seventh",
  38: "thirty-eighth",
  39: "thirty-ninth",
  40: "fortieth",
  41: "forty-first",
  42: "forty-second",
  43: "forty-third",
  44: "forty-fourth",
  45: "forty-fifth",
  46: "forty-sixth",
  47: "forty-seventh",
  48: "forty-eighth",
  49: "forty-ninth",
  50: "fiftieth",
  51: "fifty-first",
  52: "fifty-second",
  53: "fifty-third",
  54: "fifty-fourth",
  55: "fifty-fifth",
  56: "fifty-sixth",
  57: "fifty-seventh",
  58: "fifty-eighth",
  59: "fifty-ninth",
  60: "sixtieth",
  61: "sixty-first",
  62: "sixty-second",
  63: "sixty-third",
  64: "sixty-fourth",
  65: "sixty-fifth",
  66: "sixty-sixth",
  67: "sixty-seventh",
}
let count = 0;
document.getElementById("Add").addEventListener("click", () => {
    count++;
    CreateEntry(count);
})

function CreateEntry(count) {
    const table = document.getElementById("Table");
    const entry = document.createElement("tr");
    entry.id = `r${count}`;

    let td1 = document.createElement("td");
    let textInput = document.createElement("input");
    textInput.disabled = true;
    textInput.value = entries[count] || "";
    textInput.id = `t${count}`;
    td1.appendChild(textInput);
    entry.appendChild(td1);

    let td2 = document.createElement("td");
    let numberInput = document.createElement("input");
    numberInput.disabled = true;
    numberInput.value = Math.floor(Math.random() * 1000);
    numberInput.id = `n${count}`;
    td2.appendChild(numberInput);
    entry.appendChild(td2);

    let td3 = document.createElement("td");
    let upBtn = document.createElement("button");
    upBtn.innerHTML = "↑";
    upBtn.id = `mu${count}`;
    upBtn.addEventListener("click", () => moveUp(count));
    td3.appendChild(upBtn);
    entry.appendChild(td3);

    let td4 = document.createElement("td");
    let downBtn = document.createElement("button");
    downBtn.innerHTML = "↓";
    downBtn.id = `md${count}`;
    downBtn.addEventListener("click", () => moveDown(count));
    td4.appendChild(downBtn);
    entry.appendChild(td4);

    let td5 = document.createElement("td");
    let delBtn = document.createElement("button");
    delBtn.innerHTML = "x";
    delBtn.id = `de${count}`;
    delBtn.addEventListener("click", () => deleteEntry(count));
    td5.appendChild(delBtn);
    entry.appendChild(td5);

    table.appendChild(entry);
    hideBlanks(true);
}

function hideBlanks(bool) {
    let oR = document.getElementById("r0");
    if (bool == true) oR.style.visibility = "collapse";
    else oR.style.visibility = "visible";
} 


function moveUp(count) {
    const curr = document.getElementById(`r${count}`);
    const prev = curr.previousElementSibling;
    const parent = curr.parentNode;
    if(prev) parent.insertBefore(curr, prev);
}

function moveDown(count) {
    const curr = document.getElementById(`r${count}`);
    const next = curr.nextElementSibling;
    const parent = curr.parentNode;
    if(next) parent.insertBefore(next, curr);
}

function deleteEntry(count) {
    const curr = document.getElementById(`r${count}`);
    if (curr) curr.remove();
}

document.getElementById("Save").addEventListener("click", () => {
    const pf = document.getElementById("pf");
    const table = document.getElementById("Table");
    let rows = table.querySelectorAll("tr");

    pf.innerText = "{";
    rows.forEach((row, index) => {
        if (index) {
            let v1 = row.getElementsByTagName("td")[0].getElementsByTagName("input")[0].value;
            let v2 = row.getElementsByTagName("td")[1].getElementsByTagName("input")[0].value;
            pf.innerText += `"${v1}":"${v2}"`;
            if (index < rows.length-1) pf.innerText += ",";
            else pf.innerText += "}";
        }
    });
})

