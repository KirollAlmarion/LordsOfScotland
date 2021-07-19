"use strict";

const RENOMMER_JOUEUR = 0,
    ENTRER_SALON = 1,
    SORTIR_SALON = 2;

let partieEnCours = false;

let messageBienvenue = document.getElementById('bienvenue');
let champNom = document.getElementById('nom');
let btnNom = document.getElementById('btnNom');

if (Modernizr.websockets) {
    messageBienvenue.textContent = "Fàilte gu Alba";
}

if (!window.WebSocket && window.MozWebSocket) {
    window.WebSocket = window.MozWebSocket;
}

var connection;

var host = "ws://" + window.location.host + "/Services/GestionnaireHttp.ashx";

try {
    connection = new WebSocket(host);
}
catch (exception) {
    console.error(exception);
}


connection.onerror = function (error) {
    console.error(error);
};

//connection.onopen = function () {
//    $(".btn").css("color", "green");
//}

connection.onopen = function () {
    fetch("/Salons/Index");
}

btnNom.onclick = () => {
    let requete = {
        enJeu: partieEnCours,
        action: RENOMMER_JOUEUR,
        nom: champNom.value
    }
    connection.send(JSON.stringify(requete));
}