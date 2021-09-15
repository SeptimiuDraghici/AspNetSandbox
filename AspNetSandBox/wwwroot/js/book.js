"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.on("BookCreated", function (book) {
    console.log("BookCreated: ${JSON.stringify(book)}");
    $("tbody").append("
    < tr >
        < td >
            Metro 2034
        </td >
        <td>
            Dmitry Glukhovsky
        </td>
        <td>
            Russian
        </td>
        <td>
            <a href="/Books/Edit?id=2">Edit</a> |
            <a href="/Books/Details?id=2">Details</a> |
            <a href="/Books/Delete?id=2">Delete</a>
        </td>
    </tr > ");
});

connection.start().then(function () {
    console.log("connection established.");
}).catch(function (err) {
    return console.error(err.toString());
});