"use strict"

$(document).ready(() => {



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
        console.log($(e.currentTarget).index())
        console.log($(e.currentTarget).css(`backgroundImage`));
        console.log($(`#cardFilm`).find(`div:first-child`).css(`backgroundImage`, `url(https://localhost:7203/imgSrc/posters/Ghostbusters.jpg)`));
        console.log($(`#cardFilm`).find(`div:first-child`).css(`backgroundImage`));
    })




    


});