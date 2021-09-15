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

connection.on("BookDeleted", function (book) {
    console.log(`BookDeleted: ${JSON.stringify(book)}`);
    $(`tr:has(td:contains("${book.title}"))`).remove();
});

connection.on("BookEdited", function (book, oldbook) {
    console.log(`BookEdited: ${JSON.stringify(book)}`);
    console.log(`OldBook: ${JSON.stringify(oldbook)}`);
    $(`tr:has(td:contains("${oldbook.title}"))`).remove();
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