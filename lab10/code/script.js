const curtain = document.getElementById("curtain");
curtain.addEventListener("click", () => {
    curtain.classList.toggle("up");
    
})

const lamp = document.getElementById("hcao");
const light = document.getElementById("light");
const witch = document.getElementById("witch");
const hat = document.getElementById("hat");
const rabbit = document.getElementById("rabbit");
const bird = document.getElementById("bird");


let turnedOn = false;
lamp.addEventListener("click", () => {
    lamp.classList.remove("giatday");
    void lamp.offsetHeight;
    lamp.classList.add("giatday");
    if (!turnedOn) TurnOn();
    else TurnOff();
    turnedOn = !turnedOn;
})

let onOpp = ["0.5", "1", "1", "1", "1"];
let offOpp = ["0", "0", "0", "0", "0"];
function TurnOn() {
    ["light", "witch", "hat", "rabbit", "bird" ].forEach((id, i) => {
        document.getElementById(id).style.visibility = "visible";
        document.getElementById(id).style.opacity = onOpp[i];
    })

    if (iteration == 0) bird.style.visibility = "hidden";
    if (iteration == 1) rabbit.style.visibility = "hidden";
}
function TurnOff() {
    ["light", "witch", "hat", "rabbit", "bird" ].forEach((id, i) => {
        document.getElementById(id).style.opacity = offOpp[i];
        document.getElementById(id).style.visibility = "hidden";
    })
}

let iteration = 0;

rabbit.addEventListener("click", () => {
    bird.style.visibility = "visible";

    rabbit.style.transition = "transform 0.5s ease";
    rabbit.style.transform = "translateY(100px)";

    setTimeout(() => {
        bird.style.transition = "transform 0.5s ease";
        bird.style.transform = "translateY(-100px)";
    }, 500);

    iteration = 1;
});

bird.addEventListener("click", () => {
    rabbit.style.visibility = "visible";

    bird.style.transition = "transform 0.4s ease";
    bird.style.transform = "translate(800px, -100px)";
    setTimeout(() => {
        rabbit.classList.add("jump");
    }, 1000);
    iteration = 2;
});

hat.addEventListener("click", () => {
    rabbit.style.visibility = "visible";
  if (iteration === 2) {
    rabbit.classList.remove("jump");
    bird.style.transition = "transform 0s ease";
    rabbit.style.transition = "transform 0s ease";

    bird.style.transform = "translate(0px, 0px)";
    rabbit.style.transform = "translate(0px, 0px)";

    iteration = 0;
  }

});

