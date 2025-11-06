var dogs = document.getElementById("d-c").style;
var cats = document.getElementById('c-c').style;
var cp = document.getElementById("c-c").getElementsByTagName("img")[0].style;
var dp = document.getElementById('d-c').getElementsByTagName("img")[0].style;

function CatWin() {
    cats.width = "96%";
    dogs.width = "10%";
    cp.width = "80%";
    dp.width = "0%";  
    cats.justifyContent = "left";
}

function DogWin() {
    cats.width = "10%";
    dogs.width = "96%";
    cp.width = "0%";
    dp.width = "80%";
    dogs.justifyContent = "left";
}

function Draw() {
    cats.width = "50%";
    dogs.width = "50%";
    cp.width = dp.width = "300px";
    dogs.justifyContent = "center";
    cats.justifyContent = "center";
}