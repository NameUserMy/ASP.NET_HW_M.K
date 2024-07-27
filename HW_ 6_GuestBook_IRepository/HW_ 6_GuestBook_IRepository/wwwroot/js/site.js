"use strict"
import page from "./modules/GetMethods.js"
import mesg from "./modules/PostMethods.js"
let pages = new page.Pagination();
let methodPost = new mesg.PostMethod();

let button = null;
let str = "";

let pagess=1;
$(document).ready(() => {
    
    button = $(`.button`);
    $(button[4]).css(`display`, `block`);
    str = $(`#user`).text()

    if (str.lastIndexOf("Гость") === -1) {
        $(button[1]).css(`display`, `block`);
        $(button[3]).css(`display`, `block`);
    } else {
        $(button[0]).css(`display`, `block`)
        $(button[2]).css(`display`, `block`);
    }


    

    $("#userRegistrationBtn").on("mousedown", (e) => {
        e.preventDefault();
        methodPost.Registration();


    });

    const currentUrl = window.location.pathname;
    console.log(currentUrl);
    if (currentUrl == "/") {
        pages.GetPage(1);


        $(".messageContanier").on("mousedown", `#left`, () => {

            pages.GetPage(pagess -= 1);

        });
        $(".messageContanier").on("mousedown", `#right`, () => {

            pages.GetPage(pagess += 1);


        });
    }

    $(`#messagSendBtn`).on("mousedown", (e) => {
        e.preventDefault();
        methodPost.PublishMessage();
    });


});






