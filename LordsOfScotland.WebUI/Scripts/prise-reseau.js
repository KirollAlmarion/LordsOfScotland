"use strict";

const RENOMMER_JOUEUR = 0,
    ENTRER_SALON = 1,
    SORTIR_SALON = 2;

let partieEnCours = false;

let messageBienvenue = document.getElementById('bienvenue');
let btnNom = document.getElementById('btnNom');
let btnCree = document.getElementById('btnCree');

if (Modernizr.websockets) {
    messageBienvenue.textContent = "Fàilte gu Alba";
}

if (!window.WebSocket && window.MozWebSocket) {
    window.WebSocket = window.MozWebSocket;
}

btnCree.onclick = () => {
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

    connection.onopen = function () {
        //fetch("/Salons/Index");
    }

    connection.onmessage = function (message) {
        var data = window.JSON.parse(message.data);
        btnNom.value = data;
    };

}