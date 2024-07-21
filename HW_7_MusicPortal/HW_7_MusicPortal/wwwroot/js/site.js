$(document).ready(() => {



   



    $(`.textInput`).on(`focus`, (e) => {
        $(e.currentTarget).removeAttr("readonly");
    })
    $(`.textInput`).on(`focusout`, (e) => {
        $(e.currentTarget).attr("readonly","true");
    })
   
});
