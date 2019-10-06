$(document).ready(function () {
    let url = window.location.href;
    let id = url[url.length - 1];
    let qrDiv = document.getElementById("qrcode");

    new QRCode(qrDiv, id);
    

});