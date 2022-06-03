"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();



connection.on("Connect", function (info) {

    document.getElementById("statusspan").innerHTML = "Online";
});
connection.on("Disconnect", function (info) {


    document.getElementById("statusspan").innerHTML="Offline";

});

connection.start().then(function () {



    alert("Connected to Signalr Server");  


}).catch(function (err) {
    return console.error(err.toString());
});