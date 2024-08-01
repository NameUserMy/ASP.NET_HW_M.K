import req from "./modules/Request.js"
import btn from "./modules/Buttons.js" 

const request = new req.RequestApi();
const buttons = new btn.Button();



$(document).ready(() => {



    $(`#userMenu`).on('mousedown', (e) => {
        buttons.UserMenu($(e.target).index());
    })
    $(`#musicMenu`).on(`mousedown`, (e) => {
        buttons.MusicMenu($(e.target).index());
    })
 
    $(`#RenderBody`).on(`mousedown`, ".confirm-button", (e) => {
        let id = $(e.target).attr(`data-info`);
        request.UpdateConfirm(`/api/User/${id}`);
        buttons.UserMenu($(0).index());
    });

    $(`#RenderBody`).on(`mousedown`, ".delete-button", (e) => {
        let id = $(e.target).attr(`data-info`);
        request.DeleteUser(`/api/User/${id}`);
        buttons.UserMenu($(0).index());
    });

    $(`#RenderBody`).on(`mousedown`, ".performerConfirm", (e) => {
        let id = $(e.target).attr(`data-info`);

        console.log(id)

        request.UpdateConfirm(`/api/Performers/${id}`);
        buttons.UserMenu($(5).index());
    });
    //form button
    $(`#RenderBody`).on(`mousedown`, "#userReg-Btn", () => {
        request.UserPost("/api/User/");
    });

    $(`#RenderBody`).on(`mousedown`, "#userEdit-Btn", () => {
        request.UserPut("/api/User/");
    });

    $(`#RenderBody`).on(`mousedown`, `#addTrack`, (e) => {
        e.preventDefault();
        request.AddTrack("/api/Track");
    });

    $(`#RenderBody`).on(`mousedown`, `#addGenre`, (e) => {
        e.preventDefault();
        request.AddGenre("/api/Genre");
    });


    $(`#RenderBody`).on(`mousedown`, `#addPerformer`, (e) => {
        e.preventDefault();
        request.AddPerformer("/api/Performers");
    });



});