function OpenPopup(id) {
    popup = document.getElementsByClassName("popup")[0];
    popup_protection = document.getElementsByClassName("popup-protection")[0];
    h2 = popup.querySelector('h2');
    h2.innerText = 'Новости ' + id;
    h2.style.TextAlign = 'center';
    
    popup.style.display = 'block';
    popup_protection.style.display = 'block';
}  

function ClosePopup() {
    document.getElementsByClassName("popup")[0].style.display = 'none';
    document.getElementsByClassName("popup-protection")[0].style.display = 'none';
}