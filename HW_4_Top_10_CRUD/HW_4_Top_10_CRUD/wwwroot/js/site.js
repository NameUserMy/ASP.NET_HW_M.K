"use strict"
let rawdata = { 'id': '2' };
$(document).ready(() => {


    
    $.ajax({
        type: "GET",
        url: "/Home/Details/",
        data: rawdata,
        success: function (viewHTML) {
            $("#forCard").html(viewHTML);
        },
        error: function (errorData) { onError(errorData); }
    });

    $(`#posterForm`).on(`mouseenter`, (e) => {

        $(`#PosterInfo`).css(`display`, `none`)
        $(`#uploadPoster`).css(`display`, `block`);
    })
    $(`#posterForm`).on(`mouseleave`, (e) => {
        $(`#PosterInfo`).css(`display`, `block`)
        $(`#uploadPoster`).css(`display`, `none`);
    })


    $(`#file-upload`).on(`change`, () => {
        console.log($(`#file-upload`).prop('files')[0]["name"]);
        const [file] = $(`#file-upload`).prop('files');
        console.log(URL.createObjectURL(file));
        $(`#posterForm`).css(`backgroundImage`, 'url(' + URL.createObjectURL(file) + ')');
        $(`#posterForm`).off()

    });


    $(`.cardFilmP`).on(`mousedown`, (e) => {
        let src = $(e.currentTarget).find(`input:first-child`).val();

          rawdata = { 'id': src};
          $.ajax({
              type: "GET",
              url: "/Home/Details/",
              data: rawdata,
              success: function (viewHTML) {
                  $("#forCard").html(viewHTML);
              },
              error: function (errorData) { onError(errorData); }
          });
         
    })




    


});