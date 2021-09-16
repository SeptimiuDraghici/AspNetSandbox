"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.on("BookCreated", function (book) {
    console.log(`BookCreated: ${JSON.stringify(book)}`);
    $("tbody").append(`
    <tr>
        <td>
        ${book.title}
        </td>
        <td>
        ${book.author}
        </td>
        <td>
        ${book.language}
        </td>
        <td>
        <a href="/Books/Edit?id=${book.id}">Edit</a> |
        <a href="/Books/Details?id=${book.id}">Details</a> |
        <a href="/Books/Delete?id=${book.id}">Delete</a>
        </td>
    </tr>`);
});

connection.on("BookDeleted", function (id) {
    var row = document.getElementById(`${id}`);
    row.remove();
});

connection.on("BookEdited", function (book) {
    console.log(`BookEditedTo: ${JSON.stringify(book)}`);
    var row = document.getElementById(`${book.id}`);
    row.remove();
    $("tbody").append(`
    <tr>
        <td>
        ${book.title}
        </td>
        <td>
        ${book.author}
        </td>
        <td>
        ${book.language}
        </td>
        <td>
        <a href="/Books/Edit?id=${book.id}">Edit</a> |
        <a href="/Books/Details?id=${book.id}">Details</a> |
        <a href="/Books/Delete?id=${book.id}">Delete</a>
        </td>
    </tr>`);
});

connection.start().then(function () {
    console.log("connection established.");
}).catch(function (err) {
    return console.error(err.toString());
});