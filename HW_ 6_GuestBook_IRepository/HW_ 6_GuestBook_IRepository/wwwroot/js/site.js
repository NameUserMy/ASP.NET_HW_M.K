
let button = null;
let str = "";
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
    let test ="Lorem ipsum dolor sit amet consectetur adipisicing elit. Totam voluptate, rerum voluptatibus sunt nostrum porro. Dolorum, sit vel aut consequuntur quisquam iure fugiat soluta rerum assumenda odio unde ipsa perspiciatis."

    console.log(test.length);
});