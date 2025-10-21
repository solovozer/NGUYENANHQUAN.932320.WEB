const table = document.getElementById("Table");
var save = document.getElementById("Save");



document.getElementById("Add").addEventListener("click", () => {
    const text = document.getElementById("Text");
    const number = document.getElementById("Number");
    if (text != null && number != null) {
        const row = table.insertRow(-1);
        row.innerHTML = `
            <td>${text}</td>
            <td>${number}</td>
            <td><button id="MoveUp">↑</button></td>
            <td><button id="MoveDown">↓</button></td>
            <td><button id="DeleteEntry">x</button></td>
        `;
    }
    text.value = "";
    number.value = "";   
})



